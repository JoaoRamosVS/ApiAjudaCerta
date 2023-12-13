using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
using ApiAjudaCerta.Models.Enuns;
using ApiAjudaCerta.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApiAjudaCerta.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PessoasController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        private string CriarToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration.GetSection("ConfiguracaoToken:Chave").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task<bool> UsuarioExistente(string email)
        {
            if (await _context.Usuario.AnyAsync(u => u.Email == email))
            {
                return true;
            }
            return false;
        }

        private int ObterUsuarioId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        private string FormatarCpf(string cpf)
        {
            string Cpf = cpf.Replace("-","");
            Cpf = Cpf.Replace(".","");

            return(Cpf);
        }
        private string FormatarCnpj(string cnpj)
        {
            string Cnpj = cnpj.Replace("-","");
            Cnpj = Cnpj.Replace(".","");
            Cnpj = Cnpj.Replace("/","");

            return(Cnpj);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Pessoa p = await _context.Pessoa
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                    
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByUsuarioId")]
        public async Task<IActionResult> GetByUsuarioId()
        {
            try
            {
                Pessoa p = await _context.Pessoa
                            .FirstOrDefaultAsync(pBusca => pBusca.Usuario.Id == ObterUsuarioId());
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByUsername")]
        public async Task<IActionResult> GetByUsername(Pessoa pessoa)
        {
            try
            {
                Pessoa p = await _context.Pessoa
                            .FirstOrDefaultAsync(pBusca => pBusca.Username == pessoa.Username);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByNomeAproximado/{nomePessoa}")]
        public async Task<IActionResult> GetByNomeAproximado(string nomePessoa)
        {
            try
            {
                List<Pessoa> lista = await _context.Pessoa
                    	.Where(p => p.Nome.ToLower().Contains(nomePessoa.ToLower()))
                        .ToListAsync();

                return Ok(lista); 
            }
            catch (Exception ex)
            {                
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> Add(Pessoa novaPessoa)
        {
            try
            {
                if (!Validacao.VerificaEmail(novaPessoa.Usuario.Email))
                {
                    throw new Exception("Endereço de e-mail inválido.");
                }
                else if (await UsuarioExistente(novaPessoa.Usuario.Email))
                {
                    throw new System.Exception("Este e-mail já está cadastrado.");
                }
                else if (novaPessoa.Usuario.Senha.Length < 8)
                {
                    throw new Exception("A senha requer 8 caracteres ou mais.");
                }


                if(novaPessoa.fisicaJuridica == FisicaJuridicaEnum.PESSOA_FISICA)
                {
                    if(!Validacao.ValidaCPF(novaPessoa.Documento))
                        throw new Exception("CPF inválido.");
                    else if(!Validacao.VerificaMaioridade(novaPessoa.DataNasc))
                        throw new Exception("O usuário precisa ser maior de idade.");
                    else
                    {
                        novaPessoa.Documento = FormatarCpf(novaPessoa.Documento);
                        Pessoa p = await _context.Pessoa.FirstOrDefaultAsync(pBusca => pBusca.Documento == novaPessoa.Documento);

                        if(p != null)
                            throw new Exception("Este CPF já está cadastrado, tente recuperar sua conta.");
                    }
                }
                else if(novaPessoa.fisicaJuridica == FisicaJuridicaEnum.PESSOA_JURIDICA)
                {
                    if(!Validacao.ValidaCNPJ(novaPessoa.Documento))
                        throw new Exception("CNPJ inválido.");
                    else
                    {
                        novaPessoa.Documento = FormatarCnpj(novaPessoa.Documento);
                        Pessoa p = await _context.Pessoa.FirstOrDefaultAsync(pBusca => pBusca.Documento == novaPessoa.Documento);

                        if(p != null)
                            throw new Exception("Este CNPJ já está cadastrado, tente recuperar sua conta.");
                    }
                }

                // if(!Validacao.ValidaCEP(novaPessoa.Endereco.Cep))
                //     throw new Exception("Digite um CEP válido.");

                //novaPessoa.Usuario = _context.Usuario.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());
                Criptografia.CriarPasswordHash(novaPessoa.Usuario.Senha, out byte[] hash, out byte[] salt);
                novaPessoa.Usuario.Senha = string.Empty;
                novaPessoa.Usuario.Senha_Hash = hash;
                novaPessoa.Usuario.Senha_Salt = salt;
                
                await _context.Pessoa.AddAsync(novaPessoa);
                await _context.SaveChangesAsync();


                return Ok(novaPessoa.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarDados")]
        public async Task<IActionResult> AtualizarFoto(Pessoa p)
        {
            try
            {
                Pessoa pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(x => x.Id == p.Id);
                
                var attach = _context.Attach(pessoa);

                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Username).IsModified = true;
                attach.Property(x => x.Telefone).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
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
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public UsuariosController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

        private static bool IsEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                List<Usuario> lista = await _context.Usuario.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                Usuario u = await _context.Usuario.FirstOrDefaultAsync(uBusca => uBusca.Id == id);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> Add(Usuario novoUsuario)
        {
            try
            {
                if (!IsEmail(novoUsuario.Email))
                {
                    throw new Exception("Endereço de e-mail inválido.");
                }
                else if (await UsuarioExistente(novoUsuario.Email))
                {
                    throw new System.Exception("Este e-mail já está cadastrado.");
                }
                else if (novoUsuario.Senha.Length < 8)
                {
                    throw new Exception("A senha requer 8 caracteres ou mais.");
                }
                Criptografia.CriarPasswordHash(novoUsuario.Senha, out byte[] hash, out byte[] salt);
                novoUsuario.Senha = string.Empty;
                novoUsuario.Senha_Hash = hash;
                novoUsuario.Senha_Salt = salt;
                await _context.Usuario.AddAsync(novoUsuario);
                await _context.SaveChangesAsync();
                novoUsuario.Token = CriarToken(novoUsuario);

                return Ok(novoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuario
                    .FirstOrDefaultAsync(u => u.Email == credenciais.Email);
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia
                    .VerificarPasswordHash(credenciais.Senha, usuario.Senha_Hash, usuario.Senha_Salt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    usuario.UltimoAcesso = System.DateTime.Now;
                    _context.Usuario.Update(usuario);
                    await _context.SaveChangesAsync();

                    usuario.Senha_Hash = null;
                    usuario.Senha_Salt = null;
                    usuario.Token = CriarToken(usuario);

                    return Ok(usuario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail(Usuario u)
        {
            try
            {
                Usuario usuario = await _context.Usuario //Busca o usuário no banco através do Id
                .FirstOrDefaultAsync(x => x.Id == u.Id);
                usuario.Email = u.Email;
                var attach = _context.Attach(usuario);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Email).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarFoto")]
        public async Task<IActionResult> AtualizarFoto(Usuario u)
        {
            try
            {
                Usuario usuario = await _context.Usuario
                .FirstOrDefaultAsync(x => x.Id == u.Id);
                usuario.Foto = u.Foto;
                var attach = _context.Attach(usuario);  
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Foto).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarSenha")]
        public async Task<IActionResult> AtualizarSenha(Usuario u)
        {
            try
            {
                Usuario usuario = await _context.Usuario
                .FirstOrDefaultAsync(x => x.Id == u.Id);
                Criptografia.CriarPasswordHash(u.Senha, out byte[] hash, out byte[] salt);
                usuario.Senha = string.Empty;
                usuario.Senha_Hash = hash;
                usuario.Senha_Salt = salt;

                var attach = _context.Attach(usuario);  
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Senha_Hash).IsModified = true;
                attach.Property(x => x.Senha_Salt).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(("{id}"))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Usuario u = await _context.Usuario.FirstOrDefaultAsync(uBusca => uBusca.Id == id);

                _context.Usuario.Remove(u);
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
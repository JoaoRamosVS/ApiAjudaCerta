using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAjudaCerta.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class EnderecosController : ControllerBase
    {
        private readonly DataContext _context;

        public EnderecosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Endereco e = await _context.Endereco
                    .FirstOrDefaultAsync(eBusca => eBusca.Id == id);
                
                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Post(Endereco novoEndereco)
        {
            try
            {
                await _context.Endereco.AddAsync(novoEndereco);
                await _context.SaveChangesAsync();

                return Ok(novoEndereco.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarDados")]
        public async Task<IActionResult> AtualizarFoto(Endereco e)
        {
            try
            {
                Endereco endereco = await _context.Endereco
                .FirstOrDefaultAsync(x => x.Id == e.Id);
                endereco.Cep = e.Cep;
                endereco.Rua = e.Rua;
                endereco.Numero = e.Numero;
                endereco.Bloco = e.Bloco;
                endereco.Bairro = e.Bairro;
                endereco.Cidade = e.Cidade;
                endereco.Complemento = e.Complemento;
                endereco.Estado = e.Estado;
                

                var attach = _context.Attach(endereco);

                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Rua).IsModified = true;
                attach.Property(x => x.Bloco).IsModified = true;
                attach.Property(x => x.Numero).IsModified = true;
                attach.Property(x => x.Bairro).IsModified = true;
                attach.Property(x => x.Bloco).IsModified = true;
                attach.Property(x => x.Rua).IsModified = true;
                attach.Property(x => x.Estado).IsModified = true;
                attach.Property(x => x.Cidade).IsModified = true;
                
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
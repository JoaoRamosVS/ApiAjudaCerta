using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
using ApiAjudaCerta.Models.Enuns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAjudaCerta.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[Controller]")]
    public class ItemDoacaoDoadoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemDoacaoDoadoController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("IddByIdDoacao/{id}")]
        public async Task<IActionResult> GetIDDPorIdDoacao(int id)
        {
            try
            {
                ItemDoacaoDoado idd = await _context.ItemDoacaoDoado
                    .FirstOrDefaultAsync(iddBusca => iddBusca.DoacaoId == id);
                    
                return Ok(idd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("IddByIdItemDoacao/{id}")]
        public async Task<IActionResult> GetIDDPorIdItemDoacao(int id)
        {
            try
            {
                ItemDoacaoDoado idd = await _context.ItemDoacaoDoado
                    .FirstOrDefaultAsync(iddBusca => iddBusca.ItemDoacaoId == id);
                    
                return Ok(idd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private int ObterUsuarioId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public PostsController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("ListarPosts")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Post> lista = await _context.Post
                                    .OrderBy(p => p.DataPostagem)
                                    .ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AdicionarPost")]
        public async Task<IActionResult> Add(Post novoPost)
        {
            try
            {
                if(novoPost.Conteudo != null)
                {
                    await _context.Post.AddAsync(novoPost);
                    await _context.SaveChangesAsync();

                    return Ok(novoPost.Id);
                }
                else
                    throw new Exception("O conteúdo do post não pode estar vazio.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarPost")]
        public async Task<IActionResult> Remove(Post post)
        {
            try
            {
                if(post != null)
                {
                    _context.Post.Remove(post);
                    int linhasAfetadas = await _context.SaveChangesAsync();
                    return Ok(linhasAfetadas);
                }
                else
                    throw new Exception("Deve selecionar um post para excluir");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
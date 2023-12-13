using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
using ApiAjudaCerta.Models.Enuns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAjudaCerta.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class ItemDoacaoController : ControllerBase
    {
        
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private int ObterUsuarioId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public ItemDoacaoController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ItemDoacao itemD = await _context.ItemDoacao
                    .FirstOrDefaultAsync(idBusca => idBusca.Id == id);


                return Ok(itemD);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProduto/{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            try
            {
                Produto p = await _context.Produto
                    .FirstOrDefaultAsync(idBusca => idBusca.ItemDoacaoId == id);


                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRoupa/{id}")]
        public async Task<IActionResult> GetRoupa(int id)
        {
            try
            {
                Roupa r = await _context.Roupa
                    .FirstOrDefaultAsync(idBusca => idBusca.ItemDoacaoId == id);


                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEletrodomestico/{id}")]
        public async Task<IActionResult> GetEletrodomestico(int id)
        {
            try
            {
                Eletrodomestico e = await _context.Eletrodomestico
                    .FirstOrDefaultAsync(idBusca => idBusca.ItemDoacaoId == id);


                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMobilia/{id}")]
        public async Task<IActionResult> GetMobilia(int id)
        {
            try
            {
                Mobilia m = await _context.Mobilia
                    .FirstOrDefaultAsync(idBusca => idBusca.ItemDoacaoId == id);


                return Ok(m);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    if(d.TipoItem == TipoItemEnum.PRODUTO)
                    {
                        d.Produtos.Add(_context.Produto.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                    }
                    else if(d.TipoItem == TipoItemEnum.MOBILIA)
                    {
                        d.Mobilias.Add(_context.Mobilia.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                    }
                    else if(d.TipoItem == TipoItemEnum.ELETRODOMESTICO)
                    {
                        d.Eletrodomesticos.Add(_context.Eletrodomestico.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                    }
                    else if(d.TipoItem == TipoItemEnum.ROUPA)
                    {
                        d.Roupas.Add(_context.Roupa.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                    } 
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarTodosDisponiveis")]
        public async Task<IActionResult> GetAllDisponiveis()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    if(d.TipoItem == TipoItemEnum.PRODUTO)
                    {
                        d.Produtos.Add(_context.Produto.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                        if(d.Produtos.First().StatusItem == StatusItemEnum.INDISPONIVEL)
                            lista.Remove(d);
                    }
                    else if(d.TipoItem == TipoItemEnum.MOBILIA)
                    {
                        d.Mobilias.Add(_context.Mobilia.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                        if(d.Mobilias.First().StatusItem == StatusItemEnum.INDISPONIVEL)
                            lista.Remove(d);
                    }
                    else if(d.TipoItem == TipoItemEnum.ELETRODOMESTICO)
                    {
                        d.Eletrodomesticos.Add(_context.Eletrodomestico.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                        if(d.Eletrodomesticos.First().StatusItem == StatusItemEnum.INDISPONIVEL)
                            lista.Remove(d);
                    }
                    else if(d.TipoItem == TipoItemEnum.ROUPA)
                    {
                        d.Roupas.Add(_context.Roupa.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                        if(d.Roupas.First().StatusItem == StatusItemEnum.INDISPONIVEL)
                            lista.Remove(d);
                    } 
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarTodosIndisponiveis")]
        public async Task<IActionResult> GetAllIndisponiveis()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    if(d.TipoItem == TipoItemEnum.PRODUTO)
                    {
                        d.Produtos.Add(_context.Produto.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                        if(d.Produtos.First().StatusItem == StatusItemEnum.DISPONIVEL)
                            lista.Remove(d);
                    }
                    else if(d.TipoItem == TipoItemEnum.MOBILIA)
                    {
                        d.Mobilias.Add(_context.Mobilia.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                        if(d.Mobilias.First().StatusItem == StatusItemEnum.DISPONIVEL)
                            lista.Remove(d);
                    }
                    else if(d.TipoItem == TipoItemEnum.ELETRODOMESTICO)
                    {
                        d.Eletrodomesticos.Add(_context.Eletrodomestico.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                        if(d.Eletrodomesticos.First().StatusItem == StatusItemEnum.DISPONIVEL)
                            lista.Remove(d);
                    }
                    else if(d.TipoItem == TipoItemEnum.ROUPA)
                    {
                        d.Roupas.Add(_context.Roupa.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                        if(d.Roupas.First().StatusItem == StatusItemEnum.DISPONIVEL)
                            lista.Remove(d);
                    } 
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarRoupas")]
        public async Task<IActionResult> ListarRoupas()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .Where(itD => itD.TipoItem == TipoItemEnum.ROUPA)
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    d.Roupas.Add(_context.Roupa.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                } 
                
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarProdutos")]
        public async Task<IActionResult> ListarProdutos()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .Where(itD => itD.TipoItem == TipoItemEnum.PRODUTO)
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    d.Produtos.Add(_context.Produto.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                } 
                
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarAlimentos")]
        public async Task<IActionResult> ListarAlimentos()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .Where(itD => itD.TipoItem == TipoItemEnum.PRODUTO)
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    d.Produtos.Add(_context.Produto.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                    if(d.Produtos.First().TipoProduto != TipoProdutoEnum.ALIMENTO)
                        lista.Remove(d);
                } 
                
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarLimpeza")]
        public async Task<IActionResult> ListarLimpezas()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .Where(itD => itD.TipoItem == TipoItemEnum.PRODUTO)
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    d.Produtos.Add(_context.Produto.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                    if(d.Produtos.First().TipoProduto != TipoProdutoEnum.LIMPEZA)
                        lista.Remove(d);
                } 
                
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarHigiene")]
        public async Task<IActionResult> ListarHigienes()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .Where(itD => itD.TipoItem == TipoItemEnum.PRODUTO)
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    d.Produtos.Add(_context.Produto.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                    if(d.Produtos.First().TipoProduto != TipoProdutoEnum.HIGIENE)
                        lista.Remove(d);
                } 
                
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarMobilias")]
        public async Task<IActionResult> ListarMobilias()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .Where(itD => itD.TipoItem == TipoItemEnum.MOBILIA)
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    d.Mobilias.Add(_context.Mobilia.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                } 
                
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarEletrodomesticos")]
        public async Task<IActionResult> ListarEletro()
        {
            try
            {
                List<ItemDoacao> lista = await _context.ItemDoacao
                                                .Where(itD => itD.TipoItem == TipoItemEnum.ELETRODOMESTICO)
                                                .ToListAsync();
                
                foreach(ItemDoacao d in lista)
                {
                    d.Eletrodomesticos.Add(_context.Eletrodomestico.FirstOrDefault(pBusca => pBusca.ItemDoacao.Id == d.Id));
                } 
                
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
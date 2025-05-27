using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Models.Enums;
using SimuladorCredito.Api.Servicos.Interfaces;

namespace SimuladorCredito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        [HttpGet("ObterPorId")]
        public async Task<ActionResult<Produto>> ObterPorId(int id)
        {
            try
            {
                var produto = await _produtoServico.ObterPorId(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObterPorTipoPessoa")]
        public async Task<ActionResult<List<Produto>>> ObterPorTipoPessoa(TipoPessoa tipoPessoa)
        {
            try
            {
                var produtos = await _produtoServico.ObterPorTipoPessoa(tipoPessoa);
                if (produtos == null || !produtos.Any())
                    return NotFound(new { mensagem = "Nenhum produto encontrado para o tipo de pessoa especificado." });

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObterTodos")]
        public async Task<ActionResult<List<Produto>>> ObterTodos()
        {
            try
            {
                var produtos = await _produtoServico.ObterTodos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Produto produto)
        {
            try
            {
                await _produtoServico.Adicionar(produto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest(new { mensagem = "O id do produto não confere com o id da rota." });

            try
            {
                await _produtoServico.Atualizar(produto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Remover")]
        public async Task<ActionResult> Remover(int id)
        {
            try
            {
                await _produtoServico.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

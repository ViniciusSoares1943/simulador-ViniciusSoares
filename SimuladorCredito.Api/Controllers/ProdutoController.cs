using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Api.Models.DTOs;
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
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(IProdutoServico produtoServico, ILogger<ProdutoController> logger)
        {
            _produtoServico = produtoServico;
            _logger = logger;
        }

        /// <summary>
        /// Obter um produto pelo id
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <response code="200">Produto obtido com sucesso.</response>
        /// <response code="400">Erro ao obter produto.</response>
        /// <response code="500">Erro interno no servidor ao obter produto.</response>
        [HttpGet("ObterPorId")]
        public async Task<ActionResult<Produto>> ObterPorId(int id)
        {
            try
            {
                var produto = await _produtoServico.ObterPorId(id);
                _logger.LogInformation("Produto obtido com sucesso.");
                return Ok(produto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produto.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter produtos por tipo de pessoa
        /// </summary>
        /// <param name="tipoPessoa">Tipo de pessoa (PessoaFisica 1 ou PessoaJuridica 2)</param>
        /// <response code="200">Produtos obtidos com sucesso.</response>
        /// <response code="404">Nenhum produto encontrado para o tipo de pessoa especificado.</response>
        /// <response code="400">Erro ao obter produtos.</response>
        /// <response code="500">Erro interno no servidor ao obter produtos.</response>
        [HttpGet("ObterPorTipoPessoa")]
        public async Task<ActionResult<List<ProdutoSaida>>> ObterPorTipoPessoa(TipoPessoa tipoPessoa)
        {
            try
            {
                var produtos = await _produtoServico.ObterPorTipoPessoa(tipoPessoa);
                if (produtos == null || !produtos.Any())
                {
                    _logger.LogInformation("Nenhum produto encontrado para o tipo de pessoa especificado.");
                    return NotFound(new { mensagem = "Nenhum produto encontrado para o tipo de pessoa especificado." });
                }

                _logger.LogInformation("Produtos obtidos com sucesso para o tipo de pessoa.");
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produtos por tipo de pessoa.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter todos os produtos
        /// </summary>
        /// <response code="200">Produtos obtidos com sucesso.</response>
        /// <response code="400">Erro ao obter produtos.</response>
        /// <response code="500">Erro interno no servidor ao obter produtos.</response>
        [HttpGet("ObterTodos")]
        public async Task<ActionResult<List<Produto>>> ObterTodos()
        {
            try
            {
                var produtos = await _produtoServico.ObterTodos();
                _logger.LogInformation("Todos os produtos obtidos com sucesso.");
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os produtos.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adicionar um novo produto
        /// </summary>
        /// <param name="produto">Objeto produto a ser adicionado</param>
        /// <response code="201">Produto adicionado com sucesso.</response>
        /// <response code="400">Erro ao adicionar produto.</response>
        /// <response code="500">Erro interno no servidor ao adicionar produto.</response>
        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Produto produto)
        {
            try
            {
                await _produtoServico.Adicionar(produto);
                _logger.LogInformation("Produto adicionado com sucesso.");
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar produto.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um produto existente
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <param name="produto">Objeto produto com dados atualizados</param>
        /// <response code="200">Produto atualizado com sucesso.</response>
        /// <response code="400">Erro ao atualizar produto.</response>
        /// <response code="500">Erro interno no servidor ao atualizar produto.</response>
        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                _logger.LogError("O id do produto não confere com o id da rota.");
                return BadRequest(new { mensagem = "O id do produto não confere com o id da rota." });
            }

            try
            {
                await _produtoServico.Atualizar(produto);
                _logger.LogInformation("Produto atualizado com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar produto.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remover um produto pelo id
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <response code="200">Produto removido com sucesso.</response>
        /// <response code="400">Erro ao remover produto.</response>
        /// <response code="500">Erro interno no servidor ao remover produto.</response>
        [HttpDelete("Remover")]
        public async Task<ActionResult> Remover(int id)
        {
            try
            {
                await _produtoServico.Remover(id);
                _logger.LogInformation("Produto removido com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover produto.");
                return BadRequest(ex.Message);
            }
        }
    }
}

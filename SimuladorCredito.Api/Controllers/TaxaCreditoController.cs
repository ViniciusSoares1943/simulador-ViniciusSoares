using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Api.Models.DTOs;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Servicos.Interfaces;

namespace SimuladorCredito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TaxaCreditoController : ControllerBase
    {
        private readonly ITaxaCreditoServico _taxaCreditoServico;
        private readonly ILogger<TaxaCreditoController> _logger;

        public TaxaCreditoController(ITaxaCreditoServico taxaCreditoServico, ILogger<TaxaCreditoController> logger)
        {
            _taxaCreditoServico = taxaCreditoServico;
            _logger = logger;
        }

        /// <summary>
        /// Obter uma taxa de crédito pelo id
        /// </summary>
        /// <param name="id">Identificador da taxa de crédito</param>
        /// <response code="200">Taxa de crédito obtida com sucesso.</response>
        /// <response code="400">Erro ao obter taxa de crédito.</response>
        /// <response code="500">Erro interno no servidor ao obter taxa de crédito.</response>
        [HttpGet("ObterPorId")]
        public async Task<ActionResult<TaxaCredito>> ObterPorId(int id)
        {
            try
            {
                var taxaCredito = await _taxaCreditoServico.ObterPorId(id);
                _logger.LogInformation("Taxa de crédito obtida com sucesso.");
                return Ok(taxaCredito);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter taxa de crédito.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter todas as taxas de crédito
        /// </summary>
        /// <response code="200">Taxas de crédito obtidas com sucesso.</response>
        /// <response code="400">Erro ao obter taxas de crédito.</response>
        /// <response code="500">Erro interno no servidor ao obter taxas de crédito.</response>
        [HttpGet("ObterTodos")]
        public async Task<ActionResult<List<TaxaCredito>>> ObterTodos()
        {
            try
            {
                var taxas = await _taxaCreditoServico.ObterTodos();
                _logger.LogInformation("Todas as taxas de crédito obtidas com sucesso.");
                return Ok(taxas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as taxas de crédito.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Simular crédito com base nos dados informados
        /// </summary>
        /// <param name="simularCreditoEntrada">Dados para simulação de crédito</param>
        /// <response code="200">Simulação realizada com sucesso.</response>
        /// <response code="400">Erro ao simular crédito.</response>
        /// <response code="500">Erro interno no servidor ao simular crédito.</response>
        [HttpPost("SimularCredito")]
        public async Task<ActionResult<SimularCreditoSaida>> SimularCredito([FromBody] SimularCreditoEntrada simularCreditoEntrada)
        {
            try
            {
                var taxaCredito = await _taxaCreditoServico.ObterTaxaSimulacao(simularCreditoEntrada);
                _logger.LogInformation("Simulação de crédito realizada com sucesso.");
                return Ok(taxaCredito);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao simular crédito.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adicionar uma nova taxa de crédito
        /// </summary>
        /// <param name="taxaCredito">Objeto taxa de crédito a ser adicionado</param>
        /// <response code="201">Taxa de crédito adicionada com sucesso.</response>
        /// <response code="400">Erro ao adicionar taxa de crédito.</response>
        /// <response code="500">Erro interno no servidor ao adicionar taxa de crédito.</response>
        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] TaxaCredito taxaCredito)
        {
            try
            {
                await _taxaCreditoServico.Adicionar(taxaCredito);
                _logger.LogInformation("Taxa de crédito adicionada com sucesso.");
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar taxa de crédito.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar uma taxa de crédito existente
        /// </summary>
        /// <param name="id">Identificador da taxa de crédito</param>
        /// <param name="taxaCredito">Objeto taxa de crédito com dados atualizados</param>
        /// <response code="200">Taxa de crédito atualizada com sucesso.</response>
        /// <response code="400">Erro ao atualizar taxa de crédito.</response>
        /// <response code="500">Erro interno no servidor ao atualizar taxa de crédito.</response>
        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] TaxaCredito taxaCredito)
        {
            if (id != taxaCredito.Id)
            {
                _logger.LogError("O id da taxa de crédito não confere com o id da rota.");
                return BadRequest(new { mensagem = "O id da taxa de crédito não confere com o id da rota." });
            }

            try
            {
                await _taxaCreditoServico.Atualizar(taxaCredito);
                _logger.LogInformation("Taxa de crédito atualizada com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar taxa de crédito.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remover uma taxa de crédito pelo id
        /// </summary>
        /// <param name="id">Identificador da taxa de crédito</param>
        /// <response code="200">Taxa de crédito removida com sucesso.</response>
        /// <response code="400">Erro ao remover taxa de crédito.</response>
        /// <response code="500">Erro interno no servidor ao remover taxa de crédito.</response>
        [HttpDelete("Remover")]
        public async Task<ActionResult> Remover(int id)
        {
            try
            {
                await _taxaCreditoServico.Remover(id);
                _logger.LogInformation("Taxa de crédito removida com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover taxa de crédito.");
                return BadRequest(ex.Message);
            }
        }
    }
}

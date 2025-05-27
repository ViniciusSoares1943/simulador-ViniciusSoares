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

        public TaxaCreditoController(ITaxaCreditoServico taxaCreditoServico)
        {
            _taxaCreditoServico = taxaCreditoServico;
        }

        [HttpGet("ObterPorId")]
        public async Task<ActionResult<TaxaCredito>> ObterPorId(int id)
        {
            try
            {
                var taxaCredito = await _taxaCreditoServico.ObterPorId(id);
                return Ok(taxaCredito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObterTodos")]
        public async Task<ActionResult<List<TaxaCredito>>> ObterTodos()
        {
            try
            {
                var taxas = await _taxaCreditoServico.ObterTodos();
                return Ok(taxas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SimularCredito")]
        public async Task<ActionResult<SimularCreditoSaida>> SimularCredito([FromBody] SimularCreditoEntrada simularCreditoEntrada)
        {
            try
            {
                var taxaCredito = await _taxaCreditoServico.ObterTaxaSimulacao(simularCreditoEntrada);
                return Ok(taxaCredito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] TaxaCredito taxaCredito)
        {
            try
            {
                await _taxaCreditoServico.Adicionar(taxaCredito);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] TaxaCredito taxaCredito)
        {
            if (id != taxaCredito.Id)
                return BadRequest(new { mensagem = "O id da taxa de crédito não confere com o id da rota." });

            try
            {
                await _taxaCreditoServico.Atualizar(taxaCredito);
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
                await _taxaCreditoServico.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Servicos.Interfaces;

namespace SimuladorCredito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class SegmentoController : ControllerBase
    {
        private readonly ISegmentoServico _segmentoServico;

        public SegmentoController(ISegmentoServico segmentoServico)
        {
            _segmentoServico = segmentoServico;
        }

        [HttpGet("ObterPorId")]
        public async Task<ActionResult<Segmento>> ObterPorId(int id)
        {
            try
            {
                var segmento = await _segmentoServico.ObterPorId(id);
                return Ok(segmento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObterTodos")]
        public async Task<ActionResult<List<Segmento>>> ObterTodos()
        {
            try
            {
                var segmentos = await _segmentoServico.ObterTodos();
                return Ok(segmentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Segmento segmento)
        {
            try
            {
                await _segmentoServico.Adicionar(segmento);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Segmento segmento)
        {
            if (id != segmento.Id)
                return BadRequest(new { mensagem = "O id do segmento não confere com o id da rota." });

            try
            {
                await _segmentoServico.Atualizar(segmento);
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
                await _segmentoServico.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

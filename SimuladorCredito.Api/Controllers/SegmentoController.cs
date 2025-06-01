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
        private readonly ILogger<SegmentoController> _logger;

        public SegmentoController(ISegmentoServico segmentoServico, ILogger<SegmentoController> logger)
        {
            _segmentoServico = segmentoServico;
            _logger = logger;
        }

        /// <summary>
        /// Obter um segmento pelo id
        /// </summary>
        /// <param name="id">Identificador do segmento</param>
        /// <response code="200">Segmento obtido com sucesso.</response>
        /// <response code="400">Erro ao obter segmento.</response>
        /// <response code="500">Erro interno no servidor ao obter segmento.</response>
        [HttpGet("ObterPorId")]
        public async Task<ActionResult<Segmento>> ObterPorId(int id)
        {
            try
            {
                var segmento = await _segmentoServico.ObterPorId(id);
                _logger.LogInformation("Segmento obtido com sucesso.");
                return Ok(segmento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter segmento.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter todos os segmentos
        /// </summary>
        /// <response code="200">Segmentos obtidos com sucesso.</response>
        /// <response code="400">Erro ao obter segmentos.</response>
        /// <response code="500">Erro interno no servidor ao obter segmentos.</response>
        [HttpGet("ObterTodos")]
        public async Task<ActionResult<List<Segmento>>> ObterTodos()
        {
            try
            {
                var segmentos = await _segmentoServico.ObterTodos();
                _logger.LogInformation("Todos os segmentos obtidos com sucesso.");
                return Ok(segmentos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os segmentos.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adicionar um novo segmento
        /// </summary>
        /// <param name="segmento">Objeto segmento a ser adicionado</param>
        /// <response code="201">Segmento adicionado com sucesso.</response>
        /// <response code="400">Erro ao adicionar segmento.</response>
        /// <response code="500">Erro interno no servidor ao adicionar segmento.</response>
        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Segmento segmento)
        {
            try
            {
                await _segmentoServico.Adicionar(segmento);
                _logger.LogInformation("Segmento adicionado com sucesso.");
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar segmento.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um segmento existente
        /// </summary>
        /// <param name="id">Identificador do segmento</param>
        /// <param name="segmento">Objeto segmento com dados atualizados</param>
        /// <response code="200">Segmento atualizado com sucesso.</response>
        /// <response code="400">Erro ao atualizar segmento.</response>
        /// <response code="500">Erro interno no servidor ao atualizar segmento.</response>
        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Segmento segmento)
        {
            if (id != segmento.Id)
            {
                _logger.LogError("O id do segmento não confere com o id da rota.");
                return BadRequest(new { mensagem = "O id do segmento não confere com o id da rota." });
            }

            try
            {
                await _segmentoServico.Atualizar(segmento);
                _logger.LogInformation("Segmento atualizado com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar segmento.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remover um segmento pelo id
        /// </summary>
        /// <param name="id">Identificador do segmento</param>
        /// <response code="200">Segmento removido com sucesso.</response>
        /// <response code="400">Erro ao remover segmento.</response>
        /// <response code="500">Erro interno no servidor ao remover segmento.</response>
        [HttpDelete("Remover")]
        public async Task<ActionResult> Remover(int id)
        {
            try
            {
                await _segmentoServico.Remover(id);
                _logger.LogInformation("Segmento removido com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover segmento.");
                return BadRequest(ex.Message);
            }
        }
    }
}

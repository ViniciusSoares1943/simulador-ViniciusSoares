using SimuladorCredito.Api.Models.Entidades;
using SimuladorCredito.Api.Repositorios.Interfaces;
using SimuladorCredito.Api.Servicos.Interfaces;

namespace SimuladorCredito.Api.Servicos
{
    public class SegmentoServico : ISegmentoServico
    {
        private readonly ISegmentoRepositorio _segmentoRepositorio;

        public SegmentoServico(ISegmentoRepositorio segmentoRepositorio)
        {
            _segmentoRepositorio = segmentoRepositorio;
        }

        public async Task<Segmento> ObterPorId(int id)
        {
            var segmento = await _segmentoRepositorio.ObterPorId(id);
            if (segmento == null)
                throw new Exception($"Segmento com Id {id} não encontrado.");
            return segmento;
        }

        public async Task<List<Segmento>> ObterTodos()
        {
            return await _segmentoRepositorio.ObterTodos();
        }

        public async Task Adicionar(Segmento segmento)
        {
            if (segmento == null)
                throw new Exception("Segmento não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(segmento.Nome))
                throw new Exception("O nome do segmento é obrigatório.");

            segmento.DataCadastro = DateTime.Now;
            segmento.DataAlteracao = DateTime.Now;
            segmento.Ativo = true;

            await _segmentoRepositorio.Adicionar(segmento);
        }

        public async Task Atualizar(Segmento segmento)
        {
            if (segmento == null)
                throw new Exception("Segmento não pode ser nulo.");

            var existente = await _segmentoRepositorio.ObterPorId(segmento.Id);
            if (existente == null)
                throw new Exception($"Segmento com Id {segmento.Id} não encontrado.");

            segmento.DataAlteracao = DateTime.Now;

            await _segmentoRepositorio.Atualizar(segmento);
        }

        public async Task Remover(int id)
        {
            var existente = await _segmentoRepositorio.ObterPorId(id);
            if (existente == null)
                throw new Exception($"Segmento com Id {id} não encontrado.");

            await _segmentoRepositorio.Remover(id);
        }
    }
}

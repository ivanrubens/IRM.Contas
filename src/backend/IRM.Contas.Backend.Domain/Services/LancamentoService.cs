using IRM.Contas.Backend.Domain.Core.Entities;
using IRM.Contas.Backend.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Domain.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _contasRepository;
        public LancamentoService(ILancamentoRepository contasRepository)
        {
            _contasRepository = contasRepository;
        }

        public async Task<IEnumerable<Lancamento>> ObterAtivosPorAnoMesAsync(string anoMes)
        {
            return await _contasRepository.ObterAtivosPorAnoMesAsync(anoMes);
        }

        public async Task<Lancamento> IncluirAsync(Lancamento lancamento)
        {
            return await _contasRepository.IncluirAsync(lancamento);
        }

        public async Task<Lancamento> AlterarAsync(Lancamento lancamento)
        {
            return await _contasRepository.AlterarAsync(lancamento);
        }

        public async Task<int> ExcluirAsync(Guid id)
        {
            return await _contasRepository.ExcluirAsync(id);
        }
    }
}

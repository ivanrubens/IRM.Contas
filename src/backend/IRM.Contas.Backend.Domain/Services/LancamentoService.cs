using IRM.Contas.Backend.Domain.Core.Entities;
using IRM.Contas.Backend.Domain.Core.Interfaces.Repositories;
using IRM.Contas.Backend.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Domain.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoService(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<IEnumerable<Lancamento>> ObterAtivosPorAnoMesAsync(string anoMes)
        {
            return await _lancamentoRepository.ObterAtivosPorAnoMesAsync(anoMes);
        }

        public async Task<Lancamento> IncluirAsync(Lancamento lancamento)
        {
            return await _lancamentoRepository.IncluirAsync(lancamento);
        }

        public async Task<Lancamento> AlterarAsync(Lancamento lancamento)
        {
            return await _lancamentoRepository.AlterarAsync(lancamento);
        }

        public async Task<int> ExcluirAsync(Guid id)
        {
            return await _lancamentoRepository.ExcluirAsync(id);
        }
    }
}

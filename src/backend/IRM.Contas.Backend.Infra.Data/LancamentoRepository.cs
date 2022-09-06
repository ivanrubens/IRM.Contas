using IRM.Contas.Backend.Domain.Core.Entities;
using IRM.Contas.Backend.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Infra.Data
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public async Task<IEnumerable<Lancamento>> ObterAtivosPorAnoMesAsync(string anoMes)
        {
            var lancamentos = new LancamentoFake().Lancamentos.Where(x => x.AnoMes == anoMes &&
                !x.Excluido
                );

            return await Task.FromResult(lancamentos);
        }
        public async Task<Lancamento> IncluirAsync(Lancamento lancamento)
        {
            return await Task.FromResult(new LancamentoFake().Lancamentos.FirstOrDefault());
        }
        public async Task<Lancamento> AlterarAsync(Lancamento lancamento)
        {
            lancamento.DataAlteracao = System.DateTime.Now;
            return await Task.FromResult(lancamento);
        }

        public async Task<int> ExcluirAsync(Guid id)
        {
            return 1;
        }
    }
}

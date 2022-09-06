using IRM.Contas.Backend.Domain.Core.Entities;
using IRM.Contas.Backend.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Infra.Data
{
    public class PeriodoRepository : IPeriodoRepository
    {
        public async Task<Periodo> AlterarAsync(Periodo periodo)
        {
            periodo.DataAlteracao = System.DateTime.Now;
            return await Task.FromResult(periodo);
        }

        public async Task<int> ExcluirAsync(string anoMes)
        {
            return 1;
        }

        public async Task<Periodo> FecharAsync(string anoMes)
        {
            var periodo = await Task.FromResult(new LancamentoFake().Periodos.FirstOrDefault());
            periodo.Aberto = false;
            return periodo;
        }

        public async Task<Periodo> IncluirAsync(Periodo periodo)
        {
            return await Task.FromResult(new LancamentoFake().Periodos.FirstOrDefault());
        }

        public async Task<IEnumerable<Periodo>> ObterAbertosAsync(string anoMes)
        {
            var periodo = new LancamentoFake().Periodos.Where(x => !x.Excluido && x.Aberto
               );

            if (!string.IsNullOrEmpty(anoMes))
            {
                periodo = periodo.Where(x => x.AnoMes == anoMes);
            }

            return periodo;
        }
    }
}

using IRM.Contas.Backend.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Domain.Core.Interfaces
{
    public interface IPeriodoRepository
    {
        Task<IEnumerable<Periodo>> ObterAtivoPorAnoMesAsync(string anoMes);
        Task<Periodo> IncluirAsync(Periodo lancamento);
        Task<Periodo> AlterarAsync(Periodo lancamento);
        Task<int> ExcluirAsync(Guid id);
    }
}

using IRM.Contas.Backend.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Domain.Core.Interfaces.Services
{
    public interface IPeriodoService
    {
        Task<IEnumerable<Periodo>> ObterAbertosAsync(string anoMes);
        Task<Periodo> FecharAsync(string anoMes);
        Task<Periodo> IncluirAsync(Periodo periodo);
        Task<Periodo> AlterarAsync(Periodo periodo);
        Task<int> ExcluirAsync(string anoMes);
    }
}

using IRM.Contas.Backend.Domain.Core.DTOs;
using IRM.Contas.Backend.Domain.Core.Entities;

namespace IRM.Contas.Blazor.Wasm.Services
{
    public interface ILancamentoService
    {
        Task<RetornoDto<IEnumerable<Lancamento>>> ObterAtivosPorAnoMesAsync(string anoMes);
    }
}

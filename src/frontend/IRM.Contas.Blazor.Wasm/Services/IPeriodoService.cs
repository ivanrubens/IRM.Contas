using IRM.Contas.Backend.Domain.Core.DTOs;
using IRM.Contas.Backend.Domain.Core.Entities;

namespace IRM.Contas.Blazor.Wasm.Services
{
    public interface IPeriodoService
    {
        Task<RetornoDto<IEnumerable<Periodo>>> ObterAbertosAsync();
    }
}

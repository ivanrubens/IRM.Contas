using IRM.Contas.Backend.Domain.Core.Entities;
using IRM.Contas.Backend.Domain.Core.Interfaces.Repositories;
using IRM.Contas.Backend.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Domain.Services
{
    public class PeriodoService : IPeriodoService
    {
        private readonly IPeriodoRepository _periodoRepository;

        public PeriodoService(IPeriodoRepository periodoRepository)
        {
            _periodoRepository = periodoRepository;
        }

        public async Task<IEnumerable<Periodo>> ObterAbertosAsync(string anoMes)
        {
            return await _periodoRepository.ObterAbertosAsync(anoMes);
        }

        public async Task<Periodo> IncluirAsync(Periodo periodo)
        {
            return await _periodoRepository.IncluirAsync(periodo);
        }

        public async Task<Periodo> AlterarAsync(Periodo periodo)
        {
            return await _periodoRepository.AlterarAsync(periodo);
        }

        public async Task<int> ExcluirAsync(string anoMes)
        {
            return await _periodoRepository.ExcluirAsync(anoMes);
        }

        public async Task<Periodo> FecharAsync(string anoMes)
        {
            return await _periodoRepository.FecharAsync(anoMes);
        }
    }
}

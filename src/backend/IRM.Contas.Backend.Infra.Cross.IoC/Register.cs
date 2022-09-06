using IRM.Contas.Backend.Domain.Core.Interfaces;
using IRM.Contas.Backend.Domain.Services;
using IRM.Contas.Backend.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.Contas.Backend.Infra.Cross.IoC
{
    public static class Register
    {
        public static void RegisterIoC(IConfiguration configuration, IServiceCollection services)
        {
            // Domain / Services
            services.AddScoped<ILancamentoService, LancamentoService>();

            // Infra / Data
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
        }
    }
}

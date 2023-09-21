using IRM.Contas.Backend.Domain.Core.DTOs;
using IRM.Contas.Backend.Domain.Core.Entities;
using System.Net.Http.Json;

namespace IRM.Contas.Blazor.Wasm.Services
{
    public class PeriodoService : IPeriodoService
    {
        protected readonly HttpClient _httpClient;
        public PeriodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<RetornoDto<IEnumerable<Periodo>>> ObterAbertosAsync()
        {
            var periodos = new RetornoDto<IEnumerable<Periodo>>();
            try
            {
                periodos = await _httpClient.GetFromJsonAsync<RetornoDto<IEnumerable<Periodo>>>($"api/Periodo");
            }
            catch (Exception ex)
            {
                periodos.Sucesso = false;
                periodos.Erros.Add(new ErroDto { Mensagem = ex.Message });

            }
            return periodos;
        }
    }
}

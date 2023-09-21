using IRM.Contas.Backend.Domain.Core.DTOs;
using IRM.Contas.Backend.Domain.Core.Entities;
using System.Net.Http.Json;

namespace IRM.Contas.Blazor.Wasm.Services
{
    public class LancamentoService : ILancamentoService
    {
        protected readonly HttpClient _httpClient;

        public LancamentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RetornoDto<IEnumerable<Lancamento>>> ObterAtivosPorAnoMesAsync(string anoMes)
        {
            var lancamentos = new RetornoDto<IEnumerable<Lancamento>>();
            try
            {
                lancamentos = await _httpClient.GetFromJsonAsync<RetornoDto<IEnumerable<Lancamento>>>($"api/Lancamentos/{anoMes}");
            }
            catch (Exception ex)
            {
                lancamentos.Sucesso = false;
                lancamentos.Erros.Add(new ErroDto { Mensagem = ex.Message });

            }
            return lancamentos;
        }
    }
}

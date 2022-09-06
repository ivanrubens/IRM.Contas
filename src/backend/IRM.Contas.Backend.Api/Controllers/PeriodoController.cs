using IRM.Contas.Backend.Domain.Core.DTOs;
using IRM.Contas.Backend.Domain.Core.Entities;
using IRM.Contas.Backend.Domain.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        private readonly IPeriodoService _periodoService;

        public PeriodoController(IPeriodoService periodoService)
        {
            _periodoService = periodoService;
        }

        [HttpGet]
        public async Task<RetornoDto<IEnumerable<Periodo>>> ObterPorPeriodoAsync(string anoMes)
        {
            var retorno = new RetornoDto<IEnumerable<Periodo>>();

            try
            {
                retorno.Resultado = await _periodoService.ObterAbertosAsync(anoMes);
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;

                var erro = new ErroDto { Codigo = "1", Mensagem = ex.Message };
                retorno.Erros.Add(erro);
            }

            return retorno;
        }

        [HttpPut]
        public async Task<RetornoDto<Periodo>> Incluir([FromBody] Periodo Periodo)
        {
            var retorno = new RetornoDto<Periodo>();

            try
            {
                if (string.IsNullOrEmpty(Periodo.AnoMes?.Trim()))
                {
                    retorno.Sucesso = false;

                    var erro = new ErroDto { Codigo = "100", Mensagem = "Ano/mês precisa ser informado." };
                    retorno.Erros.Add(erro);

                    return retorno;

                }

                retorno.Resultado = await _periodoService.IncluirAsync(Periodo);
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;

                var erro = new ErroDto { Codigo = "1", Mensagem = ex.Message };
                retorno.Erros.Add(erro);
            }

            return retorno;
        }

        [HttpPost]
        public async Task<RetornoDto<Periodo>> Alterar([FromBody] Periodo Periodo)
        {
            var retorno = new RetornoDto<Periodo>();

            try
            {
                if (string.IsNullOrEmpty(Periodo.AnoMes?.Trim()))
                {
                    retorno.Sucesso = false;

                    var erro = new ErroDto { Codigo = "110", Mensagem = "Ano/mês precisa ser informado." };
                    retorno.Erros.Add(erro);

                    return retorno;

                }

                retorno.Resultado = await _periodoService.AlterarAsync(Periodo);
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;

                var erro = new ErroDto { Codigo = "1", Mensagem = ex.Message };
                retorno.Erros.Add(erro);
            }

            return retorno;
        }

        [HttpDelete("{anoMes}")]
        public async Task<RetornoDto<Periodo>> ExcluirAsync(string anoMes)
        {
            var retorno = new RetornoDto<Periodo>();

            try
            {
                if (string.IsNullOrEmpty(anoMes?.Trim()))
                {
                    retorno.Sucesso = false;

                    var erro = new ErroDto { Codigo = "120", Mensagem = "Ano/mês precisa ser informado." };
                    retorno.Erros.Add(erro);

                    return retorno;

                }

                var excluidos = await _periodoService.ExcluirAsync(anoMes);

                if (excluidos == 0)
                {
                    retorno.Sucesso = false;
                    retorno.Erros.Add(new ErroDto { Codigo = "121", Mensagem = "Nenhum registro afetado" });

                    return retorno;
                }

                retorno.Sucesso = true;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;

                var erro = new ErroDto { Codigo = "1", Mensagem = ex.Message };
                retorno.Erros.Add(erro);
            }

            return retorno;
        }
    }
}

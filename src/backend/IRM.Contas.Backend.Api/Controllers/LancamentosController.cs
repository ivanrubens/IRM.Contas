using IRM.Contas.Backend.Domain.Core.DTOs;
using IRM.Contas.Backend.Domain.Core.Entities;
using IRM.Contas.Backend.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentoService _lancamentosService;
        public LancamentosController(ILancamentoService lancamentosService)
        {
            _lancamentosService = lancamentosService;
        }

        [HttpGet("obter-por-periodo")]
        public async Task<RetornoDto<IEnumerable<Lancamento>>> ObterPorPeriodoAsync(string anoMes)
        {
            var retorno = new RetornoDto<IEnumerable<Lancamento>>();

            try
            {
                if (!string.IsNullOrEmpty(anoMes.Trim()))
                {
                    retorno.Resultado = await _lancamentosService.ObterAtivosPorAnoMesAsync(anoMes);
                }
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
        public async Task<RetornoDto<Lancamento>> Incluir([FromBody] Lancamento lancamento)
        {
            var retorno = new RetornoDto<Lancamento>();

            try
            {
                if (lancamento.Id != Guid.Empty)
                {
                    retorno.Sucesso = false;

                    var erro = new ErroDto { Codigo = "100", Mensagem = "Id do lançamento precisa ser 'Empty'!" };
                    retorno.Erros.Add(erro);

                    return retorno;

                }

                retorno.Resultado = await _lancamentosService.IncluirAsync(lancamento);
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
        public async Task<RetornoDto<Lancamento>> Alterar([FromBody] Lancamento lancamento)
        {
            var retorno = new RetornoDto<Lancamento>();

            try
            {
                if (lancamento.Id == Guid.Empty)
                {
                    retorno.Sucesso = false;

                    var erro = new ErroDto { Codigo = "110", Mensagem = "Id do lançamento não deve ser inviado!" };
                    retorno.Erros.Add(erro);

                    return retorno;

                }

                retorno.Resultado = await _lancamentosService.AlterarAsync(lancamento);
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;

                var erro = new ErroDto { Codigo = "1", Mensagem = ex.Message };
                retorno.Erros.Add(erro);
            }

            return retorno;
        }

        [HttpDelete("{id}")]
        public async Task<RetornoDto<Lancamento>> ExcluirAsync(Guid id)
        {
            var retorno = new RetornoDto<Lancamento>();

            try
            {
                if (id == Guid.Empty)
                {
                    retorno.Sucesso = false;

                    var erro = new ErroDto { Codigo = "120", Mensagem = "Id do lançamento precisa ser informado!" };
                    retorno.Erros.Add(erro);

                    return retorno;

                }

                var excluidos = await _lancamentosService.ExcluirAsync(id);

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

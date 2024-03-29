﻿using IRM.Contas.Backend.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRM.Contas.Backend.Domain.Core.Interfaces.Repositories
{
    public interface ILancamentoRepository
    {
        Task<IEnumerable<Lancamento>> ObterAtivosPorAnoMesAsync(string anoMes);
        Task<Lancamento> IncluirAsync(Lancamento lancamento);
        Task<Lancamento> AlterarAsync(Lancamento lancamento);
        Task<int> ExcluirAsync(Guid id);
    }
}

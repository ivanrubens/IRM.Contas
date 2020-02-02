using IRM.Contas.Shared.ValueObjects;

namespace IRM.Contas.Domain.Entities
{
    public class ReferenciaMesAnterior : ValueObject
    {
        public LancamentoConsolidado LancamentoConsolidado { get; private set; }
        public decimal Saldo { get; private set; }

    }
}
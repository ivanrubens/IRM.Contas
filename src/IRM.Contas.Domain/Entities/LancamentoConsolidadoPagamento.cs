using IRM.Contas.Shared.Entities;

namespace IRM.Contas.Domain.Entities
{
    public class LancamentoConsolidadoPagamento : Entity
    {
        public LancamentoConsolidadoPagamento(decimal valorPago, string observacao)
        {
            ValorPago = valorPago;
            Observacao = observacao;
        }

        public decimal ValorPago { get; private set; }
        public string Observacao { get; private set; }
    }

}
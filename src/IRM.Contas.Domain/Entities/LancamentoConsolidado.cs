using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using IRM.Contas.Shared.Entities;

namespace IRM.Contas.Domain.Entities
{
    public class LancamentoConsolidado : Entity
    {
        private IList<LancamentoConsolidadoPagamento> _pagamentos;
        public LancamentoConsolidado(Periodo periodo,
                                     Devedor devedor,
                                     decimal valorDebito,
                                     decimal valorPago,
                                     string observacao)
        {
            Periodo = periodo;
            Devedor = devedor;
            ValorDebito = valorDebito;

            _pagamentos = new List<LancamentoConsolidadoPagamento>();

        }

        public Periodo Periodo { get; private set; }
        public Devedor Devedor { get; private set; }
        public decimal ValorDebito { get; private set; }

        public IReadOnlyCollection<LancamentoConsolidadoPagamento> LancamentoPagamentos { get { return _pagamentos.ToArray(); } }

        public void AddPagamento(LancamentoConsolidadoPagamento pagamento)
        {

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(pagamento.ValorPago,0,"ValorPago", "Valor Pago é inválido")
            );

            if (Valid)
                _pagamentos.Add(pagamento);

        }

        public void LancarSaldoProximoPeriodo(Periodo periodo)
        {

        }
    }
}
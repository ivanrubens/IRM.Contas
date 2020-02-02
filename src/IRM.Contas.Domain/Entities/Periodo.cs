using IRM.Contas.Domain.Shared.Enums;
using IRM.Contas.Shared.Entities;

namespace IRM.Contas.Domain.Entities
{
    public class Periodo : Entity
    {
        public int Ano { get; private set; }
        public int Mes { get; private set; }
        public EPeriodoStatus PeriodoStatus { get; private set; }

        public Periodo(int ano, int mes)
        {
            if ((mes < 1) || (mes > 12))
            {
                AddNotification("Mes", "Inválido!");
            }

            if ((ano < 2020) || (mes > 2030))
            {
                AddNotification("Ano", "Inválido!");
            }

            Mes = mes;
            Ano = ano;
            PeriodoStatus = EPeriodoStatus.Aberto;

        }

        public override string ToString()
        {
            return Ano.ToString() + Mes.ToString().PadLeft(2,'0');
        }
    }
}
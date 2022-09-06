using System;

namespace IRM.Contas.Backend.Domain.Core.Entities
{
    public class Periodo : EntityBase 
    {
        public string AnoMes { get; set; }
        public bool Aberto { get; set; }
        public DateTime DataFechamento { get; set; }
    }
}
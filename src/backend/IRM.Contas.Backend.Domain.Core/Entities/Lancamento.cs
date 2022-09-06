using System;

namespace IRM.Contas.Backend.Domain.Core.Entities
{
    public class Lancamento : EntityBase
    {
        public Guid Id { get; set; }
        public string AnoMes { get; set; }
        public Guid IdConta { get; set; }
        public DateTime DataCompra { get; set; }
        public string Descricao { get; set; }
        public int Parcela { get; set; }
        public int QuantidadeParcelas { get; set; }
        public decimal Valor { get; set; }
        public Guid IdPessoa { get; set; }
        public string IdStatusConta { get; set; }
        public Guid IdCategoria { get; set; }
        public string Observacao { get; set; }
    }
}

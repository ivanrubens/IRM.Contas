using System;

namespace IRM.Contas.Backend.Domain.Core.Entities
{
    public class Conta : EntityBase
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
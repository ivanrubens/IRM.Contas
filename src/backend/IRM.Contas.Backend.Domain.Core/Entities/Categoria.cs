using System;

namespace IRM.Contas.Backend.Domain.Core.Entities
{
    public class Categoria : EntityBase
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
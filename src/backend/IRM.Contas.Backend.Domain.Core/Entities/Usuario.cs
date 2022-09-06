using System;

namespace IRM.Contas.Backend.Domain.Core.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}

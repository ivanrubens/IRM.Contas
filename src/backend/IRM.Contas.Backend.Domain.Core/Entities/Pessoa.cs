using System;

namespace IRM.Contas.Backend.Domain.Core.Entities
{
    public class Pessoa : EntityBase
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
    }
}
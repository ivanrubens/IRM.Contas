using System;

namespace IRM.Contas.Backend.Domain.Core.Entities
{
    public class EntityBase
    {
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public bool Excluido { get; set; }

        public EntityBase()
        {
            DataInclusao = DateTime.Now;
        }
    }
}

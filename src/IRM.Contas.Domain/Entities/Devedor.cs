using Flunt.Validations;
using IRM.Contas.Shared.Entities;

namespace IRM.Contas.Domain.Entities
{
    public class Devedor : Entity
    {

        public string Nome { get; private set; }

        public Devedor(string nome)
        {
            AddNotifications(new Contract()
                         .HasMinLen(nome, 3, "Nome", "Nome do Devedor Inválido (mínimo de 3 caracteres)")
                         .HasMinLen(nome, 50, "Nome", "Nome do Devedor Inválido (máximo 50 caracteres)")
            );

            Nome = nome.ToUpper();
        }

        public override string ToString(){
            return Nome;
        }

    }
}

using Flunt.Validations;
using IRM.Contas.Shared.Entities;

namespace IRM.Contas.Domain.Entities
{
    public class Categoria : Entity
    {
        public Categoria(string nome)
        {
            AddNotifications(new Contract()
             .HasMinLen(nome, 3, "Nome", "Nome da Categoria Inválido (mínimo de 3 caracteres)")
             .HasMaxLen(nome, 50, "Nome", "Nome do Categoria Inválido (máximo 50 caracteres)")
            );

            Nome = nome;
        }

        public string Nome { get; private set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
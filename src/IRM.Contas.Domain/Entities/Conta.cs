using System;
using Flunt.Validations;
using IRM.Contas.Shared.Entities;
using IRM.Contas.Shared.Enums;

namespace IRM.Contas.Domain.Entities
{
    public class Conta : Entity
    {
        public Conta(string nome, int diaVencimento)
        {

            AddNotifications(new Contract()
                .HasMinLen(nome, 3, "Nome", "Nome do Cartão Inválido (mínimo de 3 caracteres)")
                .HasMaxLen(nome, 50, "Nome", "Nome do Cartão Inválido (máximo 50 caracteres)")
                .IsBetween(diaVencimento, 1, 31, "diaVencimento", "DiaVencimento do cartão inválida")
           );

            Nome = nome.ToUpper();
            DiaVencimento = diaVencimento;
            Status = ECartaoStatus.Ativo;

        }

        public Guid CartaoId { get; private set; }
        public string Nome { get; private set; }
        public int DiaVencimento { get; private set; }
        public ECartaoTipo Tipo { get; private set; }
        public ECartaoStatus Status { get; private set; }

        public override string ToString(){
            return Nome;
        }

    }
}
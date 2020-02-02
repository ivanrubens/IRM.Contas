using System;
using Flunt.Validations;
using IRM.Contas.Shared.Entities;
using IRM.Contas.Shared.Enums;

namespace IRM.Contas.Domain.Entities
{
    public class Lancamento : Entity
    {
        public Lancamento(Periodo periodo, Conta conta, DateTime data, string descricao, Categoria categoria, int parcela, int quantidadeParcelas, decimal valor, Devedor devedor)
        {

            AddNotifications(new Contract()
                .HasMinLen(descricao, 3, "Descrição", "Descrição Inválida (mínimo de 3 caracteres)")
                .HasMaxLen(descricao, 150, "Descrição", "Descrição Inválida (máximo 150 caracteres)")
                .IsBetween(Parcela, 1, QuantidadeParcelas, "Parcela", "Parcela inválida")
                .IsGreaterThan(QuantidadeParcelas, 1, "QuantidadeParcelas", "Qtd. Parcelas inválida")
                );


            Periodo = periodo;
            Conta = conta;
            Data = data;
            Descricao = descricao;
            Categoria = categoria;
            Parcela = parcela;
            QuantidadeParcelas = quantidadeParcelas;
            Valor = valor;
            Devedor = devedor;
            Status = ELancamentoStatus.Lancado;
        }

        public Periodo Periodo { get; private set; }
        public Conta Conta { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public Categoria Categoria { get; private set; }
        public int Parcela { get; private set; }
        public int QuantidadeParcelas { get; private set; }
        public decimal Valor { get; private set; }
        public ReferenciaMesAnterior ReferenciaMesAnterior { get; set; }
        public Devedor Devedor { get; private set; }
        public ELancamentoStatus Status { get; private set; }

        public void ConsolidaLancamento(Periodo periodo)
        {

        }
    }

}
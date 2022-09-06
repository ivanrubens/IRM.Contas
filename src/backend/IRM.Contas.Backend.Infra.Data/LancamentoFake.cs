using Bogus;
using IRM.Contas.Backend.Domain.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace IRM.Contas.Backend.Infra.Data
{

    public class LancamentoFake
    {
        public IEnumerable<Periodo> Periodos { get; set; }
        public IEnumerable<Conta> Contas { get; set; }
        public IEnumerable<Pessoa> Pessoas { get; set; }
        public StatusConta StatusConta { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public IEnumerable<Lancamento> Lancamentos { get; set; }

        public LancamentoFake()
        {
            Periodos = new Faker<Periodo>()
                .RuleFor(p => p.AnoMes, p => p.Date.Recent(60).ToString("yyyyMM"))
                .RuleFor(p => p.Aberto, true)
                .GenerateLazy(30);

            Contas = new Faker<Conta>()
                .RuleFor(p => p.Id, p => p.Random.Guid())
                .RuleFor(p => p.Descricao, p => p.Commerce.Product())
                .RuleFor(p => p.Excluido, p => p.Commerce.Random.Bool())
                .GenerateLazy(30);

            Pessoas = new Faker<Pessoa>()
                .RuleFor(p => p.Id, p => p.Random.Guid())
                .RuleFor(p => p.Nome, p => p.Person.FullName)
                .RuleFor(p => p.Apelido, p => p.Person.FirstName)
                .RuleFor(p => p.Excluido, p => p.Random.Bool())
                .GenerateLazy(20);

            StatusConta = new Faker<StatusConta>()
                .RuleFor(p => p.Id, p => "OK")
                .RuleFor(p => p.Status, p => "Status Ok")
                .Generate();

            Categorias = new Faker<Categoria>()
                .RuleFor(p => p.Id, p => p.Random.Guid())
                .RuleFor(p => p.Descricao, p => p.Commerce.Categories(10).FirstOrDefault())
                .RuleFor(p => p.Excluido, p => p.Commerce.Random.Bool())
                .GenerateLazy(20);

            Lancamentos = new Faker<Lancamento>()
                .RuleFor(p => p.Id, p => p.Random.Guid())
                .RuleFor(p => p.AnoMes, p => Periodos.ElementAt(p.Random.Int(1, Periodos.Count() - 1)).AnoMes)
                .RuleFor(p => p.IdConta, p => Contas.ElementAt(p.Random.Int(1, Contas.Count() - 1)).Id)
                .RuleFor(p => p.DataCompra, p => p.Date.Recent(60))
                .RuleFor(p => p.Descricao, p => p.Commerce.ProductName())
                .RuleFor(p => p.Parcela, p => p.Random.Int(1, 12))
                .RuleFor(p => p.QuantidadeParcelas, p => p.Random.Int(1, 12))
                .RuleFor(p => p.Valor, p => p.Random.Decimal(30, 250) / p.Random.Int(1, 12))
                .RuleFor(p => p.IdPessoa, p => Pessoas.ElementAt(p.Random.Int(1, Pessoas.Count() - 1)).Id)
                .RuleFor(p => p.IdStatusConta, p => StatusConta.Id)
                .RuleFor(p => p.IdCategoria, p => Categorias.ElementAt(p.Random.Int(1, Categorias.Count() - 1)).Id)
                .RuleFor(p => p.Excluido, p => p.Commerce.Random.Bool())
                .GenerateLazy(50);
        }
    }
}

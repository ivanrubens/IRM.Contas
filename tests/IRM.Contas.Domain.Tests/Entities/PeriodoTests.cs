using Microsoft.VisualStudio.TestTools.UnitTesting;
using IRM.Contas.Domain.Entities;

namespace IRM.Contas.Domain.Tests
{
    [TestClass]
    public class PeriodoTests
    {
        [TestMethod]
        public void Periodo_Ano_Invalid()
        {
            int ano;
            int mes = 01;

            ano = 2019;
            Periodo periodo1 = new Periodo(ano, mes);

            ano = 2031;
            Periodo periodo2 = new Periodo(ano, mes);

            Assert.IsFalse(periodo1.Valid && periodo2.Valid);
        }

        [TestMethod]
        public void Periodo_Mes_Invalid()
        {
            int ano = 2020;
            int mes = 0;

            Periodo periodo1 = new Periodo(ano, mes);

            mes = 13;
            Periodo periodo2 = new Periodo(ano, mes);

            Assert.IsFalse(periodo1.Valid && periodo2.Valid);
        }

        [TestMethod]
        public void Periodo_Periodo_Valid()
        {
            int ano = 2020;
            int mes = 01;

            Periodo periodo1 = new Periodo(ano, mes);

            ano = 2030;
            mes = 12;
            Periodo periodo2 = new Periodo(ano, mes);

            Assert.IsTrue(periodo1.Valid && periodo2.Valid);
        }

    }
}

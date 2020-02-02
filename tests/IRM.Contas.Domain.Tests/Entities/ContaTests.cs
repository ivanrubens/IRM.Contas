using Microsoft.VisualStudio.TestTools.UnitTesting;
using IRM.Contas.Domain.Entities;

namespace IRM.Contas.Domain.Tests
{
    [TestClass]
    public class ContaTests
    {
        [TestMethod]
        public void ContaInvalid()
        {
            Conta Conta1 = new Conta("VI", 7);
            Conta Conta2 = new Conta("VISA", 0);
            Conta Conta3 = new Conta("MASTERCARD", -32);
            Conta Conta4 = new Conta("MASTERCARD", 32);

            Assert.IsFalse(Conta1.Valid && Conta2.Valid && Conta3.Valid && Conta4.Valid);
        }

        [TestMethod]
        public void ContaValid()
        {
            Conta Conta1 = new Conta("VISA", 7);
            Conta Conta2 = new Conta("MASTERCARD", 31);

            Assert.IsTrue(Conta1.Valid && Conta2.Valid);
        }


    }
}

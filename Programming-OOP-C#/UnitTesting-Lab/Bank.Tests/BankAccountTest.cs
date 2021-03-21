using NUnit.Framework;
using System;

namespace Bank.Tests
{
    [TestFixture]
    public class BankAccountTest
    {
        private decimal amount;
        private string name;
        private BankAccount bankAccount;


        [SetUp]
        public void SetUp()
        {
            this.name = "Pesho";
            this.amount = 5;
            this.bankAccount = new BankAccount(amount, name);
        }

        [Test]
        public void WhenAccountInitializeWhithPositiveValue_AmountShouldBeChenged() 
        {      
            Assert.That(bankAccount.Amount, Is.EqualTo(amount));       
        }

        [Test]
        public void WhenAccountDepositmade_ShouldChangeAmount()
        {
            bankAccount.Deposit(amount);
            Assert.That(bankAccount.Amount, Is.EqualTo(amount * 2));
        }
    }
}

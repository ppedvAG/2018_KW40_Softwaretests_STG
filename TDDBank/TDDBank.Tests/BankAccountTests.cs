using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDBank.Tests
{
    //Bankkonto
    //✔- Kontostand abfragen
    //✔- Betrag einzahlen(nicht Negativ)
    //✔- Betrag abheben(nicht Negativ)
    //✔	- Darf nicht unter 0 fallen
    //✔ Neues Konto hat 0 als Kontostand

    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void BankAccount_new_account_has_0_as_balance()
        {
            var ba = new BankAccount();

            Assert.AreEqual(0m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_can_deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(3m);
            Assert.AreEqual(3m, ba.Balance);

            ba.Deposit(5m);
            Assert.AreEqual(8m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_deposit_zero_or_negative_value_throws_ArgumentException()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(-3));

            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(0));
        }

        [TestMethod]
        public void BankAccount_can_withdraw()
        {
            var ba = new BankAccount();
            ba.Deposit(10m);

            ba.Withdraw(3m);
            Assert.AreEqual(7m, ba.Balance);

            ba.Withdraw(4m);
            Assert.AreEqual(3m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_withdraw_zero_or_negative_value_throws_ArgumentException()
        {
            var ba = new BankAccount();
            ba.Deposit(10m);

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(-3));

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(-0));
            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(0));
        }

        [TestMethod]
        public void BankAccount_withdraw_more_than_balance_throws_InvalidOperationException()
        {
            var ba = new BankAccount();
            ba.Deposit(10m);


            Assert.ThrowsException<InvalidOperationException>(() => ba.Withdraw(20m));
            Assert.ThrowsException<InvalidOperationException>(() => ba.Withdraw(11m));

            ba.Withdraw(10m);
            Assert.AreEqual(0m, ba.Balance);
        }
    }
}

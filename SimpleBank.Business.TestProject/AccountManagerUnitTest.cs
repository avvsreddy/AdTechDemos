namespace SimpleBank.Business.TestProject
{
    class MockTransactionLogger : ITansactionLogger
    {
        public void Log(string message)
        {

        }
    }

    [TestClass]
    public class AccountManagerUnitTest
    {
        AccountManager target = null;
        [TestInitialize]
        public void Init()
        {
            // exe before every test case

            target = new AccountManager(new MockTransactionLogger());
        }


        [TestMethod]
        public void DepsitTest_OnSuccess_ShouldIncreaseBalance() // Test Case
        {
            // AAA Approach
            // A - Arrange
            //AccountManager target = new AccountManager();
            //int accno = 111;
            //int amount = 2000;
            //int expectedBalance = 3000;
            // A - Act
            Account acc = target.Deposit(111, 2000);
            // A - Assert
            //if(acc.Balance == expectedBalance)
            Assert.AreEqual(3000, acc.Balance);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountNotExistException))]
        public void DepositTest_AccountNotExist_ThrowsExp()
        {
            //AccountManager target = new AccountManager();
            //int accno = 123;
            //int amount = 2000;
            //int expectedBalance = 3000;
            Account acc = target.Deposit(123, 2000);
            //
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAmountException))]
        public void DepositTest_MinimumAmount_ThrowsExp()
        {
            //AccountManager target = new AccountManager();
            //int accno = 111;
            //int amount = 500;
            //int expectedBalance = 3000;
            Account acc = target.Deposit(111, 500);
        }


        [TestMethod]
        public void WithdrawTest_OnSuccess_DecreasesTheBalance()
        {
            //AccountManager target = new AccountManager();
            //int accno = 111;
            //int amount = 500;
            //int expectedBalance = 500;
            Account acc = target.Withdraw(111, 500, 1234);
            Assert.AreEqual(500, acc.Balance);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountNotExistException))]
        public void WithdrawTest_AccountNotExist_ThrowsExp()
        {
            //AccountManager target = new AccountManager();
            //int accno = 123;
            //int amount = 2000;
            //int expectedBalance = 3000;
            Account acc = target.Withdraw(123, 500, 1234);
            //
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficcientBalanceException))]
        public void WithdrawTest_InsufficcientBalance_ThrowsExp()
        {
            //AccountManager target = new AccountManager();
            //int accno = 123;
            //int amount = 2000;
            //int expectedBalance = 3000;
            Account acc = target.Withdraw(111, 5000, 1234);
            //
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPinException))]
        public void WithdrawTest_InvalidPin_ThrowsExp()
        {
            Account acc = target.Withdraw(111, 500, 0000);
        }

    }
}
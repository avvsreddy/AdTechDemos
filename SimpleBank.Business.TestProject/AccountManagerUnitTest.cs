namespace SimpleBank.Business.TestProject
{
    [TestClass]
    public class AccountManagerUnitTest
    {
        [TestMethod]
        public void DepsitTest_OnSuccess_ShouldIncreaseBalance() // Test Case
        {
            // AAA Approach
            // A - Arrange
            AccountManager target = new AccountManager();
            int accno = 111;
            int amount = 2000;
            int expectedBalance = 3000;
            // A - Act
            Account acc = target.Deposit(accno, amount);
            // A - Assert
            //if(acc.Balance == expectedBalance)
            Assert.AreEqual(expectedBalance, acc.Balance);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountNotExistException))]
        public void DepositTest_AccountNotExist_ThrowsExp()
        {
            AccountManager target = new AccountManager();
            int accno = 123;
            int amount = 2000;
            //int expectedBalance = 3000;
            Account acc = target.Deposit(accno, amount);
            //
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAmountException))]
        public void DepositTest_MinimumAmount_ThrowsExp()
        {
            AccountManager target = new AccountManager();
            int accno = 111;
            int amount = 500;
            //int expectedBalance = 3000;
            Account acc = target.Deposit(accno, amount);
        }
    }
}
namespace SimpleBank.Business
{
    public class AccountManager
    {
        private List<Account> accounts = new List<Account>();

        private ITansactionLogger logger = null;

        public AccountManager()
        {
            Account account1 = new Account { AccountNo = 111, AccountType = "SAVINGS", Balance = 1000, Pin = 1234 };
            accounts.Add(account1);
            Account account2 = new Account { AccountNo = 222, AccountType = "SAVINGS", Balance = 1000, Pin = 6754 };
            accounts.Add(account2);
            Account account3 = new Account { AccountNo = 333, AccountType = "SAVINGS", Balance = 1000, Pin = 4536 };
            accounts.Add(account3);
            Account account4 = new Account { AccountNo = 444, AccountType = "SAVINGS", Balance = 1000, Pin = 2564 };
            accounts.Add(account4);
            Account account5 = new Account { AccountNo = 555, AccountType = "SAVINGS", Balance = 1000, Pin = 2323 };
            accounts.Add(account5);
        }
        public AccountManager(ITansactionLogger logger) : this()
        {
            this.logger = logger; //DIP 
        }
        public Account Deposit(int accNo, int amount)
        {
            Account accountToDeposit = IsAccountExist(accNo);

            // minimum 1000 rs to be deposited
            if (amount < 1000)
            {
                throw new InvalidAmountException("Minimum Deposit amount is Rs.1000");
            }

            // if it success, should increase the balance
            accountToDeposit.Balance += amount;

            // save the below details into file
            //01/02/2024,Deposit,111,2000
            //TransactionLogger logger = new TransactionLogger();
            logger.Log($"{DateTime.Now},Deposit,{accNo},{amount}");

            return accountToDeposit;

        }

        private Account IsAccountExist(int accNo)
        {
            // account must exist
            Account accountToDeposit = accounts.Find(a => a.AccountNo == accNo);
            if (accountToDeposit == null)
            {
                // thorw exp
                throw new AccountNotExistException($"Account {accNo} not exist");
            }

            return accountToDeposit;
        }


        public Account GetAccount(int accountNo)
        {
            return accounts.Find(a => a.AccountNo == accountNo);
        }

        public Account Withdraw(int accNo, int amount, int pin)
        {
            // business rules
            // account must exist
            Account accountToDeposit = IsAccountExist(accNo);
            //if (accountToDeposit == null)
            //    throw new AccountNotExistException("Account not found");
            // sufficcient balance
            if (accountToDeposit.Balance < amount)
                throw new InsufficcientBalanceException("Less balance");
            // valid pin
            if (accountToDeposit.Pin != pin)
                throw new InvalidPinException("Invalid Pin");
            // update/reduce the balance
            accountToDeposit.Balance -= amount;

            // save the below details into file
            //01/02/2024,Deposit,111,2000
            //ITransactionLogger logger = new TransactionLogger();
            logger.Log($"{DateTime.Now},Withdraw,{accNo},{amount}");
            return accountToDeposit;
        }


        public void Transfer(int fromAcc, int toAcc, int amount, int fromAccPin)
        {
            // fromAcc must exist
            // toacc must exist
            // fromAccPin must match
            // sufficcient balance in fromAcc
            // minimum amount to transfer 1000
            // fromacc balance should decrease
            // toAcc balance should increase

        }



    }
}

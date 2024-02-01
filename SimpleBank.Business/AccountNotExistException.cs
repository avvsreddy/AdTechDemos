namespace SimpleBank.Business
{
    public class AccountNotExistException : ApplicationException
    {
        public AccountNotExistException(string msg = null) : base(msg)
        {

        }
    }
}

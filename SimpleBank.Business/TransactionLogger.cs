namespace SimpleBank.Business
{

    public interface ITansactionLogger
    {
        void Log(string message);
    }

    public class TransactionLogger : ITansactionLogger
    {
        public void Log(string msg)
        {
            StreamWriter w = new StreamWriter("a:\\test\\banktran.txt");
            w.WriteLine(msg);
            w.Close();
        }
    }
}

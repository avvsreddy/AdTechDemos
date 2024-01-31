using System.Collections.Concurrent;

namespace MTDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LargeData large = new LargeData();
            //large.Fill();
            //large.Fill();
            Parallel.Invoke(large.Fill, large.Fill);
            Console.WriteLine(large.Data.Count);

        }
    }

    class LargeData
    {
        //public Stack<int> Data { get; set; } = new Stack<int>();
        public ConcurrentStack<int> Data { get; set; } = new ConcurrentStack<int>();

        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Fill()
        {
            for (int i = 1; i <= 10000000; i++)
            {
                //lock (this)
                //{
                Data.Push(i);
                //}
            }
        }
    }
}

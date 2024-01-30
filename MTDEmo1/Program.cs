using System.Diagnostics;

namespace MTDEmo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Main() - {Thread.CurrentThread.ManagedThreadId}");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Running Seq....");
            M1();
            M2();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Running in Threades");
            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);
            t1.Start();

            Thread t2 = new Thread(M2);
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            Console.WriteLine("Running in Task");
            Task tt1 = new Task(M1);
            tt1.Start();
            Task tt2 = new Task(M2);
            tt2.Start();
            tt1.Wait();
            tt2.Wait();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Running in Parallel");
            Parallel.Invoke(M1, M2);
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Runnin Parallel loop");
            Parallel.Invoke(M11, M22);
            Console.WriteLine(sw.ElapsedMilliseconds);

        }

        static void M1()
        {
            //Console.WriteLine($"M1() - {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i <= 10; i++)
            {
                //Console.WriteLine($"M1() - {i}");
                Thread.Sleep(500);
            }

        }

        static void M2()
        {
            //Console.WriteLine($"M2() - {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i <= 10; i++)
            {
                //Console.WriteLine($"M2() - {i}");
                Thread.Sleep(500);
            }

        }

        static void M11()
        {
            //Console.WriteLine($"M1() - {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 1; i <= 10; i++)
            Parallel.For(1, 11, i =>
            {
                //Console.WriteLine($"M1() - {i}");
                Thread.Sleep(500);
            });

        }

        static void M22()
        {
            //Console.WriteLine($"M1() - {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 1; i <= 10; i++)
            Parallel.For(1, 11, i =>
            {
                //Console.WriteLine($"M1() - {i}");
                Thread.Sleep(500);
            });

        }
    }
}

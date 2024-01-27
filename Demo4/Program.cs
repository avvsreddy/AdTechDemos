namespace Demo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine(Sum());
            //Console.WriteLine(Sum(1));
            //Console.WriteLine(Sum(1, 2));
            //Console.WriteLine(Sum(1, 2, 3));
            //Console.WriteLine(Sum(1, 2, 3, 4));
            //int a = 10;
            //int b = 20;
            //Console.WriteLine($"Before a={a} and b={b}");
            //Swap(ref a, ref b);
            //Console.WriteLine($"After a={a} and b={b}");

            //Print("resume.doc");
            //Print("resume.doc", color: "black");
            Print(color: "red", doc: "invoice.doc");

        }


        static int Sum(int a = 0, int b = 0, int c = 0, int d = 0)
        {
            return a + b + c + d;
        }

        static void Print(string doc, int copies = 1, string color = "gray")
        {
            Console.WriteLine($"Printing {doc}, {copies} copies using {color} color");
        }

        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

    }
}

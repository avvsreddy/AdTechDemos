// import lang
using MyMathLibrary;

namespace FirstConsoleApp // UI - SRP
{
    internal class Program // UI - SRP
    {
        static void Main(string[] args) // UI SRP
        {
            // Accept two ints find the maximum and display
            // Step 1: create storage vaiables
            int fno;
            int sno;
            int max;

            // Step 2: collect data from user
            Console.Write("Enter First Number: ");
            fno = int.Parse(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            sno = int.Parse(Console.ReadLine());
            // Step 3: find the max number

            //Program p = new Program();
            MathLibrary math = new MathLibrary();
            max = math.FindMax(fno, sno);



            // Step 4: display the result
            Console.WriteLine($"The maximum of {fno} and {sno} is {max}");

        }


    }


}


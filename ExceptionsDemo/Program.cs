namespace ExceptionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exception Handling Demo");

            // accept two ints and find the sum continuesly

            while (true)
            {
                try
                {
                    Console.Write("Enter First Number: ");
                    int fno = int.Parse(Console.ReadLine());
                    Console.Write("Enter Second Nummber: ");
                    int sno = int.Parse(Console.ReadLine());
                    // find the sum
                    int sum = fno + sno;
                    // display the result
                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
                    Console.WriteLine("--------------------------------------");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter only integer number");
                }
            }


        }
    }
}

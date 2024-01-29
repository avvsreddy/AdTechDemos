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
                    Calculator calc = new Calculator();
                    int sum = calc.FindSum(fno, sno);
                    // display the result
                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
                    Console.WriteLine("--------------------------------------");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter only integer number");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Please enter small integer number only");
                }
                catch (NonPositiveNumberException ex)
                {
                    Console.WriteLine("Please enter positive integer number only");
                }

                catch (Exception ex) // catch all block
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // resource management
                }
            }


        }
        /// <summary>
        /// Calculator class used for calculating mathematical results
        /// </summary>
        class Calculator // BLL
        {
            /// <summary>
            /// Finds sum of two positive even integer numbers sum
            /// </summary>
            /// <param name="fno">positive even integer number</param>
            /// <param name="sno">positive even integer number</param>
            /// <returns>sum of positive enven ingere sum</returns>
            /// <exception cref="NonEvenNumberException"></exception>
            /// <exception cref="NonPositiveNumberException"></exception>
            public int FindSum(int fno, int sno)
            {
                // Rules: 1. find sum for only even numbers otherwise throw exp
                // 2. find sum for only +ve numbers

                /*
                 * dflkdjdk
                 * dslfkjsdfklsdfjdf
                 * sdklfjsdklf
                 * lsdfkjsdlf
                 * */

                if (fno % 2 != 0 || sno % 2 != 0)
                {
                    throw new NonEvenNumberException("Please enter even numbers only");
                }

                if (fno < 0 || sno < 0)
                {
                    throw new NonPositiveNumberException();
                }
                return fno + sno;
            }
        }

        class NonEvenNumberException : ApplicationException
        {
            public NonEvenNumberException(string msg) : base(msg)
            {
                //this.Message = msg;
            }

        }

        class NonPositiveNumberException : ApplicationException
        {

        }
    }
}

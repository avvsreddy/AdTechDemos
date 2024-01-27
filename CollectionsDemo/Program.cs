namespace CollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int data = 10; // scalar - value type

            int[] datas = new int[10]; // ref type
            datas[0] = 10;

            datas[1] = 10;
            int a = datas[0];

            int[] numbers1 = new int[10];
            int[] numbers2 = new int[3] { 1, 2, 3 };
            int[] numbers3 = new int[] { 1, 2, 3 };
            int[] numbers4 = { 1, 2, 3, 4 };

            int[] numbers = { 1, 345, 2, 78, 234, 78, 454, 4, 679, 45, 34 };
            //foreach (var item in numbers)
            //{
            //    Console.WriteLine(item);
            //}
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[100]);
            //}

            // find sum
            int sum = numbers.Sum();
            int min = numbers.Min();
            int max = numbers.Max();
            double avg = numbers.Average();

            // sort
            Array.Sort(numbers);
            Array.Reverse(numbers);
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            // 2 dim

            int[,] twod = new int[5, 3];

            // Jagged Arrays
            // step 1: create rows
            int[][] j = new int[3][];
            // next stepts : create cols for each row
            j[0] = new int[3];


        }
    }
}

namespace DynamicCollectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // need to process n number of int
            // Typed Dynamic Collection

            List<int> ints = new List<int>();
            // add number
            ints.Add(1);
            ints.Add(2);
            ints.Add(2);

            // read

            int x = ints[0];

            // read all

            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }

            Stack<int> stack = new Stack<int>();
            // add
            stack.Push(10);
            stack.Push(20);

            // reads = lifo
            int a = stack.Pop(); // reads and deletes
            a = stack.Peek(); // only reads

            Queue<int> q = new Queue<int>();
            //add
            q.Enqueue(10);
            q.Enqueue(20);

            // read fifo
            a = q.Dequeue(); //reads and removes
            // read only
            a = q.Peek(); // only reads


            Dictionary<int, string> results = new Dictionary<int, string>();
            // add
            results.Add(111, "Pass");
            results.Add(222, "Fail");

            // read with key

            var r = results[111];

            HashSet<int> set = new HashSet<int>();
            // add
            set.Add(1);
            set.Add(2);
            set.Add(2);

        }
    }
}

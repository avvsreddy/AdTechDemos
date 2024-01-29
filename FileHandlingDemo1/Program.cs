namespace FileHandlingDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read line by line
            StreamReader reader = new StreamReader("e:\\test\\people.txt");
            string line = string.Empty;

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                Console.WriteLine(line);
            }

            reader.Close();
        }

        private static void ReadAll()
        {
            // read data from file into mem
            StreamReader reader = new StreamReader("e:\\test\\people.txt");
            // read all 
            string allNames = reader.ReadToEnd();
            reader.Close();
            Console.WriteLine(allNames);
        }

        private static void FileWrite()
        {
            Console.WriteLine("File Handling Demo");

            // Write a person name into a file
            // input: from user into memory 
            // output: from memory into file
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter("e:\\test\\people.txt", true);
                Console.Write("Enter person name: ");
                string pname = Console.ReadLine();
                // write into file
                writer.WriteLine(pname);
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            finally
            {
                writer.Close();
            }
        }
    }
}

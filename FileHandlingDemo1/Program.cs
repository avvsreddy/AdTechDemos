namespace FileHandlingDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // get all files in a folder

            string[] files = Directory.GetFiles("e:\\test");
            // display
            foreach (string file in files)
            {
                // display size of the file
                FileInfo fileInfo = new FileInfo(file);
                Console.WriteLine($"Name {file} and its size is {fileInfo.Length}");
            }

            // get all drives in a system

            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            Console.WriteLine("Drives");
            foreach (var item in driveInfos)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine($"Total Size: {item.TotalSize} Free Size {item.TotalFreeSpace}");

            }

        }

        private static void ReadLine()
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

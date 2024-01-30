using System.Diagnostics;

namespace DelegatesDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessManager pMgr = new ProcessManager();
            //client developer 1
            //pMgr.ShowProcessList();
            // client 2
            //FilterDelegate filter = new FilterDelegate(FilterByName);
            //pMgr.ShowProcessList(filter);
            // client 3
            pMgr.ShowProcessList(FilterByMemSize);
        }
        // client 2
        public static bool FilterByName(Process p)
        {
            return p.ProcessName.StartsWith("S");
        }



        // client 3
        public static bool FilterByMemSize(Process p)
        {
            if (p.WorkingSet64 >= 100 * 1024 * 1024)
                return true;
            else return false;
        }

    }


    //backend developer

    public delegate bool FilterDelegate(Process p);

    class ProcessManager //OCP
    {
        //public void ShowProcessList()
        //{
        //    foreach (var p in Process.GetProcesses())
        //    {
        //        Console.WriteLine(p.ProcessName);
        //    }
        //}
        //public void ShowProcessList(string sw)
        //{
        //    foreach (var p in Process.GetProcesses())
        //    {
        //        if (p.ProcessName.StartsWith(sw))
        //            Console.WriteLine(p.ProcessName);
        //    }
        //}
        public void ShowProcessList(FilterDelegate filter) // OCP
        {
            foreach (var p in Process.GetProcesses())
            {
                if (filter(p))
                    Console.WriteLine(p.ProcessName);
            }
        }
    }
}

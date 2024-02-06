using ManageDepartments.DataAccess;

namespace ManageDepartments.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDepartmentRepository repo = new DepartmentRepository();

            Department d = new Department();
            d.DepartmentNo = 50;
            d.DepartmentName = "Management";
            d.Location = "Hyderabad";

            repo.Insert(d);
            //Console.WriteLine("Inserted");
        }
    }
}

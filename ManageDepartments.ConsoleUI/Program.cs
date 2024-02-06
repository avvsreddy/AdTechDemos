using ManageDepartments.DataAccess;

namespace ManageDepartments.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDepartmentRepository repo = new DepartmentRepository();
            var departments = repo.GetDepartments();
            Console.WriteLine("Dept No\tName\tLocation");
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentNo}\t{department.DepartmentName}\t{department.Location}");
            }

        }
    }
}

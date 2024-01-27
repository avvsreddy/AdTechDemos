namespace OODemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee;
            employee = new Employee { EmpID = 111, Name = "Rama", HRA = 15000, Salary = 50000 };
            Console.WriteLine(employee.CalculateSalary());

            employee = new Manager { EmpID = 222, Name = "Krishna", HRA = 20000, Salary = 750000, Bonus = 10000 };
            Console.WriteLine(employee.CalculateSalary());


        }
    }


    abstract class Test1
    {
        public abstract void M1();// { }
        public abstract void M2();// { }
    }

    interface Test2
    {
        void M1();
        void M2();
    }

    class Test : Employee, Test2
    {
        void Test2.M1()
        {
            throw new NotImplementedException();
        }

        void Test2.M2()
        {
            throw new NotImplementedException();
        }
    }

    public class Employee
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int HRA { get; set; }
        public int CalculateSalary()
        {
            Console.WriteLine("Calculating Employee Salary");
            return Salary + HRA;
        }
        //public abstract void Promote();

    }
    class Manager : Employee
    {

        public int Bonus { get; set; }


        //public int CalculateSalary()
        //{
        //    Console.WriteLine("Calculating Employee Salary");
        //    return Salary + HRA;
        //}
        public new int CalculateSalary() // Method Hiding
        {
            Console.WriteLine("Calculating Manager Salary");
            return Salary + HRA + Bonus;
        }

        //public override void Promote()
        //{
        //    Console.WriteLine("Manager promoted to Sr. Manager");
        //}
    }

}

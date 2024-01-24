namespace OODemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // store emplyee data and display
            // step1: create emp class
            // step2: create emp obj - instantiation
            Employee emp = new Employee();

            // step3: store the emp data into obj
            //emp.empid = 111;
            //emp.name = "Ravi";
            //emp.salary = -6000;
            emp.Salary = 6000;
            // step4: process data

            // step5: display data
            //Console.WriteLine(emp.name);
            Console.WriteLine(emp.Salary);
            //Console.WriteLine(emp.salary);

        }
    }


    class Employee
    {
        // data member - fields

        // property for empid
        //public int EmpId
        //{
        //    get { return empid; }
        //    set { empid = value; }
        //}
        //private int empid; // backing field
        //private int eid;

        //private int __backingfield2312312312;
        public int EmpId // automatic property
        {
            get;// {return __backingfield2312312312; }
            set;// {__backingfield2312312312 = value; }
        }

        //private string name;

        public string Name
        {
            get;// { return name; }
            set;// { name = value; }
        }
        private int salary;

        // property for salary
        public int Salary
        {
            get
            {
                return salary;
            }

            set
            {
                // validate
                if (value >= 50000)
                    salary = value;
                else
                    //salary = 50000;
                    throw new Exception("Minimum salary should be 50000");
            }
        }


        public int Exp
        {
            get;
            set;
        }


        public int Bonus { set; get; } = 10000;

    }
}

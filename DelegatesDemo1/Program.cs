namespace DelegatesDemo1
{

    //class MyDelegate : Delegate
    //{

    //}

    // 1: Delegate declaration
    delegate void MyDelegate(string str);
    delegate int MyDelegate2();


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates Demo");
            // call greet method directly
            // name of the method - Greet
            // signature - returns void takes string
            // type of the method - static or instance
            // class name - program
            // namespace name - delegatesdemo1

            //Greet("Hello");


            // call method indirectly using its address (use delegates)

            //Delegate d = new Delegate();
            //2: Delegate Instatiation and Initialization
            MyDelegate d = new MyDelegate(Greet);
            Program p = new Program();
            d += p.Hi; // subscription
            d -= Greet; // unsubscription
            MyDelegate2 d2 = new MyDelegate2(p.hello);
            //d += p.hello;
            int x = d2();

            //3: invocation
            //Greet("hi");
            //d.Invoke("Hello");
            d("Hello again");
        }


        static void Greet(string msg)
        {
            Console.WriteLine($"Greet: {msg}");
        }

        void Hi(string msg)
        {
            Console.WriteLine($"Hi: {msg}");
        }

        int hello()
        {
            Console.WriteLine("Hello");
            return 1;
        }

    }
}

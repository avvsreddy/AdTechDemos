using ContactManagerConsoleApp.DataAccess;

namespace ContactManagerConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! Welcome to Contacts Management");
            Console.WriteLine("-----------------------------------------------");
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("========================");
                Console.WriteLine("1. Save/Create Contact");
                Console.WriteLine("2. Display All Contacts");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit Application");
                Console.WriteLine("--------------------------");
                int choice;
                Console.WriteLine("Enter Your Choice [1 to 5]");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateContact(); break;
                    case 2: DisplayAll(); break;
                    case 3: Search(); break;
                    case 4: Delete(); break;
                    case 5: return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            // 1. store/save contact info
            // 2. display all contacts
            // 3. search contact
            // 4. delete contact
            // 5. edit contact

        }

        static IContactsRepository repo = new EFContactsRepository(); // DIP
        private static void Delete()
        {
            //throw new NotImplementedException();
            repo.Delete(111);
        }

        private static void Search()
        {
            //throw new NotImplementedException();
            int contatToSearch = 111;
            Contact c = repo.Get(contatToSearch);
            // display c data
        }

        private static void DisplayAll()
        {
            //throw new NotImplementedException();
            List<Contact> contacts = repo.GetAll();
            // run a loop and display all contacts

        }

        private static void CreateContact()
        {
            try
            {
                Contact c = new Contact();
                Console.Write("Enter Contact ID: ");
                c.ContactID = int.Parse(Console.ReadLine());
                Console.Write("Enter Contact Name: ");
                c.Name = Console.ReadLine();
                Console.Write("Enter Email ID: ");
                c.Email = Console.ReadLine();
                Console.Write("Enter Mobile: ");
                c.Mobile = Console.ReadLine();
                Console.Write("Enter the Contact Location: ");
                c.Location = Console.ReadLine();

                repo.Save(c);
                Console.WriteLine("Contact saved");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}

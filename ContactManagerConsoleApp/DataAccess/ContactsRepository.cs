namespace ContactManagerConsoleApp.DataAccess
{
    public class ContactsRepository : IContactsRepository
    {

        private readonly string fileName = "E:\\test\\contacts.txt";
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            // get all contacts and return
            throw new NotImplementedException();
        }

        public void Save(Contact contact)
        {
            StreamWriter w = null;
            try
            {
                w = new StreamWriter(fileName, true);
                string contactCSV = $"{contact.ContactID},{contact.Name},{contact.Email},{contact.Mobile},{contact.Location}\n";
                w.WriteLine(contactCSV);
            }
            finally
            {
                w.Close();
            }
        }

        public void Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}

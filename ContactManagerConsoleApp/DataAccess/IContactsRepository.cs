namespace ContactManagerConsoleApp.DataAccess
{
    public interface IContactsRepository
    {
        void Save(Contact contact);
        List<Contact> GetAll();
        Contact Get(int id);
        void Delete(int id);
        void Update(Contact contact);
    }
}

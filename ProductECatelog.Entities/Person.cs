namespace ProductECatelog.Entities
{
    abstract public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Location { get; set; }
    }
}
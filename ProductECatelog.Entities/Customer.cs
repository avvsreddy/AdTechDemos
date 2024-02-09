namespace ProductECatelog.Entities
{
    //[Table("Customers")] //TPT
    public class Customer : Person
    {
        public int Discount { get; set; }
        public string CustomerType { get; set; }
    }
}
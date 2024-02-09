namespace ProductECatelog.Entities
{
    //[Table("Suppliers")] //TPT
    public class Supplier : Person
    {
        public string GSTNo { get; set; }
        public string TradeLicenceNo { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
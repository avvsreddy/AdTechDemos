namespace ProductECatelog.Entities
{
    public class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}

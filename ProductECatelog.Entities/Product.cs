using System.ComponentModel.DataAnnotations;

namespace ProductECatelog.Entities
{
    //[Table("Items")]
    public class Product
    {
        //[Key]
        //[Column("product_id")]
        public int ProductID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        //[Column(TypeName = "money(10.2)")]
        public int Price { get; set; }

        //[NotMapped]
        //public int ProfitMargin { get; set; }
        [MaxLength(100)] public string? Brand { get; set; }

        public Catagory Catagory { get; set; }

    }
}

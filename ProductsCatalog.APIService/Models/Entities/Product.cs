using System.ComponentModel.DataAnnotations;

namespace ProductsCatalog.APIService.Models.Entities
{
    public class Product // Entity Class - Persistance Class - DTO
    {
        public int ProductID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        public int Price { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string Catagory { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Catagory
    {
        public int CatagoryID { get; set; }
        [Required(ErrorMessage = "Please Provide Name for Catagory")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }

    }
}

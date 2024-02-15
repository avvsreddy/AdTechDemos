using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [Url]
        [MaxLength(200)]
        public string ArticleURL { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public virtual Catagory Catagory { get; set; }
        public int CatagoryID { get; set; }
        //[Required]
        public string PostedBy { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsApproved { get; set; } = false;


    }
}

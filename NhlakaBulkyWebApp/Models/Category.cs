using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NhlakaBulkyWebApp.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Display Order")]
        [Range(1, 10000, ErrorMessage = "Dispaly Order needs to be between 1 & 10 000")]
        public int DisplayOrder { get; set; }
    }
}

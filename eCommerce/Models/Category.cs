using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Category
    {
        
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]

        public String Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}

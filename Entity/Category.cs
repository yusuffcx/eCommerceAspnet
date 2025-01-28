using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Category
    {

        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 60, ErrorMessage = "Display order must be 1 between 60")]
        public int DisplayOrder { get; set; }
        public virtual ICollection<Product> Products { get; } = new List<Product>();

    }
}




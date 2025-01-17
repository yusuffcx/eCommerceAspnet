using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required]
        [DisplayName("List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [DisplayName("List Price 1-50")]
        [Range(1,1000)]
        public double ListPrice2 { get; set; }

        [Required]
        [DisplayName("List Price +50")]
        [Range(1, 1000)]
        public double ListPrice50 { get; set; }

        [Required]
        [DisplayName("List Price +100")]
        [Range(1, 1000)]
        public double ListPrice100 { get; set; }




    }
}

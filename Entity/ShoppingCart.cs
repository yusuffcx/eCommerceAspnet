using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Range(1,1000,ErrorMessage ="Please enter a value between 1 and 1000")]
        public int Count { get; set; }
        public string AppUserId { get; set; }
        public ApplicationUser AppUser { get; set; }

        public double Price { get; set; }


    }
}

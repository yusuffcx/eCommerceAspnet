using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCart> Products { get; set; }
        public double TotalPrice { get; set; }
        public int? TotalCount { get; set; }
        public OrderDetail OrderDetail { get; set; }

        public string loggedUserId { get; set; }
        

    }
}

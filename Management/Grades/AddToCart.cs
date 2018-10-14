using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grades
{
    public class AddToCart
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }

    }
}

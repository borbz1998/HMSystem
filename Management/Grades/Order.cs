using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grades
{
    class Order
    {
        public int InvoiceNo { get; set; }

        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
       
        public DateTime OrderDate { get; set; }

    }
}

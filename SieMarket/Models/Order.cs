using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarket.Models
{
    internal class Order
    {
        public int id { get; set; }
        public DateTime orderDate { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();
        
        public decimal CalculateFinalPrice() //cerinta 2.2
        {
            decimal total = items.Sum(item => item.CalculateTotalPrice());
            if (total > 500)
                total = total * 0.9m; // se aplica discountul de 10% daca este cazul

            return total;
        }

    }
}

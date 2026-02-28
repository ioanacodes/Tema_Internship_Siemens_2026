using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarket.Models
{
    internal class OrderItem
    {
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal pricePerUnit { get; set; }

        public decimal CalculateTotalPrice()
        {
            return pricePerUnit * quantity; 
        }
    }
}

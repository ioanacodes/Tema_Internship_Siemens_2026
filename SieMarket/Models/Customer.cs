using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarket.Models
{
    internal class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Order> orders { get; set; } = new List<Order>();

        public decimal CalculateTotalSpent()
        {
            return orders.Sum(order => order.CalculateFinalPrice()); //calculeaza totalul comenzilor
        }
    }
}

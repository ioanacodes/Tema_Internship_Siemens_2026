using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieMarket.Models;

namespace SieMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer> //creare clienti si comenzi pentru a testa functionalitatile
            {
                new Customer
                {
                    id = 1,
                    name = "Ioana Adrian",
                    orders = new List<Order>
                    {
                        new Order
                        {
                            id = 100,
                            orderDate = new DateTime(2026, 2, 13),
                            items = new List<OrderItem>
                            {
                                new OrderItem { productName = "Computer", quantity = 2, pricePerUnit = 300.00m },
                                new OrderItem { productName = "SmartWatch", quantity = 67, pricePerUnit = 42.50m }
                            }
                        }

                    }
                },
                new Customer
                {
                    id = 2,
                    name = "Matei Stefanescu",
                    orders = new List<Order>
                    {
                        new Order
                        {
                            id = 101,
                            orderDate = new DateTime(2026, 1, 11),
                            items = new List<OrderItem>
                            {
                                new OrderItem { productName = "Mouse", quantity = 1, pricePerUnit = 11.67m },
                                new OrderItem { productName = "Laptop", quantity = 1, pricePerUnit = 450.00m },
                                new OrderItem { productName = "Microwave", quantity = 1, pricePerUnit = 70.00m }
                            }
                        }

                    }
                }

            };

            foreach (var c in customers)
            {
                Console.WriteLine("Customer: " + c.name);
                foreach (var o in c.orders)
                {
                    Console.WriteLine(" Order Details: " + o.id + " , " + o.orderDate);
                    Console.WriteLine(" Total: " + o.CalculateFinalPrice() + " EUR");
                }

                Console.WriteLine();

            }

            var bestCustomer = customers // cerinta 2.3 
                    .OrderByDescending(c => c.CalculateTotalSpent())
                    .FirstOrDefault();

            if (bestCustomer != null)
            {
                Console.WriteLine("Our favourite customer is: " + bestCustomer.name);
            }

            Console.WriteLine();

            var popularProducts = customers // cerinta 2.4
                .SelectMany(c => c.orders)
                .SelectMany(o => o.items)
                .GroupBy(pn => pn.productName)
                .Select(p => new { productName = p.Key, totalQuantity = p.Sum(q => q.quantity) });
            Console.WriteLine("Our popular products are: ");
            foreach (var p in popularProducts)
                Console.WriteLine(p.productName + " - quantity: " + p.totalQuantity);
        }
    }
}
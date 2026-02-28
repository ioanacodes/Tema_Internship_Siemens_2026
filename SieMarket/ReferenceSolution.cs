using System;
using System.Collections.Generic;
using System.Linq;

namespace SieMarket
{
    // ===== 2.1 - Classes =====

    public class OrderItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice()
        {
            return Quantity * UnitPrice;
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        // ===== 2.2 - Final price with discount =====
        public decimal FinalPrice()
        {
            decimal total = Items.Sum(item => item.TotalPrice());

            if (total > 500)
                total *= 0.9m; // 10% discount

            return total;
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public decimal TotalSpent()
        {
            return Orders.Sum(order => order.FinalPrice());
        }
    }

    // ===== Main program with sample data and methods for 2.3 & 2.4 =====

    internal class ReferenceSolution
    {
        // 2.3 - Find the customer who spent the most
        static string GetTopSpender(List<Customer> customers)
        {
            var topCustomer = customers
                .OrderByDescending(c => c.TotalSpent())
                .FirstOrDefault();

            return topCustomer?.Name ?? "No customers found.";
        }

        // 2.4 (Bonus) - Popular products with total quantity sold
        static List<(string ProductName, int TotalQuantity)> GetPopularProducts(List<Customer> customers)
        {
            return customers
                .SelectMany(c => c.Orders)
                .SelectMany(o => o.Items)
                .GroupBy(i => i.ProductName)
                .Select(g => (ProductName: g.Key, TotalQuantity: g.Sum(i => i.Quantity)))
                .OrderByDescending(p => p.TotalQuantity)
                .ToList();
        }

        static void Run()
        {
            // --- Sample data ---
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Alice",
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            Id = 101,
                            OrderDate = new DateTime(2025, 1, 15),
                            Items = new List<OrderItem>
                            {
                                new OrderItem { ProductName = "Laptop",      Quantity = 1, UnitPrice = 899.99m },
                                new OrderItem { ProductName = "Mouse",       Quantity = 2, UnitPrice = 25.00m  }
                            }
                        },
                        new Order
                        {
                            Id = 102,
                            OrderDate = new DateTime(2025, 3, 10),
                            Items = new List<OrderItem>
                            {
                                new OrderItem { ProductName = "Keyboard",    Quantity = 1, UnitPrice = 75.00m  },
                                new OrderItem { ProductName = "USB Cable",   Quantity = 3, UnitPrice = 10.00m  }
                            }
                        }
                    }
                },
                new Customer
                {
                    Id = 2,
                    Name = "Bob",
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            Id = 201,
                            OrderDate = new DateTime(2025, 2, 20),
                            Items = new List<OrderItem>
                            {
                                new OrderItem { ProductName = "Monitor",     Quantity = 2, UnitPrice = 350.00m },
                                new OrderItem { ProductName = "Mouse",       Quantity = 1, UnitPrice = 25.00m  }
                            }
                        }
                    }
                }
            };

            // --- 2.2 - Show final price per order ---
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer: {customer.Name}");
                foreach (var order in customer.Orders)
                {
                    decimal raw = order.Items.Sum(i => i.TotalPrice());
                    decimal final_ = order.FinalPrice();
                    Console.WriteLine($"  Order #{order.Id}: Subtotal = {raw:C} | Final = {final_:C}" +
                                      (raw > 500 ? " (10% discount applied)" : ""));
                }
                Console.WriteLine();
            }

            // --- 2.3 - Top spender ---
            string topSpender = GetTopSpender(customers);
            Console.WriteLine($"Top spender: {topSpender}");
            Console.WriteLine();

            // --- 2.4 - Popular products ---
            var popular = GetPopularProducts(customers);
            Console.WriteLine("Popular products:");
            foreach (var p in popular)
            {
                Console.WriteLine($"  {p.ProductName} - {p.TotalQuantity} units sold");
            }
        }
    }
}

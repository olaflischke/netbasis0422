using EfCoreReverseEngineering.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfCoreTests
{
    public class NorthwindTests
    {
        NorthwindContext context;
        [SetUp]
        public void Setup()
        {
            context = new NorthwindContext();
        }

        [Test]
        public void CountCustomers()
        {

            List<Customer> customers = context.Customers.ToList();

            foreach (Customer item in customers)
            {
                Console.WriteLine($"{item.CompanyName}");
            }

            Assert.AreEqual(92, customers.Count);
        }

        [Test]
        public void MariaHatGeheiratet()
        {
            Customer customer = context.Customers.Find("ALFKI");
            if (customer != null)
            {
                customer.ContactName = "Maria Anders";
                context.SaveChanges();
            }
        }

        [Test]
        public void GetOrdersForAflki()
        {
            Customer customer = context.Customers
                                        .Include(cu => cu.Orders) // wg. Lazy-Loading explizit angeben, was mitgeladen werden soll
                                        .Where(cu => cu.CustomerId == "ALFKI")
                                        .First();
            if (customer != null)
            {
                foreach (Order order in customer.Orders)
                {
                    Console.WriteLine($"{order.Id}");
                }
            }
        }
    }
}
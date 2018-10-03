using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    internal class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsNew { get; set; }

        public Customer(string firstName, string lastName,
            string address, bool isNew)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.IsNew = isNew;
        }

        public static List<Customer> Customers()
        {
            return new List<Customer>(new Customer[4] {
            new Customer("A.", "Zero",
                "12 North Third Street, Apartment 45",
                false),
            new Customer("B.", "One",
                "34 West Fifth Street, Apartment 67",
                false),
            new Customer("C.", "Two",
                "56 East Seventh Street, Apartment 89",
                true),
            new Customer("D.", "Three",
                "78 South Ninth Street, Apartment 10",
                true)
            });
        }
    }
}

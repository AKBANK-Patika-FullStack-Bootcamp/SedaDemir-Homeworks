using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomersWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private static List<Customer> CustomerList = new List<Customer>()
        {
            //Customer format: Customer ID, First Name, Last Name, DoB, Account ID
            new Customer(1, "Seda", "Demir", new DateTime(2020, 01, 01), 200),
            new Customer(2, "Canan", "Deniz", new DateTime(1993, 03, 01), 201),
            new Customer(3, "Veli", "Yılmaz", new DateTime(1996, 01, 10), 202),
        };

        // GET: api/customers
        [HttpGet]
        public List<Customer> GetCustomers()
        {
            List<Customer> customerList = CustomerList.OrderBy(x => x.Lname).ToList();
            return customerList;
        }

        // GET: api/customers/1
        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
           var customer= CustomerList.Where((customer) => id == customer.CustomerID).SingleOrDefault();
           return customer;
        }


        // POST: api/customers
        [HttpPost]
        public Customer AddCustomer([FromBody] Customer newCustomer)
        {
            var customerFound = CustomerList.Where(obj =>
            obj.CustomerID == newCustomer.CustomerID ||
            (obj.AccountID == newCustomer.AccountID &&
            obj.CustomerID == newCustomer.CustomerID)).SingleOrDefault();
            if(customerFound is null)
                CustomerList.Add(newCustomer);
            return newCustomer;
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public Customer Put(int id, [FromBody] Customer updatedCustomer)
        {
            var customerFound = CustomerList.SingleOrDefault(obj => obj.CustomerID == id);
            if(customerFound is not null)
            {

                customerFound.CustomerID = updatedCustomer.CustomerID != default ? customerFound.CustomerID : updatedCustomer.CustomerID;
                customerFound.AccountID = updatedCustomer.AccountID != default ? customerFound.AccountID
                    : updatedCustomer.AccountID;
                customerFound.Fname = updatedCustomer.Fname !=  default ? customerFound.Fname : updatedCustomer.Fname;
                customerFound.Lname = updatedCustomer.Lname !=  default ? customerFound.Lname : updatedCustomer.Lname;
                customerFound.DoB = updatedCustomer.DoB != default ? customerFound.DoB : updatedCustomer.DoB;
                CustomerList.Remove(customerFound);
                CustomerList.Add(updatedCustomer);
                return updatedCustomer;

            }
            return customerFound;
        }

        // DELETE api/customer/2
        [HttpDelete("{id}")]
        public Customer DeleteCustomer(int id)
        {
            var customer = CustomerList.SingleOrDefault(obj => obj.CustomerID == id);
            if (customer is not null)
                CustomerList.Remove(customer);
            return customer;
        }



    }
}


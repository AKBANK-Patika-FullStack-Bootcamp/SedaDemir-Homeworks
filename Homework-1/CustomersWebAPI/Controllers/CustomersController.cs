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
            //Sort Customers list by last name
            List<Customer> customerList = CustomerList.OrderBy(x => x.Lname).ToList();

            return customerList;
        }

        // GET by id: api/customers/1
        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
            Result _result = new();

            //Search for a customer in a List
            var customer = CustomerList.Where((customer) => id == customer.CustomerID).SingleOrDefault();

            if (customer is not null)
            {
                _result.status = 1;
                _result.message = "One customer found";

                return customer;
            }
            else
            {
                _result.status = 0;
                _result.message = "No customers found";
                return null;
            }
        }


        // POST: api/customers
        [HttpPost]
        public Result AddCustomer([FromBody] Customer newCustomer)
        {
            Result _result = new();

            //Search before adding a customer to avoid duplicates
            var customer = CustomerList.Where(obj =>
                obj.CustomerID == newCustomer.CustomerID ||
                (obj.AccountID == newCustomer.AccountID &&
                obj.CustomerID == newCustomer.CustomerID)).SingleOrDefault();

            if (customer is null)
            {
                // Add new customer
                CustomerList.Add(newCustomer);

                _result.status = 1;
                _result.message = "New customer added";

                return _result;
            }
            else
            {
                _result.status = 0;
                _result.message = "Customer already exists";

                return _result;
            }
         
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public Result UpdateCustomer(int id, [FromBody] Customer updatedCustomer){

            Result _result = new();

            //Search customer to be updated
            var customer = CustomerList.SingleOrDefault(obj => obj.CustomerID == id);

            if(customer is not null) {
             
                customer.CustomerID = updatedCustomer.CustomerID != default ? customer.CustomerID : updatedCustomer.CustomerID;
                customer.AccountID = updatedCustomer.AccountID != default ? customer.AccountID
                    : updatedCustomer.AccountID;
                customer.Fname = updatedCustomer.Fname != default ? customer.Fname : updatedCustomer.Fname;
                customer.Lname = updatedCustomer.Lname != default ? customer.Lname : updatedCustomer.Lname;
                customer.DoB = updatedCustomer.DoB != default ? customer.DoB : updatedCustomer.DoB;

                CustomerList.Remove(customer);
                CustomerList.Add(updatedCustomer);

                _result.status = 1;
                _result.message = "Customer update is successful";

                return _result;
            }
            else {
                 _result.status = 0;
                 _result.message = "Could not update customer";
                 return _result;
            }
        }

        // DELETE api/customer/2
        [HttpDelete("{id}")]
        public Result DeleteCustomer(int id)
        {
            Result _result = new();

            //Search customer to be deleted
            var customer = CustomerList.SingleOrDefault(obj => obj.CustomerID == id);

            if (customer is not null)
            {
                CustomerList.Remove(customer);

                _result.status = 1;
                _result.message = "Customer with ID: " + customer.CustomerID + " Deleted";

                return _result;
            }
            else
            {
                _result.status = 0;
                _result.message = "Could not delete customer";

                return _result;
            }
        }



    }
}


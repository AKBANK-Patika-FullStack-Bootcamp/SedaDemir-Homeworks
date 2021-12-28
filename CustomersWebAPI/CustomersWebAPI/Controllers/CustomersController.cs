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
        public object GetCustomers()
        {
            object customerList = CustomerList.OrderBy(x => x.Lname);
            return customerList;
        }

        // GET api/customers/1
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    

        
    }
}


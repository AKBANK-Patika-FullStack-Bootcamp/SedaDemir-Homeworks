using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace CustomersWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersOperationsController : ControllerBase
    {
        List<Customer> customerList = new List<Customer>();
        Result _result = new Result();
        //Create an instance of DBOperations
        DBOperations dbOperation = new DBOperations();


        [Authorize]
        // GET all customers in Customers Table
        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return dbOperation.GetCustomers();
        }

        [Authorize]
        //Get customers in smaller chunks
        [HttpGet("/CustomersOperations/customers")]
        public IActionResult GetCustomersPaging([FromQuery] Paging paging)
        {
            
            //paging.PageNumber = 0;
            //paging.PageSize = 3;

            var owners = dbOperation.GetCustomers() 
                                               
           .Skip(paging.PageNumber) // Which page ? Every page contains #"paging.pageSize" customers
           .Take(paging.PageSize) // How many customers ?
           .ToList();


            return Ok(owners);
        }

        // GET a customer by CustomerId  Customers Table
        [HttpGet("{Id}")]
        public Customer GetCustomer(int Id)
        {
            List<Customer> customerList = new List<Customer>();

            Customer? resultObject = new Customer();
            resultObject = customerList.Find(x => x.CustomerId == Id);
            return resultObject;
        }


        // POST: Insert a customer into Customers Table
        [HttpPost]
        public Result AddCustomer(Customer newCustomer)
        {
            Customer customer = dbOperation.FindCustomer(newCustomer.FirstName, newCustomer.LastName);
            //Check if new customer already exists
            bool userCheck = (customer != null) ? true : false;

            if (userCheck == false)
            {
                //Add new customer
                if (dbOperation.AddModel(newCustomer) == true)
                {
                    _result.status = 1;
                    _result.message = "Yeni eleman listeye eklendi.";
                }
                else
                {
                    _result.status = 0;
                    _result.message = "Hata, kullanıcı eklenemedi.";
                }

            }
            else
            {
                _result.status = 0;
                _result.message = "Bu eleman listede zaten var.";
            }

            return _result;

        }

        // PUT: Update a customer using its CustomerId 
        [HttpPut("{Id}")]
        public Result UpdateCustomer(int Id, Customer newValue)
        {

            Result _result = new();

            Customer? _oldValue = customerList.Find(o => o.CustomerId == Id);
            if (_oldValue != null)
            {
                customerList.Add(newValue);
                customerList.Remove(_oldValue);

                _result.status = 1;
                _result.message = "Kullanıcı bilgileri başarıyla güncellendi";
                _result.CustomerList = customerList;
            }
            else
            {
                _result.status = 0;
                _result.message = "Bu kullanıcıyı içerde bulamadık.";
            }
            return _result;
        }

        // DELETE: Delete a customer using CustomerId
        [HttpDelete("{Id}")]
        public Result DeleteCustomer(int Id)
        {
            Result _result = new();

            //Search customerId
            if (dbOperation.DeleteModel(Id))
            {
                _result.status = 1;
                _result.message = "Kullanıcı silindi";
                _result.CustomerList = customerList;
            }
            else
            {
                _result.status = 0;
                _result.message = "Kullanıcı zaten silinmişti.";
            }
            return _result;
        }



    }
}


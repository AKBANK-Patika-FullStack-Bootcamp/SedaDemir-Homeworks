using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace CustomersWebAPI.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class CustomersOperationsController : ControllerBase
    {
        List<Customer> customerList = new List<Customer>();
        Result _result = new Result();

        DBOperations dbOperation = new DBOperations();

        [Authorize]

        // GET: api/customers
        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return dbOperation.GetCustomers();
        }

        // GET by id: api/customers/1
        [HttpGet("{Id}")]
        public Customer GetCustomer(int Id)
        {
            List<Customer> customerList = new List<Customer>();

            Customer? resultObject = new Customer();
            resultObject = customerList.Find(x => x.CustomerId == Id);
            return resultObject;
        }


        // POST: api/customers
        [HttpPost]
        public Result AddCustomer(Customer newCustomer)
        {
            Customer customer = dbOperation.FindCustomer(newCustomer.FirstName, newCustomer.LastName);
            //Yeni eleman listede var m? ? 
            bool userCheck = (customer != null) ? true : false;

            if (userCheck == false)
            {
                //Listeye yeni eleman ekleniyor.
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

        // PUT: api/customers/5
        [HttpPut("{Id}")]
        public Result UpdateCustomer(int Id, Customer newValue){

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

        // DELETE api/customer/2
        [HttpDelete("{Id}")]
        public Result DeleteCustomer(int Id)
        {
            Result _result = new();

            //Search customer to be deleted
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


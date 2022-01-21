using DAL.Model;
using Entities;

namespace CustomersWebAPI.Controllers
{
    public class DBOperations
    {
        private CustomerContext _context = new CustomerContext();
        LoggerCls logger = new LoggerCls();

        #region CUSTOMER FUNCTIONS...
        public bool AddModel(Customer _customer)
        {
            try
            {
                _context.Customer.Add(_customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                logger.createLog("HATA " + exc.Message);
                return false;
            }
        }
        public bool DeleteModel(int Id)
        {
            try
            {
                _context.Customer.Remove(FindCustomer("", "", Id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                logger.createLog("HATA " + exc.Message);
                return false;
            }
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            customers = _context.Customer.OrderBy(x => x.LastName).ToList();
            //Order customers by Last Name
            

            return customers;
        }

        //public void InnerJoinExample()
        //{
        //    var customer = _context.Customer.Join(_context.APIAuthority, a => a.CustomerId,
        //          u => u.CustomerId, (customer, auth) => new CustomerDetail
        //          {
        //              FName = customer.FirstName,
        //              LName = customer.LastName,
        //              Email = auth.Email
        //          }).ToList();

        //}

        public Customer FindCustomer(string FirstName = "", string LastName = "", int CustomerId = 0)
        {
            Customer? customer = new Customer();
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
                customer = _context.Customer.FirstOrDefault(m => m.FirstName == FirstName && m.LastName == LastName);
            else if (CustomerId > 0)
            {
                customer = _context.Customer.FirstOrDefault(m => m.CustomerId == CustomerId);
            }
            return customer;
        }
        #endregion


        #region TOKEN FUNCTIONS...
        public void CreateLogin(APIAuthority loginCustomer)
        {
            _context.APIAuthority.Add(loginCustomer);
            _context.SaveChanges();
        }

        public APIAuthority GetLogin(APIAuthority loginCustomer)
        {
            APIAuthority? customer = new APIAuthority();
            if (!string.IsNullOrEmpty(loginCustomer.Email) && !string.IsNullOrEmpty(loginCustomer.Password))
            {
                customer = _context.APIAuthority.FirstOrDefault(m => m.Email == loginCustomer.Email && m.Password == loginCustomer.Password);
            }

            return customer;

        }
        #endregion



    }
}


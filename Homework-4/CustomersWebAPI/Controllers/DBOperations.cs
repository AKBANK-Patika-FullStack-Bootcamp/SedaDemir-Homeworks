using DAL.Model;
using EFLibCore;

namespace CustomersWebAPI.Controllers
{
    public class DBOperations
    {
        private CustomerContext _context = new CustomerContext();
        LoggerCls logger = new LoggerCls();
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
            customers = _context.Customer.ToList();
            customers.OrderBy(x => x.LastName).ToList(); ;

            return customers;
        }

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


     

    }
}


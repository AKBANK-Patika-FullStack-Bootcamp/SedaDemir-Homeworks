using System;
namespace CustomersWebAPI
{
    public class Customer
    {
        private int _customerID;
        private string _fname;
        private string _lname;
        public DateTime _dob;
        private int _accountID;

        public int CustomerID { get => _customerID; set => _customerID = value; }
        public string Fname { get => _fname; set => _fname = value; }
        public string Lname { get => _lname; set => _lname = value; }
        public DateTime DoB { get => _dob; set => _dob = value; }
        public int AccountID { get => _accountID; set => _accountID = value; }

        public Customer(int customerID, string fname, string lname, DateTime dob, int accountID)
        {
            _customerID = customerID;
            _fname = fname ?? throw new ArgumentNullException(nameof(fname));
            _lname = lname ?? throw new ArgumentNullException(nameof(lname));
            _dob = dob;
            _accountID = accountID;
        }
    }
}


namespace DAL.Model
{
	// A custom result class for the api
	
	public class Result
	{
		public int status { get; set; }
		public string message { get; set; }
		public List<Customer>? CustomerList { get; set; }

	}
}


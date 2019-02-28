namespace Models.Core
{
    using System;

    public partial class Employees
	{
		public int EmployeeID { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string NationalIDNumber { get; set; }
		public int NationalIDTypeID { get; set; }
		public int GenderID { get; set; }
		public string BirthDate { get; set; }
		public string Address { get; set; }
		public int PlaceID { get; set; }
		public int CountryID { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
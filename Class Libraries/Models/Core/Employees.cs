namespace Models.Core
{
	using System;
	using System.Collections.Generic;

	public partial class Employees
	{
		public Int32 EmployeeID { get; set; }
		public String Username { get; set; }
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public String NationalIDNumber { get; set; }
		public Int32 NationalIDTypeID { get; set; }
		public Int32 GenderID { get; set; }
		public String BirthDate { get; set; }
		public String Address { get; set; }
		public Int32 PlaceID { get; set; }
		public Int32 CountryID { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
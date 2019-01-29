namespace Models.Core
{
	using System;
	using System.Collections.Generic;

	public partial class vEmployeesDetails
	{
		public Int32 EmployeeID { get; set; }
		public String Username { get; set; }
		public String FirstName { get; set; }
		public String NationalIDNumber { get; set; }
		public String NationalIDTypeTitle { get; set; }
		public String GenderTitle { get; set; }
		public String BirthDate { get; set; }
		public String Address { get; set; }
		public String PlaceTitle { get; set; }
		public String CountryTitle { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
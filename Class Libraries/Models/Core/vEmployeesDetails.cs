namespace Models.Core
{
    using System;

    public partial class vEmployeesDetails
	{
		public int EmployeeID { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string NationalIDNumber { get; set; }
		public string NationalIDTypeTitle { get; set; }
		public string GenderTitle { get; set; }
		public string BirthDate { get; set; }
		public string Address { get; set; }
		public string PlaceTitle { get; set; }
		public string CountryTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
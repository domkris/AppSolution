namespace Models.Core
{
    using System;

    public partial class Countries
	{
		public int CountryID { get; set; }
		public string CountryCode { get; set; }
		public string CountryTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
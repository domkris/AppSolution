namespace Models.Core
{
	using System;
	using System.Collections.Generic;

	public partial class Countries
	{
		public Int32 CountryID { get; set; }
		public String CountryCode { get; set; }
		public String CountryTitle { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
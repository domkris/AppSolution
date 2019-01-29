namespace Models.Core
{
	using System;
	using System.Collections.Generic;

	public partial class Regions
	{
		public Int32 RegionID { get; set; }
		public String RegionTitle { get; set; }
		public Int32 CountryID { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
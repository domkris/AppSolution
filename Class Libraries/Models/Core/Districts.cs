namespace Models.Core
{
	using System;
	using System.Collections.Generic;

	public partial class Districts
	{
		public Int32 DistrictID { get; set; }
		public String DistrictTitle { get; set; }
		public Int32 RegionID { get; set; }
		public String DistrictType { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
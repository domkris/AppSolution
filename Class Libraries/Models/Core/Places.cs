namespace Models.Core
{
	using System;
	using System.Collections.Generic;

	public partial class Places
	{
		public Int32 PlaceID { get; set; }
		public String PlaceNationalCode { get; set; }
		public String PlaceTitle { get; set; }
		public Int32 DistrictID { get; set; }
		public Int32 RegionID { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
namespace Models.Core
{
    using System;

    public partial class Places
	{
		public int PlaceID { get; set; }
		public string PlaceNationalCode { get; set; }
		public string PlaceTitle { get; set; }
		public int DistrictID { get; set; }
		public int RegionID { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
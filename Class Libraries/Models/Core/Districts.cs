namespace Models.Core
{
    using System;

    public partial class Districts
	{
		public int DistrictID { get; set; }
		public string DistrictTitle { get; set; }
		public int RegionID { get; set; }
		public string DistrictType { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
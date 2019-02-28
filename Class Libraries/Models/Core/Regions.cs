namespace Models.Core
{
    using System;

    public partial class Regions
	{
		public int RegionID { get; set; }
		public string RegionTitle { get; set; }
		public int CountryID { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
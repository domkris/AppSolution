namespace Models.Core
{
    using System;

    public partial class NationalIDTypes
	{
		public int NationalIDTypeID { get; set; }
		public string NationalIDTypeTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
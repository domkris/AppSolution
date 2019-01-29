namespace Models.Core
{
	using System;
	using System.Collections.Generic;

	public partial class NationalIDTypes
	{
		public Int32 NationalIDTypeID { get; set; }
		public String NationalIDTypeTitle { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
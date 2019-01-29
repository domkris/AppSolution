namespace Models.Administration
{
	using System;
	using System.Collections.Generic;

	public partial class ApplicationUsers
	{
		public Int32 ApplicationUserID { get; set; }
		public Int32 UserID { get; set; }
		public Int32 ApplicationID { get; set; }
	}
}
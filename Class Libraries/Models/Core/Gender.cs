namespace Models.Core
{
	using System;
	using System.Collections.Generic;

	public partial class Gender
	{
		public Int32 GenderID { get; set; }
		public String GenderShort { get; set; }
		public String GenderTitle { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public String Description { get; set; }
	}
}
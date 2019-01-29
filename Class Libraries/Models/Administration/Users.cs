namespace Models.Administration
{
	using System;
	using System.Collections.Generic;

	public partial class Users
	{
		public Int32 UserID { get; set; }
		public String Username { get; set; }
		public String PasswordHash { get; set; }
		public Boolean IsActive { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public Boolean isRegistered { get; set; }
		public String UserModified { get; set; }
		public DateTime DateModified { get; set; }
	}
}
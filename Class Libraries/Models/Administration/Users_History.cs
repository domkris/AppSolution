namespace Models.Administration
{
	using System;
	using System.Collections.Generic;

	public partial class Users_History
	{
		public Int32 UserID { get; set; }
		public String Username { get; set; }
		public String PasswordHash { get; set; }
		public Boolean IsActive { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public Boolean IsRegistered { get; set; }
		public String ChangeType { get; set; }
		public String UserModified { get; set; }
		public DateTime DateModified { get; set; }
	}
}
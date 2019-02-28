namespace Models.Administration
{
    using System;

    public partial class User_History
	{
		public int UserID { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public bool IsActive { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public bool IsRegistered { get; set; }
		public string ChangeType { get; set; }
		public string UserModified { get; set; }
		public DateTime DateModified { get; set; }
	}
}
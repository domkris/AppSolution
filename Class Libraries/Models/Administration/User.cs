namespace Models.Administration
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
	{
        [Key]
		public int UserID { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public bool IsActive { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public bool IsRegistered { get; set; }
		public string UserModified { get; set; }
		public DateTime? DateModified { get; set; }
	}

    public class UserLogin
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
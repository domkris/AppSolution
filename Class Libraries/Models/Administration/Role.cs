namespace Models.Administration
{
    using System;

    public partial class Role
	{
		public int RoleID { get; set; }
		public string RoleTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string UserModified { get; set; }
		public DateTime DateModified { get; set; }
	}
}
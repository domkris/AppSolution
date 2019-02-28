namespace Models.Administration
{
    using System;

    public partial class RoleAuthorization
	{
		public int RoleAuthorizationID { get; set; }
		public int RoleID { get; set; }
		public int AuthorizationID { get; set; }
	}
}
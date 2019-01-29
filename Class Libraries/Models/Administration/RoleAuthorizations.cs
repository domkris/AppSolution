namespace Models.Administration
{
	using System;
	using System.Collections.Generic;

	public partial class RoleAuthorizations
	{
		public Int32 RoleAuthorization { get; set; }
		public Int32 RoleID { get; set; }
		public Int32 AuthorizationID { get; set; }
	}
}
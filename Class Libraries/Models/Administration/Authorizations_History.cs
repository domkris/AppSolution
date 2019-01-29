namespace Models.Administration
{
	using System;
	using System.Collections.Generic;

	public partial class Authorizations_History
	{
		public Int32 AuthorizationID { get; set; }
		public String AuthorizationTitle { get; set; }
		public String UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public String ChangeType { get; set; }
		public String UserModified { get; set; }
		public DateTime DateModified { get; set; }
	}
}
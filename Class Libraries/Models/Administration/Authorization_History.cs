namespace Models.Administration
{
    using System;

    public partial class Authorization_History
	{
		public int AuthorizationID { get; set; }
		public string AuthorizationTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string ChangeType { get; set; }
		public string UserModified { get; set; }
		public DateTime DateModified { get; set; }
	}
}
namespace Models.Administration
{
    using System;

    public partial class Application_History
	{
		public int ApplicationID { get; set; }
		public string ApplicationTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string ChangeType { get; set; }
		public string UserModified { get; set; }
		public DateTime DateModified { get; set; }
	}
}
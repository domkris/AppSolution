namespace Models.Administration
{
    using System;

    public partial class ApplicationUser
	{
		public int ApplicationUserID { get; set; }
		public int UserID { get; set; }
		public int ApplicationID { get; set; }
	}
}
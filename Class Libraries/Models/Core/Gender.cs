namespace Models.Core
{
	using System;

	public partial class Gender
	{
		public int GenderID { get; set; }
		public string GenderShort { get; set; }
		public string GenderTitle { get; set; }
		public string UserCreated { get; set; }
		public DateTime DateCreated { get; set; }
		public string Description { get; set; }
	}
}
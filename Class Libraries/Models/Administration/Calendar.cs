namespace Models.Administration
{
	using System;
	using System.Collections.Generic;

	public partial class Calendar
	{
		public DateTime Date { get; set; }
		public String Day { get; set; }
		public String TypeOfDay { get; set; }
	}
}
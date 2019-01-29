namespace Models.Logging
{
	using System;
	using System.Collections.Generic;

	public partial class Log
	{
		public Int32 LogID { get; set; }
		public String ApplicationName { get; set; }
		public String Message { get; set; }
		public String MessageType { get; set; }
		public String UserCreated { get; set; }
		public DateTime LogDateTimeStamp { get; set; }
	}
}
namespace Models.Logging
{
	using System;

	public partial class Log_History
	{
		public int LogID { get; set; }
		public string ApplicationName { get; set; }
		public string Message { get; set; }
		public string MessageType { get; set; }
		public string UserCreated { get; set; }
		public DateTime LogDateTimeStamp { get; set; }
		public DateTime DateMoved { get; set; }
	}
}
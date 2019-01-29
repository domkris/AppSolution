using MainApp.Models.Abstract;
using Microsoft.SqlServer.Management.Smo;

namespace MainApp.Models
{
    public class TableForExport : BaseExportClass
    {
        public Table Table { get; set; }
    }
}

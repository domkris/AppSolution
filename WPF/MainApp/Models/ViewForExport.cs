using MainApp.Models.Abstract;
using Microsoft.SqlServer.Management.Smo;

namespace MainApp.Models
{
    class ViewForExport : BaseExportClass
    {
        public View View { get; set; }
    }
}

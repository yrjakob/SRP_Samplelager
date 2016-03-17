using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class ExportModel : IExportModel
    {
        public ExportModel()
        {
            Von = DateTime.Today.Date;
            Bis = DateTime.Today.Date;
        }

        public string Mensch { get; set; }
        public List<string> MenschList { get; set; }
        public string Aktion { get; set; }
        public List<string> AktionList { get; set; }
        public List<IExport> ExportList { get; set; }
        public List<IExport> gesamteList { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
    }

    public class Export : IExport
    {
        public string User { get; set; }
        public string Name { get; set; }
        public string Aktion { get; set; }
        public DateTime Datum { get; set; }
    }

}

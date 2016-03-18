using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public interface IExportModel
    {
        string Mensch { get; set; }
        List<string> MenschList { get; set; }
        string Aktion { get; set; }
        List<string> AktionList { get; set; }
        List<IExport> ExportList { get; set; }
        List<IExport> gesamteList { get; set; }
        DateTime Von { get; set; }
        DateTime Bis { get; set; }
    }

    public interface IExport
    {
        string User { get; set; }
        string Name { get; set; }
        string Aktion { get; set; }
        DateTime Datum { get; set; }
    }
}

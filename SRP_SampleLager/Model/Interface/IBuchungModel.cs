using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public interface IBuchungModel
    {
        string Lagerplatz { get; set; }
        int Anzahl { get; set; }
        string Muster { get; set; }
        List<IBuchung> MusterList { get; set; }

        string Artikel { get; set; }
        string Name { get; set; }
        int Menge { get; set; }
        DateTime Eingang { get; set; }
        DateTime Ausgang { get; set; }
        string Zweck { get; set; }
        string Kunde { get; set; }
        string Kundeneigentum { get; set; }
        string Ruecksendung { get; set; }
        string Referenznummer { get; set; }
        string Ansprechpartner { get; set; }
    }

    public interface IBuchung
    {
        int Anzahl { get; set; }
        string Muster { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class BuchungModel : IBuchungModel
    {
        public BuchungModel()
        {
            Eingang = DateTime.Today.Date;
            Ausgang = DateTime.Today.Date;
        }

        public string Lagerplatz { get; set; }
        public int Anzahl { get; set; }
        public string Muster { get; set; }
        public List<IBuchung> MusterList { get; set; }
        public string Artikel { get; set; }
        public string Name { get; set; }
        public int Menge { get; set; }
        public DateTime Eingang { get; set; }
        public DateTime Ausgang { get; set; }
        public string Zweck { get; set; }
        public string Kunde { get; set; }
        public string Kundeneigentum { get; set; }
        public string Ruecksendung { get; set; }
        public string Referenznummer { get; set; }
        public string Ansprechpartner { get; set; }
    }

    public class Buchung : IBuchung
    {
        public int Anzahl { get; set; }
        public string Muster { get; set; }
    }

}

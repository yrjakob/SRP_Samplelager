using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class OverviewModel : IOverviewModel
    {
        public int id { get; set; }
        public List<IOverview> OverviewList { get; set; }
    }

    public class Overview : IOverview
    {
        public int MusterLagerId { get; set; }
        public int MusterId { get; set; }
        public int LagerId { get; set; }
        public string Name { get; set; }
        public string Lagerort { get; set; }
        public int Menge { get; set; }
        public DateTime Eingangsdatum { get; set; }
        public DateTime Ausgangsdatum { get; set; }
        public string Referenznummer { get; set; }
        public bool Kundeneigentum { get; set; }
        public bool Ruecksendung { get; set; }
        public string Kunde { get; set; }
        public string Ansprechpartner { get; set; }
    }
}

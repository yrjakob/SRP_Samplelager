using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public interface IOverviewModel
    {
        int id { get; set; }
        List<IOverview> OverviewList { get; set; }
    }

    public interface IOverview
    {
        int MusterLagerId { get; set; }
        int MusterId { get; set; }
        int LagerId { get; set; }
        string Name { get; set; }
        string Lagerort { get; set; }
        int Menge { get; set; }
        DateTime Eingangsdatum { get; set; }
        DateTime Ausgangsdatum { get; set; }
        string Referenznummer { get; set; }
        bool Kundeneigentum { get; set; }
        bool Ruecksendung { get; set; }
        string Kunde { get; set; }
        string Ansprechpartner { get; set; }
    }
}

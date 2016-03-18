using System;
using System.Collections.Generic;

namespace SRP_SampleLager
{
    public interface IBuchungModel : IBuchungMuster
    {
        bool isLager { get; set; }
        int LagerId { get; set; }
        int MusterId { get; set; }
        int MusterLagerId { get; set; }
        string Platz { get; set; }
        string Ort { get; set; }

        string Lagerplatz { get; set; }
        int Anzahl { get; set; }
        BuchungMuster SelectedMuster { get; set; }
        List<BuchungMuster> ArtikelList { get; set; }
        List<IBuchung> MusterList { get; set; }
    }

    public interface IBuchungMuster
    {
        int id { get; set; }
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

using System;
using System.Collections.Generic;

namespace SRP_SampleLager
{
    public class BuchungModel : IBuchungModel
    {
        public bool isLager { get; set; }
        public int LagerId { get; set; }
        public int MusterId { get; set; }
        public int MusterLagerId { get; set; }
        public string Platz { get; set; }
        public string Ort { get; set; }

        public string Lagerplatz { get; set; }
        public int Anzahl { get; set; }
        public BuchungMuster SelectedMuster { get; set; }
        public List<BuchungMuster> ArtikelList { get; set; }
        public List<IBuchung> MusterList { get; set; }

        public int id { get; set; }
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

    public class BuchungMuster : IBuchungMuster
    {
        public int id { get; set; }
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
        public override string ToString()
        {
            return Name;
        }
    }

    public class Buchung : IBuchung
    {
        public int Anzahl { get; set; }
        public string Muster { get; set; }
    }
}

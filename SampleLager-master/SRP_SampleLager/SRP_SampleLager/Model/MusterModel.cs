using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SRP_SampleLager
{
    public class MusterModel : IMusterModel
    {
        public ObservableCollection<Muster> MusterList { get; set; }
        public int id { get; set; }
        public string Name { get; set; }
        public string Zweck { get; set; }
        public DateTime Eingangsdatum { get; set; }
        public DateTime Ausgangsdatum { get; set; }
        public string Referenznummer { get; set; }
        public string Kunde { get; set; }
        public ObservableCollection<KundeMuster> KundeList { get; set; }
        public bool Kundeneigentum { get; set; }
        public bool Rücksendung { get; set; }
        public KundeMuster SelectedKunde { get; set; }
        public ObservableCollection<AnsprechpartnerMuster> AnsprechpartnerList { get; set; }
        public AnsprechpartnerMuster SelectedAnsprechpartner { get; set; }
        public string Ansprechpartner { get; set; }
        public int Gesamtmenge { get; set; }
    }

    public class Muster : IMuster
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Zweck { get; set; }
        public DateTime Eingangsdatum { get; set; }
        public DateTime Ausgangsdatum { get; set; }
        public string Referenznummer { get; set; }
        public string Kunde { get; set; }
        public ObservableCollection<KundeMuster> KundeList { get; set; }
        public bool Kundeneigentum { get; set; }
        public bool Rücksendung { get; set; }
        public KundeMuster SelectedKunde { get; set; }
        public ObservableCollection<AnsprechpartnerMuster> AnsprechpartnerList { get; set; }
        public AnsprechpartnerMuster SelectedAnsprechpartner { get; set; }
        public string Ansprechpartner { get; set; }
        public int Gesamtmenge { get; set; }
    }

    public class KundeMuster : IKundeMuster
    {
        public int id { get; set; }
        public string Kunde { get; set; }

        public override string ToString()
        {
            return Kunde;
        }
    }

    public class AnsprechpartnerMuster : IAnsprechpartnerMuster
    {
        public int id { get; set; }
        public string Ansprechpartner { get; set; }

        public override string ToString()
        {
            return Ansprechpartner;
        }
    }
}

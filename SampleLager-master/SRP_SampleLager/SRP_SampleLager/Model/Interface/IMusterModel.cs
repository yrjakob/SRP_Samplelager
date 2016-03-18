using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SRP_SampleLager
{
    public interface IMusterModel : IMuster
    {
        ObservableCollection<Muster> MusterList { get; set; }
    }

    public interface IMuster
    {
        int id { get; set; }
        string Name { get; set; }
        string Zweck { get; set; }
        DateTime Eingangsdatum { get; set; }
        DateTime Ausgangsdatum { get; set; }
        string Referenznummer { get; set; }
        string Kunde { get; set; }
        ObservableCollection<KundeMuster> KundeList { get; set; }
        bool Kundeneigentum { get; set; }
        bool Rücksendung { get; set; }
        KundeMuster SelectedKunde { get; set; }
        ObservableCollection<AnsprechpartnerMuster> AnsprechpartnerList { get; set; }
        AnsprechpartnerMuster SelectedAnsprechpartner { get; set; }
        string Ansprechpartner { get; set; }
        int Gesamtmenge { get; set; }
    }

    public interface IKundeMuster
    {
        int id { get; set; }
        string Kunde { get; set; }
    }

    public interface IAnsprechpartnerMuster
    {
        int id { get; set; }
        string Ansprechpartner { get; set; }
    }
}

using System;
using System.Collections.ObjectModel;

namespace SRP_SampleLager
{
    public interface IEditLagerModel : IEditLager
    {
        ObservableCollection<IEditLager> LagerList { get; set; }
    }

    public interface IEditLager
    {
        int id { get; set; }
        string Gebaeude { get; set; }
        string Nummer { get; set; }
        string Kommentar { get; set; }
    }
}

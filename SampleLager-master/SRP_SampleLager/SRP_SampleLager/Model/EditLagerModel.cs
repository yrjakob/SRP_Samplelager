using System;
using System.Collections.ObjectModel;

namespace SRP_SampleLager
{
    public class EditLagerModel : IEditLagerModel
    {
        public ObservableCollection<IEditLager> LagerList { get; set; }
        public int id { get; set; }
        public string Gebaeude { get; set; }
        public string Nummer { get; set; }
        public string Kommentar { get; set; }
    }

    public class EditLager : IEditLager
    {
        public int id { get; set; }
        public string Gebaeude { get; set; }
        public string Nummer { get; set; }
        public string Kommentar { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SRP_SampleLager
{
    public class LagerModel : ILagerModel
    {
        public Lagerraum SelectedLager { get; set; }
        public ObservableCollection<Lagerraum> LagerList { get; set; }
        public bool isEditable { get; set; }
        public string Gebaeude { get; set; }
        public string Nummer { get; set; }
        public string Kommentar { get; set; }
        public ObservableCollection<Lagerplatz> PlatzList { get; set; }
        public ObservableCollection<TabItem> RegalList { get; set; }
        public Page Frame { get; set; }
        public Visibility FrameVisibility { get; set; }
        public Visibility TabVisibility { get; set; }
    }

    public class Lagerraum : ILagerraum
    {
        public int id { get; set; }
        public string Gebaeude { get; set; }
        public string Nummer { get; set; }
        public string Kommentar { get; set; }

        public override string ToString()
        {
            return Gebaeude + " " + Nummer;
        }
    }

    public class Lagerplatz : ILagerplatz
    {
        public int id { get; set; }
        public string Ort { get; set; }
        public string Platz { get; set; }
        public int Raum { get; set; }

        public override string ToString()
        {
            return "Platz: " + Platz;
        }
    }
}

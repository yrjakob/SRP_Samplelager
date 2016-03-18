using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SRP_SampleLager
{
    public interface ILagerModel
    {
        Lagerraum SelectedLager { get; set; }
        ObservableCollection<Lagerraum> LagerList { get; set; }
        bool isEditable { get; set; }
        string Gebaeude { get; set; }
        string Nummer { get; set; }
        string Kommentar { get; set; }
        ObservableCollection<Lagerplatz> PlatzList { get; set; }
        ObservableCollection<TabItem> RegalList { get; set; }
        Page Frame { get; set; }
        Visibility FrameVisibility { get; set; }
        Visibility TabVisibility { get; set; }
    }

    public interface ILagerraum
    {
        int id { get; set; }
        string Gebaeude { get; set; }
        string Nummer { get; set; }
        string Kommentar { get; set; }
    }

    public interface ILagerplatz
    {
        int id { get; set; }
        string Ort { get; set; }
        string Platz { get; set; }
        int Raum { get; set; }
    }
}

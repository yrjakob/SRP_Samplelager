using System;
using System.Collections.ObjectModel;

namespace SRP_SampleLager
{
    public interface IPlatzModel : IPlatz
    {
        string Headline { get; set; }
        string Ort { get; set; }
        int RaumId { get; set; }
        ObservableCollection<IPlatz> PlatzList { get; set; }
    }

    public interface IPlatz
    {
        int id { get; set; }
        string PlatzName { get; set; }
    }
}

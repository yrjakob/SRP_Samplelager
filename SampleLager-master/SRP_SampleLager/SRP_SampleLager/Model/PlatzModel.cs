using System;
using System.Collections.ObjectModel;

namespace SRP_SampleLager
{
    public class PlatzModel : IPlatzModel
    {
        public string Headline { get; set; }
        public string Ort { get; set; }
        public int RaumId { get; set; }
        public ObservableCollection<IPlatz> PlatzList { get; set; }
        public int id { get; set; }
        public string PlatzName { get; set; }
    }

    public class Platz : IPlatz
    {
        public int id { get; set; }
        public string PlatzName { get; set; }
    }
}

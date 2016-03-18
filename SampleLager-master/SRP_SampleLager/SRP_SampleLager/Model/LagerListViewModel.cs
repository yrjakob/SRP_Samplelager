using System;
using System.Collections.Generic;

namespace SRP_SampleLager
{
    public class LagerListViewModel : ILagerListViewModel
    {
        public LagerListViewModel()
        {
            List = new List<string>();
        }

        public int RaumId { get; set; }
        public int index { get; set; }
        public string Ort { get; set; }
        public List<string> List { get; set; } 
    }
}

using System;
using System.Collections.Generic;

namespace SRP_SampleLager
{
    public interface ILagerListViewModel
    {
        int RaumId { get; set; }
        int index { get; set; }
        string Ort { get; set; }
        List<string> List { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public interface IOverviewModel
    {
        List<IOverview> OverviewList { get; set; }
    }

    public interface IOverview
    {
        int MusterId { get; set; }
        string Name { get; set; }
        string Lagerort { get; set; }
        int Menge { get; set; }
        DateTime Eingangsdatum { get; set; }
        DateTime Ausgangsdatum { get; set; }
        string Referenznummer { get; set; }
        bool Kundeneigentum { get; set; }
        bool Ruecksendung { get; set; }
        string Kunde { get; set; }
        string Ansprechpartner { get; set; }
    }
}

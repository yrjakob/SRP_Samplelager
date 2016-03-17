using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public interface IKundeModel : IKunde
    {
        IList<IKunde> KundeListe { get; set; }
        IList<IAnrede> AnredeListe { get; set; }

    }

    public interface IKunde
    {
        string Firma { get; set; }
        string Straße { get; set; }
        string Hausnummer { get; set; }
        string Postleitzahl { get; set; }
        string Ort { get; set; }
        string Land { get; set; }
        string Titel { get; set; }
        string Ansprechpartner { get; set; }
        string Telefon { get; set; }
        string Email { get; set; }
        string Kommentar { get; set; }
    }

    public interface IAnrede
    {
        int ID { get; set; }
        string Titel { get; set; }
    }
}

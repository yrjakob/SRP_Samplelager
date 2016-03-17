using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class KundeModel : IKundeModel
    {
        public IList<IKunde> KundeListe { get; set; }
        public IList<IAnrede> AnredeListe { get; set; }
        public string Firma { get; set; }
        public string Straße { get; set; }
        public string Hausnummer { get; set; }
        public string Postleitzahl { get; set; }
        public string Ort { get; set; }
        public string Land { get; set; }
        public string Titel { get; set; }
        public string Ansprechpartner { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Kommentar { get; set; }
    }

    public class Kunde : IKunde
    {
        public string Firma { get; set; }
        public string Straße { get; set; }
        public string Hausnummer { get; set; }
        public string Postleitzahl { get; set; }
        public string Ort { get; set; }
        public string Land { get; set; }
        public string Titel { get; set; }
        public string Ansprechpartner { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Kommentar { get; set; }
    } 

    public class Anrede : IAnrede
    {
        public int ID { get; set; }
        public string Titel { get; set; }
    }
}     

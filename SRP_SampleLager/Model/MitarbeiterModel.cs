using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class MitarbeiterModel : IMitarbeiterModel
    {
        public IList<IMitarbeiter> MitarbeiterListe { get; set; }
        public IList<string> StellvertreterListe { get; set; }
        public IList<IAnrede> AnredeListe { get; set; }
        public int id { get; set; }
        public string Titel { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Kurzform { get; set; }
        public string PersonalNr { get; set; }
        public string TelefonIntern { get; set; }
        public string TelefonPrivat { get; set; }
        public string Email { get; set; }
        public string Stellvertretung { get; set; }
        public int StellvertreterID { get; set; }
    }

    public class Mitarbeiter : IMitarbeiter
    {
        public int id { get; set; }
        public string Titel { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Kurzform { get; set; }
        public string PersonalNr { get; set; }
        public string TelefonIntern { get; set; }
        public string TelefonPrivat { get; set; }
        public string Email { get; set; }
        public string Stellvertretung { get; set; }
        public int StellvertreterID { get; set; }
    }
}

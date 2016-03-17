using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public interface IMitarbeiterModel : IMitarbeiter
    {
        IList<IMitarbeiter> MitarbeiterListe { get; set; }
        IList<string> StellvertreterListe { get; set; }
        IList<IAnrede> AnredeListe { get; set; }
    }

    public interface IMitarbeiter
    {
        int id { get; set; }
        string Titel { get; set; }
        string Nachname { get; set; }
        string Vorname { get; set; }
        string Kurzform { get; set; }
        string PersonalNr { get; set; }
        string TelefonIntern { get; set; }
        string TelefonPrivat { get; set; }
        string Email { get; set; }
        string Stellvertretung { get; set; }
        int StellvertreterID { get; set; }
    }
}

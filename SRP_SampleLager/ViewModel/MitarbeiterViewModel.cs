using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class MitarbeiterViewModel : ViewModelBase, IMitarbeiterModel
    {
        private readonly IMitarbeiterModel _Model;
        private readonly IRepository<IMitarbeiterModel> _Repository;
        private bool isSelected = false;

        public MitarbeiterViewModel(IMitarbeiterModel Model, IRepository<IMitarbeiterModel> Repository)
        {
            if (Model == null)
                throw new ArgumentNullException("Model");
            if (Repository == null)
                throw new ArgumentNullException("Repository");

            _Model = Model;
            _Repository = Repository;
        }

        // Properties
        #region Properties
        public IList<IMitarbeiter> MitarbeiterListe
        {
            get { return _Model.MitarbeiterListe; }
            set
            {
                if (MitarbeiterListe != value)
                {
                    _Model.MitarbeiterListe = value;
                    OnPropertyChanged("MitarbeiterListe");
                }
            }
        }

        public IList<IAnrede> AnredeListe
        {
            get { return _Model.AnredeListe; }
            set
            {
                if (AnredeListe != value)
                {
                    _Model.AnredeListe = value;
                    OnPropertyChanged("AnredeListe");
                }
            }
        }

        public IList<string> StellvertreterListe
        {
            get { return _Model.StellvertreterListe; }
            set
            {
                if (StellvertreterListe != value)
                {
                    _Model.StellvertreterListe = value;
                    OnPropertyChanged("StellvertreterListe");
                }
            }
        }
        public int id
        {
            get { return _Model.id; }
            set
            {
                if (id != value)
                {
                    _Model.id = value;
                    OnPropertyChanged("id");
                }
            }
        }
        public int StellvertreterID
        {
            get { return _Model.StellvertreterID; }
            set
            {
                if (StellvertreterID != value)
                {
                    _Model.StellvertreterID = value;
                    OnPropertyChanged("StellvertreterID");
                }
            }
        }

        public string Nachname
        {
            get { return _Model.Nachname; }
            set
            {
                if (Nachname != value)
                {
                    _Model.Nachname = value;
                    OnPropertyChanged("Nachname");
                }
            }
        }

        public string Vorname
        {
            get { return _Model.Vorname; }
            set
            {
                if (Vorname != value)
                {
                    _Model.Vorname = value;
                    OnPropertyChanged("Vorname");
                }
            }
        }

        public string Kurzform
        {
            get { return _Model.Kurzform; }
            set
            {
                if (Kurzform != value)
                {
                    _Model.Kurzform = value;
                    OnPropertyChanged("Kurzform");
                }
            }
        }

        public string PersonalNr
        {
            get { return _Model.PersonalNr; }
            set
            {
                if (PersonalNr != value)
                {
                    _Model.PersonalNr = value;
                    OnPropertyChanged("PersonalNr");
                }
            }
        }

        public string TelefonIntern
        {
            get { return _Model.TelefonIntern; }
            set
            {
                if (TelefonIntern != value)
                {
                    _Model.TelefonIntern = value;
                    OnPropertyChanged("TelefonIntern");
                }
            }
        }

        public string TelefonPrivat
        {
            get { return _Model.TelefonPrivat; }
            set
            {
                if (TelefonPrivat != value)
                {
                    _Model.TelefonPrivat = value;
                    OnPropertyChanged("TelefonPrivat");
                }
            }
        }

        public string Email
        {
            get { return _Model.Email; }
            set
            {
                if (Email != value)
                {
                    _Model.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Stellvertretung
        {
            get { return _Model.Stellvertretung; }
            set
            {
                if (Stellvertretung != value)
                {
                    _Model.Stellvertretung = value;
                    OnPropertyChanged("Stellvertretung");
                }
            }
        }

        public string Titel
        {
            get { return _Model.Titel; }
            set
            {
                if (Titel != value)
                {
                    _Model.Titel = value;
                    OnPropertyChanged("Titel");
                }
            }
        }

        #endregion


        // Methoden
        #region Methoden
        private void load()
        {
            MitarbeiterListe = new List<IMitarbeiter>();
            AnredeListe = new List<IAnrede>();
            _Repository.Select(this);

            foreach (var item in this.MitarbeiterListe)
            {
                if (item.StellvertreterID == -1)
                    continue;

                var list = this.MitarbeiterListe.Where(x => x.id == item.StellvertreterID).ToList();
                item.Stellvertretung = list[0].Vorname + " " + list[0].Nachname;
            }
        }

        private void save()
        {
            _Repository.Insert(this);
            var List = MitarbeiterListe;
            List.Add(new Mitarbeiter
            {
                Nachname = Nachname,
                Vorname = Vorname,
                Kurzform = Kurzform,
                PersonalNr = PersonalNr,
                TelefonIntern = TelefonIntern,
                TelefonPrivat = TelefonPrivat,
                Email = Email,
                Stellvertretung = Stellvertretung
            });

            MitarbeiterListe = new List<IMitarbeiter>();
            MitarbeiterListe = List;

            clear();
        }
        private void edit(object param)
        {
            var Index = Convert.ToInt32(param);
            if (Index == -1)
                return;

            _Repository.Update(this);
            var List = MitarbeiterListe;
            List[Index].Nachname = Nachname;
            List[Index].Vorname = Vorname;
            List[Index].Kurzform = Kurzform;
            List[Index].PersonalNr = PersonalNr;
            List[Index].TelefonIntern = TelefonIntern;
            List[Index].TelefonPrivat = TelefonPrivat;
            List[Index].Email = Email;
            List[Index].Stellvertretung = Stellvertretung;

            MitarbeiterListe = new List<IMitarbeiter>();
            MitarbeiterListe = List;

            CanExecute = !CanExecute;
            isSelected = !isSelected;

            clear();
        }
        private void delete(object param)
        {
            var Index = Convert.ToInt32(param);
            if (Index == -1)
                return;

            _Repository.Delete(this);
            var List = MitarbeiterListe;
            List.RemoveAt(Index);

            MitarbeiterListe = new List<IMitarbeiter>();
            MitarbeiterListe = List;

            CanExecute = !CanExecute;
            isSelected = !isSelected;

            clear();
        }
        private void selected(object param)
        {
            var Index = Convert.ToInt32(param);
            if (Index == -1)
                return;

            if (!isSelected)
            {
                CanExecute = !CanExecute;
                isSelected = !isSelected;
            }

            Nachname = MitarbeiterListe[Index].Nachname;
            Vorname = MitarbeiterListe[Index].Vorname;
            Kurzform = MitarbeiterListe[Index].Kurzform;
            PersonalNr = MitarbeiterListe[Index].PersonalNr;
            TelefonIntern = MitarbeiterListe[Index].TelefonIntern;
            TelefonPrivat = MitarbeiterListe[Index].TelefonPrivat;
            Email = MitarbeiterListe[Index].Email;
            Stellvertretung = MitarbeiterListe[Index].Stellvertretung;
        }
        private void clear()
        {
            Nachname = "";
             Vorname = "";
             Kurzform = "";
             PersonalNr = "";
             TelefonIntern = "";
             TelefonPrivat = "";
             Email = "";
             Stellvertretung = "";

        }

        #endregion

        // Commands
        #region Commands
        private ICommand _LoadCommand;
        public ICommand LoadCommand
        {
            get { return _LoadCommand ?? (_LoadCommand = new RelayCommand(x => load())); }
        }
        private ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get { return _SaveCommand ?? (_SaveCommand = new RelayCommand(x => save(), param => !CanExecute)); }
        }
        private ICommand _EditCommand;
        public ICommand EditCommand
        {
            get { return _EditCommand ?? (_EditCommand = new RelayCommand(x => edit(x), param => CanExecute)); }
        }
        private ICommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get { return _DeleteCommand ?? (_DeleteCommand = new RelayCommand(x => delete(x), param => CanExecute)); }
        }
        private ICommand _SelectedCommand;
        public ICommand SelectedCommand
        {
            get { return _SelectedCommand ?? (_SelectedCommand = new RelayCommand(x => selected(x))); }
        }

        private bool CanExecute = false;
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class KundeViewModel : ViewModelBase, IKundeModel
    {
        private readonly IKundeModel _Model;
        private readonly IRepository<IKundeModel> _Repository;
        private bool isSelected = false;

        public KundeViewModel(IKundeModel Model, IRepository<IKundeModel> Repository)
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
        public IList<IKunde> KundeListe
        {
            get { return _Model.KundeListe; }
            set
            {
                if (KundeListe != value)
                {
                    _Model.KundeListe = value;
                    OnPropertyChanged("KundeListe");
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

        public string Firma
        {
            get { return _Model.Firma; }
            set
            {
                if (Firma != value)
                {
                    _Model.Firma = value;
                    OnPropertyChanged("Firma");
                }
            }
        }

        public string Straße
        {
            get { return _Model.Straße; }
            set
            {
                if (Straße != value)
                {
                    _Model.Straße = value;
                    OnPropertyChanged("Straße");
                }
            }
        }

        public string Hausnummer
        {
            get { return _Model.Hausnummer; }
            set
            {
                if (Hausnummer != value)
                {
                    _Model.Hausnummer = value;
                    OnPropertyChanged("Hausnummer");
                }
            }
        }

        public string Postleitzahl
        {
            get { return _Model.Postleitzahl; }
            set
            {
                if (Postleitzahl != value)
                {
                    _Model.Postleitzahl = value;
                    OnPropertyChanged("Postleitzahl");
                }
            }
        }

        public string Ort
        {
            get { return _Model.Ort; }
            set
            {
                if (Ort != value)
                {
                    _Model.Ort = value;
                    OnPropertyChanged("Ort");
                }
            }
        }

        public string Land
        {
            get { return _Model.Land; }
            set
            {
                if (Land != value)
                {
                    _Model.Land = value;
                    OnPropertyChanged("Land");
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

        public string Ansprechpartner
        {
            get { return _Model.Ansprechpartner; }
            set
            {
                if (Ansprechpartner != value)
                {
                    _Model.Ansprechpartner = value;
                    OnPropertyChanged("Ansprechpartner");
                }
            }
        }
        public string Telefon
        {
            get { return _Model.Telefon; }
            set
            {
                if (Telefon != value)
                {
                    _Model.Telefon = value;
                    OnPropertyChanged("Telefon");
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
        public string Kommentar
        {
            get { return _Model.Kommentar; }
            set
            {
                if (Kommentar != value)
                {
                    _Model.Kommentar = value;
                    OnPropertyChanged("Kommentar");
                }
            }
        }

        #endregion


        // Methoden
        #region Methoden
        private void load()
        {
            KundeListe = new List<IKunde>();
            AnredeListe = new List<IAnrede>();
            _Repository.Select(this);
            
        }

        private void save()
        {
            _Repository.Insert(this);
            var List = KundeListe;
            List.Add(new Kunde
            {
                Firma = Firma,
                Straße = Straße,
                Hausnummer = Hausnummer,
                Postleitzahl = Postleitzahl,
                Ort = Ort,
                Land = Land,
                Titel = Titel,
                Ansprechpartner = Ansprechpartner,
                Telefon = Telefon,
                Email = Email,
                Kommentar = Kommentar
            });

            KundeListe = new List<IKunde>();
            KundeListe = List;

            clear();
        }
        private void edit(object param)
        {
            var Index = Convert.ToInt32(param);
            if (Index == -1)
                return;

            _Repository.Update(this);
            var List = KundeListe;
            List[Index].Firma = Firma;
            List[Index].Straße = Straße;
            List[Index].Hausnummer = Hausnummer;
            List[Index].Postleitzahl = Postleitzahl;
            List[Index].Ort = Ort;
            List[Index].Land = Land;
            List[Index].Titel = Titel;
            List[Index].Ansprechpartner = Ansprechpartner;
            List[Index].Telefon = Telefon;
            List[Index].Email = Email;
            List[Index].Kommentar = Kommentar;

            KundeListe = new List<IKunde>();
            KundeListe = List;

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
            var List = KundeListe;
            List.RemoveAt(Index);

            KundeListe = new List<IKunde>();
            KundeListe = List;

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
            
            Firma = KundeListe[Index].Firma;
            Straße = KundeListe[Index].Straße;
            Hausnummer = KundeListe[Index].Hausnummer;
            Postleitzahl = KundeListe[Index].Postleitzahl;
            Ort = KundeListe[Index].Ort;
            Land = KundeListe[Index].Land;
            Titel = KundeListe[Index].Titel;
            Ansprechpartner = KundeListe[Index].Ansprechpartner;
            Telefon = KundeListe[Index].Telefon;
            Email = KundeListe[Index].Email;
            Kommentar = KundeListe[Index].Kommentar;
        }
        private void clear()
        {
            Firma = "";
            Straße = "";
            Hausnummer = "";
            Postleitzahl = "";
            Ort = "";
            Land = "";
            Titel = "";
            Ansprechpartner = "";
            Telefon = "";
            Email = "";
            Kommentar = "";
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

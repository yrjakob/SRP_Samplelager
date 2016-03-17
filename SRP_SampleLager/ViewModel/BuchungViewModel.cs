using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class BuchungViewModel : ViewModelBase, IBuchungModel
    {
        private readonly IBuchungModel _model;
        private readonly IRepository<IBuchungModel> _repository;

        public BuchungViewModel(IBuchungModel model, IRepository<IBuchungModel> repository)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (repository == null) throw new ArgumentNullException("repository");

            _model = model;
            _repository = repository;
        }

        #region Commands
        private ICommand _LoadedCommand;
        public ICommand LoadedCommand
        {
            get { return _LoadedCommand ?? (_LoadedCommand = new RelayCommand(x => load())); }
        }

        private ICommand _NeuesMusterCommand;
        public ICommand NeuesMusterCommand
        {
            get { return _NeuesMusterCommand ?? (_NeuesMusterCommand = new RelayCommand(x => musterHinzufügen())); }
        }

        private ICommand _PlusCommand;
        public ICommand PlusCommand
        {
            get { return _PlusCommand ?? (_PlusCommand = new RelayCommand(x => plus(x))); }
        }

        private ICommand _MinusCommand;
        public ICommand MinusCommand
        {
            get { return _MinusCommand ?? (_MinusCommand = new RelayCommand(x => minus(x))); }
        }

        private ICommand _LeerenCommand;
        public ICommand LeerenCommand
        {
            get { return _LeerenCommand ?? (_LeerenCommand = new RelayCommand(x => leeren())); }
        }
        #endregion

        #region Methods
        private void load()
        {
            MusterList = new List<IBuchung>();
            _repository.Select(this);

            Lagerplatz = "Lagerplatz";
            Artikel = "Artikel";

            for (int i = 0; i < 10; i++)
                MusterList.Add(new Buchung { Muster = "Hallo", Anzahl = i });
        }
        private void musterHinzufügen()
        {
            index = -1;
            _repository.Insert(this);

            var list = MusterList;
        }
        private void plus(object param)
        {
            int i = MusterList.IndexOf((Buchung)param);
            MusterList[i].Anzahl++;
        }
        private void minus(object param) 
        {
            int i = MusterList.IndexOf((Buchung)param);
            MusterList[i].Anzahl--;
        }
        private void leeren() { }
	    #endregion

        #region Properties
        public int index = -1;
        public string Lagerplatz
        {
            get { return _model.Lagerplatz; }
            set
            {
                if (Lagerplatz != value)
                {
                    _model.Lagerplatz = value;
                    OnPropertyChanged("Lagerplatz");
                }
            }
        }
        public int Anzahl
        {
            get { return _model.Anzahl; }
            set
            {
                if (Anzahl != value)
                {
                    _model.Anzahl = value;
                    OnPropertyChanged("Anzahl");
                }
            }
        }
        public string Muster
        {
            get { return _model.Muster; }
            set
            {
                if (Muster != value)
                {
                    _model.Muster = value;
                    OnPropertyChanged("Muster");
                }
            }
        }
        public List<IBuchung> MusterList
        {
            get { return _model.MusterList; }
            set
            {
                if (MusterList != value)
                {
                    _model.MusterList = value;
                    OnPropertyChanged("MusterList");
                }
            }
        }
        public string Artikel
        {
            get { return _model.Artikel; }
            set
            {
                if (Artikel != value)
                {
                    _model.Artikel = value;
                    OnPropertyChanged("Artikel");
                }
            }
        }
        public string Name
        {
            get { return _model.Name; }
            set
            {
                if (Name != value)
                {
                    _model.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public int Menge
        {
            get { return _model.Menge; }
            set
            {
                if (Menge != value)
                {
                    _model.Menge = value;
                    OnPropertyChanged("Menge");
                }
            }
        }
        public DateTime Eingang
        {
            get { return _model.Eingang; }
            set
            {
                if (Eingang != value)
                {
                    _model.Eingang = value;
                    OnPropertyChanged("Eingang");
                }
            }
        }
        public DateTime Ausgang
        {
            get { return _model.Ausgang; }
            set
            {
                if (Ausgang != value)
                {
                    _model.Ausgang = value;
                    OnPropertyChanged("Ausgang");
                }
            }
        }
        public string Zweck
        {
            get { return _model.Zweck; }
            set
            {
                if (Zweck != value)
                {
                    _model.Zweck = value;
                    OnPropertyChanged("Zweck");
                }
            }
        }
        public string Kunde
        {
            get { return _model.Kunde; }
            set
            {
                if (Kunde != value)
                {
                    _model.Kunde = value;
                    OnPropertyChanged("Kunde");
                }
            }
        }
        public string Kundeneigentum
        {
            get { return _model.Kundeneigentum; }
            set
            {
                if (Kundeneigentum != value)
                {
                    _model.Kundeneigentum = value;
                    OnPropertyChanged("Kundeneigentum");
                }
            }
        }
        public string Ruecksendung
        {
            get { return _model.Ruecksendung; }
            set
            {
                if (Ruecksendung != value)
                {
                    _model.Ruecksendung = value;
                    OnPropertyChanged("Ruecksendung");
                }
            }
        }
        public string Referenznummer
        {
            get { return _model.Referenznummer; }
            set
            {
                if (Referenznummer != value)
                {
                    _model.Referenznummer = value;
                    OnPropertyChanged("Referenznummer");
                }
            }
        }
        public string Ansprechpartner
        {
            get { return _model.Ansprechpartner; }
            set
            {
                if (Ansprechpartner != value)
                {
                    _model.Ansprechpartner = value;
                    OnPropertyChanged("Ansprechpartner");
                }
            }
        } 
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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

            this._model = model;
            this._repository = repository;
        }

        #region Commands
        private ICommand _LoadedCommand;
        public ICommand LoadedCommand
        {
            get { return this._LoadedCommand ?? (this._LoadedCommand = new RelayCommand(x => this.load())); }
        }
        private ICommand _NewMusterCommand;
        public ICommand NewMusterCommand
        {
            get { return this._NewMusterCommand ?? (this._NewMusterCommand = new RelayCommand(x => this.addMuster())); }
        }
        private ICommand _SelectCommand;
        public ICommand SelectCommand
        {
            get { return this._SelectCommand ?? (this._SelectCommand = new RelayCommand(x => this.select(x))); }
        }
        private ICommand _ClearCommand;
        public ICommand ClearCommand
        {
            get { return this._ClearCommand ?? (this._ClearCommand = new RelayCommand(x => this.clear())); }
        }
        #endregion

        #region Methods
        private void load()
        {
            this.Eingang = DateTime.Today;
            this.Ausgang = DateTime.Today;
            this.MusterList = new List<IBuchung>();
            this.ArtikelList = new List<BuchungMuster>();
            this._repository.Select(this);

            if (this.isLager)
                this.Lagerplatz = this.Ort + " Platz: " + this.Platz;
            else this.SelectedMuster = this.ArtikelList.First(x => x.id == this.MusterId);
        }
        private void addMuster()
        {
            this.index = -1;
            this._repository.Update(this);

            var list = this.MusterList;

            if (!this.isLager)
            {
                int ind = list.IndexOf(list.First(x => x.Muster == Name));
                list[ind].Anzahl = Anzahl;
            }

            MusterList = new List<IBuchung>();
            MusterList = list;
        }
        private void select(object param)
        {
            if (param != null)
            {
                this.index = int.Parse(param.ToString());
                this.SelectedMuster = this.ArtikelList.Where(x => x.Name == this.MusterList[this.index].Muster).ToList()[0];
                //return;
            }

            this.Zweck = this.SelectedMuster.Zweck;
            this.Referenznummer = this.SelectedMuster.Referenznummer;
            this.Kundeneigentum = this.SelectedMuster.Kundeneigentum;
            this.Ruecksendung = this.SelectedMuster.Ruecksendung;
            this.Ausgang = this.SelectedMuster.Ausgang;
            this.Eingang = this.SelectedMuster.Eingang;
            this.Name = this.SelectedMuster.Name;
            this.Menge = this.SelectedMuster.Menge;
            this.Kunde = this.SelectedMuster.Kunde;
            this.Ansprechpartner = this.SelectedMuster.Ansprechpartner;
            this.Artikel = this.SelectedMuster.Name;
        }
        private void clear()
        {
            MessageBoxResult msg = MessageBox.Show("Wollen Sie wirklich den ganzen Lagerplatz leeren?", "Lagerplatz leeren", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (msg == MessageBoxResult.Yes)
            {
                this._repository.Delete(this);
                this.MusterList = new List<IBuchung>();
                MessageBox.Show("Der Lagerplatz wurde geleert.", "Lagerplatz leeren", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region Properties
        private int index;
        public bool isLager
        {
            get { return this._model.isLager; }
            set
            {
                if (isLager != value)
                {
                    this._model.isLager = value;
                    base.OnPropertyChanged("isLager");
                }
            }
        }
        public int LagerId
        {
            get { return this._model.LagerId; }
            set
            {
                if (LagerId != value)
                {
                    this._model.LagerId = value;
                    base.OnPropertyChanged("LagerId");
                }
            }
        }
        public int MusterId
        {
            get { return this._model.MusterId; }
            set
            {
                if (MusterId != value)
                {
                    this._model.MusterId = value;
                    base.OnPropertyChanged("MusterId");
                }
            }
        }
        public int MusterLagerId
        {
            get { return this._model.MusterLagerId; }
            set
            {
                if (MusterLagerId != value)
                {
                    this._model.MusterLagerId = value;
                    base.OnPropertyChanged("MusterLagerId");
                }
            }
        }
        public string Platz
        {
            get { return this._model.Platz; }
            set
            {
                if (Platz != value)
                {
                    this._model.Platz = value;
                    base.OnPropertyChanged("Platz");
                }
            }
        }
        public string Ort
        {
            get { return this._model.Ort; }
            set
            {
                if (Ort != value)
                {
                    this._model.Ort = value;
                    base.OnPropertyChanged("Ort");
                }
            }
        }

        public string Lagerplatz
        {
            get { return this._model.Lagerplatz; }
            set
            {
                if (Lagerplatz != value)
                {
                    this._model.Lagerplatz = value;
                    base.OnPropertyChanged("Lagerplatz");
                }
            }
        }
        public int Anzahl
        {
            get { return this._model.Anzahl; }
            set
            {
                if (Anzahl != value)
                {
                    this._model.Anzahl = value;
                    base.OnPropertyChanged("Anzahl");
                }
            }
        }
        public BuchungMuster SelectedMuster
        {
            get { return this._model.SelectedMuster; }
            set
            {
                if (SelectedMuster != value)
                {
                    this._model.SelectedMuster = value;
                    base.OnPropertyChanged("SelectedMuster");
                }
            }
        }
        public List<BuchungMuster> ArtikelList
        {
            get { return this._model.ArtikelList; }
            set
            {
                if (ArtikelList != value)
                {
                    this._model.ArtikelList = value;
                    base.OnPropertyChanged("ArtikelList");
                }
            }
        }
        public List<IBuchung> MusterList
        {
            get { return this._model.MusterList; }
            set
            {
                if (MusterList != value)
                {
                    this._model.MusterList = value;
                    base.OnPropertyChanged("MusterList");
                }
            }
        }
        
        public int id
        {
            get { return this._model.id; }
            set
            {
                if (id != value)
                {
                    this._model.id = value;
                    base.OnPropertyChanged("id");
                }
            }
        }
        public string Artikel
        {
            get { return this._model.Artikel; }
            set
            {
                if (Artikel != value)
                {
                    this._model.Artikel = value;
                    base.OnPropertyChanged("Artikel");
                }
            }
        }
        public string Name
        {
            get { return this._model.Name; }
            set
            {
                if (Name != value)
                {
                    this._model.Name = value;
                    base.OnPropertyChanged("Name");
                }
            }
        }
        public int Menge
        {
            get { return this._model.Menge; }
            set
            {
                if (Menge != value)
                {
                    this._model.Menge = value;
                    base.OnPropertyChanged("Menge");
                }
            }
        }
        public DateTime Eingang
        {
            get { return this._model.Eingang; }
            set
            {
                if (Eingang != value)
                {
                    this._model.Eingang = value;
                    base.OnPropertyChanged("Eingang");
                }
            }
        }
        public DateTime Ausgang
        {
            get { return this._model.Ausgang; }
            set
            {
                if (Ausgang != value)
                {
                    this._model.Ausgang = value;
                    base.OnPropertyChanged("Ausgang");
                }
            }
        }
        public string Zweck
        {
            get { return this._model.Zweck; }
            set
            {
                if (Zweck != value)
                {
                    this._model.Zweck = value;
                    base.OnPropertyChanged("Zweck");
                }
            }
        }
        public string Kunde
        {
            get { return this._model.Kunde; }
            set
            {
                if (Kunde != value)
                {
                    this._model.Kunde = value;
                    base.OnPropertyChanged("Kunde");
                }
            }
        }
        public string Kundeneigentum
        {
            get { return this._model.Kundeneigentum; }
            set
            {
                if (Kundeneigentum != value)
                {
                    this._model.Kundeneigentum = value;
                    base.OnPropertyChanged("Kundeneigentum");
                }
            }
        }
        public string Ruecksendung
        {
            get { return this._model.Ruecksendung; }
            set
            {
                if (Ruecksendung != value)
                {
                    this._model.Ruecksendung = value;
                    base.OnPropertyChanged("Ruecksendung");
                }
            }
        }
        public string Referenznummer
        {
            get { return this._model.Referenznummer; }
            set
            {
                if (Referenznummer != value)
                {
                    this._model.Referenznummer = value;
                    base.OnPropertyChanged("Referenznummer");
                }
            }
        }
        public string Ansprechpartner
        {
            get { return this._model.Ansprechpartner; }
            set
            {
                if (Ansprechpartner != value)
                {
                    this._model.Ansprechpartner = value;
                    base.OnPropertyChanged("Ansprechpartner");
                }
            }
        } 
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class MusterViewModel : ViewModelBase, IMusterModel
    {
        private readonly IMusterModel _model;
        private readonly IRepository<IMusterModel> _repository;

        public MusterViewModel(IMusterModel model, IRepository<IMusterModel> repository)
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

        private ICommand _AddCommand;
        public ICommand AddCommand
        {
            get { return this._AddCommand ?? (this._AddCommand = new RelayCommand(x => this.add())); }
        }

        private ICommand _EditCommand;
        public ICommand EditCommand
        {
            get { return this._EditCommand ?? (this._EditCommand = new RelayCommand(x => this.saveChanges(x))); }
        }

        private ICommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get { return this._DeleteCommand ?? (this._DeleteCommand = new RelayCommand(x => this.delete(x))); }
        }
        #endregion

        private void load()
        {
            #region Initialize
            this.MusterList = new ObservableCollection<Muster>();
            this.KundeList = new ObservableCollection<KundeMuster>();
            this.AnsprechpartnerList = new ObservableCollection<AnsprechpartnerMuster>(); 
            #endregion

            this.KundeList.Add(new KundeMuster { id = -1, Kunde = "" });
            this.AnsprechpartnerList.Add(new AnsprechpartnerMuster { id = -1, Ansprechpartner = "" });

            this._repository.Select(this);

            if (this.id == -1)
                return;

            #region Show selected 'Muster'
            var list = this.MusterList.Where(x => x.id == this.id).ToList();
            this.Name = list[0].Name;
            this.Zweck = list[0].Zweck;
            this.Eingangsdatum = list[0].Eingangsdatum;
            this.Ausgangsdatum = list[0].Ausgangsdatum;
            this.Referenznummer = list[0].Referenznummer;
            this.SelectedKunde = this.KundeList.Where(x => x.Kunde == list[0].Kunde).ToList()[0];
            this.Kundeneigentum = list[0].Kundeneigentum;
            this.Rücksendung = list[0].Rücksendung;
            this.SelectedAnsprechpartner = this.AnsprechpartnerList.Where(x => x.Ansprechpartner == list[0].Ansprechpartner).ToList()[0];
            this.Gesamtmenge = list[0].Gesamtmenge; 
            #endregion
        }
        private void add()
        {
            if (!check()) return;

            this._repository.Insert(this);
            refreshList();
            clear();
        }
        private void saveChanges(object param)
        {
            int index = int.Parse(param.ToString());

            if (!check(index)) return;
            if (index == -1)
                index = this.MusterList.IndexOf(this.MusterList.Where(x => x.id == this.id).ToList()[0]);
            
            this._repository.Update(this);
            this.refreshList(index, false);
            this.clear();
        }
        private void delete(object param)
        {
            int index = int.Parse(param.ToString());

            if (!check(index)) return;
            if (index == -1)
                index = this.MusterList.IndexOf(this.MusterList.Where(x => x.id == this.id).ToList()[0]);

            this._repository.Delete(this);
            this.refreshList(index, true);
            this.clear();
        }

        private void clear()
        {
            this.Name = "";
            this.Zweck = "";
            this.Eingangsdatum = DateTime.Today;
            this.Ausgangsdatum = DateTime.Today;
            this.Referenznummer = "";
            this.SelectedKunde = this.KundeList.Where(x => x.id == -1).ToList()[0];
            this.SelectedAnsprechpartner = this.AnsprechpartnerList.Where(x => x.id == -1).ToList()[0];
            this.Gesamtmenge = 0;
            this.Kundeneigentum = false;
            this.Rücksendung = false;
            this.id = -1;
        }
        private void refreshList()
        {
            var list = this.MusterList;
            list.Add(new Muster 
            {
                id = this.MusterList[this.MusterList.Count - 1].id - 1,
                Name = this.Name,
                Zweck = this.Zweck,
                Eingangsdatum = this.Eingangsdatum,
                Ausgangsdatum = this.Ausgangsdatum,
                Referenznummer = this.Referenznummer,
                Kunde = this.SelectedKunde.Kunde,
                Kundeneigentum = this.Kundeneigentum,
                Rücksendung = this.Rücksendung
            });

            this.MusterList = new ObservableCollection<Muster>();
            this.MusterList = list;
        }
        private void refreshList(int index, bool delete)
        {       
            var list = this.MusterList;
            if (delete)
            {
                list.RemoveAt(index);
            }
            else
            {
                list[index].Name = this.Name;
                list[index].Zweck = this.Zweck;
                list[index].Eingangsdatum = this.Eingangsdatum;
                list[index].Ausgangsdatum = this.Ausgangsdatum;
                list[index].Referenznummer = this.Referenznummer;
                list[index].Kunde = this.SelectedKunde.Kunde;
                list[index].Kundeneigentum = this.Kundeneigentum;
                list[index].Rücksendung = this.Rücksendung;
            }

            this.MusterList = new ObservableCollection<Muster>();
            MusterList = list;
        }
        private bool check()
        {
            if (this.id != -1)
            {
                MessageBox.Show("Das Muster existiert bereits. Sie können es nicht nochmal hinzufügen.", "Hinzufügen eines Musters", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!selected()) return false;
            return true;
        }
        private bool check(int index)
        {
            if (index == -1 && this.id == -1)
            {
                MessageBox.Show("Sie können nur ein vorhandenes Muster bearbeiten.", "Kein Muster ausgewählt", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!selected()) return false;

            return true;
        }
        private bool selected()
        {
            if (this.SelectedKunde.Kunde == "")
            {
                MessageBox.Show("Sie müssen einen Kunden auswählen.", "Kein Kunde ausgewählt", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (this.SelectedAnsprechpartner.Ansprechpartner == "")
            {
                MessageBox.Show("Sie müssen einen Ansprechpartner auswählen.", "Kein Ansprechpartner ausgewählt", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        #region Properties
        public int id { get; set; }
        public ObservableCollection<Muster> MusterList
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
        public DateTime Eingangsdatum
        {
            get { return _model.Eingangsdatum; }
            set
            {
                if (Eingangsdatum != value)
                {
                    _model.Eingangsdatum = value;
                    OnPropertyChanged("Eingangsdatum");
                }
            }
        }
        public DateTime Ausgangsdatum
        {
            get { return _model.Ausgangsdatum; }
            set
            {
                if (Ausgangsdatum != value)
                {
                    _model.Ausgangsdatum = value;
                    OnPropertyChanged("Ausgangsdatum");
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
        public ObservableCollection<KundeMuster> KundeList
        {
            get { return _model.KundeList; }
            set
            {
                if (KundeList != value)
                {
                    _model.KundeList = value;
                    OnPropertyChanged("KundeList");
                }
            }
        }
        public bool Kundeneigentum
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
        public bool Rücksendung
        {
            get { return _model.Rücksendung; }
            set
            {
                if (Rücksendung != value)
                {
                    _model.Rücksendung = value;
                    OnPropertyChanged("Rücksendung");
                }
            }
        } 
        public KundeMuster SelectedKunde
        {
            get { return _model.SelectedKunde; }
            set
            {
                if (SelectedKunde != value)
                {
                    _model.SelectedKunde = value;
                    OnPropertyChanged("SelectedKunde");
                }
            }
        }
        public ObservableCollection<AnsprechpartnerMuster> AnsprechpartnerList
        {
            get { return _model.AnsprechpartnerList; }
            set 
            {
                if (AnsprechpartnerList != value)
                {
                    _model.AnsprechpartnerList = value;
                    OnPropertyChanged("AnsprechpartnerList");
                }
            }
        }
        public AnsprechpartnerMuster SelectedAnsprechpartner
        {
            get { return _model.SelectedAnsprechpartner; }
            set
            {
                if (SelectedAnsprechpartner != value)
                {
                    _model.SelectedAnsprechpartner = value;
                    OnPropertyChanged("SelectedAnsprechpartner");
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
        public int Gesamtmenge
        {
            get { return _model.Gesamtmenge; }
            set
            {
                if (Gesamtmenge != value)
                {
                    _model.Gesamtmenge = value;
                    OnPropertyChanged("Gesamtmenge");
                }
            }
        }
        #endregion
    }
}

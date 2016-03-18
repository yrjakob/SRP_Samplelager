using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class EditLagerViewModel : ViewModelBase, IEditLagerModel
    {
        private readonly IEditLagerModel _model;
        private readonly IRepository<IEditLagerModel> _repository;
        private readonly List<CommandPattern> _commands;

        public EditLagerViewModel(IEditLagerModel model, IRepository<IEditLagerModel> repository, List<CommandPattern> commands)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (repository == null) throw new ArgumentNullException("repository");
            if (commands == null) throw new ArgumentNullException("commands");

            this._model = model;
            this._repository = repository;
            this._commands = commands;
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
            get { return this._EditCommand ?? (this._EditCommand = new RelayCommand(x => this.edit(x))); }
        }
        private ICommand _SelectCommand;
        public ICommand SelectCommand
        {
            get { return this._SelectCommand ?? (this._SelectCommand = new RelayCommand(x => this.select(x))); }
        }
        private ICommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get { return this._DeleteCommand ?? (this._DeleteCommand = new RelayCommand(x => this.delete())); }
        }
        private ICommand _CloseCommand;
        public ICommand CloseCommand
        {
            get { return this._CloseCommand ?? (this._CloseCommand = new RelayCommand(x => this.close())); }
        }
        #endregion

        private void load()
        {
            this.LagerList = new ObservableCollection<IEditLager>();
            this._repository.Select(this);

            if(this.id != -1)
            {
                this.Gebaeude = this.LagerList.First(x => x.id == this.id).Gebaeude;
                this.Nummer = this.LagerList.First(x => x.id == this.id).Nummer;
                this.Kommentar = this.LagerList.First(x => x.id == this.id).Kommentar;
            }
        }
        private void add()
        {
            if(this.id != -1 && !this.LagerList.Contains(this.LagerList.First(x => x.Gebaeude == this.Gebaeude && x.Nummer == this.Nummer)))
            {
                MessageBox.Show("Diese Lager existiert bereits.", "Lager hinzufügen", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this._repository.Insert(this);
            this.LagerList = new ObservableCollection<IEditLager>();
            this._repository.Select(this);
            this.clear();
        }
        private void edit(object param)
        {
            if(this.id == -1)
            {
                MessageBoxResult msg = MessageBox.Show("Sie können kein Lager bearbeiten, dass nicht existiert.\r\nWollen Sie ein neues erstellen?", 
                                                       "Änderungen speichern", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (msg == MessageBoxResult.Yes)
                    add();

                return;
            }

            this._repository.Update(this);
            this.LagerList = new ObservableCollection<IEditLager>();
            this._repository.Select(this);
            this.clear();
        }
        private void delete()
        {
            if(this.id == -1)
            {
                MessageBox.Show("Sie können kein Lager löschen, dass nicht existiert.", "Lager löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this._repository.Delete(this);
            this.LagerList = new ObservableCollection<IEditLager>();
            this._repository.Select(this);
            this.clear();
        }
        private void select(object param)
        {
            int index = int.Parse(param.ToString());
            if (param == null || index == -1)
                return;

            this.id = this.LagerList[index].id;
            this.Gebaeude = this.LagerList[index].Gebaeude;
            this.Nummer = this.LagerList[index].Nummer;
            this.Kommentar = this.LagerList[index].Kommentar;
        }
        private void close()
        {
            this._commands.First(x => x.Command == "Lager").Execute();
        }

        private void clear()
        {
            this.id = -1;
            this.Gebaeude = "";
            this.Nummer = "";
            this.Kommentar = "";
        }

        #region Properties
        public ObservableCollection<IEditLager> LagerList
        {
            get { return this._model.LagerList; }
            set
            {
                if (LagerList != value)
                {
                    this._model.LagerList = value;
                    base.OnPropertyChanged("LagerList");
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
        public string Gebaeude
        {
            get { return this._model.Gebaeude; }
            set
            {
                if (Gebaeude != value)
                {
                    this._model.Gebaeude = value;
                    base.OnPropertyChanged("Gebaeude");
                }
            }
        }
        public string Nummer
        {
            get { return this._model.Nummer; }
            set
            {
                if (Nummer != value)
                {
                    this._model.Nummer = value;
                    base.OnPropertyChanged("Nummer");
                }
            }
        }
        public string Kommentar
        {
            get { return this._model.Kommentar; }
            set
            {
                if (Kommentar != value)
                {
                    this._model.Kommentar = value;
                    base.OnPropertyChanged("Kommentar");
                }
            }
        } 
        #endregion
    }
}

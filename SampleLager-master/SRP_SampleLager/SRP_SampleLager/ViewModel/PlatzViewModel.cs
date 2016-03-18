using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class PlatzViewModel : ViewModelBase, IPlatzModel
    {
        private readonly IPlatzModel _model;
        private readonly IRepository<IPlatzModel> _repository;

        public PlatzViewModel(IPlatzModel model, IRepository<IPlatzModel> repository)
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
            get { return this._EditCommand ?? (this._EditCommand = new RelayCommand(x => this.edit())); }
        }
        private ICommand _SelectCommand;
        public ICommand SelectCommand
        {
            get { return this._SelectCommand ?? (this._SelectCommand = new RelayCommand(x => this.select(x))); }
        } 
        #endregion

        #region Methods
        private void load()
        {
            this.Headline = this.Ort + " bearbeiten";
            this.PlatzList = new ObservableCollection<IPlatz>();
            this._repository.Select(this);
        }
        private void add()
        {
            if (this.id != -1)
            {
                MessageBox.Show("Dieser Platz besteht bereits.", "Platz hinzufügen", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this._repository.Insert(this);
            this.PlatzList = new ObservableCollection<IPlatz>();
            this._repository.Select(this);
            this.clear();
        }
        private void edit()
        {
            if (this.id == -1)
            {
                MessageBoxResult msg = MessageBox.Show("Dieser Platz besteht noch nicht.\r\nMöchten Sie diesen neu erstellen?", "Platz bearbeiten",
                                                       MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msg == MessageBoxResult.Yes)
                    add();
                return;
            }

            this._repository.Update(this);
            this.PlatzList = new ObservableCollection<IPlatz>();
            this._repository.Select(this);
            this.clear();
        }
        private void select(object param)
        {
            int index = 0;
            if (param == null || int.Parse(param.ToString()) == -1)
                return;
            else index = int.Parse(param.ToString());

            this.id = this.PlatzList[index].id;
            this.PlatzName = this.PlatzList[index].PlatzName;
            this._repository.findById(this);
        }

        private void clear()
        {
            this.id = -1;
            this.PlatzName = "";
        } 
        #endregion
        
        #region Properties
        public string Headline
        {
            get { return this._model.Headline; }
            set
            {
                if (Headline != value)
                {
                    this._model.Headline = value;
                    base.OnPropertyChanged("Headline");
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
        public int RaumId
        {
            get { return this._model.RaumId; }
            set
            {
                if (RaumId != value)
                {
                    this._model.RaumId = value;
                    base.OnPropertyChanged("RaumId");
                }
            }
        }
        public ObservableCollection<IPlatz> PlatzList
        {
            get { return this._model.PlatzList; }
            set
            {
                if (PlatzList != value)
                {
                    this._model.PlatzList = value;
                    base.OnPropertyChanged("PlatzList");
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
        public string PlatzName
        {
            get { return this._model.PlatzName; }
            set
            {
                if (PlatzName != value)
                {
                    this._model.PlatzName = value;
                    base.OnPropertyChanged("PlatzName");
                }
            }
        } 
        #endregion
    }
}

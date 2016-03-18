using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class OrtViewModel : ViewModelBase, IOrtModel
    {
        private readonly IOrtModel _model;
        private readonly IRepository<IOrtModel> _repository;

        public OrtViewModel(IOrtModel model, IRepository<IOrtModel> repository)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (repository == null) throw new ArgumentNullException("repository");

            this._model = model;
            this._repository = repository;
        }

        #region Commands
        private ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get { return this._SaveCommand ?? (this._SaveCommand = new RelayCommand(x => this.save(), param => this.canExecute)); }
        }
        private ICommand _AbortCommand;
        public ICommand AbortCommand
        {
            get { return this._AbortCommand ?? (this._AbortCommand = new RelayCommand(x => this.abort())); }
        }
        private ICommand _LoadedCommand;
        public ICommand LoadedCommand
        {
            get { return this._LoadedCommand ?? (this._LoadedCommand = new RelayCommand(x => this.load())); }
        }
        #endregion

        #region Methods
        private void load()
        {
            if (this.Ort == "" || this.Ort == null)
            {
                this.Headline = "Neuen Ort hinzufügen";
                this.neuerOrt = true;
            }
            else
            {
                this.Headline = "Ort " + Ort + " bearbeiten";
                this.neuerOrt = false;
                this.oldOrt = this.Ort;
            }
        }
        private void save()
        {
            if (this.neuerOrt)
                this._repository.Insert(this);
            else this._repository.Update(this);
            this.abort();
        }
        private void abort()
        {
            this.neuerOrt = false;
            this.RaumId = -1;
            this.Ort = "";
            this.oldOrt = "";
            this.Headline = "";
            CurrentWindow.Close();
        }
        #endregion

        #region Properties
        protected Window CurrentWindow
        {
            get { return Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive); }
        }
        private bool neuerOrt = false;
        private bool canExecute = false;
        public int RaumId
        {
            get { return this._model.RaumId; }
            set
            {
                if (RaumId != value)
                {
                    this._model.RaumId = value;
                    OnPropertyChanged("RaumId");
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

                    if (!String.IsNullOrEmpty("Ort"))
                        this.canExecute = true;
                    else this.canExecute = false;
                }
            }
        }
        public string oldOrt
        {
            get { return this._model.oldOrt; }
            set
            {
                if (oldOrt != value)
                {
                    this._model.oldOrt = value;
                    base.OnPropertyChanged("oldOrt");
                }
            }
        }
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
        #endregion
    }
}

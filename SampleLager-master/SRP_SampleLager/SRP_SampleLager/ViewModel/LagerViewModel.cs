using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class LagerViewModel : ViewModelBase, ILagerModel
    {
        private readonly ILagerModel _model;
        private readonly IList<CommandPattern> _commands;

        public LagerViewModel(ILagerModel model, IList<CommandPattern> commands)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (commands == null) throw new ArgumentNullException("commands");

            this._model = model;
            this._commands = commands;

            this.isEditable = true;
            this.TabVisibility = Visibility.Visible;
            this.FrameVisibility = Visibility.Collapsed;
        }

        private ICommand _Command;
        public ICommand Command
        {
            get { return this._Command ?? (this._Command = new RelayCommand(x => Execute(x))); }
        }
        private ICommand _AddOrtCommand;
        public ICommand AddOrtCommand
        {
            get { return this._AddOrtCommand ?? (this._AddOrtCommand = new RelayCommand(x => add(x))); }
        }
        
        private void add(object param)
        {
            if (param == null || ((TabItem)param).Header.ToString() != "+")
                return;

            Execute("NewOrt");
            Execute("Loaded");
        }
        private void Execute(object param)
        {
            this._commands.First(x => x.Command == param.ToString()).Execute();
        }

        #region Prpoerties
        public Lagerraum SelectedLager
        {
            get { return this._model.SelectedLager; }
            set
            {
                if (SelectedLager != value)
                {
                    this._model.SelectedLager = value;
                    base.OnPropertyChanged("SelectedLager");
                }
            }
        }
        public ObservableCollection<Lagerraum> LagerList
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
        public bool isEditable
        {
            get { return this._model.isEditable; }
            set
            {
                if (isEditable != value)
                {
                    this._model.isEditable = value;
                    base.OnPropertyChanged("isEditable");
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
        public ObservableCollection<Lagerplatz> PlatzList
        {
            get { return this._model.PlatzList; }
            set
            {
                if (PlatzList != value)
                {
                    _model.PlatzList = value;
                    base.OnPropertyChanged("PlatzList");
                }
            }
        }
        public ObservableCollection<TabItem> RegalList
        {
            get { return this._model.RegalList; }
            set
            {
                if (RegalList != value)
                {
                    this._model.RegalList = value;
                    base.OnPropertyChanged("RegalList");
                }
            }
        }
        public Page Frame
        {
            get { return this._model.Frame; }
            set
            {
                if (Frame != value)
                {
                    this._model.Frame = value;
                    base.OnPropertyChanged("Frame");
                }
            }
        }
        public Visibility FrameVisibility
        {
            get { return this._model.FrameVisibility; }
            set
            {
                if (FrameVisibility != value)
                {
                    this._model.FrameVisibility = value;
                    base.OnPropertyChanged("FrameVisibility");
                }
            }
        }
        public Visibility TabVisibility
        {
            get { return this._model.TabVisibility; }
            set
            {
                if (TabVisibility != value)
                {
                    this._model.TabVisibility = value;
                    base.OnPropertyChanged("TabVisibility");
                }
            }
        }
        #endregion
    }
}

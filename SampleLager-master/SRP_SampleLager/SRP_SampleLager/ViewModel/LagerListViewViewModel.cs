using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class LagerListViewViewModel : ViewModelBase, ILagerListViewModel
    {
        private readonly ILagerListViewModel _model;
        private readonly IList<CommandPattern> _commands;

        public LagerListViewViewModel(ILagerListViewModel model, IList<CommandPattern> commands)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (commands == null) throw new ArgumentNullException("commands");

            this._model = model;
            this._commands = commands;
        }

        #region Commands
        private ICommand _Command;
        public ICommand Command
        {
            get { return this._Command ?? (this._Command = new RelayCommand(x => this.Execute(x))); }
        }
        #endregion

        private void Execute(object param)
        {
            this._commands.First(x => x.Command == param.ToString()).Execute();
        }
                
        #region Properties
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
        public int index
        {
            get { return this._model.index; }
            set
            {
                if (index != value)
                {
                    this._model.index = value;
                    base.OnPropertyChanged("index");
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
        public List<string> List
        {
            get { return this._model.List; }
            set
            {
                if (List != value)
                {
                    this._model.List = value;
                    base.OnPropertyChanged("List");
                }
            }
        } 
        #endregion
    }
}

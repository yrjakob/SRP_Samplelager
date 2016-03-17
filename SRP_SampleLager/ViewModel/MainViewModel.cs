using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class MainViewModel : ViewModelBase, IMainModel
    {
        private readonly IMainModel _model;
        private readonly IList<CommandPattern> _commands;

        public MainViewModel(IMainModel model, IList<CommandPattern> commands)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (commands == null) throw new ArgumentNullException("commands");

            _model = model;
            _commands = commands;
        }

        private ICommand _Command;
        public ICommand Command
        {
            get { return _Command ?? (_Command = new RelayCommand(x => Execute(x))); }
        }

        private void Execute(object param)
        {
            _commands.First(x => x.Command == param.ToString()).Execute();
        }

        public Page Frame
        {
            get { return _model.Frame; }
            set
            {
                if (Frame != value)
                {
                    _model.Frame = value;
                    OnPropertyChanged("Frame");
                }
            }
        }
    }
}

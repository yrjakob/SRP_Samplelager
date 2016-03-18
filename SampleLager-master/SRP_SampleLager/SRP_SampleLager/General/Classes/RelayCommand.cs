using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class RelayCommand : ICommand
    {
        private Action<object> _action;
        private Predicate<object> _canExecute;

        public RelayCommand(Action<object> action) : this(action, param => true) { }

        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            if (action == null) throw new ArgumentNullException("action");
            if (canExecute == null) throw new ArgumentNullException("canExecute");

            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object param)
        {
            return _canExecute != null && _canExecute(param);
        }

        public void Execute(object param)
        {
            _action(param);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}

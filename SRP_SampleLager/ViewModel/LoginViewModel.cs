using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class LoginViewModel : ViewModelBase, ILoginModel
    {
        private readonly ILoginModel _model;
        private readonly IRepository<ILoginModel> _repository;

        public LoginViewModel(ILoginModel model, IRepository<ILoginModel> repository)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (repository == null) throw new ArgumentNullException("repository");

            _model = model;
            _repository = repository;
        }

        #region Commands
        private ICommand _LoginCommand;
        public ICommand LoginCommand
        {
            get { return _LoginCommand ?? (_LoginCommand = new RelayCommand((x) => login(x))); }
        }

        private ICommand _CancelCommand;
        public ICommand CancelCommand
        {
            get { return _CancelCommand ?? (_CancelCommand = new RelayCommand((x) => cancel())); }
        }
        #endregion

        #region Methods
        private void login(object param)
        {
            Password = (param as PasswordBox).Password;
            _repository.Select(this);

            if (AD_Access.isUser(Username, Password) && inDb)
            {
                _repository.Insert(this);
                CurrentWindow.DialogResult = true;
            }

            Password = String.Empty;
        }
        private void cancel()
        {
            Environment.Exit(0);
        }
        #endregion

        #region Properties
        protected Window CurrentWindow
        {
            get { return Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive); }
        }
        public string Username
        {
            get { return _model.Username; }
            set
            {
                if (Username != value)
                {
                    _model.Username = value;
                    OnPropertyChanged("Username");
                }
            }
        }
        public string Password
        {
            get { return _model.Password; }
            set
            {
                if (Password != value)
                {
                    _model.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public bool inDb
        {
            get { return _model.inDb; }
            set
            {
                if (inDb != value)
                {
                    _model.inDb = value;
                    OnPropertyChanged("inDb");
                }
            }
        }
        #endregion
    }
}

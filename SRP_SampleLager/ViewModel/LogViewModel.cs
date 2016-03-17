using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class LogViewModel : ViewModelBase, ILogModel
    {
        private readonly ILogModel _model;
        private readonly IRepository<ILogModel> _repository;

        public LogViewModel(ILogModel model, IRepository<ILogModel> repository)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (repository == null) throw new ArgumentNullException("repository");

            _model = model;
            _repository = repository;
        }

        #region Commands
        private ICommand _LoadedCommand;
        public ICommand LoadedCommand
        {
            get { return _LoadedCommand ?? (_LoadedCommand = new RelayCommand(x => load())); }
        }

        private ICommand _SelectUserCommand;
        public ICommand SelectUserCommand
        {
            get { return _SelectUserCommand ?? (_SelectUserCommand = new RelayCommand(x => selectUsername())); }
        }

        private ICommand _SelectActionCommand;
        public ICommand SelectActionCommand
        {
            get { return _SelectActionCommand ?? (_SelectActionCommand = new RelayCommand(x => selectAction())); }
        }

        private ICommand _SelectVonCommand;
        public ICommand SelectVonCommand
        {
            get { return _SelectVonCommand ?? (_SelectVonCommand = new RelayCommand(x => selectVon())); }
        }

        private ICommand _SelectBisCommand;
        public ICommand SelectBisCommand
        {
            get { return _SelectBisCommand ?? (_SelectBisCommand = new RelayCommand(x => selectBis())); }
        }
        #endregion

        #region Methods
        private void load()
        {
            gesamteList = new List<ILog>();
            LogList = new List<ILog>();
            UsernameList = new List<string>();
            ActionList = new List<string>();

            UsernameList.Add("Alle");
            ActionList.Add("Alle");

            _repository.Select(this);

            var list = LogList;
            gesamteList = list;
        }
        private void selectUsername()
        {
            if (Username == "Alle")
                return;

            var list = gesamteList.Where(x => x.Username == Username).ToList();

            if (Action != "Alle" && Action != null)
                list = list.Where(x => x.Action == Action).ToList();

            list = list.Where(x => DateTime.Compare(Von, x.Datum) <= 0 && DateTime.Compare(x.Datum, Bis) <= 0).ToList();

            LogList = list;
        }
        private void selectAction()
        {
            if (Action == "Alle")
                return;

            var list = gesamteList.Where(x => x.Action == Action).ToList();

            if (Username != "Alle" && Username != null)
                list = list.Where(x => x.Username == Username).ToList();

            list = list.Where(x => DateTime.Compare(Von, x.Datum) <= 0 && DateTime.Compare(x.Datum, Bis) <= 0).ToList();

            LogList = list;
        }
        private void selectVon()
        {
            var list = gesamteList.Where(x => DateTime.Compare(Von, x.Datum) <= 0 && DateTime.Compare(x.Datum, Bis) <= 0).ToList();

            if (Username != "Alle" && Username != null)
                list = list.Where(x => x.Username == Username).ToList();

            if (Action != "Alle" && Action != null)
                list = list.Where(x => x.Action == Action).ToList();

            LogList = list;
        }
        private void selectBis()
        {
            var list = gesamteList.Where(x => DateTime.Compare(Von, x.Datum) <= 0 && DateTime.Compare(x.Datum, Bis) <= 0).ToList();

            if (Username != "Alle" && Username != null)
                list = list.Where(x => x.Username == Username).ToList();

            if (Action != "Alle" && Action != null)
                list = list.Where(x => x.Action == Action).ToList();

            LogList = list;
        }
        #endregion

        #region Properties
        public DateTime Von
        {
            get { return _model.Von; }
            set
            {
                if (Von != value)
                {
                    _model.Von = value;
                    OnPropertyChanged("Von");
                }
            }
        }
        public DateTime Bis
        {
            get { return _model.Bis; }
            set
            {
                if (Bis != value)
                {
                    _model.Bis = value;
                    OnPropertyChanged("Bis");
                }
            }
        }
        public IList<string> UsernameList
        {
            get { return _model.UsernameList; }
            set
            {
                if (UsernameList != value)
                {
                    _model.UsernameList = value;
                    OnPropertyChanged("UsernameList");
                }
            }
        }
        public IList<string> ActionList
        {
            get { return _model.ActionList; }
            set
            {
                if (ActionList != value)
                {
                    _model.ActionList = value;
                    OnPropertyChanged("ActionList");
                }
            }
        }
        public IList<ILog> LogList
        {
            get { return _model.LogList; }
            set
            {
                if (LogList != value)
                {
                    _model.LogList = value;
                    OnPropertyChanged("LogList");
                }
            }
        }
        public IList<ILog> gesamteList
        {
            get { return _model.gesamteList; }
            set
            {
                if (gesamteList != value)
                {
                    _model.gesamteList = value;
                    OnPropertyChanged("gesamteList");
                }
            }
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
        public string Action
        {
            get { return _model.Action; }
            set
            {
                if (Action != value)
                {
                    _model.Action = value;
                    OnPropertyChanged("Action");
                }
            }
        }
        public DateTime Datum
        {
            get { return _model.Datum; }
            set
            {
                if (Datum != value)
                {
                    _model.Datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }
        #endregion
    }
}

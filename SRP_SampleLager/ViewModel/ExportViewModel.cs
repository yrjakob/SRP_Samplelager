using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class ExportViewModel : ViewModelBase, IExportModel
    {
        private readonly IExportModel _model;
        private readonly IRepository<IExportModel> _repository;

        public ExportViewModel(IExportModel model, IRepository<IExportModel> repository)
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

        private ICommand _DruckenCommand;
        public ICommand DruckenCommand
        {
            get { return _DruckenCommand ?? (_DruckenCommand = new RelayCommand(x => drucken())); }
        }
        #endregion

        #region Methods
        private void load() 
        {
            MenschList = new List<string>();
            AktionList = new List<string>();
            ExportList = new List<IExport>();
            gesamteList = new List<IExport>();

            MenschList.Add("Alle");
            AktionList.Add("Alle");

            _repository.Select(this);
        }
        private void drucken() 
        {
            ExportList = gesamteList.Where(x => x.Name == Mensch && x.Aktion == Aktion && DateTime.Compare(Von, x.Datum) <= 0 && DateTime.Compare(x.Datum, Bis) <= 0).ToList();
        }
        #endregion

        #region Properties
        public string Mensch
        {
            get { return _model.Mensch; }
            set
            {
                if (Mensch != value)
                {
                    _model.Mensch = value;
                    OnPropertyChanged("Mensch");
                }
            }
        }
        public List<string> MenschList
        {
            get { return _model.MenschList; }
            set
            {
                if (MenschList != value)
                {
                    _model.MenschList = value;
                    OnPropertyChanged("MenschList");
                }
            }
        }
        public string Aktion
        {
            get { return _model.Aktion; }
            set
            {
                if (Aktion != value)
                {
                    _model.Aktion = value;
                    OnPropertyChanged("Aktion");
                }
            }
        }
        public List<string> AktionList
        {
            get { return _model.AktionList; }
            set
            {
                if (AktionList != value)
                {
                    _model.AktionList = value;
                    OnPropertyChanged("AktionList");
                }
            }
        }
        public List<IExport> ExportList
        {
            get { return _model.ExportList; }
            set
            {
                if (ExportList != value)
                {
                    _model.ExportList = value;
                    OnPropertyChanged("ExportList");
                }
            }
        }
        public List<IExport> gesamteList
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
        #endregion
    }
}

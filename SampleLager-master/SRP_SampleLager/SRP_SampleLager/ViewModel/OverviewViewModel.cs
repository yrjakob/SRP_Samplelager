using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SRP_SampleLager
{
    public class OverviewViewModel : ViewModelBase, IOverviewModel
    {
        private readonly IOverviewModel _model;
        private readonly IList<CommandPattern> _commands;

        public OverviewViewModel(IOverviewModel model, IList<CommandPattern> commands)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (commands == null) throw new ArgumentNullException("commands");

            _model = model;
            _commands = commands;
        }

        private ICommand _Command;
        public ICommand Command
        {
            get { return _Command ?? (_Command = new RelayCommand(x => execute(x))); }
        }
                
        private void execute(object param)
        {
            _commands.FirstOrDefault(x => x.Command == param.ToString()).Execute();
        }
        //private void load()
        //{
        //    _repository.Select(this);

        //    foreach (PropertyInfo p in typeof(Overview).GetProperties())
        //    {
        //        FilterList.Add(p.Name.ToString());
        //    }

        //    FilterList.Sort();
        //}

        #region Properties
        public int id
        {
            get { return _model.id; }
            set
            {
                if (id != value)
                {
                    _model.id = value;
                    OnPropertyChanged("id");
                }
            }
        }
        public List<IOverview> OverviewList
        {
            get { return _model.OverviewList; }
            set
            {
                if (OverviewList != value)
                {
                    _model.OverviewList = value;
                    OnPropertyChanged("OverviewList");
                }
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class LogFactory : IFactory<LogView>
    {
        private readonly ILogModel _viewModel;

        public LogFactory(ILogModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            _viewModel = viewModel;
        }

        public LogView create()
        {
            return new LogView { DataContext = _viewModel };
        }


        public LogView create(object param)
        {
            throw new NotImplementedException();
        }
    }
}

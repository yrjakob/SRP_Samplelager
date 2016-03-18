using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class ExportFactory : IFactory<ExportView>
    {
        private readonly IExportModel _viewModel;

        public ExportFactory(IExportModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            _viewModel = viewModel;
        }

        public ExportView create()
        {
            return new ExportView { DataContext = _viewModel };
        }


        public ExportView create(object param)
        {
            throw new NotImplementedException();
        }
    }
}

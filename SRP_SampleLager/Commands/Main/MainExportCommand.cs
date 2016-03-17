using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class MainExportCommand : CommandPattern
    {
        private readonly IMainModel _viewModel;
        private readonly IFactory<ExportView> _factory;

        public MainExportCommand(string Command, IMainModel viewModel, IFactory<ExportView> factory)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (factory == null) throw new ArgumentNullException("factory");

            _viewModel = viewModel;
            _factory = factory;
        }

        public override void Execute()
        {
            _viewModel.Frame = null;
            _viewModel.Frame = _factory.create();
        }
    }
}

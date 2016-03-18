using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class OverviewMusterCommand : CommandPattern
    {
        private readonly IMainModel _viewModel;
        private readonly IFactory<MusterView> _factory;

        public OverviewMusterCommand(string Command, IMainModel viewModel, IFactory<MusterView> factory)
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

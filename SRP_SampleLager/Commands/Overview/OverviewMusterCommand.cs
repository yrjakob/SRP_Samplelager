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
        // Factory

        public OverviewMusterCommand(string Command, IMainModel viewModel /*Factory*/)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            // Factory

            _viewModel = viewModel;
        }

        public override void Execute()
        {
            _viewModel.Frame = null;
            // Factory
        }
    }
}

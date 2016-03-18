using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class OverviewFactory : IFactory<OverviewView>
    {
        private readonly IOverviewModel _viewModel;

        public OverviewFactory(IOverviewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            _viewModel = viewModel;
        }

        public OverviewView create()
        {
            return new OverviewView { DataContext = _viewModel };
        }


        public OverviewView create(object param)
        {
            throw new NotImplementedException();
        }
    }
}

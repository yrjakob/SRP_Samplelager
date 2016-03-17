using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class BuchungFactory : IFactory<BuchungView>
    {
        private readonly IBuchungModel _viewModel;

        public BuchungFactory(IBuchungModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            _viewModel = viewModel;
        }

        public BuchungView create()
        {
            return new BuchungView { DataContext = _viewModel };
        }
    }
}

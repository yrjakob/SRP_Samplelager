using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class BuchungUebersichtFactory : IFactory<BuchungView>
    {
        private readonly IBuchungModel _viewModel;
        private readonly IOverviewModel _overviewViewModel;

        public BuchungUebersichtFactory(IBuchungModel viewModel, IOverviewModel overviewViewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (overviewViewModel == null) throw new ArgumentNullException("overviewViewModel");

            _viewModel = viewModel;
            _overviewViewModel = overviewViewModel;
        }

        public BuchungView create()
        {
            _viewModel.isLager = false;
            _viewModel.MusterId = _overviewViewModel.OverviewList[_overviewViewModel.id].MusterId;
            _viewModel.LagerId = _overviewViewModel.OverviewList[_overviewViewModel.id].LagerId;
            _viewModel.MusterLagerId = _overviewViewModel.OverviewList[_overviewViewModel.id].MusterLagerId;
            return new BuchungView { DataContext = _viewModel };
        }
        public BuchungView create(object param)
        {
            throw new NotImplementedException();
        }
    }
}

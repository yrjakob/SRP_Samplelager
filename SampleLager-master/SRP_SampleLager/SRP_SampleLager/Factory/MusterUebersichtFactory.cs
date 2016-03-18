using System;

namespace SRP_SampleLager
{
    public class MusterUebersichtFactory : IFactory<MusterView>
    {
        private readonly IMusterModel _viewModel;
        private readonly IOverviewModel _overview;

        public MusterUebersichtFactory(IMusterModel viewModel, IOverviewModel overview)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (overview == null) throw new ArgumentNullException("overview");

            this._viewModel = viewModel;
            this._overview = overview;
        }

        public MusterView create()
        {
            this._viewModel.id = this._overview.OverviewList[this._overview.id].MusterId;
            return new MusterView { DataContext = this._viewModel };
        }


        public MusterView create(object param)
        {
            throw new NotImplementedException();
        }
    }
}

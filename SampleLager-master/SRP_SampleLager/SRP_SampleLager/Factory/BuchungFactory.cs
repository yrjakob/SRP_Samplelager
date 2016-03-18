using System;
using System.Collections.Generic;

namespace SRP_SampleLager
{
    public class BuchungFactory : IFactory<BuchungView>
    {
        private readonly IBuchungModel _viewModel;
        private readonly ILagerModel _lagerViewModel;

        public BuchungFactory(IBuchungModel viewModel, ILagerModel lagerViewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (lagerViewModel == null) throw new ArgumentNullException("lagerViewModel");

            this._viewModel = viewModel;
            this._lagerViewModel = lagerViewModel;
        }

        public BuchungView create()
        {
            return new BuchungView { DataContext = this._viewModel };   
        }
        public BuchungView create(object param)
        {
            var list = (List<string>)param;

            this._viewModel.isLager = true;
            this._viewModel.LagerId = this._lagerViewModel.SelectedLager.id;
            this._viewModel.Platz = list[0].Replace("Platz: ", "");
            this._viewModel.Ort = list[1];
            return new BuchungView { DataContext = this._viewModel };
        }
    }
}

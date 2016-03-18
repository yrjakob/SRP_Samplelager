using System;
using System.Collections.Generic;

namespace SRP_SampleLager
{
    public class PlatzFactory : IFactory<PlatzView>
    {
        private readonly IPlatzModel _viewModel;

        public PlatzFactory(IPlatzModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            this._viewModel = viewModel;
        }

        public PlatzView create()
        {
            return new PlatzView { DataContext = this._viewModel };
        }

        public PlatzView create(object param)
        {
            var list = (List<string>)param;
            this._viewModel.Ort = list[0];
            this._viewModel.RaumId = int.Parse(list[1]);
            this._viewModel.id = int.Parse(list[2]);
            return new PlatzView { DataContext = this._viewModel };
        }
    }
}

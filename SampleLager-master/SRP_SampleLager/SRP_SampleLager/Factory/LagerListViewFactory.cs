using System;
using System.Collections.Generic;
using System.Linq;

namespace SRP_SampleLager
{
    public class LagerListViewFactory : IFactory<LagerListView>
    {
        private readonly ILagerListViewModel _viewModel;

        public LagerListViewFactory(ILagerListViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            this._viewModel = viewModel;
        }

        public LagerListView create()
        {
            return new LagerListView { DataContext = this._viewModel };
        }
        public LagerListView create(object param)
        {
            this._viewModel.RaumId = int.Parse(param.ToString());
            return new LagerListView { DataContext = this._viewModel };
        }
    }
}

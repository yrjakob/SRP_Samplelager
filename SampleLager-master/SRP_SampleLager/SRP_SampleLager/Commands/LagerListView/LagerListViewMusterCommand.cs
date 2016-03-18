using System;
using System.Collections.Generic;
using System.Windows;

namespace SRP_SampleLager
{
    public class LagerListViewMusterCommand : CommandPattern
    {
        private readonly ILagerListViewModel _viewModel;
        private readonly ILagerModel _lagerViewModel;
        private readonly IFactory<BuchungView> _factory;

        public LagerListViewMusterCommand(string Command, ILagerListViewModel viewModel, ILagerModel lagerViewModel, IFactory<BuchungView> factory)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (lagerViewModel == null) throw new ArgumentNullException("viewModel");
            if (factory == null) throw new ArgumentNullException("factory");

            this._viewModel = viewModel;
            this._lagerViewModel = lagerViewModel;
            this._factory = factory;
        }

        public override void Execute()
        {
            var list = new List<string>();
            list.Add(this._viewModel.List[this._viewModel.index]);
            list.Add(this._viewModel.Ort);

            this._lagerViewModel.Frame = null;
            this._lagerViewModel.Frame = this._factory.create(list);
            this._lagerViewModel.FrameVisibility = Visibility.Visible;
            this._lagerViewModel.TabVisibility = Visibility.Collapsed;
        }
    }
}

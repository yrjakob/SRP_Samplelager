using System;
using System.Collections.Generic;
using System.Windows;

namespace SRP_SampleLager
{
    public class LagerListViewPlatzCommand : CommandPattern
    {
        private readonly ILagerListViewModel _viewModel;
        private readonly ILagerModel _lagerViewModel;
        private readonly IFactory<PlatzView> _factory;

        public LagerListViewPlatzCommand(string Command, ILagerListViewModel viewModel, ILagerModel lagerViewModel, IFactory<PlatzView> factory)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (lagerViewModel == null) throw new ArgumentNullException("lagerViewModel");
            if (factory == null) throw new ArgumentNullException("factory");

            this._viewModel = viewModel;
            this._lagerViewModel = lagerViewModel;
            this._factory = factory;
        }

        public override void Execute()
        {
            this._lagerViewModel.Frame = null;
            this._lagerViewModel.Frame = _factory.create(new List<string>() { this._viewModel.Ort, this._lagerViewModel.SelectedLager.id.ToString(), "-1" });
            this._lagerViewModel.FrameVisibility = Visibility.Visible;
            this._lagerViewModel.TabVisibility = Visibility.Collapsed;
        }
    }
}

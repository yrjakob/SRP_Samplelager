using System;
using System.Windows;

namespace SRP_SampleLager
{
    public class LagerEditCommand : CommandPattern
    {
        private readonly ILagerModel _viewModel;
        private readonly IFactory<EditLagerView> _factory;

        public LagerEditCommand(string Command, ILagerModel viewModel, IFactory<EditLagerView> factory)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (factory == null) throw new ArgumentNullException("factory");

            this._viewModel = viewModel;
            this._factory = factory;
        }

        public override void Execute()
        {
            this._viewModel.Frame = null;

            if (this._viewModel.SelectedLager.id == -1)
                this._viewModel.Frame = this._factory.create();
            else this._viewModel.Frame = this._factory.create(this._viewModel.SelectedLager.id);

            this._viewModel.FrameVisibility = Visibility.Visible;
            this._viewModel.TabVisibility = Visibility.Collapsed;
            this._viewModel.isEditable = true;
        }
    }
}

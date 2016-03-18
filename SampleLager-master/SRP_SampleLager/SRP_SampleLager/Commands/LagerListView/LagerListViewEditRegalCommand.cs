using System;

namespace SRP_SampleLager
{
    public class LagerListViewEditRegalCommand : CommandPattern
    {
        private readonly ILagerListViewModel _viewModel;
        private readonly IFactory<OrtView> _factory;

        public LagerListViewEditRegalCommand(string Command, ILagerListViewModel viewModel, IFactory<OrtView> factory)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (factory == null) throw new ArgumentNullException("factory");

            this._viewModel = viewModel;
            this._factory = factory;
        }

        public override void Execute()
        {
            _factory.create(this._viewModel.Ort).ShowDialog();
        }
    }
}

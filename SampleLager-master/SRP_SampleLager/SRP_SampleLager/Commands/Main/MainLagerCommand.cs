using System;

namespace SRP_SampleLager
{
    public class MainLagerCommand : CommandPattern
    {
        private readonly IMainModel _viewModel;
        private readonly IFactory<LagerView> _factory;

        public MainLagerCommand(string Command, IMainModel viewModel, IFactory<LagerView> factory)
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
            this._viewModel.Frame = this._factory.create();
        }
    }
}

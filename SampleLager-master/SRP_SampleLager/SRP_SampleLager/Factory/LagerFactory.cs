using System;

namespace SRP_SampleLager
{
    public class LagerFactory : IFactory<LagerView>
    {
        private readonly ILagerModel _viewModel;

        public LagerFactory(ILagerModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            this._viewModel = viewModel;
        }

        public LagerView create()
        {
            return new LagerView { DataContext = this._viewModel };
        }


        public LagerView create(object param)
        {
            throw new NotImplementedException();
        }
    }
}

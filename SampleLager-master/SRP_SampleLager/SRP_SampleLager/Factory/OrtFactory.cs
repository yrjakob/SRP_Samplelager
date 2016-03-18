using System;

namespace SRP_SampleLager
{
    public class OrtFactory : IFactory<OrtView>
    {
        private readonly IOrtModel _viewModel;
        private readonly ILagerModel _lager;

        public OrtFactory(IOrtModel viewModel, ILagerModel lager)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (lager == null) throw new ArgumentNullException("lager");

            this._viewModel = viewModel;
            this._lager = lager;
        }

        public OrtView create()
        {
            this._viewModel.RaumId = this._lager.SelectedLager.id;
            return new OrtView { DataContext = this._viewModel };
        }
        public OrtView create(object param)
        {
            this._viewModel.Ort = param.ToString();
            return create();
        }
    }
}

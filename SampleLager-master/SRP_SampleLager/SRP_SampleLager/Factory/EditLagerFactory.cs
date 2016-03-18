using System;

namespace SRP_SampleLager
{
    public class EditLagerFactory : IFactory<EditLagerView>
    {
        private readonly IEditLagerModel _viewModel;

        public EditLagerFactory(IEditLagerModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            this._viewModel = viewModel;
        }

        public EditLagerView create()
        {
            this._viewModel.id = -1;
            return new EditLagerView() { DataContext = this._viewModel };
        }

        public EditLagerView create(object param)
        {
            this._viewModel.id = int.Parse(param.ToString());
            return new EditLagerView() { DataContext = this._viewModel };
        }
    }
}

using System;
using System.Collections.Generic;

namespace SRP_SampleLager
{
    public class LagerListViewFactoryVM : IFactory<ILagerListViewModel>
    {
        private readonly IFactory<ILagerListViewModel> _factory;
        private readonly IRepository<ILagerListViewModel> _repository;
        private readonly IFactory<OrtView> _ortFactory;
        private readonly ILagerModel _viewModel;
        private readonly IFactory<BuchungView> _buchungFactory;
        private readonly IFactory<PlatzView> _platzFactory;
        private IList<CommandPattern> _commands;

        // eklig..
        // bitte nicht nachmachen!
        public LagerListViewFactoryVM(IFactory<ILagerListViewModel> factory, IRepository<ILagerListViewModel> repository, 
                                      IFactory<OrtView> ortFactory, ILagerModel viewModel, IFactory<BuchungView> buchungFactory, IFactory<PlatzView> platzFactory)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (repository == null) throw new ArgumentNullException("repository");
            if (ortFactory == null) throw new ArgumentNullException("ortFactory");
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (buchungFactory == null) throw new ArgumentNullException("buchungFactory");
            if (platzFactory == null) throw new ArgumentNullException("platzFactory");

            this._factory = factory;
            this._repository = repository;
            this._ortFactory = ortFactory;
            this._viewModel = viewModel;
            this._buchungFactory = buchungFactory;
            this._platzFactory = platzFactory;
        }

        public ILagerListViewModel create()
        {
            this._commands = new List<CommandPattern>();
            var viewModel = new LagerListViewViewModel(this._factory.create(), this._commands);
            this.fillCommands(viewModel);
            return viewModel;
        }
        public ILagerListViewModel create(object param)
        {
            this._commands = new List<CommandPattern>();
            var viewModel = new LagerListViewViewModel(this._factory.create(int.Parse(param.ToString())), this._commands);
            this.fillCommands(viewModel);
            return viewModel;
        }

        private void fillCommands(ILagerListViewModel viewModel)
        {
            this._commands.Add(new LagerListViewDeleteRegalCommand("Delete", viewModel, this._repository, this._viewModel));
            this._commands.Add(new LagerListViewEditRegalCommand("Edit", viewModel, this._ortFactory));
            this._commands.Add(new LagerListViewMusterCommand("Muster", viewModel, this._viewModel, this._buchungFactory));
            this._commands.Add(new LagerListViewPlatzCommand("Platz", viewModel, this._viewModel, this._platzFactory));
        }
    }
}

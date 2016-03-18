using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class OverviewLoadedCommand : CommandPattern
    {
        private readonly IOverviewModel _viewModel;
        private readonly IRepository<IOverviewModel> _repository;

        public OverviewLoadedCommand(string Command, IOverviewModel viewModel, IRepository<IOverviewModel> repository)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (repository == null) throw new ArgumentNullException("repository");

            _viewModel = viewModel;
            _repository = repository;
        }

        public override void Execute()
        {
            _viewModel.OverviewList = new List<IOverview>();
            _repository.Select(_viewModel);
        }
    }
}

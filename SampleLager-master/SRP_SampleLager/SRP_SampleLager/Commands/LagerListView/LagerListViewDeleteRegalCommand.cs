using System;
using System.Windows;

namespace SRP_SampleLager
{
    public class LagerListViewDeleteRegalCommand : CommandPattern
    {
        private readonly ILagerListViewModel _viewModel;
        private readonly IRepository<ILagerListViewModel> _repository;
        private readonly ILagerModel _lagerViewModel;

        public LagerListViewDeleteRegalCommand(string Command, ILagerListViewModel viewModel, IRepository<ILagerListViewModel> repository, ILagerModel lagerViewModel)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (repository == null) throw new ArgumentNullException("repository");
            if (lagerViewModel == null) throw new ArgumentNullException("lagerViewModel");

            this._viewModel = viewModel;
            this._repository = repository;
            this._lagerViewModel = lagerViewModel;
        }

        public override void Execute()
        {
            MessageBoxResult msg;

            if (this._viewModel.List[0].Contains("kein Platz zugewiesen"))
                msg = MessageBox.Show("Wollen Sie diesen Ort wirklich löschen?", "Löschen eines Ortes", MessageBoxButton.YesNo, MessageBoxImage.Question);
            else msg = MessageBox.Show("Dieser Ort enthält mindestens einen Platz.\r\nWollen Sie diesen Ort wirklich löschen? Dadurch gehen auch alle Plätze verloren.",
                                       "Löschen eines Ortes", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (msg == MessageBoxResult.No)
                return;

            this._repository.Delete(this._viewModel);

            foreach (var item in this._lagerViewModel.RegalList)
            {
                if(item.Header.ToString() == this._viewModel.Ort)
                {
                    this._lagerViewModel.RegalList.Remove(item);
                    break;
                }
            }
        }
    }
}

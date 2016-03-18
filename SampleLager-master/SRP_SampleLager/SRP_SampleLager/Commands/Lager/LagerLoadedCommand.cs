using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SRP_SampleLager
{
    public class LagerLoadedCommand : CommandPattern
    {
        private readonly ILagerModel _viewModel;
        private readonly IRepository<ILagerModel> _repository;

        public LagerLoadedCommand(string Command, ILagerModel viewModel, IRepository<ILagerModel> repository)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (repository == null) throw new ArgumentNullException("repository");

            this._viewModel = viewModel;
            this._repository = repository;
        }

        public override void Execute()
        {
            Lagerraum selected;

            if (this._viewModel.isEditable)
                selected = this._viewModel.SelectedLager;
            else selected = null;

            this._viewModel.LagerList = new ObservableCollection<Lagerraum>();
            this._viewModel.RegalList = new ObservableCollection<TabItem>();
            this._viewModel.PlatzList = new ObservableCollection<Lagerplatz>();

            this._viewModel.LagerList.Add(new Lagerraum { id = -1, Gebaeude = "", Kommentar = "", Nummer = "" });

            this._repository.Select(_viewModel);

            if (selected == null)
                fill(-1);
            else fill(selected.id);
            this._viewModel.isEditable = false;
        }

        private void fill(int id)
        {
            this._viewModel.SelectedLager = this._viewModel.LagerList.First(x => x.id == id);
            this._viewModel.Gebaeude = this._viewModel.SelectedLager.Gebaeude;
            this._viewModel.Nummer = this._viewModel.SelectedLager.Nummer;
            this._viewModel.Kommentar = this._viewModel.SelectedLager.Kommentar;
            this._viewModel.FrameVisibility = Visibility.Hidden;
            this._viewModel.TabVisibility = Visibility.Visible;
        }
    }
}

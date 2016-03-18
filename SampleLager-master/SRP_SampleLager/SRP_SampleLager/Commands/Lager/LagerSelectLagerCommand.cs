using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SRP_SampleLager
{
    public class LagerSelectLagerCommand : CommandPattern
    {
        private readonly ILagerModel _viewModel;
        private IList<ILagerListViewModel> _listViews;
        private readonly IFactory<ILagerListViewModel> _factoryVM;
        private List<TabItem> regale;

        public LagerSelectLagerCommand(string Command, ILagerModel viewModel, IFactory<ILagerListViewModel> factoryVM)
            : base(Command)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (factoryVM == null) throw new ArgumentNullException("factoryVM");

            this._viewModel = viewModel;
            this._factoryVM = factoryVM;
        }

        public override void Execute()
        {
            this._viewModel.RegalList = new ObservableCollection<TabItem>();
            this.regale = new List<TabItem>();

            if (this._viewModel.SelectedLager == null || this._viewModel.SelectedLager.id == -1)
            {
                this.fill(this._viewModel.SelectedLager);
                return;
            }

            this.fill(this._viewModel.SelectedLager);
            this._listViews = new List<ILagerListViewModel>();
            var list = new List<string>();
            int index = 0;

            foreach (var item in this._viewModel.PlatzList.Where(x => x.Raum == this._viewModel.SelectedLager.id).ToList())
            {
                if (list.Contains(item.Ort))
                {
                    foreach (var tabs in this.regale)
                    {
                        if (tabs.Header.ToString() == item.Ort)
                        {
                            index = this._listViews.IndexOf(this._listViews.Where(x => x.Ort == item.Ort).ToList()[0]);
                            this._listViews[index].List.Add(item.ToString());
                        }
                    }
                    continue;
                }

                list.Add(item.Ort);
                this.createTab(item);
            }

            this.regale.Add(new TabItem { Header = "+" });
            this._viewModel.RegalList = new ObservableCollection<TabItem>(regale);
        }     
   
        private void fill(Lagerraum selected)
        {
            if (selected == null) return;
            this._viewModel.Gebaeude = selected.Gebaeude;
            this._viewModel.Nummer = selected.Nummer;
            this._viewModel.Kommentar = selected.Kommentar;
        }
        private void createTab(Lagerplatz lagerplatz)
        {
            try
            {
                this._listViews.Add(this._factoryVM.create(this._viewModel.SelectedLager.id));
                int i = this._listViews.Count - 1;
                regale.Add(new TabItem { Header = lagerplatz.Ort, Content = new Frame() { Content = new LagerListView() { DataContext = this._listViews[i] } } });
                this._listViews[i].Ort = lagerplatz.Ort;
                this._listViews[i].List = new List<string>();
                this._listViews[i].List.Add(lagerplatz.ToString());
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

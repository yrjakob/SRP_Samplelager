using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SRP_SampleLager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var MainWindow = new MainWindow();
            base.MainWindow = MainWindow;

            var mainCommands = new List<CommandPattern>();
            var mainModel = new MainModel();
            var mainViewModel = new MainViewModel(mainModel, mainCommands);
            MainWindow.DataContext = mainViewModel;
            
            var loginModel = new LoginModel();
            var loginRepository = new LoginRepository();
            var loginViewModel = new LoginViewModel(loginModel, loginRepository);

            var overviewCommands = new List<CommandPattern>();
            var overviewModel = new OverviewModel();
            var overviewRepository = new OverviewRepository();
            var overviewViewModel = new OverviewViewModel(overviewModel, overviewCommands);
            var overviewFactory = new OverviewFactory(overviewViewModel);

            var logModel = new LogModel();
            var logRepository = new LogRepository();
            var logViewModel = new LogViewModel(logModel, logRepository);
            var logFactory = new LogFactory(logViewModel);

            var exportModel = new ExportModel();
            var exportRepository = new ExportRepository();
            var exportViewModel = new ExportViewModel(exportModel, exportRepository);
            var exportFactory = new ExportFactory(exportViewModel);

            var lagerCommands = new List<CommandPattern>();
            var lagerModel = new LagerModel();
            var lagerRepository = new LagerRepository();
            var lagerViewModel = new LagerViewModel(lagerModel, lagerCommands);
            var lagerFactory = new LagerFactory(lagerViewModel);

            var buchungModel = new BuchungModel();
            var buchungRepository = new BuchungRepository();
            var buchungViewModel = new BuchungViewModel(buchungModel, buchungRepository);
            var buchungUebersichtFactory = new BuchungUebersichtFactory(buchungViewModel, overviewViewModel);
            var buchungFactory = new BuchungFactory(buchungViewModel, lagerViewModel);

            var musterModel = new MusterModel();
            var musterRepository = new MusterRepository();
            var musterViewModel = new MusterViewModel(musterModel, musterRepository);
            var musterUebersichtFactory = new MusterUebersichtFactory(musterViewModel, overviewViewModel);
                        
            var ortModel = new OrtModel();
            var ortRepository = new OrtRepository();
            var ortViewModel = new OrtViewModel(ortModel, ortRepository);
            var ortFactory = new OrtFactory(ortViewModel, lagerViewModel);
            
            var platzModel = new PlatzModel();
            var platzRepository = new PlatzRepository();
            var platzViewModel = new PlatzViewModel(platzModel, platzRepository);
            var platzFactory = new PlatzFactory(platzViewModel);

            var lagerListViewCommands = new List<CommandPattern>();
            var lagerListViewModel = new LagerListViewModel();
            var lagerListViewRepository = new LagerListViewRepository();
            var lagerListViewViewModel = new LagerListViewViewModel(lagerListViewModel, lagerListViewCommands);
            var lagerListViewFactory = new LagerListViewFactory(lagerListViewViewModel);
            var lagerListViewFactoryM = new LagerListViewFactoryM();
            var lagerListViewFactoryVM = new LagerListViewFactoryVM(lagerListViewFactoryM, lagerListViewRepository, ortFactory, lagerViewModel, buchungFactory, platzFactory);

            var editLagerModel = new EditLagerModel();
            var editLagerRepository = new EditLagerRepository();
            var editLagerViewModel = new EditLagerViewModel(editLagerModel, editLagerRepository, mainCommands);
            var editLagerFactory = new EditLagerFactory(editLagerViewModel);
                        
            var loginView = new LoginView();
            loginView.DataContext = loginViewModel;
            loginView.ShowDialog();
                        
            lagerCommands.Add(new LagerLoadedCommand("Loaded", lagerViewModel, lagerRepository));
            lagerCommands.Add(new LagerSelectLagerCommand("SelectLager", lagerViewModel, lagerListViewFactoryVM));
            lagerCommands.Add(new LagerNewOrtCommand("NewOrt", ortFactory));
            lagerCommands.Add(new LagerEditCommand("Edit", lagerViewModel, editLagerFactory));

            overviewCommands.Add(new OverviewLoadedCommand("Loaded", overviewViewModel, overviewRepository));
            overviewCommands.Add(new OverviewMusterCommand("Muster", mainViewModel, musterUebersichtFactory));
            overviewCommands.Add(new OverviewBuchungCommand("Buchung", mainViewModel, buchungUebersichtFactory));

            mainCommands.Add(new MainLoadedCommand("Loaded", mainViewModel, overviewFactory));
            mainCommands.Add(new MainLogoutCommand("Logout"));
            mainCommands.Add(new MainLogCommand("Log", mainViewModel, logFactory));
            mainCommands.Add(new MainExportCommand("Export", mainViewModel, exportFactory));
            mainCommands.Add(new MainLagerCommand("Lager", mainViewModel, lagerFactory));

            if (loginView.DialogResult.Value)
                MainWindow.ShowDialog();

            Environment.Exit(0);
        }
    }
}

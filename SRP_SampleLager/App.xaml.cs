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

            var buchungModel = new BuchungModel();
            var buchungRepository = new BuchungRepository();
            var buchungViewModel = new BuchungViewModel(buchungModel, buchungRepository);
            var buchungFactory = new BuchungFactory(buchungViewModel);

            var mainCommands = new List<CommandPattern>();
            var mainModel = new MainModel();
            var mainViewModel = new MainViewModel(mainModel, mainCommands);
            MainWindow.DataContext = mainViewModel;

            var loginView = new LoginView();
            loginView.DataContext = loginViewModel;
            loginView.ShowDialog();

            var mitarbeiterModel = new MitarbeiterModel();
            var mitarbeiterRepository = new MitarbeiterRepository();
            var mitarbeiterViewModel = new MitarbeiterViewModel(mitarbeiterModel, mitarbeiterRepository);
            var mitarbeiterFactory = new MitarbeiterFactory(mitarbeiterViewModel);

            var kundeModel = new KundeModel();
            var kundeRepository = new KundeRepository();
            var kundeViewModel = new KundeViewModel(kundeModel, kundeRepository);
            var kundeFactory = new KundeFactory(kundeViewModel);

            overviewCommands.Add(new OverviewLoadedCommand("Loaded", overviewViewModel, overviewRepository));
            overviewCommands.Add(new OverviewMusterCommand("Muster", mainViewModel));
            overviewCommands.Add(new OverviewBuchungCommand("Buchung", mainViewModel, buchungFactory));

            mainCommands.Add(new MainLoadedCommand("Loaded", mainViewModel, overviewFactory));
            mainCommands.Add(new MainLogoutCommand("Logout"));
            mainCommands.Add(new MainLogCommand("Log", mainViewModel, logFactory));
            mainCommands.Add(new MainExportCommand("Export", mainViewModel, exportFactory));
            mainCommands.Add(new MainMitarbeiterCommand("Mitarbeiter", mainViewModel, mitarbeiterFactory));
            mainCommands.Add(new MainKundeCommand("Kunde", mainViewModel, kundeFactory));

            if (loginView.DialogResult.Value)
                MainWindow.ShowDialog();

            Environment.Exit(0);
        }
    }
}

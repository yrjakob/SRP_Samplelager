using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class MainKundeCommand : CommandPattern
    {
        private readonly IMainModel _MainModel;
        private readonly IFactory<KundeView> _Factory;

        public MainKundeCommand(string Command, IMainModel MainModel, IFactory<KundeView> Factory)
            : base(Command)
        {
            if (MainModel == null)
                throw new ArgumentNullException("MainModel");

            if (Factory == null)
                throw new ArgumentNullException("Factory");

            _MainModel = MainModel;
            _Factory = Factory;
        }

        public override void Execute()
        {
            _MainModel.Frame = null;
            _MainModel.Frame = _Factory.create();
        }
    }
}

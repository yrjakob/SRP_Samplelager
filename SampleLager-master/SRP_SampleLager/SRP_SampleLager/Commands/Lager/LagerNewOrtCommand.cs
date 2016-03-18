using System;
using System.Collections.Generic;
using System.Linq;

namespace SRP_SampleLager
{
    public class LagerNewOrtCommand : CommandPattern
    {
        private readonly IFactory<OrtView> _factory;

        public LagerNewOrtCommand(string Command, IFactory<OrtView> factory)
            : base(Command)
        {
            if (factory == null) throw new ArgumentNullException("factory");

            this._factory = factory;
        }

        public override void Execute()
        {
            this._factory.create().ShowDialog();
        }
    }
}

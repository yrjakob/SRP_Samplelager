using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP_SampleLager
{
    public abstract class CommandPattern
    {
        private readonly string _Command;

        public CommandPattern(string Command)
        {
            _Command = Command;
        }

        public abstract void Execute();

        public string Command
        {
            get { return _Command; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRP_SampleLager
{
    public class MainLogoutCommand : CommandPattern
    {
        public MainLogoutCommand(string Command)
            : base(Command)
        { }

        public override void Execute()
        {
            Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }
    }
}

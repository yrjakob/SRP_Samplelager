using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public interface ILogModel : ILog
    {
        DateTime Von { get; set; }
        DateTime Bis { get; set; }
        IList<string> UsernameList { get; set; }
        IList<string> ActionList { get; set; }
        IList<ILog> LogList { get; set; }
        IList<ILog> gesamteList { get; set; }
    }

    public interface ILog
    {
        string Username { get; set; }
        string Action { get; set; }
        DateTime Datum { get; set; }
    }
}

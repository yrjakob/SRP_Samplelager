using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class LogModel : ILogModel
    {
        public LogModel()
        {
            Von = DateTime.Today.Date;
            Bis = DateTime.Today.Date;
        }

        public bool Zeitraum { get; set; }
        public bool IsVonEnabled { get; set; }
        public bool IsBisEnabled { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public IList<string> UsernameList { get; set; }
        public IList<string> ActionList { get; set; }
        public IList<ILog> LogList { get; set; }
        public IList<ILog> gesamteList { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public DateTime Datum { get; set; }
    }

    public class Log : ILog
    {
        public string Username { get; set; }
        public string Action { get; set; }
        public DateTime Datum { get; set; }
    }
}

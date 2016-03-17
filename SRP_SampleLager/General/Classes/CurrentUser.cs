using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP_SampleLager
{
    public class CurrentUser
    {
        private static CurrentUser _instance;

        private CurrentUser()
        { }

        public string User { get; set; }
        public long Id { get; set; }
        public long Ansprechpartner { get; set; }
        public string Rechte { get; set; }
        public bool Gesperrt { get; set; }

        public static CurrentUser getInstance()
        {
            if (_instance == null)
                _instance = new CurrentUser();
            return _instance;
        }
    }
}

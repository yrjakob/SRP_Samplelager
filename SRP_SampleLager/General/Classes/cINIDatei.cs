using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace SRP_SampleLager
{
    public static class cINIDatei
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
          string key, string def, StringBuilder retVal,
          int size, string filePath);

        //Read a key value from the config.ini file
        public static string IniReadValue(string section, string Key)
        {
            string path = Directory.GetCurrentDirectory() + "\\General\\Resources\\config.ini";

            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, Key, "", temp, 255, path);
            return temp.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.DirectoryServices;
using System.Windows;

namespace SRP_SampleLager
{
    //written by Michael Weigert (personell number: 5095)
    public class AD_Access
    {
        //Test
        private static int personalnummer;
        private static string eMail;
        private static List<string> name;
        private static string telefonnummer;

        public static bool? admin;

        /// <summary>
        /// Method to find out which use right a person has
        /// </summary>
        /// <param name="winLogin">Windows Login Name</param>
        /// <returns>True, if person is an administrator</returns>
        /// <returns>False, if person is a program user</returns>
        /// <returns>Null, if person has no use rights</returns>
        /// 
        //Benutzer der erstellt werden soll auf existens überprüfen
        public static bool isUser(string WinLogin)
        {
            try
            {
                System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(cINIDatei.IniReadValue("LDAP", "ActiveDirectoryPath"));
                System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(entry);
                string LDAPSearchString = "(&(objectCategory=person)(sAMAccountName=" + WinLogin + "))";
                mySearcher.Filter = (LDAPSearchString);

                foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
                {
                    System.DirectoryServices.DirectoryEntry de = resEnt.GetDirectoryEntry();

                    string strString = de.Properties["Mail"].Value.ToString();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        //Überprüfen ob die Login Daten des Benutzers richtig sind | Von Gmach Christoph
        public static bool isUser(string username, string password)
        {
            SecureString pwd = new SecureString();
            DirectoryEntry entry = null;
            //Test
            DirectorySearcher mySearcher = new DirectorySearcher(entry);

            //Durchläuft das Passwort und hänge es dem SecureString an
            foreach (char c in password) pwd.AppendChar(c);

            //Bewirkt, dass das Passwort nicht mehr verändert werden kann
            pwd.MakeReadOnly();

            //Passwort wird einem Pointer übergeben, damit dieser später "entschlüsselt" werden kann
            IntPtr pPwd = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(pwd);

            try
            {
                entry = new DirectoryEntry(string.Concat(@"LDAP://", "MDOM1"/*domain*/), username, System.Runtime.InteropServices.Marshal.PtrToStringBSTR(pPwd));
                string LDAPSearchString = "(&(objectCategory=person)(sAMAccountName=" + username + "))";
                mySearcher.Filter = (LDAPSearchString);

                //Test
                foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
                {
                    System.DirectoryServices.DirectoryEntry de = resEnt.GetDirectoryEntry();

                    personalnummer = Convert.ToInt32(de.Properties["Pager"].Value);
                    eMail = de.Properties["Mail"].Value.ToString();
                    name = de.Properties["cn"].Value.ToString().Split(' ').ToList<string>();
                    telefonnummer = de.Properties["TelephoneNumber"].Value.ToString();
                }

                object nativeObject = entry.NativeObject;
                admin = true;
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Login failure",
                //                MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                admin = false;
                return false;
            }
            finally
            {
                entry.Close();
                entry.Dispose();
            }
        }

        #region getter|setter
        public static int Personalnummer
        {
            get { return personalnummer; }
        }

        public static string EMail
        {
            get { return eMail; }
        }

        public static List<string> Name
        {
            get { return name; }
        }
        #endregion
    }
}
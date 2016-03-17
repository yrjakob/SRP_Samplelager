using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace SRP_SampleLager
{
    static class DBAccess
    {
        private static SqlConnection _mSqlCon;
        
        //indicates if the database is open 
        private static bool _mDbOpen;

        #region db access member
        private static string _mDataSource = "sv-mssql-svr";
        private static string _mDatabase = "ASRP_TMS";
        private static string _mUserId = "root";
        private static string _mUserPass = "roding2012";
        #endregion

        public static bool openDB()
        {
            try
            {
                String strProvider = "SERVER = " + _mDataSource + "; Database = " + _mDatabase + "; User Id = " + _mUserId + "; Password = " + _mUserPass;
                _mSqlCon = new SqlConnection(strProvider);
                _mSqlCon.Open();
                _mDbOpen = true;

                return true;
            }

            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        throw (new DBException("Cannot connect to server.  Contact administrator"));

                    case 1045:
                        throw (new DBException("Invalid username/password, please try again"));

                    default:
                        throw (new DBException(ex.Message));
                }
            }
            catch (Exception ex)
            {
                throw (new DBException(ex.Message + " - Unknown Exception"));
            }
        }
        public static bool closeDB()
        {
            try
            {
                _mSqlCon.Close();
                _mDbOpen = false;
            }
            catch (MySqlException ex)
            {
                throw (new DBException(ex.Message));
            }
            catch (Exception ex)
            {
                throw (new DBException(ex.Message));
            }

            return true;
        }

        #region getter

        public static SqlConnection mSqlCon
        {
            get { return _mSqlCon; }
        }

        public static bool mDbOpen
        {
            get { return _mDbOpen; }
        }
        #endregion
    }

    public class DBException : ApplicationException
    {
        public DBException(string message)
            : base(message)
        {
        }
    }
}

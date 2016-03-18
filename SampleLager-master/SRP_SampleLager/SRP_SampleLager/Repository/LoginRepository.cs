using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace SRP_SampleLager
{
    public class LoginRepository : IRepository<ILoginModel>
    {
        public void Select(ILoginModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                viewModel.inDb = dbSelect(viewModel.Username);
                DBAccess.closeDB();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Insert(ILoginModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                dbInsert();
                DBAccess.closeDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Update(ILoginModel viewModel)
        {
            throw new NotImplementedException();
        }
        public void Delete(ILoginModel viewModel)
        {
            throw new NotImplementedException();
        }
        public void findById(ILoginModel viewModel)
        {
            throw new NotImplementedException();
        }

        #region db
        private bool dbSelect(String user)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT pk_user " +
                        ", fk_Mitarbeiter" +
                        ", rechte " +
                        ", mbuser" +
                        ", gesperrt" +
                        " FROM [dbo].[MBUser] WHERE MBUser='" + user + "';";

            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = DBAccess.mSqlCon;
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command = connection.CreateCommand();
                command.CommandText = sSql;

                reader = command.ExecuteReader();

                reader.Read();
                if (!reader.HasRows)
                {
                    MessageBox.Show("Sie sind nicht berechtigt, dieses Programm zu benutzen.", "Keine Berechtigung", MessageBoxButton.OK, MessageBoxImage.Error);
                    rw = false;
                }
                else
                {
                    CurrentUser.getInstance().Id = Convert.ToInt32(reader["pk_user"]);
                    //CurrentUser.getInstance().Id = reader.GetInt32(reader.GetOrdinal("pk_user"));
                    CurrentUser.getInstance().Ansprechpartner = reader.GetInt32(reader.GetOrdinal("fk_mitarbeiter"));
                    CurrentUser.getInstance().Rechte = reader["rechte"].ToString();
                    CurrentUser.getInstance().User = reader["mbuser"].ToString();
                    CurrentUser.getInstance().Gesperrt = reader["gesperrt"].ToString() == "0" ? false : true;
                    rw = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Sql Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unknown Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                ///cleaning!
                reader.Dispose();
                command.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return rw;
        }
        private bool dbInsert()
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "INSERT INTO [dbo].[log] (FK_User, Aktion, Datum) VALUES('" + CurrentUser.getInstance().Id + "', 'Login', '" + DateTime.Today + "');";

            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = DBAccess.mSqlCon;
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command = connection.CreateCommand();
                command.CommandText = sSql;
                command.ExecuteNonQuery();

                rw = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Sql Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unknown Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                ///cleaning!
                command.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return rw;
        } 
        #endregion
    }
}

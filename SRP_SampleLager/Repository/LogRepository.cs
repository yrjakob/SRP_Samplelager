using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SRP_SampleLager
{
    public class LogRepository : IRepository<ILogModel>
    {
        public void Select(ILogModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                dbSelect(viewModel);
                DBAccess.closeDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Insert(ILogModel viewModel)
        {
            MessageBox.Show("Insert einbauen", "LogRepository", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Update(ILogModel viewModel)
        {
            MessageBox.Show("Update einbauen", "LogRepository", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Delete(ILogModel viewModel)
        {
            MessageBox.Show("Delete einbauen", "LogRepository", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void findById(ILogModel viewModel)
        {
            MessageBox.Show("findById einbauen", "LogRepository", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool dbSelect(ILogModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT l.*, u.MBUser FROM [dbo].[log] l " +
                   "JOIN [dbo].[MBUser] u ON u.PK_User = l.FK_User";

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

                if (!reader.HasRows)
                {
                    rw = false;
                }
                else
                {
                    while (reader.Read())
                    {
                        Log l = new Log();
                        l.Username = reader.GetString(reader.GetOrdinal("MBUser"));
                        l.Action = reader.GetString(reader.GetOrdinal("Aktion"));
                        l.Datum = reader.GetDateTime(reader.GetOrdinal("Datum"));

                        viewModel.LogList.Add(l);

                        if(!viewModel.UsernameList.Contains(l.Username))
                            viewModel.UsernameList.Add(l.Username);

                        if (!viewModel.ActionList.Contains(l.Action))
                            viewModel.ActionList.Add(l.Action);
                    }

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
    }
}

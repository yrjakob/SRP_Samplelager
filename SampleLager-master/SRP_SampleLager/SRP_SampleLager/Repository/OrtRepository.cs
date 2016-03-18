using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SRP_SampleLager
{
    public class OrtRepository : IRepository<IOrtModel>
    {
        public void Select(IOrtModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Insert(IOrtModel viewModel)
        {
            DBAccess.openDB();
            dbInsert(viewModel);
            DBAccess.closeDB();
        }
        public void Update(IOrtModel viewModel)
        {
            DBAccess.openDB();
            dbUpdate(viewModel);
            DBAccess.closeDB();
        }

        public void Delete(IOrtModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void findById(IOrtModel viewModel)
        {
            throw new NotImplementedException();
        }

        private bool dbInsert(IOrtModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "INSERT INTO [dbo].[lagerplatz] (Menge, Ort, Platz, FK_Raum, Gesperrt) VALUES(0, '" + viewModel.Ort + 
                   "', 'kein Platz zugewiesen', " + viewModel.RaumId + ", 0);";

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
        public static bool dbUpdate(IOrtModel viewModel)
        {
            bool rw = false;

            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlTransaction transaction = null;

            String sSql = "UPDATE [ASRP_TMS].[dbo].[lagerplatz] " +
                          "SET Ort='" + viewModel.Ort + "' " +
                          "WHERE Ort='" + viewModel.oldOrt + "' AND FK_Raum=" + viewModel.RaumId + " AND Gesperrt=0";

            try
            {
                connection = DBAccess.mSqlCon;
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                transaction = connection.BeginTransaction();

                cmd = connection.CreateCommand();

                cmd.Transaction = transaction;
                cmd.CommandText = sSql;
                cmd.ExecuteNonQuery();

                transaction.Commit();

                rw = true;
            }

            //MySQL exception
            catch (SqlException ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (SqlException ex2)
                {
                    if (transaction.Connection != null)
                    {
                        MessageBox.Show(ex2.Message, ex2.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //other exception
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (SqlException ex)
                {
                    if (transaction.Connection != null)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                MessageBox.Show(e.Message, e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //cleaning!
                transaction.Dispose();
                cmd.Dispose();

                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }

            return rw;
        }
    }
}

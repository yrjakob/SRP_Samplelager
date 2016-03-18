using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SRP_SampleLager
{
    public class LagerListViewRepository : IRepository<ILagerListViewModel>
    {
        public void Select(ILagerListViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Insert(ILagerListViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(ILagerListViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(ILagerListViewModel viewModel)
        {
            DBAccess.openDB();
            dbDelete(viewModel.Ort, viewModel.RaumId);
            DBAccess.closeDB();
        }

        public void findById(ILagerListViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public static bool dbDelete(string ort, int id)
        {
            bool rw = false;

            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlTransaction transaction = null;

            String sSql = "UPDATE [dbo].[lagerplatz] " +
                          "SET Gesperrt=1 " +
                          "WHERE Ort='" + ort + "' AND FK_Raum=" + id + "AND Gesperrt=0";

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

                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

            return rw;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SRP_SampleLager
{
    public class EditLagerRepository : IRepository<IEditLagerModel>
    {
        public void Select(IEditLagerModel viewModel)
        {
            DBAccess.openDB();
            dbSelect(viewModel);
            DBAccess.closeDB();
        }
        public void Insert(IEditLagerModel viewModel)
        {
            DBAccess.openDB();
            dbInsert(viewModel);
            DBAccess.closeDB();
        }
        public void Update(IEditLagerModel viewModel)
        {
            DBAccess.openDB();
            dbUpdate(viewModel);
            DBAccess.closeDB();
        }
        public void Delete(IEditLagerModel viewModel)
        {
            DBAccess.openDB();
            dbDelete(viewModel.id);
            DBAccess.closeDB();
        }

        public void findById(IEditLagerModel viewModel)
        {
            throw new NotImplementedException();
        }

        private bool dbSelect(IEditLagerModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT * FROM [dbo].[lagerraum] WHERE Gesperrt=0";

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
                        EditLager e = new EditLager();
                        e.id = reader.GetInt32(reader.GetOrdinal("PK_Lagerraum"));
                        e.Gebaeude = reader.GetString(reader.GetOrdinal("Gebaeude"));
                        e.Nummer = reader.GetString(reader.GetOrdinal("Nummer"));
                        e.Kommentar = reader.GetString(reader.GetOrdinal("Kommentar"));

                        viewModel.LagerList.Add(e);
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
        private bool dbInsert(IEditLagerModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "INSERT INTO [dbo].[lagerraum] " +
                   "(Gebaeude, Nummer, Kommentar, Gesperrt) " +
                   "VALUES('" + viewModel.Gebaeude + "', '" + viewModel.Nummer + "', '" + viewModel.Kommentar + "', 0);";

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
        public static bool dbUpdate(IEditLagerModel viewModel)
        {
            bool rw = false;

            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlTransaction transaction = null;

            String sSql = "UPDATE [ASRP_TMS].[dbo].[lagerraum] " +
                          "SET Gebaeude='" + viewModel.Gebaeude + "', " +
                          "Nummer='" + viewModel.Nummer + "', " +
                          "Kommentar='" + viewModel.Kommentar + "' " +
                          "WHERE PK_Lagerraum = " + viewModel.id;

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
        public static bool dbDelete(int id)
        {
            bool rw = false;

            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlTransaction transaction = null;

            String sSql = "UPDATE [ASRP_TMS].[dbo].[lagerraum] " +
                          "SET Gesperrt=1 " +
                          "WHERE PK_Lagerraum = " + id;

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

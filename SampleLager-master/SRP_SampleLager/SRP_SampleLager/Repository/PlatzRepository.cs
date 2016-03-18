using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SRP_SampleLager
{
    public class PlatzRepository : IRepository<IPlatzModel>
    {
        public void Select(IPlatzModel viewModel)
        {
            DBAccess.openDB();
            dbSelect(viewModel);
            DBAccess.closeDB();
        }
        public void Insert(IPlatzModel viewModel)
        {
            DBAccess.openDB();
            dbInsert(viewModel);
            DBAccess.closeDB();
        }
        public void Update(IPlatzModel viewModel)
        {
            DBAccess.openDB();
            //
            DBAccess.closeDB();
        }

        public void Delete(IPlatzModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void findById(IPlatzModel viewModel)
        {
            DBAccess.openDB();
            dbFindy(viewModel);
            DBAccess.closeDB();
        }

        private bool dbFindy(IPlatzModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT FK_Raum FROM [dbo].[lagerplatz] WHERE PK_Lagerplatz=" + viewModel.id + " AND Gesperrt=0";

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
                        viewModel.RaumId = reader.GetInt32(reader.GetOrdinal("FK_Raum"));
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
        private bool dbSelect(IPlatzModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT PK_Lagerplatz, Platz FROM [dbo].[lagerplatz] WHERE Ort='" + viewModel.Ort + "' AND Gesperrt=0";

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
                        Platz p = new Platz();
                        p.id = reader.GetInt32(reader.GetOrdinal("PK_Lagerplatz"));
                        p.PlatzName = reader.GetString(reader.GetOrdinal("Platz"));

                        viewModel.PlatzList.Add(p);
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
        private bool dbInsert(IPlatzModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "INSERT INTO [dbo].[lagerplatz] (Menge, Ort, Platz, FK_Raum, Gesperrt) " +
                   "VALUES(0, '" + viewModel.Ort + "', '" + viewModel.PlatzName + "', " + viewModel.RaumId + ", 0);";

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
        public static bool dbUpdate(int id, int anzahl)
        {
            bool rw = false;

            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlTransaction transaction = null;

            String sSql = "UPDATE [ASRP_TMS].[dbo].[lagerplatz] " +
                          "SET Menge=" + anzahl + " " +
                          "WHERE PK_Lagerplatz = " +
                          "(SELECT FK_Lager FROM [ASRP_TMS].[dbo].[muster_lager] " +
                          "WHERE PK_Muster_Lager=" + id + ")";

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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SRP_SampleLager
{
    public class LagerRepository : IRepository<ILagerModel>
    {
        public void Select(ILagerModel viewModel)
        {
            DBAccess.openDB();
            dbSelectRaum(viewModel);
            dbSelectPlatz(viewModel);
            DBAccess.closeDB();
        }

        public void Insert(ILagerModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(ILagerModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(ILagerModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void findById(ILagerModel viewModel)
        {
            throw new NotImplementedException();
        }

        private bool dbSelectRaum(ILagerModel viewModel)
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
                        Lagerraum l = new Lagerraum();
                        l.id = reader.GetInt32(reader.GetOrdinal("PK_Lagerraum"));
                        l.Gebaeude = reader.GetString(reader.GetOrdinal("Gebaeude"));
                        l.Nummer = reader.GetString(reader.GetOrdinal("Nummer"));
                        l.Kommentar = reader.GetString(reader.GetOrdinal("Kommentar"));

                        viewModel.LagerList.Add(l);
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
        private bool dbSelectPlatz(ILagerModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT * FROM [dbo].[lagerplatz] WHERE Gesperrt=0";

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
                        Lagerplatz l = new Lagerplatz();
                        l.id = reader.GetInt32(reader.GetOrdinal("PK_Lagerplatz"));
                        l.Ort = reader.GetString(reader.GetOrdinal("Ort"));
                        l.Platz = reader.GetString(reader.GetOrdinal("Platz"));
                        l.Raum = reader.GetInt32(reader.GetOrdinal("FK_Raum"));

                        viewModel.PlatzList.Add(l);
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

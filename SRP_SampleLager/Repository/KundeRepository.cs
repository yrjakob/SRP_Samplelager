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
    public class KundeRepository : IRepository<IKundeModel>
    {

        public void Select(IKundeModel viewModel)
        {
            DBAccess.openDB();
            dbSelect(viewModel);
            dbSelectTitel(viewModel);
            DBAccess.closeDB();
        }

        public void Insert(IKundeModel viewModel)
        {
            DBAccess.openDB();
            dbSelect(viewModel);
            DBAccess.closeDB();
        }

        public void Update(IKundeModel viewModel)
        {

        }

        public void Delete(IKundeModel viewModel)
        {

        }

        public void findById(IKundeModel viewModel)
        {

        }
        private bool dbSelect(IKundeModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT *FROM [ASRP_TMS].[dbo].[kunde]";

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
                        Kunde o = new Kunde();
                        o.Firma = reader.GetString(reader.GetOrdinal("Firma"));
                        o.Straße = reader.GetString(reader.GetOrdinal("Ort"));
                        o.Hausnummer = reader.GetString(reader.GetOrdinal("Ort"));
                        o.Postleitzahl = reader.GetString(reader.GetOrdinal("Ort"));
                        o.Ort = reader.GetString(reader.GetOrdinal("Ort"));
                        o.Land = reader.GetString(reader.GetOrdinal("Land"));
                        o.Titel = reader.GetString(reader.GetOrdinal("Ansprechpartner"));
                        o.Ansprechpartner = reader.GetString(reader.GetOrdinal("Ansprechpartner"));
                        o.Telefon = reader.GetString(reader.GetOrdinal("Kontakt"));
                        o.Email = reader.GetString(reader.GetOrdinal("eMail"));
                        if (reader["Komentar"] != DBNull.Value)
                        {
                            o.Kommentar = reader.GetString(reader.GetOrdinal("Komentar"));
                        }
                        else { o.Kommentar = ""; }
                        

                        viewModel.KundeListe.Add(o);
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

        private bool dbSelectTitel(IKundeModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT *FROM [ASRP_TMS].[dbo].[Anrede]";

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
                        Anrede o = new Anrede();
                        o.ID = reader.GetInt32(reader.GetOrdinal("PK_Anrede"));
                        o.Titel = reader.GetString(reader.GetOrdinal("Titel"));

                        viewModel.AnredeListe.Add(o);
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
                
                MessageBox.Show(ex.Message, "Sql Execption", MessageBoxButton.OK, MessageBoxImage.Error);
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

    }
}

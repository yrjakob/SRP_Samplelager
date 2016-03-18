using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SRP_SampleLager
{
    public class MusterRepository : IRepository<IMusterModel>
    {
        public void Select(IMusterModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                dbSelectAnsprechpartner(viewModel);
                dbSelectKunde(viewModel);
                dbSelect(viewModel);
                DBAccess.closeDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Insert(IMusterModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                dbInsert(viewModel);
                dbInsertLog("Muster erstellt");
                DBAccess.closeDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Update(IMusterModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                dbUpdate(viewModel);
                dbInsertLog("Muster geändert");
                DBAccess.closeDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Delete(IMusterModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                dbDelete(viewModel.id);
                dbInsertLog("Muster gelöscht");
                DBAccess.closeDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void findById(IMusterModel viewModel)
        {
            throw new NotImplementedException();
        }

        private bool dbSelect(IMusterModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT m.*, k.Firma, mit.Nachname, mit.Vorname " +
                   "FROM [dbo].[muster] m, [dbo].[kunde] k, [dbo].[mitarbeiter] mit " +
                   "WHERE m.Gesperrt=0 AND k.PK_Kunde = m.FK_Kunde AND mit.PK_Mitarbeiter = m.FK_Ansprechpartner AND m.Gesperrt=0";

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
                        Muster m = new Muster();
                        m.id = reader.GetInt32(reader.GetOrdinal("PK_Muster"));
                        m.Name = reader.GetString(reader.GetOrdinal("MusterName"));
                        m.Zweck = reader.GetString(reader.GetOrdinal("Zweck"));
                        m.Eingangsdatum = reader.GetDateTime(reader.GetOrdinal("EingangDatum"));
                        m.Ausgangsdatum = reader.GetDateTime(reader.GetOrdinal("AusgangDatum"));
                        m.Referenznummer = reader.GetString(reader.GetOrdinal("Auftrag_Referenz_Nr"));
                        m.Kunde = reader.GetString(reader.GetOrdinal("Firma"));
                        m.Kundeneigentum = reader.GetInt16(reader.GetOrdinal("Kundeneigentum")) == 0 ? true : false;
                        m.Rücksendung = reader.GetInt16(reader.GetOrdinal("Rücksendung")) == 0 ? true : false;
                        m.Ansprechpartner = reader.GetString(reader.GetOrdinal("Vorname")) + " " + reader.GetString(reader.GetOrdinal("Nachname"));
                        m.Gesamtmenge = reader.GetInt32(reader.GetOrdinal("Gesamtmenge"));

                        viewModel.MusterList.Add(m);
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
        private bool dbSelectKunde(IMusterModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT PK_Kunde, Firma " +
                   "FROM [dbo].[kunde] " +
                   "WHERE Gesperrt=0";

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
                        KundeMuster k = new KundeMuster();
                        k.id = reader.GetInt32(reader.GetOrdinal("PK_Kunde"));
                        k.Kunde = reader.GetString(reader.GetOrdinal("Firma"));

                        viewModel.KundeList.Add(k);
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
        private bool dbSelectAnsprechpartner(IMusterModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT PK_Mitarbeiter, Nachname, Vorname " +
                   "FROM [dbo].[mitarbeiter] " +
                   "WHERE Gesperrt=0";

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
                        AnsprechpartnerMuster a = new AnsprechpartnerMuster();
                        a.id = reader.GetInt32(reader.GetOrdinal("PK_Mitarbeiter"));
                        a.Ansprechpartner = reader.GetString(reader.GetOrdinal("Vorname")) + " " + reader.GetString(reader.GetOrdinal("Nachname"));

                        viewModel.AnsprechpartnerList.Add(a);
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

        private bool dbInsert(IMusterModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            int kundeneigentum = viewModel.Kundeneigentum ? 0 : 1;
            int ruecksendung = viewModel.Rücksendung ? 0 : 1;

            sSql = "INSERT INTO [ASRP_TMS].[dbo].[muster] "+
                   "(MusterName, Zweck, EingangDatum, AusgangDatum, Auftrag_Referenz_Nr, FK_Kunde, Kundeneigentum, Rücksendung, FK_Ansprechpartner, Gesamtmenge) " +
                   "VALUES ('" + viewModel.Name + "', '" + viewModel.Zweck + "', '" + viewModel.Eingangsdatum + "', '" + viewModel.Ausgangsdatum + 
                   "', '" + viewModel.Referenznummer + "', " + viewModel.SelectedKunde.id + ", " + viewModel.Kundeneigentum + ",  " + viewModel.Rücksendung + 
                   ", " + viewModel.SelectedAnsprechpartner.id + ", " + viewModel.Gesamtmenge + ")";

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

        public static bool dbUpdate(IMusterModel viewModel)
        {
            bool rw = false;

            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlTransaction transaction = null;

            String sSql = "UPDATE [ASRP_TMS].[dbo].[muster] " +
                          "SET Zweck='" + viewModel.Zweck + "', " +
                          "Auftrag_Referenz_Nr='" + viewModel.Referenznummer + "', " +
                          "Kundeneigentum=" + (viewModel.Kundeneigentum ? 0 : 1) + ", " +
                          "Rücksendung=" + (viewModel.Rücksendung ? 0 : 1) + ", " +
                          "AusgangDatum='" + viewModel.Ausgangsdatum + "', " +
                          "EingangDatum='" + viewModel.Eingangsdatum + "', " +
                          "FK_Ansprechpartner=" + viewModel.SelectedAnsprechpartner.id + ", " +
                          "FK_Kunde=" + viewModel.SelectedKunde.id + ", " +
                          "MusterName='" + viewModel.Name + "', " +
                          "Gesamtmenge=" + viewModel.Gesamtmenge + " " +
                          "WHERE PK_Muster = " + viewModel.id;

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

            String sSql = "UPDATE [dbo].[muster] " +
                          "SET Gesperrt=1 " +
                          "WHERE PK_Muster=" + id;

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

        // Log
        private bool dbInsertLog(string Aktion)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "INSERT INTO [ASRP_TMS].[dbo].[log] " +
                   "(FK_User, AKtion, Datum) " +
                   "VALUES ((SELECT PK_User FROM [ASRP_TMS].[dbo].[MBUser] WHERE MBUser='" + CurrentUser.getInstance().User + "', " +
                   "'" + Aktion + "', '" + DateTime.Now + "')";

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
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace SRP_SampleLager
{
    public class BuchungRepository : IRepository<IBuchungModel>
    {
        public void Select(IBuchungModel viewModel)
        {
            dbSelectMuster(viewModel);

            // Abfragen nach isLager
            if (!viewModel.isLager)
            {
                try
                {
                    DBAccess.openDB();
                    dbSelect(viewModel);
                    dbSelectUebersicht(viewModel);
                    DBAccess.closeDB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                DBAccess.openDB();
                dbSelectLager(viewModel);
                DBAccess.closeDB();
            }
        }

        public void Insert(IBuchungModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(IBuchungModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                dbUpdate(viewModel.LagerId, viewModel.Anzahl);
                DBAccess.closeDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Delete(IBuchungModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                dbDelete(viewModel.MusterLagerId);
                DBAccess.closeDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void findById(IBuchungModel viewModel)
        {
            throw new NotImplementedException();
        }

        #region db
        private bool dbSelect(IBuchungModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT ml.*, lp.Menge, m.MusterName FROM [ASRP_TMS].[dbo].[muster_lager] ml " +
                   "JOIN [ASRP_TMS].[dbo].[muster] m ON m.PK_Muster = ml.FK_Muster " +
                   "JOIN [ASRP_TMS].[dbo].[lagerplatz] lp ON lp.PK_Lagerplatz = ml.FK_Lager " +
                   "WHERE Gesperrt=0 AND PK_Muster_Lager = " + viewModel.MusterLagerId;

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
                        Buchung b = new Buchung();
                        b.Anzahl = Convert.ToInt32(reader.GetString(reader.GetOrdinal("Menge")));
                        b.Muster = reader.GetString(reader.GetOrdinal("MusterName"));

                        viewModel.MusterList.Add(b);
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
        private bool dbSelectUebersicht(IBuchungModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT m.*, lr.*, lp.*, k.Firma, mit.[Vorname], mit.[Nachname] FROM [ASRP_TMS].[dbo].[muster_lager] ml " +
                   "JOIN [ASRP_TMS].[dbo].[muster] m ON m.[PK_Muster] = ml.[FK_Muster] " +
                   "JOIN [ASRP_TMS].[dbo].[lagerplatz] lp ON lp.[PK_Lagerplatz] = ml.[FK_Lager] " +
                   "JOIN [ASRP_TMS].[dbo].[lagerraum] lr ON  lr.[PK_Lagerraum] = " +
                   "(SELECT FK_Raum FROM [ASRP_TMS].[dbo].[muster_lager] " +
                   "JOIN [ASRP_TMS].[dbo].[lagerplatz] ON [ASRP_TMS].[dbo].[lagerplatz].PK_Lagerplatz = [ASRP_TMS].[dbo].[muster_lager].FK_Lager) " +
                   "JOIN [ASRP_TMS].[dbo].[kunde] k ON k.PK_Kunde =  " +
                   "(SELECT FK_Kunde FROM [ASRP_TMS].[dbo].[muster_lager] " +
                   "JOIN [ASRP_TMS].[dbo].[muster] ON [ASRP_TMS].[dbo].[muster].PK_Muster = [ASRP_TMS].[dbo].[muster_lager].FK_Muster) " +
                   "JOIN [ASRP_TMS].[dbo].[mitarbeiter] mit ON mit.PK_Mitarbeiter = " +
                   "(SELECT FK_Ansprechpartner FROM [ASRP_TMS].[dbo].[muster_lager] " +
                   "JOIN [ASRP_TMS].[dbo].[muster] ON [ASRP_TMS].[dbo].[muster].PK_Muster = [ASRP_TMS].[dbo].[muster_lager].FK_Muster) " +
                   "WHERE Gesperrt=0 AND PK_Muster_Lager = " + viewModel.MusterLagerId;

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
                        #region Lagerort
                        string gebaeude = reader.GetString(reader.GetOrdinal("Gebaeude"));
                        string nummer = reader.GetString(reader.GetOrdinal("Nummer"));
                        string ort = reader.GetString(reader.GetOrdinal("Ort"));
                        string platz = reader.GetString(reader.GetOrdinal("Platz"));
                        #endregion

                        //viewModel.SelectedMuster.Name = reader.GetString(reader.GetOrdinal("MusterName"));
                        //viewModel.Muster = reader.GetString(reader.GetOrdinal("MusterName"));
                        viewModel.Menge = reader.GetInt32(reader.GetOrdinal("Gesamtmenge"));
                        viewModel.Eingang = reader.GetDateTime(reader.GetOrdinal("EingangDatum"));
                        viewModel.Ausgang = reader.GetDateTime(reader.GetOrdinal("AusgangDatum"));
                        viewModel.Zweck = reader.GetString(reader.GetOrdinal("Zweck"));
                        viewModel.Kunde = reader.GetString(reader.GetOrdinal("Firma"));
                        viewModel.Kundeneigentum = (reader.GetInt16(reader.GetOrdinal("Kundeneigentum"))) == 0 ? "Ja" : "Nein";
                        viewModel.Ruecksendung = (reader.GetInt16(reader.GetOrdinal("Rücksendung"))) == 0 ? "Ja" : "Nein";
                        viewModel.Referenznummer = (reader.GetString(reader.GetOrdinal("Auftrag_Referenz_Nr")));
                        viewModel.Ansprechpartner = reader.GetString(reader.GetOrdinal("Vorname")) + " " + reader.GetString(reader.GetOrdinal("Nachname"));
                        viewModel.Lagerplatz = gebaeude + " " + nummer + " " + ort + " " + platz;
                        viewModel.Anzahl = Convert.ToInt32(reader.GetString(reader.GetOrdinal("Menge")));
                        viewModel.Artikel = reader.GetString(reader.GetOrdinal("MusterName"));
                        viewModel.Name = viewModel.Artikel;
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
        private bool dbSelectMuster(IBuchungModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT m.*, k.Firma, mit.Nachname, mit.Vorname " +
                   "FROM [dbo].[muster] m, [dbo].[kunde] k, [dbo].[mitarbeiter] mit " +
                   "WHERE m.Gesperrt=0 AND k.Gesperrt=0 AND mit.Gesperrt=0 " +
                   "AND m.FK_Kunde = k.PK_Kunde AND m.FK_Ansprechpartner = mit.PK_Mitarbeiter";

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
                        BuchungMuster bm = new BuchungMuster();
                        bm.id = reader.GetInt32(reader.GetOrdinal("PK_Muster"));
                        bm.Zweck = reader.GetString(reader.GetOrdinal("Zweck"));
                        bm.Referenznummer = reader.GetString(reader.GetOrdinal("Auftrag_Referenz_Nr"));
                        bm.Kundeneigentum = (reader.GetInt16(reader.GetOrdinal("Kundeneigentum"))) == 0 ? "Ja" : "Nein";
                        bm.Ruecksendung = (reader.GetInt16(reader.GetOrdinal("Rücksendung"))) == 0 ? "Ja" : "Nein";
                        bm.Ausgang = reader.GetDateTime(reader.GetOrdinal("AusgangDatum"));
                        bm.Eingang = reader.GetDateTime(reader.GetOrdinal("EingangDatum"));
                        bm.Name = reader.GetString(reader.GetOrdinal("MusterName"));
                        bm.Menge = reader.GetInt32(reader.GetOrdinal("Gesamtmenge"));
                        bm.Kunde = reader.GetString(reader.GetOrdinal("Firma"));
                        bm.Ansprechpartner = reader.GetString(reader.GetOrdinal("Vorname")) + " " + reader.GetString(reader.GetOrdinal("Nachname"));

                        viewModel.ArtikelList.Add(bm);
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
        private bool dbSelectLager(IBuchungModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT ml.*, lp.Menge, m.MusterName FROM [ASRP_TMS].[dbo].[muster_lager] ml " +
                   "JOIN [ASRP_TMS].[dbo].[muster] m ON m.PK_Muster = ml.FK_Muster " +
                   "JOIN [ASRP_TMS].[dbo].[lagerplatz] lp ON lp.PK_Lagerplatz = ml.FK_Lager " +
                   "WHERE ml.Gesperrt=0 AND FK_Lager = " + 
                   "(SELECT PK_Lagerplatz FROM [dbo].[lagerplatz] WHERE Ort='" + viewModel.Ort + "' AND Platz=" + viewModel.Platz + ")";

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
                        Buchung b = new Buchung();
                        b.Anzahl = Convert.ToInt32(reader.GetString(reader.GetOrdinal("Menge")));
                        b.Muster = reader.GetString(reader.GetOrdinal("MusterName"));

                        viewModel.MusterList.Add(b);
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

        public static bool dbDelete(int mlId)
        {
            bool rw = false;

            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlTransaction transaction = null;

            String sSql = "UPDATE [ASRP_TMS].[dbo].[muster_lager] SET Gesperrt=1 WHERE PK_Muster_Lager=" + mlId + "; " +
                          "UPDATE [ASRP_TMS].[dbo].[lagerplatz] SET Menge=0 WHERE PK_Lagerplatz= " +
                          "(SELECT PK_Lagerplatz FROM [ASRP_TMS].[dbo].[muster_lager] " +
                          "JOIN [ASRP_TMS].[dbo].[lagerplatz] ON [ASRP_TMS].[dbo].[lagerplatz].FK_Raum = [ASRP_TMS].[dbo].[muster_lager].FK_Lager " +
                          "WHERE PK_Muster_Lager=" + mlId + ") ";

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
        #endregion
    }
}

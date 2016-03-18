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
    public class OverviewRepository : IRepository<IOverviewModel>
    {
        public void Select(IOverviewModel viewModel)
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

        public void Insert(IOverviewModel viewModel)
        {
            throw new NotImplementedException();
        }
        public void Update(IOverviewModel viewModel)
        {
            throw new NotImplementedException();
        }
        public void Delete(IOverviewModel viewModel)
        {
            throw new NotImplementedException();
        }
        public void findById(IOverviewModel viewModel)
        {
            throw new NotImplementedException();
        }

        #region db
        private bool dbSelect(IOverviewModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT ml.PK_Muster_Lager, ml.FK_Lager, m.PK_Muster, m.MusterName, lr.Gebaeude, lr.Nummer, lp.Platz, lp.Ort, lp.Menge, m.EingangDatum, m.AusgangDatum, " +
                   "m.Auftrag_Referenz_Nr, m.Kundeneigentum, m.Rücksendung, k.Firma, mit.Vorname, mit.Nachname " +
                   "FROM [muster_lager] ml, [muster] m, [lagerplatz] lp, [lagerraum] lr, [kunde] k, [mitarbeiter] mit " +
                   "WHERE m.PK_Muster = ml.FK_Muster AND lp.PK_Lagerplatz = ml.FK_Lager AND k.PK_Kunde = m.FK_Kunde " +
                   "AND mit.PK_Mitarbeiter = m.FK_Ansprechpartner AND ml.Gesperrt = 0 AND lp.FK_Raum = lr.PK_Lagerraum";

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

                        Overview o = new Overview();
                        o.MusterLagerId = reader.GetInt32(reader.GetOrdinal("PK_Muster_Lager"));
                        o.LagerId = reader.GetInt32(reader.GetOrdinal("FK_Lager"));
                        o.MusterId = reader.GetInt32(reader.GetOrdinal("PK_Muster"));
                        o.Name = reader.GetString(reader.GetOrdinal("MusterName"));
                        o.Lagerort = gebaeude + " " + nummer + " " + ort + " " + platz;
                        o.Menge = Convert.ToInt32(reader.GetString(reader.GetOrdinal("Menge")));
                        o.Eingangsdatum = reader.GetDateTime(reader.GetOrdinal("EingangDatum"));
                        o.Ausgangsdatum = reader.GetDateTime(reader.GetOrdinal("AusgangDatum"));
                        o.Referenznummer = reader.GetString(reader.GetOrdinal("Auftrag_Referenz_Nr"));
                        o.Kundeneigentum = reader.GetInt16(reader.GetOrdinal("Kundeneigentum")) == 0 ? true : false;
                        o.Ruecksendung = reader.GetInt16(reader.GetOrdinal("Rücksendung")) == 0 ? true : false;
                        o.Kunde = reader.GetString(reader.GetOrdinal("Firma"));
                        o.Ansprechpartner = reader.GetString(reader.GetOrdinal("Vorname")) + " " + reader.GetString(reader.GetOrdinal("Nachname"));

                        viewModel.OverviewList.Add(o);
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
        #endregion
    }
}

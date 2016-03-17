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
    public class MitarbeiterRepository : IRepository<IMitarbeiterModel>
    {

        public void Select(IMitarbeiterModel viewModel)
        {
            DBAccess.openDB();
            dbSelect(viewModel);
            //dbSelectTitel(viewModel);
            DBAccess.closeDB();
        }

        public void Insert(IMitarbeiterModel viewModel)
        {

        }

        public void Update(IMitarbeiterModel viewModel)
        {

        }

        public void Delete(IMitarbeiterModel viewModel)
        {

        }

        public void findById(IMitarbeiterModel viewModel)
        {

        }

        private bool dbSelect(IMitarbeiterModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT m.*,a.Titel FROM [ASRP_TMS].[dbo].[mitarbeiter] m JOIN [ASRP_TMS].[dbo].[Anrede] a ON a.Pk_Anrede = m.Fk_Anrede";

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
                        Mitarbeiter o = new Mitarbeiter();
                        o.id = reader.GetInt32(reader.GetOrdinal("PK_Mitarbeiter"));
                        o.Titel = reader.GetString(reader.GetOrdinal("Titel"));
                        o.Nachname = reader.GetString(reader.GetOrdinal("Nachname"));
                        o.Vorname = reader.GetString(reader.GetOrdinal("Vorname"));
                        if(reader["Kurzform"] != DBNull.Value)
                        o.Kurzform = reader.GetString(reader.GetOrdinal("Kurzform"));
                        if (reader["PersNr"] != DBNull.Value)
                        o.PersonalNr = reader.GetString(reader.GetOrdinal("PersNr"));
                        if(reader["Tel1"] != DBNull.Value)
                        o.TelefonIntern = reader.GetString(reader.GetOrdinal("Tel1"));
                        if(reader["Tel2"] != DBNull.Value)
                        o.TelefonPrivat = reader.GetString(reader.GetOrdinal("Tel2"));
                        o.Email = reader.GetString(reader.GetOrdinal("eMail"));
                        if (reader["FK_Stellvertreter"] != DBNull.Value)
                            o.StellvertreterID = reader.GetInt32(reader.GetOrdinal("FK_Stellvertreter"));
                        else o.StellvertreterID = -1;
                        
                        viewModel.MitarbeiterListe.Add(o);
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

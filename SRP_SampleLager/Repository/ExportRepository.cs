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
    public class ExportRepository : IRepository<IExportModel>
    {
        public void Select(IExportModel viewModel)
        {
            try
            {
                DBAccess.openDB();
                dbSelect(viewModel);
                DBAccess.closeDB();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Insert(IExportModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(IExportModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(IExportModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void findById(IExportModel viewModel)
        {
            throw new NotImplementedException();
        }

        private bool dbSelect(IExportModel viewModel)
        {
            bool rw = false;
            string sSql = string.Empty;

            sSql = "SELECT mb.MBUser, m.Vorname, m.Nachname, l.Aktion, l.Datum FROM [ASRP_TMS].[dbo].[log] l " +
                   "JOIN [ASRP_TMS].[dbo].[MBUser] mb ON mb.PK_User = l.FK_User " +
                   "JOIN [ASRP_TMS].[dbo].[mitarbeiter] m ON m.PK_Mitarbeiter = mb.FK_Mitarbeiter";

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

                reader.Read();
                if (!reader.HasRows)
                {
                    rw = false;
                }
                else
                {
                    while (reader.Read())
                    {
                        Export e = new Export();
                        e.User = reader.GetString(reader.GetOrdinal("MBUser"));
                        e.Name = reader.GetString(reader.GetOrdinal("Vorname")) + " " + reader.GetString(reader.GetOrdinal("Nachname"));
                        e.Aktion = reader.GetString(reader.GetOrdinal("Aktion"));
                        e.Datum = reader.GetDateTime(reader.GetOrdinal("Datum"));

                        viewModel.gesamteList.Add(e);

                        if (!viewModel.MenschList.Contains(e.Name))
                            viewModel.MenschList.Add(e.Name);

                        if (!viewModel.AktionList.Contains(e.Aktion))
                            viewModel.AktionList.Add(e.Aktion);
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

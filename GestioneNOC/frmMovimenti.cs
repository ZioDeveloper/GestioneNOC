using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneNOC
{
    public partial class frmMovimenti : Form
    {

        DataSet ds;
        SqlDataAdapter da;
        string SQL = "";
        string aSQLClause = "";

        public frmMovimenti()
        {
            InitializeComponent();
            cboSelect.SelectedIndex = 1;
            //dtIni.MinDate = DateTime.Now;
            //dtEnd.MinDate = DateTime.Now;

            dtIni.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            masterDataGridView.DataSource = null;
            DoRefresh();
        }

        private void DoRefresh()
        {
            DateTime start = dtIni.Value;
            DateTime end = dtEnd.Value;

            if (cboSelect.SelectedIndex == 0)
                aSQLClause = "  ";
            if (cboSelect.SelectedIndex == 1)
            {
                if (chkFiltraXDate.Checked)
                {
                    aSQLClause = " WHERE  DataTreno  >= '" + start.Year.ToString("0000") + start.Month.ToString("00") + start.Day.ToString("00") +
                                 "' AND DataTreno  <= '" + end.Year.ToString("0000") + end.Month.ToString("00") + end.Day.ToString("00") + "'";
                }
                else
                {
                    aSQLClause = " ";
                }

                SQL =    "SELECT TelaiAnagrafica.Chassis, \n"
                       + "       TelaiAnagrafica.IDModello, \n"
                       + "       Danni_NOC.vin, \n"
                       + "       DWH_RespDanniDecoded_vw.Mercato, \n"
                       + "       Dealer AS CodDealer, \n"
                       + "       D.Descr1 AS Dealer, \n"
                       + "       Danni_NOC.Treno, \n"
                       + "       Danni_NOC.DataTreno, \n"
                       + "       SUM(Danni_NOC.Importo) AS ImportoNOC, \n"
                       + "       SUM(DISTINCT RDTDealerDettagliDanni.Importo) AS ImportoScheda,\n"
                       + "       CASE\n"
                       + "           WHEN MAX(CONVERT(INT, ISFatturato)) > 0\n"
                       + "           THEN 'Si'\n"
                       + "           ELSE 'No'\n"
                       + "       END AS Fatturato\n"
                       + "FROM TelaiAnagrafica\n"
                       + "     INNER JOIN Danni_NOC ON TelaiAnagrafica.ID = Danni_NOC.IDTelaio\n"
                       + "     INNER JOIN DWH_RespDanniDecoded_vw ON TelaiAnagrafica.ID = DWH_RespDanniDecoded_vw.IDTelaio\n"
                       + "     INNER JOIN Dealers D(NOLOCK) ON D.ID = DWH_RespDanniDecoded_vw.iddealer\n"
                       + "     LEFT OUTER JOIN RDTDealerDettagliDanni ON DWH_RespDanniDecoded_vw.IDSchedaDealer = RDTDealerDettagliDanni.IDTesta\n"
                       + aSQLClause 
                       + "GROUP BY TelaiAnagrafica.Chassis, \n"
                       + "         TelaiAnagrafica.IDModello, \n"
                       + "         Danni_NOC.vin, \n"
                       + "         Danni_NOC.Treno, \n"
                       + "         Danni_NOC.DataTreno, \n"
                       + "         DWH_RespDanniDecoded_vw.Mercato, \n"
                       + "         Dealer, \n"
                       + "         D.Descr1;";



            }

            GetData();
        }

        private void GetData()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Creo connessione
            da = new SqlDataAdapter();
            ds = new DataSet();

            string connectionString = Utils.GetConnectionStringByName("CSMS");
            connectionString += "User ID=" + Utils.AppUser + ";Password=" + Utils.AppPassword;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = 0;
                    da.SelectCommand = cmd;
                    conn.Open();
                    ds.Clear();
                    da.Fill(ds);
                }
            }
            bindSrc.DataSource = ds.Tables[0];
            bindNav.BindingSource = this.bindSrc;
            masterDataGridView.DataSource = bindSrc;
            Cursor.Current = Cursors.Default;
            //FormatCells();

        }

        private void cmdCopiaGriglia_Click(object sender, EventArgs e)
        {
            if (this.masterDataGridView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(this.masterDataGridView.GetClipboardContent());
                    MessageBox.Show("Dati copiati.");

                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("The Clipboard could not be accessed. Please try again.");
                }
            }
        }

        private void cmdExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkFiltraXDate_CheckedChanged(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void cmdElaboraFattura_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Procedo con fatturazione NOC ?", "Conferma", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int I = 0;
                foreach (DataGridViewRow myrow in masterDataGridView.Rows)
                {
                    string cs = Utils.GetConnectionStringByName("CSMS");
                    cs += "User ID=" + Utils.AppUser + ";Password=" + Utils.AppPassword;
                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            I++;
                            cmd.Connection = conn;
                            Application.DoEvents();


                            try
                            {
                                SQL = "";
                            }
                            catch (SqlException exc)
                            {

                                MessageBox.Show(exc.Message);

                            }
                            catch (Exception exc)
                            {

                                MessageBox.Show(exc.Message);
                            }



                        }
                    }
                }
            }
            

            MessageBox.Show("Aggiornamento dati da CSMS terminato");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneNOC
{
    public partial class frmAggiornaAvvisiIVECO : Form
    {
        string myFileName = "";
        string fileName = "";
        string SQL = "";

        public frmAggiornaAvvisiIVECO()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSelezionaFile_Click(object sender, EventArgs e)
        {
            string dir = @"C:\CSMS";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            dir = @"C:\CSMS\AggiornamentoAvvisi";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            dir = @"C:\CSMS\FilesElaborati";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }



            try
            {
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Open CVS File";
                theDialog.Filter = "CSV files|*.csv";
                theDialog.InitialDirectory = @"C:\CSMS\AggiornamentoAvvisi";
                if (theDialog.ShowDialog() == DialogResult.OK)
                    lblFileName.Text = theDialog.FileName.ToString();

                this.Cursor = Cursors.WaitCursor;

                myFileName = System.IO.Path.GetFileName(theDialog.FileName.ToString());
                fileName = myFileName;
                txtLog.Text += "Caricato file : \r\n" + myFileName + Environment.NewLine;
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdImportaSingoloFile_Click(object sender, EventArgs e)
        {
            myFileName = lblFileName.Text;
            Cursor = Cursors.WaitCursor;

            if (String.IsNullOrEmpty(myFileName) || myFileName == "...")
            {
                MessageBox.Show("Selezionare un file !", "Errore", MessageBoxButtons.OK);

                Application.DoEvents();
                Cursor = Cursors.Default;
                return;
            }

            if (String.IsNullOrEmpty(txtTestoDaInserire.Text))
            {
                MessageBox.Show("Inserire una descrizione !", "Errore", MessageBoxButtons.OK);

                Application.DoEvents();
                Cursor = Cursors.Default;
                return;
            }

            DataTable imported_data = GetDataFromFile();

            if (imported_data == null) return;

            SaveImportDataToDatabase(imported_data);

            //MessageBox.Show("load data succ.....!");
            //txtFileName.Text = string.Empty;
            txtLog.Text += Environment.NewLine + "Importazione terminata." + Environment.NewLine;
            Application.DoEvents();
            Cursor = Cursors.Default;
        }
        private DataTable GetDataFromFile()
        {
            // Cancella dati da Tabella appoggio...


            txtLog.Text += "Importo i dati nella tabella temporanea." + Environment.NewLine + Environment.NewLine;
            Application.DoEvents();

            DataTable importedData = new DataTable();

            try
            {
                using (StreamReader sr = new StreamReader(lblFileName.Text))
                {


                    string header = sr.ReadLine();
                    if (string.IsNullOrEmpty(header))
                    {

                        MessageBox.Show("no file data");
                        return null;
                    }



                    string[] headerColumns = header.Split(';');
                    foreach (string headerColumn in headerColumns)
                    {
                        importedData.Columns.Add(headerColumn);
                    }



                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();
                        if (string.IsNullOrEmpty(line)) continue;
                        string[] fields = line.Split(';');
                        DataRow importedRow = importedData.NewRow();

                        for (int i = 0; i < fields.Count(); i++)
                        {

                            importedRow[i] = fields[i];

                        }

                        importedData.Rows.Add(importedRow);
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return importedData;
        }

        private bool HasVINBlocked()
        {
            int cnt = 0;
            string cs = "IVECO".GetConnectionStringComplete();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    SQL = "SELECT TOP 1 COUNT( T.ID) AS Cnt\n"
                       + "FROM TelaiAnagrafica AS T\n"
                       + "WHERE T.Chassis	 IN\n"
                       + "(\n"
                       + "    SELECT DISTINCT\n"
                       + "           (Telaio)\n"
                       + "    FROM ElencoTelai\n"
                       + ")\n"
                       + "GROUP BY T.Chassis\n"
                       + "ORDER BY Cnt";

                    cmd.CommandText = SQL;
                    cmd.Connection = conn;
                    try
                    {
                        cnt = (int)cmd.ExecuteScalar();
                    }
                    catch
                    {
                        cnt = 0;
                    }
                }

            }

            return cnt > 1;
        }

        private void SaveImportDataToDatabase(DataTable imported_data)
        {

            bool IsBlocked = HasVINBlocked();
            if (IsBlocked)
            {
                txtLog.Text += "Impossibile proseguire, esiste almeno un telaio NON UNIVOCO." + Environment.NewLine;
                Application.DoEvents();
                return;
            }
            int I = 0;
            string cs = "IVECO".GetConnectionStringComplete();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    SQL = " DELETE  ElencoTelai";

                    cmd.CommandText = SQL;
                    cmd.Connection = conn;
                    int ins = 0;
                    ins = cmd.ExecuteNonQuery();
                    txtLog.Text += "Cancellati i precedenti : " + ins.ToString("#,##0") + " telai" + Environment.NewLine;
                    Application.DoEvents();
                    //return;
                }


                foreach (DataRow importRow in imported_data.Rows)
                {

                    //MessageBox.Show(importRow["telaio"].ToString());
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        //SQL = " INSERT INTO  ElencoTelai(Modello, Telaio)" +
                        //     "   VALUES( @Modello,@IDTelaio) ";

                        //cmd.Parameters.AddWithValue("@Modello", importRow["Modello"].ToString());
                        //cmd.Parameters.AddWithValue("@IDTelaio", importRow["Telaio"].ToString());

                        SQL = " INSERT INTO  ElencoTelai( Telaio)" +
                             "   VALUES( @IDTelaio) ";


                        cmd.Parameters.AddWithValue("@IDTelaio", importRow["Telaio"].ToString());

                        cmd.CommandText = SQL;
                        cmd.Connection = conn;
                        try
                        {
                            int ins = cmd.ExecuteNonQuery();
                            I++;
                        }
                        catch { } // Brucio eccezione SQL in caso di telai doppi, così  i telai sono univoci, per via dell'indice univoco in tabella SQL 


                        Application.DoEvents();

                    }

                }
                txtLog.Text += "Inseriti : " + I.ToString("#,##0") + " telai." + Environment.NewLine;

                using (SqlCommand cmd = new SqlCommand())
                {
                    SQL = "UPDATE TelaiWarning\n"
                       + "  SET \n"
                       + "      Annotazioni = CAST(" + Utils.QuotedStr(txtTestoDaInserire.Text) + " AS VARCHAR(MAX)) + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + CAST(TelaiWarning.Annotazioni AS VARCHAR(MAX))\n"
                       + "WHERE ID IN\n"
                       + "(\n"
                       + "    SELECT ID\n"
                       + "    FROM TelaiWarning\n"
                       + "    WHERE IDTelaio IN\n"
                       + "    (\n"
                       + "        SELECT TelaiAnagrafica.ID AS IDTelaio\n"
                       + "        FROM ElencoTelai\n"
                       + "             INNER JOIN TelaiAnagrafica \n"
                       + "             ON ElencoTelai.Telaio = TelaiAnagrafica.Chassis\n"
                       + "             LEFT JOIN TelaiWarning ON dbo.TelaiAnagrafica.ID = dbo.TelaiWarning.IDTelaio\n"
                       + "        WHERE TelaiWarning.ID IS NOT NULL\n"
                       + "    )\n"
                       + ");";

                    cmd.CommandText = SQL;
                    cmd.Connection = conn;
                    int ins = 0;
                    ins = cmd.ExecuteNonQuery();
                    txtLog.Text += "UPDATE : " + ins.ToString("#,##0") + " avvisi." + Environment.NewLine;
                    Application.DoEvents();

                }
                //txtLog.Text += "Sezione aggiornamento terminata." + Environment.NewLine;

                using (SqlCommand cmd = new SqlCommand())
                {
                    SQL = "  INSERT INTO TelaiWarning\n"
                        + "(IDTelaio, Annotazioni \n"
                        + ")\n"
                        + "       SELECT TelaiAnagrafica.ID, \n"
                        + " CAST (" + Utils.QuotedStr(txtTestoDaInserire.Text) + " AS VARCHAR(MAX))\n"
                        + "       FROM ElencoTelai\n"
                        + "            INNER JOIN TelaiAnagrafica ON   ElencoTelai.Telaio = TelaiAnagrafica.Chassis\n"
                        + "            LEFT JOIN TelaiWarning ON dbo.TelaiAnagrafica.ID = dbo.TelaiWarning.IDTelaio\n"
                        + "       WHERE TelaiWarning.ID IS NULL\n"
                        + "             AND TelaiAnagrafica.ID IS NOT NULL\n"
                        + "       GROUP BY TelaiAnagrafica.ID;";

                    cmd.CommandText = SQL;
                    cmd.Connection = conn;
                    int ins = 0;
                    ins = cmd.ExecuteNonQuery();
                    txtLog.Text += "INSERT : " + ins.ToString("#,##0") + " avvisi." + Environment.NewLine;
                    Application.DoEvents();
                    //txtLog.Text += "Sezione inserimento terminata."+ Environment.NewLine;
                }

            }

            File.Copy(myFileName, @"C:\CSMS\FilesElaborati\" + Path.GetFileNameWithoutExtension(myFileName) + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + Path.GetExtension(myFileName));
            txtLog.Text += "File copiato in archivio." + Environment.NewLine;
        }

        private void cmdCreaCVS_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            Application.DoEvents();
            string dir = @"C:\CSMS";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            dir = @"C:\CSMS\AggiornamentoAvvisi";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            dir = @"C:\CSMS\FilesElaborati";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\CSMS\AggiornamentoAvvisi");
            di.CleandDirectory();


            var file = @"C:\CSMS\AggiornamentoAvvisi\TelaiXAvvisi.csv";

            using (var stream = File.CreateText(file))
            {
                string csvRow = string.Format("{0}", "Telaio");



                stream.WriteLine(csvRow);
            }

            Process.Start(file);
            lblFileName.Text = file;
        }

       
    }
}


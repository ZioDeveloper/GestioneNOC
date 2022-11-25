using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneNOC
{
    public partial class frmAggiornaAvvisiFax2RDT : Form
    {
        string myFileName = "";
        string fileName = "";
        string SQL = "";

        public frmAggiornaAvvisiFax2RDT()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSelezionaFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Open CVS File";
                theDialog.Filter = "CSV files|*.csv";
                //theDialog.InitialDirectory = @"C:\test";
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

            DataTable imported_data = GetDataFromFile();

            if (imported_data == null) return;

            SaveImportDataToDatabase(imported_data);

            //MessageBox.Show("load data succ.....!");
            //txtFileName.Text = string.Empty;
            txtLog.Text += Environment.NewLine + "Importazione terminata.";
            Application.DoEvents();
            Cursor = Cursors.Default;
        }
        private DataTable GetDataFromFile()
        {
            // Cancella dati da Tabella appoggio...

            
            txtLog.Text = "Importo dati in tabella temporanea.";
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
        private void SaveImportDataToDatabase(DataTable imported_data)
        {
            int I = 0;
            string cs = Utils.GetConnectionStringComplete("CSMS");
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    SQL = " DELETE  ElencoTelai" ;

                    cmd.CommandText = SQL;
                    cmd.Connection = conn;
                    int ins = cmd.ExecuteNonQuery();
                    Application.DoEvents();

                }

                
                foreach (DataRow importRow in imported_data.Rows)
                {

                    //MessageBox.Show(importRow["telaio"].ToString());
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SQL = " INSERT INTO  ElencoTelai(Modello, Telaio)" +
                             "   VALUES( @Modello,@IDTelaio) ";

                        cmd.Parameters.AddWithValue("@Modello", importRow["Modello"].ToString());
                        cmd.Parameters.AddWithValue("@IDTelaio", importRow["Telaio"].ToString());
                        cmd.CommandText = SQL;
                        cmd.Connection = conn;
                        int ins = cmd.ExecuteNonQuery();
                        I++;
                        txtLog.Text = "Inserimento riga : " + I.ToString("#,###");
                        cmd.Connection = conn;
                        Application.DoEvents();
                       
                    }
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    SQL = "UPDATE TelaiWarning\n"
                       + "  SET \n"
                       + "      Annotazioni = CAST(" + Utils.QuotedStr(txtTestoDaInserire.Text)+ " AS VARCHAR(MAX)) + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + CAST(TelaiWarning.Annotazioni AS VARCHAR(MAX))\n"
                       + "WHERE ID IN\n"
                       + "(\n"
                       + "    SELECT ID\n"
                       + "    FROM TelaiWarning\n"
                       + "    WHERE IDTelaio IN\n"
                       + "    (\n"
                       + "        SELECT TelaiAnagrafica.ID AS IDTelaio\n"
                       + "        FROM ElencoTelai\n"
                       + "             INNER JOIN TelaiAnagrafica --ON  ElencoTelai.Modello =  TelaiAnagrafica.IDModello\n"
                       + "             ON ElencoTelai.Telaio = TelaiAnagrafica.Chassis\n"
                       + "             LEFT JOIN TelaiWarning ON dbo.TelaiAnagrafica.ID = dbo.TelaiWarning.IDTelaio\n"
                       + "        WHERE TelaiWarning.ID IS NOT NULL\n"
                       + "    )\n"
                       + ");";

                    cmd.CommandText = SQL;
                    cmd.Connection = conn;
                    int ins = cmd.ExecuteNonQuery();
                    Application.DoEvents();

                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    SQL = "  INSERT INTO TelaiWarning\n"
                        + "(IDTelaio, Annotazioni \n"
                        + ")\n"
                        + "       SELECT TelaiAnagrafica.ID, \n"
                        + " CAST (" + Utils.QuotedStr(txtTestoDaInserire.Text) + " AS VARCHAR(MAX))\n"
                        + "       FROM ElencoTelai\n"
                        + "            INNER JOIN TelaiAnagrafica ON --ElencoTelai.Modello = TelaiAnagrafica.IDModello\n"
                        + "            /*AND*/\n"
                        + "\n"
                        + "            ElencoTelai.Telaio = TelaiAnagrafica.Chassis\n"
                        + "            LEFT JOIN TelaiWarning ON dbo.TelaiAnagrafica.ID = dbo.TelaiWarning.IDTelaio\n"
                        + "       WHERE TelaiWarning.ID IS NULL\n"
                        + "             AND TelaiAnagrafica.ID IS NOT NULL\n"
                        + "       GROUP BY TelaiAnagrafica.ID;";

                    cmd.CommandText = SQL;
                    cmd.Connection = conn;
                    int ins = cmd.ExecuteNonQuery();
                    Application.DoEvents();

                }

            }

        }
    }
}
        

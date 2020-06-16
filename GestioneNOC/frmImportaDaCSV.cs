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
    public partial class frmImportaDaCSV : Form
    {
        string myFileName = "";
        string fileName = "";
        string SQL = "";

        public frmImportaDaCSV()
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
                theDialog.Filter = "CSV files|*.csv|All files (*.*)|*.*";
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

        private bool CanInsertRecord(string aTelaio, string aModello, string aTreno, string aCodiceParte, string aCodiceDanno)
        {

            int cnt = 0;

            string cs = Utils.GetConnectionStringByName("CSMS");
            cs += "User ID=" + Utils.AppUser + ";Password=" + Utils.AppPassword;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    SQL = " SELECT COUNT(ID) FROM  Danni_NOC " +
                        "   WHERE Telaio = @Telaio " +
                        "    AND Modello = @Modello " + 
                        "   AND Treno = @Treno " +
                        "   AND codicedanno = @codicedanno" +
                        "   AND codiceparte = @codiceparte";
                    cmd.Parameters.AddWithValue("@Telaio", aTelaio);
                    cmd.Parameters.AddWithValue("@Modello", aModello);
                    cmd.Parameters.AddWithValue("@Treno", aTreno);
                    cmd.Parameters.AddWithValue("@codicedanno", aTreno);
                    cmd.Parameters.AddWithValue("@codiceparte", aTreno);
                    cmd.CommandText = SQL;
                    cnt = (int)cmd.ExecuteScalar();
                }
            }

            if (cnt == 0)
                return true;
            else
                return false;
        }

        private int CercaIDTelaio(string aTelaio, string aModello)
        {
            int myIDtelaio = 0;
            string sqlstm = "";
            string cs = Utils.GetConnectionStringByName("CSMS");
            cs += "User ID=" + Utils.AppUser + ";Password=" + Utils.AppPassword;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(sqlstm, conn))
                {
                    sqlstm = "SELECT ID FROM TelaiAnagrafica(NOLOCK) WHERE Chassis = @Chassis AND IDModello = @IDModello AND InsertDate > '20200101' ";
                    cmd.Parameters.AddWithValue("@Chassis", aTelaio);
                    cmd.Parameters.AddWithValue("@IDModello", aModello.Left(3));
                    cmd.CommandText = sqlstm;
                    conn.Open();
                    try
                    {
                        myIDtelaio = (int)cmd.ExecuteScalar();
                    }
                    catch
                    {
                        myIDtelaio = 0;
                    }
                }
            }
            return myIDtelaio;
        }

        private void SaveImportDataToDatabase(DataTable imported_data)
        {
            string sqlstm = "";
            int I = 0;
            int myIDTelaio = 0;
            string myOLDTelaio = "";
            string cs = Utils.GetConnectionStringByName("CSMS");
            cs += "User ID=" + Utils.AppUser + ";Password=" + Utils.AppPassword;
            using (SqlConnection conn = new SqlConnection(cs))
            {


                conn.Open();
                foreach (DataRow importRow in imported_data.Rows)
                {


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        I++;
                        txtLog.Text = "Inserimento riga : " +I.ToString("#,###");
                        cmd.Connection = conn;
                        Application.DoEvents();
                        if (CanInsertRecord(importRow["telaio"].ToString(), importRow["modello"].ToString(), importRow["Treno"].ToString(),
                                            importRow["codice danno"].ToString(), importRow["codice parte"].ToString()))
                        {
                            try
                            {
                                sqlstm = "INSERT INTO dbo.Danni_NOC "
                                        + "           (IDTelaio "
                                        + "           ,telaio "
                                        + "           ,vin "
                                        + "           ,modello "
                                        + "           ,descrmodello "
                                        + "           ,descrresp "
                                        + "           ,codicedanno "
                                        + "           ,descrdanno "
                                        + "           ,codiceparte "
                                        + "           ,descrparte "
                                        + "           ,gravita "
                                        + "           ,Treno "
                                        + "           ,DataTreno,Importo,NomeFile )"
                                        + " VALUES( @IDTelaio "
                                        + "         ,@telaio "
                                        + "         ,@vin "
                                        + "         ,@modello "
                                        + "         ,@descrmodello "
                                        + "         ,@descrresp "
                                        + "         ,@codicedanno "
                                        + "         ,@descrdanno "
                                        + "         ,@codiceparte "
                                        + "         ,@descrparte "
                                        + "         ,@gravita "
                                        + "         ,@Treno "
                                        + "         ,@DataTreno,@Importo,@NomeFile) "
                                        + "";



                                if (myOLDTelaio != importRow["telaio"].ToString())
                                {
                                    myIDTelaio = CercaIDTelaio(importRow["telaio"].ToString(), importRow["modello"].ToString());
                                }
                                //else
                                //{
                                //    myIDTelaio = myIDTelaio;
                                //}

                                string myDataTreno = importRow["Data"].ToString();


                                try
                                {
                                    myDataTreno = myDataTreno.Right(4) + myDataTreno.Substring(3, 2) + myDataTreno.Left(2);
                                }
                                catch
                                {
                                    myDataTreno = "";
                                }



                                cmd.Parameters.AddWithValue("@IDTelaio", myIDTelaio);
                                cmd.Parameters.AddWithValue("@telaio", importRow["telaio"].ToString());
                                cmd.Parameters.AddWithValue("@Vin", importRow["Vin"].ToString());
                                cmd.Parameters.AddWithValue("@modello", importRow["modello"].ToString());
                                cmd.Parameters.AddWithValue("@descrmodello", importRow["descr modello"].ToString());
                                cmd.Parameters.AddWithValue("@descrresp", importRow["descr resp "].ToString());
                                cmd.Parameters.AddWithValue("@codicedanno", importRow["codice danno"].ToString());
                                cmd.Parameters.AddWithValue("@descrdanno", importRow["descr danno"].ToString());
                                cmd.Parameters.AddWithValue("@codiceparte", importRow["codice parte"].ToString());
                                cmd.Parameters.AddWithValue("@descrparte", importRow["des cr parte"].ToString());
                                cmd.Parameters.AddWithValue("@gravita", importRow["gravita"].ToString());
                                //cmd.Parameters.AddWithValue("@note", importRow["note"].ToString());
                                cmd.Parameters.AddWithValue("@treno", importRow["treno"].ToString());
                                cmd.Parameters.AddWithValue("@datatreno", myDataTreno);
                                cmd.Parameters.AddWithValue("@Importo", 0);
                                cmd.Parameters.AddWithValue("@NomeFile", fileName);





                                cmd.CommandText = sqlstm;
                                if (myIDTelaio != 0)
                                {
                                    int cnt = (int)cmd.ExecuteNonQuery();
                                    if (cnt == 0)
                                        MessageBox.Show("Eccolo");
                                }
                                else
                                {
                                    MessageBox.Show("Telaio non trovato  riga: " + importRow["telaio"].ToString() + " - " + importRow["modello"].ToString());
                                    //txtLog.Text += "Telaio non trovato  riga : " + importRow["telaio"].ToString() + " - " + importRow["modello"].ToString()+Environment.NewLine;
                                }
                                myOLDTelaio = importRow["telaio"].ToString();
                            }
                            catch (SqlException e)
                            {

                                MessageBox.Show(importRow["telaio"].ToString() + " : " + e.Message);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(importRow["telaio"].ToString() + " : " + e.Message);
                                MessageBox.Show(e.Message);
                            }
                        }
                    }
                }
            }

        }
    }
}

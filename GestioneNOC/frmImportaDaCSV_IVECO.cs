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
    public partial class frmImportaDaCSV_IVECO : Form
    {

        string myFileName = "";
        string fileName = "";
        string SQL = "";

        public frmImportaDaCSV_IVECO()
        {
            InitializeComponent();
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

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private bool CanInsertRecord(string aTelaio, string aDescr, string aDataDanno)
        {

            int cnt = 0;

            string cs = Utils.GetConnectionStringByName("IVECO");
            cs += "User ID=" + Utils.AppUser + ";Password=" + Utils.AppPassword;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    SQL = " SELECT COUNT(ID) FROM   Danni_Preesistenti(NOLOCK) " +
                        "   WHERE VAN = @Telaio " +
                        "   AND Descr = @Descr " +
                        "  ";
                    //"   AND DataDanno = @DataDanno";
                    aTelaio = aTelaio.PadLeft(10,'0');
                    cmd.Parameters.AddWithValue("@Telaio", aTelaio);
                    cmd.Parameters.AddWithValue("@Descr", aDescr);
                    //cmd.Parameters.AddWithValue("@DataDanno", aDataDanno);
                    cmd.CommandText = SQL;
                    cnt = (int)cmd.ExecuteScalar();
                }
            }

            if (cnt == 0)
                return true;
            else
                return false;
        }

        private int CercaIDTelaio(string aTelaio)
        {
            int myIDtelaio = 0;
            string sqlstm = "";
            string cs = Utils.GetConnectionStringByName("IVECO");
            cs += "User ID=" + Utils.AppUser + ";Password=" + Utils.AppPassword;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(sqlstm, conn))
                {
                    sqlstm = "SELECT ID FROM TelaiAnagrafica(NOLOCK) WHERE VAN = @VAN  AND InsertDate > '20190101' ";
                    cmd.Parameters.AddWithValue("@VAN", aTelaio);
                    
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
            string myVAN = "";
            string myData = "";
            string cs = Utils.GetConnectionStringByName("IVECO");
            cs += "User ID=" + Utils.AppUser + ";Password=" + Utils.AppPassword;
            using (SqlConnection conn = new SqlConnection(cs))
            {


                conn.Open();
                foreach (DataRow importRow in imported_data.Rows)
                {


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        I++;
                        txtLog.Text = "Elaborazione riga n° : " + I.ToString("#,###");
                        cmd.Connection = conn;
                        Application.DoEvents();
                        if (importRow["VAN"].ToString() != "")
                            myVAN = importRow["VAN"].ToString().PadLeft(10, '0');
                        else
                            myVAN = myVAN;

                        if (CanInsertRecord(myVAN,  importRow["DAMAGE DESCRIPTION"].ToString(), importRow["Date"].ToString()))
                        {
                            try
                            {
                                sqlstm = "INSERT INTO dbo. Danni_Preesistenti "
                                        + "           (IDTelaio "
                                        + "           ,VAN "
                                        + "           ,DataDanno "
                                        + "           ,Descr "
                                        + "           ,NomeFile )"
                                        + " VALUES( @IDTelaio "
                                        + "         ,@VAN "
                                        + "         ,@DataDanno "
                                        + "         ,@Descr "
                                        + "         ,@NomeFile) "
                                        + "";

                               

                                if (myOLDTelaio != myVAN)
                                {
                                    myIDTelaio = CercaIDTelaio(myVAN);
                                }
                                //else
                                //{
                                //    myIDTelaio = myIDTelaio;
                                //}

                                if (importRow["VAN"].ToString() != "")
                                {
                                    myData = importRow["Date"].ToString();
                                    try
                                    {
                                        myData = myData.Right(4) + myData.Substring(3, 2) + myData.Left(2);
                                    }
                                    catch
                                    {
                                        myData = "";
                                    }
                                }
                                else
                                    myData = myData;


                                



                                cmd.Parameters.AddWithValue("@IDTelaio", myIDTelaio);
                                cmd.Parameters.AddWithValue("@VAN", myVAN);
                                cmd.Parameters.AddWithValue("@DataDanno", myData);
                                cmd.Parameters.AddWithValue("@Descr", importRow["DAMAGE DESCRIPTION"].ToString());
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
                                    //MessageBox.Show("Telaio non trovato  riga: " + myVAN );
                                    txtErrori.Text += "Telaio non trovato - VAN  : " + myVAN  + Environment.NewLine +"Riga n° : " + (I+1).ToString()+Environment.NewLine;
                                }
                                myOLDTelaio = myVAN;
                            }
                            catch (SqlException e)
                            {

                                MessageBox.Show(myVAN + " : " + e.Message);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(myVAN + " : " + e.Message);
                                MessageBox.Show(e.Message);
                            }
                        }
                        else
                        {
                            txtErrori.Text += "Telaio già presente - VAN  : " + myVAN + Environment.NewLine + "Riga n° : " + I.ToString() + Environment.NewLine;
                        }
                       
                    }
                    //txtLog.Text = "Inserite righe n° : " + I.ToString("#,###");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtErrori.Clear();
            txtLog.Clear();
        }
    }
}

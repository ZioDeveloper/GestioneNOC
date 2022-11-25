namespace GestioneNOC
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDati = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdVisualizzaDati = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUtilities = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportaDaCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportaDaCSV_IVECO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisposizioneFogli = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDispCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDispAffVert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDispAffOrizz = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSfondo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSfondoSi = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSfondoNo = new System.Windows.Forms.ToolStripMenuItem();
            this.coloreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColorDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColorWhiteSmoke = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCRTesting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAggiornaAvvisi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuDati,
            this.mnuUtilities,
            this.mnuDisposizioneFogli,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1263, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile_Exit});
            this.mnuFile.Image = ((System.Drawing.Image)(resources.GetObject("mnuFile.Image")));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(53, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFile_Exit
            // 
            this.mnuFile_Exit.Name = "mnuFile_Exit";
            this.mnuFile_Exit.Size = new System.Drawing.Size(93, 22);
            this.mnuFile_Exit.Text = "Exit";
            // 
            // mnuDati
            // 
            this.mnuDati.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdVisualizzaDati});
            this.mnuDati.Image = ((System.Drawing.Image)(resources.GetObject("mnuDati.Image")));
            this.mnuDati.Name = "mnuDati";
            this.mnuDati.Size = new System.Drawing.Size(104, 20);
            this.mnuDati.Text = "Gestione dati";
            // 
            // cmdVisualizzaDati
            // 
            this.cmdVisualizzaDati.Name = "cmdVisualizzaDati";
            this.cmdVisualizzaDati.Size = new System.Drawing.Size(181, 22);
            this.cmdVisualizzaDati.Text = "NOC -Visualizza dati";
            this.cmdVisualizzaDati.Click += new System.EventHandler(this.cmdVisualizzaDati_Click);
            // 
            // mnuUtilities
            // 
            this.mnuUtilities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportaDaCSV,
            this.mnuImportaDaCSV_IVECO,
            this.mnuAggiornaAvvisi});
            this.mnuUtilities.Image = ((System.Drawing.Image)(resources.GetObject("mnuUtilities.Image")));
            this.mnuUtilities.Name = "mnuUtilities";
            this.mnuUtilities.Size = new System.Drawing.Size(66, 20);
            this.mnuUtilities.Text = "Utilità";
            // 
            // mnuImportaDaCSV
            // 
            this.mnuImportaDaCSV.Name = "mnuImportaDaCSV";
            this.mnuImportaDaCSV.Size = new System.Drawing.Size(260, 22);
            this.mnuImportaDaCSV.Text = "Importa NOC da file CSV x Fax2RDT";
            this.mnuImportaDaCSV.Click += new System.EventHandler(this.mnuImportaDaCSV_Click);
            // 
            // mnuImportaDaCSV_IVECO
            // 
            this.mnuImportaDaCSV_IVECO.Name = "mnuImportaDaCSV_IVECO";
            this.mnuImportaDaCSV_IVECO.Size = new System.Drawing.Size(260, 22);
            this.mnuImportaDaCSV_IVECO.Text = "Importa pregressi IVECO";
            this.mnuImportaDaCSV_IVECO.Click += new System.EventHandler(this.mnuImportaDaCSV_IVECO_Click);
            // 
            // mnuDisposizioneFogli
            // 
            this.mnuDisposizioneFogli.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDispCascade,
            this.mnuDispAffVert,
            this.mnuDispAffOrizz});
            this.mnuDisposizioneFogli.Image = ((System.Drawing.Image)(resources.GetObject("mnuDisposizioneFogli.Image")));
            this.mnuDisposizioneFogli.Name = "mnuDisposizioneFogli";
            this.mnuDisposizioneFogli.Size = new System.Drawing.Size(143, 20);
            this.mnuDisposizioneFogli.Text = "Disposizione finestre";
            // 
            // mnuDispCascade
            // 
            this.mnuDispCascade.Name = "mnuDispCascade";
            this.mnuDispCascade.Size = new System.Drawing.Size(185, 22);
            this.mnuDispCascade.Text = "Cascata";
            this.mnuDispCascade.Click += new System.EventHandler(this.mnuDispCascade_Click);
            // 
            // mnuDispAffVert
            // 
            this.mnuDispAffVert.Name = "mnuDispAffVert";
            this.mnuDispAffVert.Size = new System.Drawing.Size(185, 22);
            this.mnuDispAffVert.Text = "Affiancate verticali";
            this.mnuDispAffVert.Click += new System.EventHandler(this.mnuDispAffVert_Click);
            // 
            // mnuDispAffOrizz
            // 
            this.mnuDispAffOrizz.Name = "mnuDispAffOrizz";
            this.mnuDispAffOrizz.Size = new System.Drawing.Size(185, 22);
            this.mnuDispAffOrizz.Text = "Affiancate orizzontali";
            this.mnuDispAffOrizz.Click += new System.EventHandler(this.mnuDispAffOrizz_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp_Info,
            this.cmdSfondo,
            this.coloreToolStripMenuItem,
            this.mnuCRTesting});
            this.mnuHelp.Image = ((System.Drawing.Image)(resources.GetObject("mnuHelp.Image")));
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(60, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuHelp_Info
            // 
            this.mnuHelp_Info.Name = "mnuHelp_Info";
            this.mnuHelp_Info.Size = new System.Drawing.Size(138, 22);
            this.mnuHelp_Info.Text = "Info";
            this.mnuHelp_Info.Click += new System.EventHandler(this.mnuHelp_Info_Click);
            // 
            // cmdSfondo
            // 
            this.cmdSfondo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdSfondoSi,
            this.cmdSfondoNo});
            this.cmdSfondo.Name = "cmdSfondo";
            this.cmdSfondo.Size = new System.Drawing.Size(138, 22);
            this.cmdSfondo.Text = "Sfondo";
            this.cmdSfondo.Visible = false;
            // 
            // cmdSfondoSi
            // 
            this.cmdSfondoSi.Name = "cmdSfondoSi";
            this.cmdSfondoSi.Size = new System.Drawing.Size(90, 22);
            this.cmdSfondoSi.Text = "Si";
            // 
            // cmdSfondoNo
            // 
            this.cmdSfondoNo.Name = "cmdSfondoNo";
            this.cmdSfondoNo.Size = new System.Drawing.Size(90, 22);
            this.cmdSfondoNo.Text = "No";
            // 
            // coloreToolStripMenuItem
            // 
            this.coloreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColorDefault,
            this.mnuColorWhiteSmoke});
            this.coloreToolStripMenuItem.Name = "coloreToolStripMenuItem";
            this.coloreToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.coloreToolStripMenuItem.Text = "Colore";
            this.coloreToolStripMenuItem.Visible = false;
            // 
            // mnuColorDefault
            // 
            this.mnuColorDefault.Name = "mnuColorDefault";
            this.mnuColorDefault.Size = new System.Drawing.Size(141, 22);
            this.mnuColorDefault.Text = "Default";
            // 
            // mnuColorWhiteSmoke
            // 
            this.mnuColorWhiteSmoke.Name = "mnuColorWhiteSmoke";
            this.mnuColorWhiteSmoke.Size = new System.Drawing.Size(141, 22);
            this.mnuColorWhiteSmoke.Text = "WhiteSmoke";
            // 
            // mnuCRTesting
            // 
            this.mnuCRTesting.Name = "mnuCRTesting";
            this.mnuCRTesting.Size = new System.Drawing.Size(138, 22);
            this.mnuCRTesting.Text = "CR Testing...";
            this.mnuCRTesting.Visible = false;
            // 
            // mnuAggiornaAvvisi
            // 
            this.mnuAggiornaAvvisi.Name = "mnuAggiornaAvvisi";
            this.mnuAggiornaAvvisi.Size = new System.Drawing.Size(260, 22);
            this.mnuAggiornaAvvisi.Text = "Aggiornamento avvisi FAX2RDT";
            this.mnuAggiornaAvvisi.Click += new System.EventHandler(this.mnuAggiornaAvvisi_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 732);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Data Analyzer";
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem mnuDati;
        private System.Windows.Forms.ToolStripMenuItem mnuUtilities;
        private System.Windows.Forms.ToolStripMenuItem mnuImportaDaCSV;
        private System.Windows.Forms.ToolStripMenuItem mnuDisposizioneFogli;
        private System.Windows.Forms.ToolStripMenuItem mnuDispCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuDispAffVert;
        private System.Windows.Forms.ToolStripMenuItem mnuDispAffOrizz;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp_Info;
        private System.Windows.Forms.ToolStripMenuItem cmdSfondo;
        private System.Windows.Forms.ToolStripMenuItem cmdSfondoSi;
        private System.Windows.Forms.ToolStripMenuItem cmdSfondoNo;
        private System.Windows.Forms.ToolStripMenuItem coloreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuColorDefault;
        private System.Windows.Forms.ToolStripMenuItem mnuColorWhiteSmoke;
        private System.Windows.Forms.ToolStripMenuItem mnuCRTesting;
        private System.Windows.Forms.ToolStripMenuItem cmdVisualizzaDati;
        private System.Windows.Forms.ToolStripMenuItem mnuImportaDaCSV_IVECO;
        private System.Windows.Forms.ToolStripMenuItem mnuAggiornaAvvisi;
    }
}


namespace GestioneNOC
{
    partial class frmAggiornaAvvisiIVECO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAggiornaAvvisiIVECO));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTestoDaInserire = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdCreaCVS = new System.Windows.Forms.Button();
            this.cmdImportaSingoloFile = new System.Windows.Forms.Button();
            this.cmdSelezionaFile = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Testo da memorizzare";
            // 
            // txtTestoDaInserire
            // 
            this.txtTestoDaInserire.Location = new System.Drawing.Point(12, 84);
            this.txtTestoDaInserire.Name = "txtTestoDaInserire";
            this.txtTestoDaInserire.Size = new System.Drawing.Size(589, 20);
            this.txtTestoDaInserire.TabIndex = 56;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(12, 123);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(586, 163);
            this.txtLog.TabIndex = 52;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblFileName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdExit);
            this.panel1.Location = new System.Drawing.Point(14, 292);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 64);
            this.panel1.TabIndex = 53;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(35, 11);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(16, 13);
            this.lblFileName.TabIndex = 5;
            this.lblFileName.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File:";
            // 
            // cmdExit
            // 
            this.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExit.Location = new System.Drawing.Point(502, 11);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 33);
            this.cmdExit.TabIndex = 0;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdCreaCVS
            // 
            this.cmdCreaCVS.Image = ((System.Drawing.Image)(resources.GetObject("cmdCreaCVS.Image")));
            this.cmdCreaCVS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCreaCVS.Location = new System.Drawing.Point(218, 13);
            this.cmdCreaCVS.Name = "cmdCreaCVS";
            this.cmdCreaCVS.Size = new System.Drawing.Size(166, 43);
            this.cmdCreaCVS.TabIndex = 58;
            this.cmdCreaCVS.Text = "Crea && Apri  file";
            this.cmdCreaCVS.UseVisualStyleBackColor = true;
            this.cmdCreaCVS.Click += new System.EventHandler(this.cmdCreaCVS_Click);
            // 
            // cmdImportaSingoloFile
            // 
            this.cmdImportaSingoloFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdImportaSingoloFile.Image")));
            this.cmdImportaSingoloFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImportaSingoloFile.Location = new System.Drawing.Point(419, 13);
            this.cmdImportaSingoloFile.Name = "cmdImportaSingoloFile";
            this.cmdImportaSingoloFile.Size = new System.Drawing.Size(185, 43);
            this.cmdImportaSingoloFile.TabIndex = 55;
            this.cmdImportaSingoloFile.Text = "Aggiorna avvisi";
            this.cmdImportaSingoloFile.UseVisualStyleBackColor = true;
            this.cmdImportaSingoloFile.Click += new System.EventHandler(this.cmdImportaSingoloFile_Click);
            // 
            // cmdSelezionaFile
            // 
            this.cmdSelezionaFile.Enabled = false;
            this.cmdSelezionaFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdSelezionaFile.Image")));
            this.cmdSelezionaFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSelezionaFile.Location = new System.Drawing.Point(12, 12);
            this.cmdSelezionaFile.Name = "cmdSelezionaFile";
            this.cmdSelezionaFile.Size = new System.Drawing.Size(166, 43);
            this.cmdSelezionaFile.TabIndex = 54;
            this.cmdSelezionaFile.Text = "Seleziona file";
            this.cmdSelezionaFile.UseVisualStyleBackColor = true;
            // 
            // frmAggiornaAvvisiIVECO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(613, 377);
            this.Controls.Add(this.cmdCreaCVS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTestoDaInserire);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.cmdImportaSingoloFile);
            this.Controls.Add(this.cmdSelezionaFile);
            this.Controls.Add(this.panel1);
            this.Name = "frmAggiornaAvvisiIVECO";
            this.Text = "frmAggiornaAvvisiIVECO";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCreaCVS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTestoDaInserire;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button cmdImportaSingoloFile;
        private System.Windows.Forms.Button cmdSelezionaFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdExit;
    }
}
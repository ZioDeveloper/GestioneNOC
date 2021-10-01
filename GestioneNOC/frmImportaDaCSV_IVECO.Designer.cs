namespace GestioneNOC
{
    partial class frmImportaDaCSV_IVECO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportaDaCSV_IVECO));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cmdImportaSingoloFile = new System.Windows.Forms.Button();
            this.cmdSelezionaFile = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdImportaFiles = new System.Windows.Forms.Button();
            this.txtErrori = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(22, 79);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(721, 83);
            this.txtLog.TabIndex = 45;
            // 
            // cmdImportaSingoloFile
            // 
            this.cmdImportaSingoloFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdImportaSingoloFile.Image")));
            this.cmdImportaSingoloFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImportaSingoloFile.Location = new System.Drawing.Point(225, 12);
            this.cmdImportaSingoloFile.Name = "cmdImportaSingoloFile";
            this.cmdImportaSingoloFile.Size = new System.Drawing.Size(212, 33);
            this.cmdImportaSingoloFile.TabIndex = 48;
            this.cmdImportaSingoloFile.Text = "Importa singolo CSV file";
            this.cmdImportaSingoloFile.UseVisualStyleBackColor = true;
            this.cmdImportaSingoloFile.Click += new System.EventHandler(this.cmdImportaSingoloFile_Click);
            // 
            // cmdSelezionaFile
            // 
            this.cmdSelezionaFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdSelezionaFile.Image")));
            this.cmdSelezionaFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSelezionaFile.Location = new System.Drawing.Point(22, 12);
            this.cmdSelezionaFile.Name = "cmdSelezionaFile";
            this.cmdSelezionaFile.Size = new System.Drawing.Size(170, 33);
            this.cmdSelezionaFile.TabIndex = 47;
            this.cmdSelezionaFile.Text = "Seleziona file";
            this.cmdSelezionaFile.UseVisualStyleBackColor = true;
            this.cmdSelezionaFile.Click += new System.EventHandler(this.cmdSelezionaFile_Click);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblFileName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdExit);
            this.panel1.Location = new System.Drawing.Point(22, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 88);
            this.panel1.TabIndex = 46;
            // 
            // cmdExit
            // 
            this.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExit.Location = new System.Drawing.Point(602, 48);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(114, 33);
            this.cmdExit.TabIndex = 0;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdImportaFiles
            // 
            this.cmdImportaFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImportaFiles.Location = new System.Drawing.Point(-263, -43);
            this.cmdImportaFiles.Name = "cmdImportaFiles";
            this.cmdImportaFiles.Size = new System.Drawing.Size(105, 33);
            this.cmdImportaFiles.TabIndex = 44;
            this.cmdImportaFiles.Text = "Seleziona file";
            this.cmdImportaFiles.UseVisualStyleBackColor = true;
            // 
            // txtErrori
            // 
            this.txtErrori.Location = new System.Drawing.Point(22, 192);
            this.txtErrori.Multiline = true;
            this.txtErrori.Name = "txtErrori";
            this.txtErrori.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrori.Size = new System.Drawing.Size(723, 80);
            this.txtErrori.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Log attività";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Errori !";
            // 
            // button1
            // 
            this.button1.Image = global::AutoDataAnalyzer.Properties.Resources.file_delete;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(575, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 33);
            this.button1.TabIndex = 52;
            this.button1.Text = "Cancella log ed errori";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmImportaDaCSV_IVECO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(760, 399);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtErrori);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.cmdImportaSingoloFile);
            this.Controls.Add(this.cmdSelezionaFile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdImportaFiles);
            this.Name = "frmImportaDaCSV_IVECO";
            this.Text = "Importa dati da file  CSV x IVECO";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button cmdImportaSingoloFile;
        private System.Windows.Forms.Button cmdSelezionaFile;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdImportaFiles;
        private System.Windows.Forms.TextBox txtErrori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}
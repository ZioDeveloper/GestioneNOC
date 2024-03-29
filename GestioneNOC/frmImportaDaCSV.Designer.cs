﻿namespace GestioneNOC
{
    partial class frmImportaDaCSV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportaDaCSV));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cmdImportaSingoloFile = new System.Windows.Forms.Button();
            this.cmdSelezionaFile = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdImportaFiles = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(21, 53);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(563, 139);
            this.txtLog.TabIndex = 40;
            // 
            // cmdImportaSingoloFile
            // 
            this.cmdImportaSingoloFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdImportaSingoloFile.Image")));
            this.cmdImportaSingoloFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImportaSingoloFile.Location = new System.Drawing.Point(396, 14);
            this.cmdImportaSingoloFile.Name = "cmdImportaSingoloFile";
            this.cmdImportaSingoloFile.Size = new System.Drawing.Size(188, 33);
            this.cmdImportaSingoloFile.TabIndex = 43;
            this.cmdImportaSingoloFile.Text = "Importa singolo CSV file";
            this.cmdImportaSingoloFile.UseVisualStyleBackColor = true;
            this.cmdImportaSingoloFile.Click += new System.EventHandler(this.cmdImportaSingoloFile_Click);
            // 
            // cmdSelezionaFile
            // 
            this.cmdSelezionaFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdSelezionaFile.Image")));
            this.cmdSelezionaFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSelezionaFile.Location = new System.Drawing.Point(21, 13);
            this.cmdSelezionaFile.Name = "cmdSelezionaFile";
            this.cmdSelezionaFile.Size = new System.Drawing.Size(169, 33);
            this.cmdSelezionaFile.TabIndex = 42;
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
            this.panel1.Location = new System.Drawing.Point(21, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 64);
            this.panel1.TabIndex = 41;
            // 
            // cmdExit
            // 
            this.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExit.Location = new System.Drawing.Point(480, 24);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(76, 33);
            this.cmdExit.TabIndex = 0;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdImportaFiles
            // 
            this.cmdImportaFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImportaFiles.Location = new System.Drawing.Point(-264, -42);
            this.cmdImportaFiles.Name = "cmdImportaFiles";
            this.cmdImportaFiles.Size = new System.Drawing.Size(104, 33);
            this.cmdImportaFiles.TabIndex = 39;
            this.cmdImportaFiles.Text = "Seleziona file";
            this.cmdImportaFiles.UseVisualStyleBackColor = true;
            // 
            // frmImportaDaCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 286);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.cmdImportaSingoloFile);
            this.Controls.Add(this.cmdSelezionaFile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdImportaFiles);
            this.Name = "frmImportaDaCSV";
            this.Text = "Importa dati Da CSV";
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
    }
}
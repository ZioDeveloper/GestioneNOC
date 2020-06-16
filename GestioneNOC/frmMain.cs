using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneNOC
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuDispCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void mnuDispAffVert_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void mnuDispAffOrizz_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void mnuImportaDaCSV_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmImportaDaCSV))
                {
                    form.Activate();
                    return;
                }
            }
            frmImportaDaCSV myfrmImportaDaCSV = new frmImportaDaCSV();
            myfrmImportaDaCSV.Show();
            myfrmImportaDaCSV.MdiParent = this;
        }

        private void cmdVisualizzaDati_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmMovimenti))
                {
                    form.Activate();
                    return;
                }
            }
            frmMovimenti myfrmMovimenti = new frmMovimenti();
            myfrmMovimenti.Show();
            myfrmMovimenti.MdiParent = this;
        }

        private void mnuHelp_Info_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmSplash))
                {
                    form.Activate();
                    return;
                }
            }
            frmSplash myfrmSplash = new frmSplash();
            myfrmSplash.Show();
            myfrmSplash.MdiParent = this;
        }
    }
}

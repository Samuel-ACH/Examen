using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen2
{
    public partial class frmMenu : Syncfusion.Windows.Forms.Office2010Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        FrmProducto frmProducto = null;
        frmPedidos FrmPedidos = null;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (frmProducto == null)
            {
                frmProducto = new FrmProducto();
                frmProducto.MdiParent = this;
                frmProducto.Show();
            }
            else
            {
                frmProducto.Activate();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (FrmPedidos == null)
            {
                FrmPedidos = new frmPedidos();
                FrmPedidos.MdiParent = this;
                FrmPedidos.Show();
            }
            else
            {
                FrmPedidos.Activate();
            }
        }
    }
}

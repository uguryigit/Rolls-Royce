using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAF_Forms
{
    public partial class POMainMenuForm : Form
    {
        public POMainMenuForm()
        {
            InitializeComponent();
        }

        private void newPurchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PODetailForm newPurchaseOrderForm = new PODetailForm();

            newPurchaseOrderForm.MdiParent = this;
            newPurchaseOrderForm.Show();
        }

        private void editSearchPOItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POSearchEditItemForm editItemForm = new POSearchEditItemForm();

            editItemForm.MdiParent = this;
            editItemForm.Show();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POAboutForm aboutForm = new POAboutForm();
            aboutForm.ShowDialog();
        }
    }
}

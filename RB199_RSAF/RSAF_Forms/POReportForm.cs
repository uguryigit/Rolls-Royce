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
    public partial class POReportForm : Form
    {
        public POReportForm()
        {
            InitializeComponent();
        }

        private void POReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'RSAF_ProdDataSet.RSAF_DETAIL' table. You can move, or remove it, as needed.
            this.RSAF_DETAILTableAdapter.Fill(this.RSAF_ProdDataSet.RSAF_DETAIL);

            this.reportViewer1.RefreshReport();
        }
    }
}

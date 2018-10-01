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
    public partial class POArchiveForm : Form
    {

        public void loadArchieve(long pDetailId)
        {
            var a = new RsafDbContext();
            var query =
                from c in a.RSAF_ARCHIVE
                where c.DETAIL_ID == pDetailId
                select c;
            foreach (var row in query)
            {
                this.TxANSPSI.Text = row.ANSPSI;
                if (row.ANSPSIDT != null)
                    this.DtANSPSIDT.Value = DateTime.Parse(row.ANSPSIDT.Value.ToShortDateString());
                this.TxANSRVREF.Text = row.ANSRVREF;
                if (row.DESPARDT != null)
                    this.DtDESPARDT.Value = DateTime.Parse(row.DESPARDT.Value.ToShortDateString()); 
                this.TxDESPPART.Text = row.DESPPART;
                if (row.INTOROS != null)
                    this.DtINTOROS.Value = DateTime.Parse(row.INTOROS.Value.ToShortDateString());
                if (row.PROMDATE != null)
                    this.DtPROMDATE.Value = DateTime.Parse(row.PROMDATE.Value.ToShortDateString());
                this.TxRCD.Text = row.RCD.ToString();
                this.TxRECDOC.Text = row.RECDOC;
                if (row.RECDPART != null)
                    this.DtRECDPART.Value = DateTime.Parse(row.RECDPART.Value.ToShortDateString()); 
                this.TxACC_DM.Text = row.ACC_DM.ToString();
                this.TxREF.Text = row.REF;
                this.TxRVREF.Text = row.RVREF;
                this.TxSCRPREF.Text = row.SCRPREF;
                this.TxX.Text = row.X.ToString();
                this.TxDESCRIPTION.Text = row.DESCRIPTION;
                if (row.PREVIOUS_PROMISE_DATE != null)
                    this.DtPREVIOUS_PROMISE_DATE.Value = DateTime.Parse(row.PREVIOUS_PROMISE_DATE.Value.ToShortDateString());

            }
            a.Dispose();
        }
        public POArchiveForm()
        {
            InitializeComponent();
        }

        private void ArchiveForm_Load(object sender, EventArgs e)
        {

        }

        private void DtRECDPART_ValueChanged(object sender, EventArgs e)
        {
            DtRECDPART.CustomFormat = "dd/MM/yyyy";
        }

        private void DtPROMDATE_ValueChanged(object sender, EventArgs e)
        {
            DtPROMDATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtINTOROS_ValueChanged(object sender, EventArgs e)
        {
            DtINTOROS.CustomFormat = "dd/MM/yyyy";
        }

        private void DtDESPARDT_ValueChanged(object sender, EventArgs e)
        {
            DtDESPARDT.CustomFormat = "dd/MM/yyyy";
        }

        private void DtANSPSIDT_ValueChanged(object sender, EventArgs e)
        {
            DtANSPSIDT.CustomFormat = "dd/MM/yyyy";
        }
    }
}

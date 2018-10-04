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
    public  enum purposeType {
        Add=1,
        Edit=2
    }



    public partial class POItemEntryForm : Form
    {
        private int returnIndex;
        private purposeType Purpose;
        private PODetailForm DetailForm;

        public void postPODetailFields
            (int pIndex,
             string pPOITEM,
             string pPART_NO,
             string pSERIAL,
             string pQTYREC,
             bool pWARR,
             string pOONUM,
             string pMDR,
             string pCTRT_DATE,
             string pBAEQTY,
             string pBAESER,
             string pBAESENT,
             string pVENDOR,
             string pPSIREF,
             string pOUTPART,
             string pRR_PO,
             string pENG_MARK,
             string pHOURS_NEW,
             string pHOURS_REP,
             string pRFR,
             string pEX_ENGINE,
             string pSALES_DOCUMENT,
             string pPO_REQ,
             string pREMARKS,
             string pQUALITY_NO
            )
        {
             TxPOITEM.Text = pPOITEM;
             TxPART_NO.Text = pPART_NO;
             TxSERIAL.Text = pSERIAL;
             TxQTYREC.Text = pQTYREC;
             CbWARR.Checked = pWARR;
             TxOONUM.Text = pOONUM;
             TxMDR.Text = pMDR;
             if (pCTRT_DATE!="")
                DtCTRT_DATE.Value = DateTime.Parse(pCTRT_DATE);
             TxBAEQTY.Text = pBAEQTY;
             TxBAESER.Text = pBAESER;
             if (pBAESENT != "")
                DtBAESENT.Value = DateTime.Parse(pBAESENT);
             TxVENDOR.Text = pVENDOR;
             TxPSIREF.Text = pPSIREF;
             TxOUTPART.Text = pOUTPART;
             TxRR_PO.Text = pRR_PO;
             TxENG_MARK.Text = pENG_MARK;
             TxHOURS_NEW.Text = pHOURS_NEW;
             TxHOURS_REP.Text = pHOURS_REP;
             TxRFR.Text = pRFR;
             TxEX_ENGINE.Text = pEX_ENGINE;
             TxSALES_DOCUMENT.Text = pSALES_DOCUMENT;
             TxPO_REQ.Text = pPO_REQ;
             TxREMARKS.Text = pREMARKS;
             TxQUALITY_NO.Text = pQUALITY_NO;
             returnIndex = pIndex;
        }

        public POItemEntryForm(purposeType purpose,PODetailForm detailForm)
        {
            InitializeComponent();
            Purpose = purpose;
            DetailForm = detailForm;
            if (purpose == purposeType.Add)
            {
                BtReturn.Text = "Add New Item";
                Text="A New Purchase Order Item Entry";
            }
            else
            {
                BtReturn.Text = "Return Changes";
                Text = "Edit the Purchase Order Item";
            }
                

        }

        private void DtBAESENT_ValueChanged(object sender, EventArgs e)
        {
            DtBAESENT.CustomFormat = "dd/MM/yyyy";
        }

        private void DtCTRT_DATE_ValueChanged(object sender, EventArgs e)
        {
            DtCTRT_DATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtCTRT_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtCTRT_DATE.CustomFormat = " ";
            if (e.KeyCode == Keys.Space)
                DtCTRT_DATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtBAESENT_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtBAESENT.CustomFormat = " ";
            if (e.KeyCode == Keys.Space)
                DtBAESENT.CustomFormat = "dd/MM/yyyy";
        }

        private void BtReturn_Click(object sender, EventArgs e)
        {

            if (Purpose == purposeType.Add)
            {

                string ctrtDate="";
                string baeSent = "";

                if (DtCTRT_DATE.CustomFormat != " ")
                    ctrtDate=DtCTRT_DATE.Value.ToShortDateString();

                if (DtBAESENT.CustomFormat != " ")
                    baeSent = DtBAESENT.Value.ToShortDateString();

                DetailForm.AddNewItem
                (
                    TxPOITEM.Text,
                    TxPART_NO.Text,
                    TxSERIAL.Text,
                    TxQTYREC.Text,
                    CbWARR.Checked,
                    TxOONUM.Text,
                    TxMDR.Text,
                    ctrtDate,
                    TxBAEQTY.Text,
                    TxBAESER.Text,
                    baeSent,
                    TxVENDOR.Text,
                    TxPSIREF.Text,
                    TxOUTPART.Text,
                    TxRR_PO.Text,
                    TxENG_MARK.Text,
                    TxHOURS_NEW.Text,
                    TxHOURS_REP.Text,
                    TxRFR.Text,
                    TxEX_ENGINE.Text,
                    TxSALES_DOCUMENT.Text,
                    TxPO_REQ.Text,
                    TxREMARKS.Text,
                    TxQUALITY_NO.Text
                );
            }
            else
            {
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[5].Value = TxPOITEM.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[6].Value = TxPART_NO.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[7].Value = TxSERIAL.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[8].Value = TxQTYREC.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[9].Value = CbWARR.Checked;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[10].Value = TxOONUM.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[11].Value = TxMDR.Text;
                if (DtCTRT_DATE.CustomFormat != " ")
                    DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[12].Value = DtCTRT_DATE.Value.ToShortDateString();
                else
                    DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[12].Value = "";
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[13].Value = TxBAEQTY.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[14].Value = TxBAESER.Text;
                if (DtBAESENT.CustomFormat != " ")
                    DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[15].Value = DtBAESENT.Value.ToShortDateString();
                else
                    DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[15].Value = "";
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[16].Value = TxVENDOR.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[17].Value = TxPSIREF.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[18].Value = TxOUTPART.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[19].Value = TxRR_PO.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[20].Value = TxENG_MARK.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[21].Value = TxHOURS_NEW.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[22].Value = TxHOURS_REP.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[23].Value = TxRFR.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[24].Value = TxEX_ENGINE.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[25].Value = TxSALES_DOCUMENT.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[26].Value = TxPO_REQ.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[27].Value = TxREMARKS.Text;
                DetailForm.RsafDetailDataGridView.Rows[returnIndex].Cells[28].Value = TxQUALITY_NO.Text;
                Close();
            }
        }

        private void TxBAEQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxPO_REQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxSALES_DOCUMENT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxEX_ENGINE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxHOURS_NEW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxENG_MARK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxQTYREC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
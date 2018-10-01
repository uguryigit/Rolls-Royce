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
    public partial class PODetailForm : Form
    {
        public PODetailForm()
        {
            InitializeComponent();
        }

        private void NewPurchaseOrderForm_Load(object sender, EventArgs e)
        {
            List<RSAF_TYPE> listType = new List<RSAF_TYPE>();
            var a = new RsafDbContext();
            listType = a.RSAF_TYPE.ToList();
            a.Dispose();
            CxTYPE.DataSource = listType;
            CxTYPE.DisplayMember = "TYPE";
            CxTYPE.ValueMember = "TYPE_CODE";

            List<RSAF_SITE> listSite = new List<RSAF_SITE>();
            var b = new RsafDbContext();
            listSite = b.RSAF_SITE.ToList();
            b.Dispose();
            CxSITE.DataSource = listSite;
            CxSITE.DisplayMember = "SITE";
            CxSITE.ValueMember = "SITE_CODE";
            
            List<RSAF_MASTER> listMaster = new List<RSAF_MASTER>();
            var d = new RsafDbContext();
            var query =
                from c in d.RSAF_MASTER
                where c.DESCRIPTION != null
                orderby c.DESCRIPTION
                select new { DESCRIPTION = c.DESCRIPTION };

            var Descriptions = query.Distinct().ToList();
            d.Dispose();

            int x = Descriptions.Count;
            string[] listDescription = new string[x];

            int i = 0;
            foreach (var row in Descriptions)
            {
                listDescription[i] = row.DESCRIPTION;
                i++;
            }

            this.TxDESCRIPTION.AutoCompleteCustomSource.AddRange(listDescription);
            this.TxDESCRIPTION.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TxDESCRIPTION.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;

            BtAddNewItem.Enabled = false;
        }


        private void RsafDetailBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.RsafDetailBindingSource.EndEdit();
            toolStripStatusLabel.Text = "Saved Changes";
        }

        private void BtAddNewItem_Click(object sender, EventArgs e)
        {
            POItemEntryForm entryItemForm = new POItemEntryForm(purposeType.Add,this);
            entryItemForm.ShowDialog();
        }

        public void AddNewItem(
             string pPOITEM,
             string pPART_NO,
             string pSERIAL,
             string pQTYREC,
             bool pWARR,
             string pOONUM,
             string pMDR,
             DateTime pCTRT_DATE,
             string pBAEQTY,
             string pBAESER,
             DateTime pBAESENT,
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

            RsafDetailDataGridView.Rows.Add(
            DateTime.Now        //CREATE_DATE
            ,null               //UPDATE_DATTE
            ,true               //STATUS
            ,null               //MASTER_ID
            ,null               //DETAIL_ID
            ,pPOITEM
            ,pPART_NO
            ,pSERIAL
            ,pQTYREC
            ,pWARR
            ,pOONUM
            ,pMDR
            ,pCTRT_DATE
            ,pBAEQTY
            ,pBAESER
            ,pBAESENT
            ,pVENDOR
            ,pPSIREF
            ,pOUTPART
            ,pRR_PO
            ,pENG_MARK
            ,pHOURS_NEW
            ,pHOURS_REP
            ,pRFR
            ,pEX_ENGINE
            ,pSALES_DOCUMENT
            ,pPO_REQ
            ,pREMARKS
            ,pQUALITY_NO);

            RsafDetailDataGridView.Refresh();
        }

        private void RsafDetailDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            POItemEntryForm entryItemForm = new POItemEntryForm(purposeType.Edit, this);
            

            var POITEM = RsafDetailDataGridView.Rows[e.RowIndex].Cells[5].Value;
            var PART_NO = RsafDetailDataGridView.Rows[e.RowIndex].Cells[6].Value;
            var SERIAL = RsafDetailDataGridView.Rows[e.RowIndex].Cells[7].Value;
            var QTYREC = RsafDetailDataGridView.Rows[e.RowIndex].Cells[8].Value;
            var WARR = RsafDetailDataGridView.Rows[e.RowIndex].Cells[9].Value;
            var OONUM = RsafDetailDataGridView.Rows[e.RowIndex].Cells[10].Value;
            var MDR = RsafDetailDataGridView.Rows[e.RowIndex].Cells[11].Value;
            var CTRT_DATE = RsafDetailDataGridView.Rows[e.RowIndex].Cells[12].Value;
            var BAEQTY = RsafDetailDataGridView.Rows[e.RowIndex].Cells[13].Value;
            var BAESER = RsafDetailDataGridView.Rows[e.RowIndex].Cells[14].Value;
            var BAESENT = RsafDetailDataGridView.Rows[e.RowIndex].Cells[15].Value;
            var VENDOR = RsafDetailDataGridView.Rows[e.RowIndex].Cells[16].Value;
            var PSIREF = RsafDetailDataGridView.Rows[e.RowIndex].Cells[17].Value;
            var OUTPART = RsafDetailDataGridView.Rows[e.RowIndex].Cells[18].Value;
            var RR_PO = RsafDetailDataGridView.Rows[e.RowIndex].Cells[19].Value;
            var ENG_MARK = RsafDetailDataGridView.Rows[e.RowIndex].Cells[20].Value;
            var HOURS_NEW = RsafDetailDataGridView.Rows[e.RowIndex].Cells[21].Value;
            var HOURS_REP = RsafDetailDataGridView.Rows[e.RowIndex].Cells[22].Value;
            var RFR = RsafDetailDataGridView.Rows[e.RowIndex].Cells[23].Value;
            var EX_ENGINE = RsafDetailDataGridView.Rows[e.RowIndex].Cells[24].Value;
            var SALES_DOCUMENT = RsafDetailDataGridView.Rows[e.RowIndex].Cells[25].Value;
            var PO_REQ = RsafDetailDataGridView.Rows[e.RowIndex].Cells[26].Value;
            var REMARKS = RsafDetailDataGridView.Rows[e.RowIndex].Cells[27].Value;
            var QUALITY_NO = RsafDetailDataGridView.Rows[e.RowIndex].Cells[28].Value;

         
            entryItemForm.postPODetailFields
            (e.RowIndex,
             POITEM != null ? POITEM.ToString() : "",
             PART_NO != null ? PART_NO.ToString() : "",
             SERIAL != null ? SERIAL.ToString() : "",
             QTYREC != null ? QTYREC.ToString() : "",
             WARR != null?(bool)WARR:false,
             OONUM != null ? OONUM.ToString() : "",
             MDR != null ? MDR.ToString() : "",
             CTRT_DATE != null ? CTRT_DATE.ToString() : "",
             BAEQTY != null ? BAEQTY.ToString() : "",
             BAESER != null ? BAESER.ToString() : "",
             BAESENT != null ? BAESENT.ToString() : "", 
             VENDOR != null ? VENDOR.ToString() : "",
             PSIREF != null ? PSIREF.ToString() : "",
             OUTPART != null ? OUTPART.ToString() : "",
             RR_PO != null ? RR_PO.ToString() : "",
             ENG_MARK != null ? ENG_MARK.ToString() : "",
             HOURS_NEW != null ? HOURS_NEW.ToString() : "",
             HOURS_REP != null ? HOURS_REP.ToString() : "",
             RFR != null ? RFR.ToString() : "",
             EX_ENGINE != null ? EX_ENGINE.ToString() : "",
             SALES_DOCUMENT != null ? SALES_DOCUMENT.ToString() : "",
             PO_REQ != null ? PO_REQ.ToString() : "",
             REMARKS != null ? REMARKS.ToString() : "",
             QUALITY_NO != null ? QUALITY_NO.ToString() : ""
            );

            entryItemForm.ShowDialog();
        }
//
        private void FindDetails()
        {
            long masterId=0;
            List<RSAF_MASTER> listMaster = new List<RSAF_MASTER>();
            var a = new RsafDbContext();
            listMaster = a.RSAF_MASTER.Where(c => c.BAEPART == TxBAEPART.Text.ToString()
                                               && c.BAEPO == TxBAEPO.Text.ToString()
                                               && c.SITE == CxSITE.SelectedValue.ToString()
                                               && c.TYPE == CxTYPE.SelectedValue.ToString()).ToList();

            string desc="";
            string roidNo="";
            if (listMaster != null)
                foreach (var x in listMaster)
                {
                    masterId = listMaster.First().MASTER_ID;
                    desc = listMaster.First().DESCRIPTION;
                    roidNo = listMaster.First().ROID_NO;
                }
            
            TxDESCRIPTION.Text = desc;
            TxROID_NO.Text = roidNo;

            a.Dispose();

            RsafDetailDataGridView.Rows.Clear();
            RsafDetailDataGridView.Refresh();
            if (masterId != 0)
            {
                List<RSAF_DETAIL> listDetail = new List<RSAF_DETAIL>();
                var b = new RsafDbContext();
                listDetail = b.RSAF_DETAIL.Where(c => c.MASTER_ID == masterId).ToList();

                RsafDetailDataGridView.AllowUserToAddRows = true;
                foreach (var dtl in listDetail)
                {
                    DataGridViewRow row = (DataGridViewRow)RsafDetailDataGridView.Rows[0].Clone();
                    row.Cells[0].Value = dtl.CREATE_DATE;
                    row.Cells[1].Value = dtl.UPDATE_DATE;
                    row.Cells[2].Value = dtl.STATUS;
                    row.Cells[3].Value = dtl.MASTER_ID;
                    row.Cells[4].Value = dtl.DETAIL_ID;
                    row.Cells[5].Value = dtl.POITEM;
                    row.Cells[6].Value = dtl.PART_NO;
                    row.Cells[7].Value = dtl.SERIAL;
                    row.Cells[8].Value = dtl.QTYREC;
                    row.Cells[9].Value = dtl.WARR;
                    row.Cells[10].Value = dtl.OONUM;
                    row.Cells[11].Value = dtl.MDR;
                    if (dtl.CTRT_DATE!=null)
                        row.Cells[12].Value = dtl.CTRT_DATE.Value.Date.ToShortDateString();
                    row.Cells[13].Value = dtl.BAEQTY;
                    row.Cells[14].Value = dtl.BAESER;
                    if (dtl.BAESENT!=null)
                        row.Cells[15].Value = dtl.BAESENT.Value.Date.ToShortDateString();
                    row.Cells[16].Value = dtl.VENDOR;
                    row.Cells[17].Value = dtl.PSIREF;
                    row.Cells[18].Value = dtl.OUTPART;
                    row.Cells[19].Value = dtl.RR_PO;
                    row.Cells[20].Value = dtl.ENG_MARK;
                    row.Cells[21].Value = dtl.HOURS_NEW;
                    row.Cells[22].Value = dtl.HOURS_REP;
                    row.Cells[23].Value = dtl.RFR;
                    row.Cells[24].Value = dtl.EX_ENGINE;
                    row.Cells[25].Value = dtl.SALES_DOCUMENT;
                    row.Cells[26].Value = dtl.PO_REQ;
                    row.Cells[27].Value = dtl.REMARKS;
                    row.Cells[28].Value = dtl.QUALITY_NO;
                    RsafDetailDataGridView.Rows.Add(row);
                }
                RsafDetailDataGridView.AllowUserToAddRows = false;
                b.Dispose();
            }

        }
////////////////////////////////////////////////
        private void TxBAEPART_TextChanged(object sender, EventArgs e)
        {
            if (TxBAEPART.Text != "" && TxBAEPO.Text !="" && CxSITE.SelectedIndex != -1 && CxTYPE.SelectedIndex != -1)
            {
                BtAddNewItem.Enabled = true;
                FindDetails();
            }
            else
            {
                BtAddNewItem.Enabled = false;
            }
        }

        private void TxBAEPO_TextChanged(object sender, EventArgs e)
        {
            if (TxBAEPART.Text != "" && TxBAEPO.Text != "" && CxSITE.SelectedIndex != -1 && CxTYPE.SelectedIndex != -1)
            {
                BtAddNewItem.Enabled = true;
                FindDetails();
            }
            else
            {
                BtAddNewItem.Enabled = false;
            }
        }

        private void CxSITE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxBAEPART.Text != "" && TxBAEPO.Text != "" && CxSITE.SelectedIndex != -1 && CxTYPE.SelectedIndex != -1)
            {
                BtAddNewItem.Enabled = true;
                FindDetails();
            }
            else
            {
                BtAddNewItem.Enabled = false;
            }
        }

        private void CxTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxBAEPART.Text != "" && TxBAEPO.Text != "" && CxSITE.SelectedIndex != -1 && CxTYPE.SelectedIndex != -1)
            {
                BtAddNewItem.Enabled = true;
                FindDetails();
            }
            else
            {
                BtAddNewItem.Enabled = false;
            }
        }

        private long checkMaster()
        {
            long masterId = 0;
            List<RSAF_MASTER> listMaster = new List<RSAF_MASTER>();
            var a = new RsafDbContext();
            listMaster = a.RSAF_MASTER.Where(c => c.BAEPART == TxBAEPART.Text.ToString()
                                               && c.BAEPO == TxBAEPO.Text.ToString()
                                               && c.SITE == CxSITE.SelectedValue.ToString()
                                               && c.TYPE == CxTYPE.SelectedValue.ToString()).ToList();

            if (listMaster != null)
                foreach (var x in listMaster)
                    masterId = listMaster.First().MASTER_ID;
            a.Dispose();
            return masterId;
        }

        private void LbBAEPART_DoubleClick(object sender, EventArgs e)
        {
            long masterId = checkMaster();
            if (masterId != 0)
            {
                POMasterForm masterForm = new POMasterForm(this);
                masterForm.SetValues(masterId,
                                     this.TxBAEPART.Text,
                                     this.TxBAEPO.Text,
                                     this.CxSITE.SelectedIndex,
                                     this.CxTYPE.SelectedIndex);
                masterForm.ShowDialog();
            }
        }

        private void toolStripDeleteButton_Click(object sender, EventArgs e)
        {
           
            foreach (DataGridViewRow row in RsafDetailDataGridView.Rows)
            { 
                if (row.Selected == true)
                {
                    RsafDetailDataGridView.Rows.RemoveAt(row.Index);
                }
            }
            RsafDetailDataGridView.Refresh();
        }

        private List<DataGridViewRow> copiedRows = new List<DataGridViewRow>();

        private void toolStripCopyButton_Click(object sender, EventArgs e)
        {
            copiedRows.Clear();
            foreach (DataGridViewRow row in RsafDetailDataGridView.Rows)
                if (row.Selected == true)
                    copiedRows.Add(row);
        }

        private void toolStripPasteButton_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in copiedRows)
            {
                DataGridViewRow pastedrow = (DataGridViewRow)RsafDetailDataGridView.Rows[0].Clone();
                pastedrow.Cells[0].Value = row.Cells[0].Value;
                pastedrow.Cells[1].Value = row.Cells[1].Value;
                pastedrow.Cells[2].Value = row.Cells[2].Value;
                pastedrow.Cells[3].Value = row.Cells[3].Value;
                pastedrow.Cells[4].Value = row.Cells[4].Value;
                pastedrow.Cells[5].Value = row.Cells[5].Value;
                pastedrow.Cells[6].Value = row.Cells[6].Value;
                pastedrow.Cells[7].Value = row.Cells[7].Value;
                pastedrow.Cells[8].Value = row.Cells[8].Value;
                pastedrow.Cells[9].Value = row.Cells[9].Value;
                pastedrow.Cells[10].Value = row.Cells[10].Value;
                pastedrow.Cells[11].Value = row.Cells[11].Value;
                pastedrow.Cells[12].Value = row.Cells[12].Value;
                pastedrow.Cells[13].Value = row.Cells[13].Value;
                pastedrow.Cells[14].Value = row.Cells[14].Value;
                pastedrow.Cells[15].Value = row.Cells[15].Value;
                pastedrow.Cells[16].Value = row.Cells[16].Value;
                pastedrow.Cells[17].Value = row.Cells[17].Value;
                pastedrow.Cells[18].Value = row.Cells[18].Value;
                pastedrow.Cells[19].Value = row.Cells[19].Value;
                pastedrow.Cells[20].Value = row.Cells[20].Value;
                pastedrow.Cells[21].Value = row.Cells[21].Value;
                pastedrow.Cells[22].Value = row.Cells[22].Value;
                pastedrow.Cells[23].Value = row.Cells[23].Value;
                pastedrow.Cells[24].Value = row.Cells[24].Value;
                pastedrow.Cells[25].Value = row.Cells[25].Value;
                pastedrow.Cells[26].Value = row.Cells[26].Value;
                pastedrow.Cells[27].Value = row.Cells[27].Value;
                pastedrow.Cells[28].Value = row.Cells[28].Value;
                RsafDetailDataGridView.Rows.Add(pastedrow);
            }
        }

        private void CxSITE_TextChanged(object sender, EventArgs e)
        {
            ComboBox oComboBox = (ComboBox)sender;
            int iListIndex = oComboBox.Text.Length == 0 ? -1 : CxSITE.FindString(oComboBox.Text);
            CxSITE.SelectedIndex = iListIndex;
            if (iListIndex == -1)
            {
                CxSITE.SelectedIndex = 0;
                CxSITE.Focus();
            }
        }

        private void CxTYPE_TextChanged(object sender, EventArgs e)
        {
            ComboBox oComboBox = (ComboBox)sender;
            int iListIndex = oComboBox.Text.Length == 0 ? -1 : CxTYPE.FindString(oComboBox.Text);
            CxTYPE.SelectedIndex = iListIndex;
            if (iListIndex == -1)
            {
                CxTYPE.SelectedIndex = 0;
                CxTYPE.Focus();
            }
        }

        private void LbBAEPO_DoubleClick(object sender, EventArgs e)
        {
            long masterId = checkMaster();
            if ( masterId != 0)
            {
                POMasterForm masterForm = new POMasterForm(this);
                masterForm.SetValues(masterId,
                                     this.TxBAEPART.Text,
                                     this.TxBAEPO.Text,
                                     this.CxSITE.SelectedIndex,
                                     this.CxTYPE.SelectedIndex);
                masterForm.ShowDialog();
            }
        }

        private void LbSITE_DoubleClick(object sender, EventArgs e)
        {
            long masterId = checkMaster();
            if (masterId != 0)
            {
                POMasterForm masterForm = new POMasterForm(this);
                masterForm.SetValues(masterId,
                                     this.TxBAEPART.Text,
                                     this.TxBAEPO.Text,
                                     this.CxSITE.SelectedIndex,
                                     this.CxTYPE.SelectedIndex);
                masterForm.ShowDialog();
            }
        }

        private void LbTYPE_DoubleClick(object sender, EventArgs e)
        {
            long masterId = checkMaster();
            if (masterId != 0)
            {
                POMasterForm masterForm = new POMasterForm(this);
                masterForm.SetValues(masterId,
                                     this.TxBAEPART.Text,
                                     this.TxBAEPO.Text,
                                     this.CxSITE.SelectedIndex,
                                     this.CxTYPE.SelectedIndex);
                masterForm.ShowDialog();
            }
        }
    }
}

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

        RsafDbContext context = new RsafDbContext();
        bool changeDesc = false;
        bool changeRoid = false;

        public PODetailForm()
        {
            InitializeComponent();
        }

        private void NewPurchaseOrderForm_Load(object sender, EventArgs e)
        {
            List<RSAF_TYPE> listType = new List<RSAF_TYPE>();
            List<RSAF_SITE> listSite = new List<RSAF_SITE>();
            List<RSAF_MASTER> listMaster = new List<RSAF_MASTER>();
            var a = new RsafDbContext();
            listType = a.RSAF_TYPE.ToList();
            listSite = a.RSAF_SITE.ToList();

            var query =
                from c in a.RSAF_MASTER
                where c.DESCRIPTION != null && c.STATUS == true
                orderby c.DESCRIPTION
                select new { DESCRIPTION = c.DESCRIPTION };

            var Descriptions = query.Distinct().ToList();
            a.Dispose();

            CxTYPE.DataSource = listType;
            CxTYPE.DisplayMember = "TYPE";
            CxTYPE.ValueMember = "TYPE_CODE";

            CxSITE.DataSource = listSite;
            CxSITE.DisplayMember = "SITE";
            CxSITE.ValueMember = "SITE_CODE";

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


        private void commitChanges()
        {

            bool isPOItemNull = false;
            bool isPOItemNonUnique = false;
            bool isAnyChange = false;
            List<string> listItem = new List<string>();
            List<string> distinctlistItem = new List<string>();
            foreach (DataGridViewRow row in RsafDetailDataGridView.Rows)
            {
                if (row.Cells[5].Value.ToString() == "")
                    isPOItemNull = true;

                listItem.Add(row.Cells[5].Value.ToString());
            }

            distinctlistItem.AddRange(listItem.Distinct());

            if (listItem.Count != distinctlistItem.Count)
                isPOItemNonUnique = true;

            if (isPOItemNull)
                MessageBox.Show("Records can not be saved. All ITEM No must have a value for all items. Please check Item No values and try again.","Error");
            else 
            if (isPOItemNonUnique)
                MessageBox.Show("Records can not be saved. ITEM No fields must have unique values for each item. Please check Item No values and try again.", "Error");
            else
            {
                /* Add the new master record */
                if (checkMaster() == 0 &&
                    TxBAEPART.Text != "" &&
                    TxBAEPO.Text != "" &&
                    CxSITE.SelectedIndex != -1 &&
                    CxTYPE.SelectedIndex != -1)
                {
                    var Date = DateTime.Now;
                    var masterRecord = new RSAF_MASTER
                    {
                        CREATE_DATE = Date,
                        UPDATE_DATE = Date,
                        STATUS = true,
                        BAEPO = TxBAEPO.Text,
                        BAEPART = TxBAEPART.Text,
                        SITE = CxSITE.SelectedValue.ToString(),
                        TYPE = CxTYPE.SelectedValue.ToString(),
                        DESCRIPTION = TxDESCRIPTION.Text,
                        ROID_NO = TxROID_NO.Text
                    };
                    context.RSAF_MASTER.Add(masterRecord);
                    isAnyChange = true;
                    context.SaveChanges();
                }

                short qtyrec;
                short? Qtyrec = null;
                bool warr = false;
                DateTime ctrtdate;
                DateTime? Ctrtdate = null;
                short baeqty;
                short? Baeqty = null;
                DateTime baesent;
                DateTime? Baesent = null;
                long rrpo;
                long? Rrpo = null;
                int engmark;
                int? Engmark = null;
                int hoursnew;
                int? Hoursnew = null;
                int exengine;
                int? Exengine = null;
                long salesdocument;
                long? Salesdocument = null;
                long poreq;
                long? Poreq = null;


                /* Add the new detail records*/
                foreach (DataGridViewRow row in RsafDetailDataGridView.Rows)
                {

                    if (row.Cells[5].Value.ToString() == "")
                        isPOItemNull = false;

                    if (row.Cells[4].Value == null)
                    {
                        var Date = DateTime.Now;


                        if (short.TryParse(row.Cells[8].Value.ToString(), out qtyrec))
                            Qtyrec = qtyrec;

                        if (row.Cells[9].Value != null)
                            warr = (bool)row.Cells[9].Value;

                        if (DateTime.TryParse(row.Cells[12].Value.ToString(), out ctrtdate))
                            Ctrtdate = ctrtdate;

                        if (short.TryParse(row.Cells[13].Value.ToString(), out baeqty))
                            Baeqty = baeqty;

                        if (DateTime.TryParse(row.Cells[15].Value.ToString(), out baesent))
                            Baesent = baesent;

                        if (long.TryParse(row.Cells[19].Value.ToString(), out rrpo))
                            Rrpo = rrpo;

                        if (int.TryParse(row.Cells[20].Value.ToString(), out engmark))
                            Engmark = engmark;

                        if (int.TryParse(row.Cells[21].Value.ToString(), out hoursnew))
                            Hoursnew = hoursnew;

                        if (int.TryParse(row.Cells[24].Value.ToString(), out exengine))
                            Exengine = exengine;

                        if (long.TryParse(row.Cells[25].Value.ToString(), out salesdocument))
                            Salesdocument = salesdocument;

                        if (long.TryParse(row.Cells[26].Value.ToString(), out poreq))
                            Poreq = poreq;

                        var detailRecord = new RSAF_DETAIL
                        {
                            CREATE_DATE = Date,
                            UPDATE_DATE = Date,
                            STATUS = true,
                            MASTER_ID = checkMaster(),
                            POITEM = row.Cells[5].Value.ToString() == "" ? null : row.Cells[5].Value.ToString(),
                            PART_NO = row.Cells[6].Value.ToString() == "" ? null : row.Cells[6].Value.ToString(),
                            SERIAL = row.Cells[7].Value.ToString() == "" ? null : row.Cells[7].Value.ToString(),
                            QTYREC = Qtyrec,
                            WARR = warr,
                            OONUM = row.Cells[10].Value.ToString() == "" ? null : row.Cells[10].Value.ToString(),
                            MDR = row.Cells[11].Value.ToString() == "" ? "N/A" : row.Cells[11].Value.ToString(),
                            CTRT_DATE = Ctrtdate,
                            BAEQTY = Baeqty,
                            BAESER = row.Cells[14].Value.ToString() == "" ? null : row.Cells[14].Value.ToString(),
                            BAESENT = Baesent,
                            VENDOR = row.Cells[16].Value.ToString() == "" ? null : row.Cells[16].Value.ToString(),
                            PSIREF = row.Cells[17].Value.ToString() == "" ? null : row.Cells[17].Value.ToString(),
                            OUTPART = row.Cells[18].Value.ToString() == "" ? null : row.Cells[18].Value.ToString(),
                            RR_PO = Rrpo,
                            ENG_MARK = Engmark,
                            HOURS_NEW = Hoursnew,
                            HOURS_REP = row.Cells[22].Value.ToString() == "" ? null : row.Cells[22].Value.ToString(),
                            RFR = row.Cells[23].Value.ToString() == "" ? null : row.Cells[23].Value.ToString(),
                            EX_ENGINE = Exengine,
                            SALES_DOCUMENT = Salesdocument,
                            PO_REQ = Poreq,
                            REMARKS = row.Cells[27].Value.ToString() == "" ? null : row.Cells[27].Value.ToString(),
                            QUALITY_NO = row.Cells[28].Value.ToString() == "" ? null : row.Cells[28].Value.ToString()
                        };
                        context.RSAF_DETAIL.Add(detailRecord);
                        isAnyChange = true;
                    }
                }

                /*Update Any Change in the detail records*/
                foreach (DataGridViewRow row in RsafDetailDataGridView.Rows)
                {
                    if (row.Cells[4].Value != null)
                    {
                        var detailPO = context.RSAF_DETAIL.Find(row.Cells[4].Value);

                        if (row.Cells[5].Value == null)
                        {
                            if (detailPO.POITEM != null)
                            {
                                detailPO.POITEM = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.POITEM != row.Cells[5].Value.ToString())
                            {
                                detailPO.POITEM = row.Cells[5].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[6].Value == null)
                        {
                            if (detailPO.PART_NO != null)
                            {
                                detailPO.PART_NO = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.PART_NO != row.Cells[6].Value.ToString())
                            {
                                detailPO.PART_NO = row.Cells[6].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[7].Value == null)
                        {
                            if (detailPO.SERIAL != null)
                            {
                                detailPO.SERIAL = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.SERIAL != row.Cells[7].Value.ToString())
                            {
                                detailPO.SERIAL = row.Cells[7].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[8].Value == null)
                        {
                            if (detailPO.QTYREC != null)
                            {
                                detailPO.QTYREC = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (short.TryParse(row.Cells[8].Value.ToString(), out qtyrec))
                                if (detailPO.QTYREC != qtyrec)
                                {
                                    detailPO.QTYREC = qtyrec;
                                    isAnyChange = true;
                                }
                        }

                        if (row.Cells[9].Value == null)
                        {
                            if (detailPO.WARR != false)
                            {
                                detailPO.WARR = false;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            warr = (bool)row.Cells[9].Value;
                            if (detailPO.WARR != warr)
                            {
                                detailPO.WARR = warr;
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[10].Value == null)
                        {
                            if (detailPO.OONUM != null)
                            {
                                detailPO.OONUM = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.OONUM != row.Cells[10].Value.ToString())
                            {
                                detailPO.OONUM = row.Cells[10].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[11].Value == null)
                        {
                            if (detailPO.MDR != null)
                            {
                                detailPO.MDR = "N/A";
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.MDR != row.Cells[11].Value.ToString())
                            {
                                detailPO.MDR = row.Cells[11].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[12].Value == null || row.Cells[12].Value.ToString() =="")
                        {
                            if (detailPO.CTRT_DATE != null  )
                            {
                                detailPO.CTRT_DATE = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            DateTime.TryParse(row.Cells[12].Value.ToString(), out ctrtdate);
                            if (detailPO.CTRT_DATE != ctrtdate)
                            {
                                detailPO.CTRT_DATE = ctrtdate;
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[13].Value == null)
                        {
                            if (detailPO.BAEQTY != null)
                            {
                                detailPO.BAEQTY = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (short.TryParse(row.Cells[13].Value.ToString(), out baeqty))
                                if (detailPO.BAEQTY != baeqty)
                                {
                                    detailPO.BAEQTY = baeqty;
                                    isAnyChange = true;
                                }
                        }

                        if (row.Cells[14].Value == null)
                        {
                            if (detailPO.BAESER != null)
                            {
                                detailPO.BAESER = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.BAESER != row.Cells[14].Value.ToString())
                            {
                                detailPO.BAESER = row.Cells[14].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[15].Value == null || row.Cells[15].Value.ToString() == "")
                        {
                            if (detailPO.BAESENT != null)
                            {
                                detailPO.BAESENT = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            DateTime.TryParse(row.Cells[15].Value.ToString(), out baesent);
                            if (detailPO.BAESENT != baesent)
                            {
                                detailPO.BAESENT = baesent;
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[16].Value == null)
                        {
                            if (detailPO.VENDOR != null)
                            {
                                detailPO.VENDOR = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.VENDOR != row.Cells[16].Value.ToString())
                            {
                                detailPO.VENDOR = row.Cells[16].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[17].Value == null)
                        {
                            if (detailPO.PSIREF != null)
                            {
                                detailPO.PSIREF = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.PSIREF != row.Cells[17].Value.ToString())
                            {
                                detailPO.PSIREF = row.Cells[17].Value.ToString();
                                isAnyChange = true;
                            }
                        }


                        if (row.Cells[18].Value == null)
                        {
                            if (detailPO.OUTPART != null)
                            {
                                detailPO.OUTPART = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.OUTPART != row.Cells[18].Value.ToString())
                            {
                                detailPO.OUTPART = row.Cells[18].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[19].Value == null)
                        {
                            if (detailPO.RR_PO != null)
                            {
                                detailPO.RR_PO = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (long.TryParse(row.Cells[19].Value.ToString(), out rrpo))
                                if (detailPO.RR_PO != rrpo)
                                {
                                    detailPO.RR_PO = rrpo;
                                    isAnyChange = true;
                                }
                        }

                        if (row.Cells[20].Value == null)
                        {
                            if (detailPO.ENG_MARK != null)
                            {
                                detailPO.ENG_MARK = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (int.TryParse(row.Cells[20].Value.ToString(), out engmark))
                                if (detailPO.ENG_MARK != engmark)
                                {
                                    detailPO.ENG_MARK = engmark;
                                    isAnyChange = true;
                                }
                        }

                        if (row.Cells[21].Value == null)
                        {
                            if (detailPO.HOURS_NEW != null)
                            {
                                detailPO.HOURS_NEW = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (int.TryParse(row.Cells[21].Value.ToString(), out hoursnew))
                                if (detailPO.HOURS_NEW != hoursnew)
                                {
                                    detailPO.HOURS_NEW = hoursnew;
                                    isAnyChange = true;
                                }
                        }

                        if (row.Cells[22].Value == null)
                        {
                            if (detailPO.HOURS_REP != null)
                            {
                                detailPO.HOURS_REP = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.HOURS_REP != row.Cells[22].Value.ToString())
                            {
                                detailPO.HOURS_REP = row.Cells[22].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[23].Value == null)
                        {
                            if (detailPO.RFR != null)
                            {
                                detailPO.RFR = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.RFR != row.Cells[23].Value.ToString())
                            {
                                detailPO.RFR = row.Cells[23].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[24].Value == null)
                        {
                            if (detailPO.EX_ENGINE != null)
                            {
                                detailPO.EX_ENGINE = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (int.TryParse(row.Cells[24].Value.ToString(), out exengine))
                                if (detailPO.EX_ENGINE != exengine)
                                {
                                    detailPO.EX_ENGINE = exengine;
                                    isAnyChange = true;
                                }
                        }

                        if (row.Cells[25].Value == null)
                        {
                            if (detailPO.SALES_DOCUMENT != null)
                            {
                                detailPO.SALES_DOCUMENT = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (long.TryParse(row.Cells[25].Value.ToString(), out salesdocument))
                                if (detailPO.SALES_DOCUMENT != salesdocument)
                                {
                                    detailPO.SALES_DOCUMENT = salesdocument;
                                    isAnyChange = true;
                                }
                        }

                        if (row.Cells[26].Value == null)
                        {
                            if (detailPO.PO_REQ != null)
                            {
                                detailPO.PO_REQ = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (long.TryParse(row.Cells[26].Value.ToString(), out poreq))
                                if (detailPO.PO_REQ != poreq)
                                {
                                    detailPO.PO_REQ = poreq;
                                    isAnyChange = true;
                                }
                        }

                        if (row.Cells[27].Value == null)
                        {
                            if (detailPO.REMARKS != null)
                            {
                                detailPO.REMARKS = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.REMARKS != row.Cells[27].Value.ToString())
                            {
                                detailPO.REMARKS = row.Cells[27].Value.ToString();
                                isAnyChange = true;
                            }
                        }

                        if (row.Cells[28].Value == null)
                        {
                            if (detailPO.QUALITY_NO != null)
                            {
                                detailPO.QUALITY_NO = null;
                                isAnyChange = true;
                            }
                        }
                        else
                        {
                            if (detailPO.QUALITY_NO != row.Cells[28].Value.ToString())
                            {
                                detailPO.QUALITY_NO = row.Cells[28].Value.ToString();
                                isAnyChange = true;
                            }
                        }
                    }
                }

                context.SaveChanges();
                if (isAnyChange || changeDesc || changeRoid)
                {
                    changeDesc = false;
                    changeRoid = false;
                    FindDetails();
                    toolStripStatusLabel.Text = "Saved Changes";
                }
            }
        }

        private void RsafDetailBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.RsafDetailBindingSource.EndEdit();
            commitChanges();
        }

        private void BtAddNewItem_Click(object sender, EventArgs e)
        {
            POItemEntryForm entryItemForm = new POItemEntryForm(purposeType.Add, this);
            toolStripStatusLabel.Text = "Adding a New Purchase Order";
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

            RsafDetailDataGridView.Rows.Add(
            DateTime.Now        //CREATE_DATE
            , null               //UPDATE_DATTE
            , true               //STATUS
            , null               //MASTER_ID
            , null               //DETAIL_ID
            , pPOITEM
            , pPART_NO
            , pSERIAL
            , pQTYREC
            , pWARR
            , pOONUM
            , pMDR
            , pCTRT_DATE
            , pBAEQTY
            , pBAESER
            , pBAESENT
            , pVENDOR
            , pPSIREF
            , pOUTPART
            , pRR_PO
            , pENG_MARK
            , pHOURS_NEW
            , pHOURS_REP
            , pRFR
            , pEX_ENGINE
            , pSALES_DOCUMENT
            , pPO_REQ
            , pREMARKS
            , pQUALITY_NO);

            toolStripStatusLabel.Text = "Added a new PO Item";
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
             WARR != null ? (bool)WARR : false,
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

            toolStripStatusLabel.Text = "Editing the PO Item";
            entryItemForm.ShowDialog();

        }
        //
        private void FindDetails()
        {
            long masterId = 0;
            List<RSAF_MASTER> listMaster = new List<RSAF_MASTER>();
            List<RSAF_DETAIL> listDetail = new List<RSAF_DETAIL>();
            var a = new RsafDbContext();
            bool isFetched = false;

            listMaster = a.RSAF_MASTER.Where(c => c.STATUS == true
                                               && c.BAEPART == TxBAEPART.Text.ToString()
                                               && c.BAEPO == TxBAEPO.Text.ToString()
                                               && c.SITE == CxSITE.SelectedValue.ToString()
                                               && c.TYPE == CxTYPE.SelectedValue.ToString()).ToList();

            string desc = "";
            string roidNo = "";
            if (listMaster != null)
                foreach (var x in listMaster)
                {
                    masterId = listMaster.First().MASTER_ID;
                    desc = listMaster.First().DESCRIPTION;
                    roidNo = listMaster.First().ROID_NO;
                }

            TxDESCRIPTION.Text = desc;
            TxROID_NO.Text = roidNo;
            changeDesc = false;
            changeRoid = false;

            RsafDetailDataGridView.Rows.Clear();
            RsafDetailDataGridView.Refresh();
            if (masterId != 0)
            {
                listDetail = a.RSAF_DETAIL.Where(c => c.MASTER_ID == masterId && c.STATUS == true)
                                          .OrderBy(c => c.DETAIL_ID)
                                          .ToList();

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
                    if (dtl.CTRT_DATE != null)
                        row.Cells[12].Value = dtl.CTRT_DATE.Value.Date.ToShortDateString();
                    row.Cells[13].Value = dtl.BAEQTY;
                    row.Cells[14].Value = dtl.BAESER;
                    if (dtl.BAESENT != null)
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
                    isFetched = true;
                }
                RsafDetailDataGridView.AllowUserToAddRows = false;
                a.Dispose();
                if (isFetched)
                    toolStripStatusLabel.Text = "Fetched the Existing PO Item(s)";
                else
                    toolStripStatusLabel.Text = "Fetched the Existing Purchase Order";

            }
            else
                toolStripStatusLabel.Text = "Entering a New Purchase Order";

        }

        private void TxBAEPART_TextChanged(object sender, EventArgs e)
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
            listMaster = a.RSAF_MASTER.Where(c => c.STATUS == true
                                               && c.BAEPART == TxBAEPART.Text.ToString()
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
                toolStripStatusLabel.Text = "Editing Purchase Order Header";

                masterForm.ShowDialog();
            }
        }

        private void toolStripDeleteButton_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in RsafDetailDataGridView.Rows)
            {
                if (row.Selected == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to remove the selected PO Item?", "Delete Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (row.Cells[4].Value != null)
                        {
                            var detailPO = context.RSAF_DETAIL.Find(row.Cells[4].Value);
                            detailPO.STATUS = false;
                            toolStripStatusLabel.Text = "Deleted PO Item";
                        }
                        RsafDetailDataGridView.Rows.RemoveAt(row.Index);
                    }
                }
            }
            RsafDetailDataGridView.Refresh();

            long masterId = checkMaster();

            var query =
                from c in context.RSAF_DETAIL
                where c.MASTER_ID == masterId && c.STATUS == true
                select new { DETAIL_ID = c.DETAIL_ID };

            var countDetail = query.Distinct().ToList().Count;

            if (masterId != 0 && countDetail == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to remove the Purchase Order Header?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var masterPO = context.RSAF_MASTER.Find(masterId);
                    masterPO.STATUS = false;
                    TxBAEPO.Text = "";
                    TxBAEPART.Text = "";
                    TxDESCRIPTION.Text = "";
                    TxROID_NO.Text = "";
                    CxSITE.SelectedIndex = 0;
                    CxTYPE.SelectedIndex = 0;
                    toolStripStatusLabel.Text = "Deleted PO Header";
                }
            }

        }

        private List<DataGridViewRow> copiedRows = new List<DataGridViewRow>();

        private void toolStripCopyButton_Click(object sender, EventArgs e)
        {
            bool isCopied = false;
            copiedRows.Clear();
            foreach (DataGridViewRow row in RsafDetailDataGridView.Rows)
                if (row.Selected == true)
                {
                    copiedRows.Add(row);
                    isCopied = true;
                }
            if (isCopied)
                toolStripStatusLabel.Text = "Copied the PO Item";

        }

        private void toolStripPasteButton_Click(object sender, EventArgs e)
        {
            bool isPasted = false;
            foreach (DataGridViewRow row in copiedRows)
            {
                isPasted = true;
                DataGridViewRow pastedrow = (DataGridViewRow)RsafDetailDataGridView.Rows[0].Clone();
                pastedrow.Cells[0].Value = row.Cells[0].Value;
                pastedrow.Cells[2].Value = row.Cells[2].Value;
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
            if (isPasted)
                toolStripStatusLabel.Text = "Pasted the PO Item";
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
            if (masterId != 0)
            {
                POMasterForm masterForm = new POMasterForm(this);
                masterForm.SetValues(masterId,
                                     this.TxBAEPART.Text,
                                     this.TxBAEPO.Text,
                                     this.CxSITE.SelectedIndex,
                                     this.CxTYPE.SelectedIndex);
                toolStripStatusLabel.Text = "Editing Purchase Order Header";

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
                toolStripStatusLabel.Text = "Editing Purchase Order Header";

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
                toolStripStatusLabel.Text = "Editing Purchase Order Header";

                masterForm.ShowDialog();
            }
        }

        private void TxDESCRIPTION_TextChanged(object sender, EventArgs e)
        {
            var mId = checkMaster();
            if (mId != 0)
            {
                var masterPO = context.RSAF_MASTER.Find(mId);
                masterPO.DESCRIPTION = this.TxDESCRIPTION.Text;
                toolStripStatusLabel.Text = "Changed Existing Purchase Order Description";
                changeDesc = true;
            }
        }

        private void PODetailForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Dispose();
        }

        private void TxROID_NO_TextChanged(object sender, EventArgs e)
        {
            var mId = checkMaster();
            if (mId != 0)
            {
                var masterPO = context.RSAF_MASTER.Find(mId);
                masterPO.ROID_NO = this.TxROID_NO.Text;
                toolStripStatusLabel.Text = "Changed Existing Purchase Order ROID No";
                changeRoid = true;
            }
        }

        private void PODetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var change = false;
            var entries = context.ChangeTracker.Entries();
            foreach (var entry in entries)
                if (entry.State != System.Data.Entity.EntityState.Unchanged)
                change = true;

            bool changeAddNewItem=false;
            foreach (DataGridViewRow row in RsafDetailDataGridView.Rows)
                if (row.Cells[4].Value == null)
                    changeAddNewItem = true;

            if (change || changeDesc || changeRoid || changeAddNewItem)
            {
                toolStripStatusLabel.Text = "The Form Closing";
                DialogResult dialogResult = MessageBox.Show("Would you like to save changings before leaving?", "Save Changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    commitChanges();
            }
        }
    }
}
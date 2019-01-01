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
    public partial class POSearchEditItemForm : Form
    {
        RsafDbContext rsafDbContext = new RsafDbContext();
        long masterId;
        long detailId;
        List<RSAF_DETAIL> query;


        public POSearchEditItemForm()
        {
            InitializeComponent();
        }

        private void BtARCHIVE_Click(object sender, EventArgs e)
        {
            POArchiveForm archiveForm = new POArchiveForm();

            if (TxDETAIL_ID.Text != "")
                archiveForm.loadArchieve(long.Parse(TxDETAIL_ID.Text));
            archiveForm.ShowDialog();
        }

        private void POSearchEditItemForm_Load(object sender, EventArgs e)
        {
            List<RSAF_TYPE> listType = new List<RSAF_TYPE>();
            List<RSAF_SITE> listSite = new List<RSAF_SITE>();


            var detail = rsafDbContext.RSAF_DETAIL.Where(c => c.ARCHIVE == false)
                                                  .OrderBy(c => c.POITEM)
                                                  .OrderBy(c => c.MASTER_ID)
                                                  .OrderByDescending(c => c.BAESENT)
                                                  .ToList();

            RsafDetailBindingSource.DataSource = detail;


            var type = rsafDbContext.RSAF_TYPE.ToList();
            listType = type;

            CxTYPE.DataSource = type;
            CxTYPE.DisplayMember = "TYPE";
            CxTYPE.ValueMember = "TYPE_CODE";

            var site = rsafDbContext.RSAF_SITE.ToList();
            listSite = site;

            CxSITE.DataSource = site;
            CxSITE.DisplayMember = "SITE";
            CxSITE.ValueMember = "SITE_CODE";

            masterId = detail.First().MASTER_ID;
            detailId = detail.First().DETAIL_ID;
            var master = rsafDbContext.RSAF_MASTER.Where(c => c.MASTER_ID == masterId).ToList();
            foreach (var x in master)
            {
                CxTYPE.SelectedValue = x.TYPE;
                CxSITE.SelectedValue = x.SITE;
                TxDESCRIPTION.Text = x.DESCRIPTION;
                TxBAEPART.Text = x.BAEPART;
                TxBAEPO.Text = x.BAEPO;
                TxROID_NO.Text = x.ROID_NO;
            }


            this.CbSTATUS.Visible = false;
            this.TxMASTER_ID.Visible = false;
            this.DtUPDATE_DATE.Visible = false;
            this.TxDETAIL_ID.Visible = false;

            long numberOfrecords = detail.Count;
            string msg;

            if (numberOfrecords == 0)
                msg = "Found no record ";
            else
            {
                if (numberOfrecords == 1)
                    msg = "Found 1 record ";
                else
                    msg = "Found " + numberOfrecords.ToString() + " records ";
            }

            toolStripStatusLabel.Text = msg + "which ARCHIVED equals to untick.";
        }
        public void postSearchCriteria(int pFieldIndex,
                                       bool pCheckboxValue,
                                       string pTextValue,
                                       string pListboxValue,
                                       Nullable<System.DateTime> pDateValue,
                                       string pSearchCriteria)
        {

            this.toolStripStatusLabel.Text = "Searching ...";
            DateTime vDateValue = DateTime.Now;
            string msgLast = "";
            if (pDateValue.Value != null)
                vDateValue = DateTime.Parse(pDateValue.Value.ToShortDateString());

            switch (pFieldIndex)
            {
                case 0://TxBAEPART
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.BAEPART == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which BAe P/N equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.BAEPART.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which BAe P/N contains " + pTextValue + ".";
                    }
                    break;
                case 1://TxBAESER
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.BAESER == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which BAES S/N equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.BAESER.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which BAES S/N contains " + pTextValue + ".";
                    }
                    break;
                case 2://TxBAEQTY
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.BAEQTY.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which BAES QTY equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.BAEQTY.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which BAES QTY contains " + pTextValue + ".";
                    }
                    break;
                case 3://DtBAESENT
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.BAESENT.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which BAES PO DATE equals to " + vDateValue.ToShortDateString() + ".";
                    break;
                case 4://TxBAEPO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.BAEPO == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which BAe Po No equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.BAEPO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which BAe Po No contains " + pTextValue + ".";
                    }
                    break;
                case 5://TxPOITEM
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.POITEM == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which ITEM No equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.POITEM.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which ITEM No contains " + pTextValue + ".";
                    }
                    break;
                case 6://CbWARR
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.WARR == pCheckboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    if (pCheckboxValue)
                        msgLast = "which WARRANTY equals to tick.";
                    else
                        msgLast = "which WARRANTY equals to untick."; ;
                    break;
                case 7://CbPOIC
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.POIC == pCheckboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();

                    if (pCheckboxValue)
                        msgLast = "which PO ITEM CLOSED equals to tick.";
                    else
                        msgLast = "which PO ITEM CLOSED equals to untick."; ;
                    break;
                case 8://TxPART_NO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PART_NO == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();

                        msgLast = "which RECVD P/N equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PART_NO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which RECVD P/N contains " + pTextValue + ".";
                    }
                    break;
                case 9://TxSERIAL
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.SERIAL == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which RECVD S/N equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.SERIAL.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which RECVD S/N contains " + pTextValue + ".";
                    }
                    break;
                case 10://TxQTYREC
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QTYREC.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which RECVD QTY equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QTYREC.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which RECVD QTY contains " + pTextValue + ".";
                    }
                    break;
                case 11://DtRECDATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.RECDATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which RECVD DATE equals to " + vDateValue.ToShortDateString() + ".";
                    break;
                case 12://TxOONUM
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.OONUM == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which SAP NWA equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.OONUM.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which SAP NWA contains " + pTextValue + ".";
                    }
                    break;
                case 13://TxPSIREF
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PSIREF == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which R.I. REF equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PSIREF.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which R.I. REF contains " + pTextValue + ".";
                    }
                    break;
                case 14://DtPSIDATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.PSIDATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which DATE equals to " + vDateValue.ToShortDateString() + ".";
                    break;
                case 15://TxEX_ENGINE
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.EX_ENGINE.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which EX ENGINE equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.EX_ENGINE.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which EX ENGINE contains " + pTextValue + ".";
                    }
                    break;
                case 16://TxENG_MARK
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.ENG_MARK.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which ENG MK equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.ENG_MARK.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which ENG MK contains " + pTextValue + ".";
                    }
                    break;
                case 17://TxHOURS_NEW
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.HOURS_NEW.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which HOURS NEW equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.HOURS_NEW.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which HOURS NEW contains " + pTextValue + ".";
                    }
                    break;
                case 18://TxHOURS_REP
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.HOURS_REP == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which HOURS REP equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.HOURS_REP.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which HOURS REP contains " + pTextValue + ".";
                    }
                    break;
                case 19://CxSITE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.SITE == pListboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which SITE equals to " + pListboxValue + ".";
                    break;
                case 20://CxTYPE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.TYPE == pListboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which TYPE equals to " + pListboxValue + ".";
                    break;
                case 21://TxOUTPART
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.OUTPART == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which P/N EX REPAIR equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.OUTPART.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which P/N EX REPAIR contains " + pTextValue + ".";
                    }
                    break;
                case 22://TxQTYSCRP
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QTYSCRP.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which SCRAP equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QTYSCRP.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which SCRAP contains " + pTextValue + ".";
                    }
                    break;
                case 23://TxRCP
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RCP.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which REPAIR COST (£) equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RCP.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which REPAIR COST (£) contains " + pTextValue + ".";
                    }
                    break;
                case 24://TxEURO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.EURO.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which EURO equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.EURO.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which EURO contains " + pTextValue + ".";
                    }
                    break;
                case 25://TxQUOTE_REF
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QUOTE_REF == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which QUOTE No equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QUOTE_REF.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which QUOTE No contains " + pTextValue + ".";
                    }
                    break;
                case 26://DtQUOTE_REF_DATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.QUOTE_REF_DATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which QUOTE DATE equals to " + vDateValue.ToShortDateString() + ".";
                    break;
                case 27://CbARCHIVE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.ARCHIVE == pCheckboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    if (pCheckboxValue)
                        msgLast = "which ARCHIVED equals to tick.";
                    else
                        msgLast = "which ARCHIVED equals to untick.";
                    break;
                case 28://TxDESPTOBA
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.DESPTOBA == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which R.R. R/NOTE equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.DESPTOBA.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which R.R. R/NOTE contains " + pTextValue + ".";
                    }
                    break;
                case 29://DtDESPDATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.DESPDATE.Value == pDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which DESPATCH DATE equals to " + vDateValue.ToShortDateString() + ".";
                    break;
                case 30://TxAWB_DETAILS
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.AWB_DETAILS == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which AWB DETAILS equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.AWB_DETAILS.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which AWB DETAILS contains " + pTextValue + ".";
                    }
                    break;
                case 31://DtINVOICE_REQUESTED
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.INVOICE_REQUESTED.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which INVOICE DATE equals to " + vDateValue.ToShortDateString() + ".";
                    break;
                case 32://TxINVOICE_NO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.INVOICE_NO == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which INVOICE No equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.INVOICE_NO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which INVOICE No contains " + pTextValue + ".";
                    }
                    break;
                case 33://DtCTRT_DATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.CTRT_DATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which CONTRACT DATE equals to " + vDateValue.ToShortDateString() + ".";
                    break;
                case 34://TxDESCRIPTION
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.DESCRIPTION == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which DESCRIPTION equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.DESCRIPTION.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which DESCRIPTION contains " + pTextValue + ".";
                    }
                    break;
                case 35://TxACC_STG
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.ACC_STG.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which P or A STG equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.ACC_STG.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which P or A STG contains " + pTextValue + ".";
                    }
                    break;
                case 36://TxPAEURO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PAEURO.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which P or A EURO equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PAEURO.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which P or A EURO contains " + pTextValue + ".";
                    }
                    break;
                case 37://DtPROMISE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.PROMISE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which PROMISE DATE equals to " + vDateValue.ToShortDateString() + ".";
                    break;
                case 38://TxRFR
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RFR == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which R.F.R equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RFR.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which R.F.R contains " + pTextValue + ".";
                    }
                    break;
                case 39://TxMDR
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.MDR == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which MDR equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.MDR.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which MDR contains " + pTextValue + ".";
                    }
                    break;
                case 40://TxQUALITY_NO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QUALITY_NO == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which QUALITY No equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QUALITY_NO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which QUALITY No contains " + pTextValue + ".";
                    }
                    break;
                case 41://TxSALES_DOCUMENT
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.SALES_DOCUMENT.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which SALES DOC No equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.SALES_DOCUMENT.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which SALES DOC No contains " + pTextValue + ".";
                    }
                    break;
                case 42://TxSAP_SES
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.SAP_SES.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which SAP SES equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.SAP_SES.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which SAP SES contains " + pTextValue + ".";
                    }
                    break;
                case 43://TxROID_NO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.ROID_NO == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which ROID No equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.ROID_NO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which ROID No contains " + pTextValue + ".";
                    }
                    break;
                case 44://TxVENDOR
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which VENDOR equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which VENDOR contains " + pTextValue + ".";
                    }
                    break;
                case 45://TxVENDOR_COFC
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR_COFC == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which VENDOR CofC equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR_COFC.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which VENDOR CofC contains " + pTextValue + ".";
                    }
                    break;
                case 46://TxVENDOR_MATERIAL_COST
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR_MATERIAL_COST.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which VENDOR MAT COST equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR_MATERIAL_COST.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which VENDOR MAT COST contains " + pTextValue + ".";
                    }
                    break;
                case 47://TxVENDOR_LABOR_COST
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR_LABOR_COST.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which VENDOR LAB COST equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR_LABOR_COST.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which VENDOR LAB COST contains " + pTextValue + ".";
                    }
                    break;
                case 48://TxRR_PO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RR_PO.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which RR PO equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RR_PO.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which RR PO contains " + pTextValue + ".";
                    }
                    break;
                case 49://TxPO_REQ
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PO_REQ.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which PO REQ equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PO_REQ.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which PO REQ contains " + pTextValue + ".";
                    }
                    break;
                case 50://CbINVOICE_PAID
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.INVOICE_PAID == pCheckboxValue)
                                                 .OrderBy(c => c.POITEM)
                                                 .OrderBy(c => c.MASTER_ID)
                                                 .OrderByDescending(c => c.BAESENT)
                                                 .ToList();
                    if (pCheckboxValue)
                        msgLast = "which INVOICE PAID equals to tick.";
                    else
                        msgLast = "which INVOICE PAID equals to untick.";
                    break;
                case 51://TxREMARKS
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.REMARKS == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which REMARKS equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.REMARKS.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which REMARKS contains " + pTextValue + ".";
                    }
                    break;
                case 52://TxMODULE_TEXT
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.MODULE_TEXT == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which MODULE TEXT equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.MODULE_TEXT.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which MODULE TEXT contains " + pTextValue + ".";
                    }
                    break;
                case 53://DtFLEX_DATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX_DATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    msgLast = "which FLEX DATE equals to " + vDateValue.ToShortDateString() + ".";
                    break;
                case 54://TxFLEX1
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX1 == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which FLEX1 equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX1.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which FLEX1 contains " + pTextValue + ".";
                    }
                    break;
                case 55://TxFLEX2
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX2 == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which FLEX2 equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX2.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which FLEX2 contains " + pTextValue + ".";
                    }
                    break;
                case 56://TxFLEX3
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX3 == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which FLEX3 equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX3.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which FLEX3 contains " + pTextValue + ".";
                    }
                    break;
                case 57://TxFLEX4
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX4 == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which FLEX4 equals to " + pTextValue + ".";
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX4.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                        msgLast = "which FLEX4 contains " + pTextValue + ".";
                    }
                    break;
            }

            RsafDetailBindingSource.DataSource = query;
            long numberOfrecords = query.Count;
            string msgFirst;
            if (numberOfrecords == 0)
                msgFirst = "Found no record ";
            else
            {
                if (numberOfrecords == 1)
                    msgFirst = "Found 1 record ";
                else
                    msgFirst = "Found " + numberOfrecords.ToString() + " records ";
            }
            toolStripStatusLabel.Text = msgFirst + msgLast;
        }

        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Boolean isChanged = false;
            foreach (var entry in rsafDbContext.ChangeTracker.Entries<RSAF_DETAIL>())
                if (entry.State == System.Data.Entity.EntityState.Modified)
                    isChanged = true;

            rsafDbContext.SaveChanges();

            if (isChanged)
                toolStripStatusLabel.Text = "Saved Changes.";
            else
                toolStripStatusLabel.Text = "No changes to be saved.";

        }
        private void DtDESPDATE_KeyDown(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            DateTime CurrentDate = DateTime.Now;
            DateTime ReceivedDate = DtRECDATE.CustomFormat == " " ? CurrentDate : DtRECDATE.Value;
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                DtDESPDATE.CustomFormat = " ";
                detailPO.DESPDATE = null;
                toolStripStatusLabel.Text = "Edited DESPATCH DATE";
            }
            if (e.KeyCode == Keys.Space)
            {
                if (detailPO.DESPDATE == null)
                {
                    detailPO.DESPDATE = CurrentDate;
                    DtDESPDATE.Value = CurrentDate;
                }
                DtDESPDATE.CustomFormat = "dd/MM/yyyy";
                toolStripStatusLabel.Text = "Edited DESPATCH DATE";
            }
            if (CurrentDate == ReceivedDate)
                TxELAPSED_TIME.Text = "";
            else
                TxELAPSED_TIME.Text = (DtDESPDATE.CustomFormat == " ") ? (CurrentDate - ReceivedDate).Days.ToString() : "";
        }

        private void DtDESPDATE_ValueChanged(object sender, EventArgs e)
        {
            if (TxDETAIL_ID.Text != "")
            {
                var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
                if (detailPO.DESPDATE != DtDESPDATE.Value)
                {
                    detailPO.DESPDATE = DtDESPDATE.Value;
                    toolStripStatusLabel.Text = "Edited DESPATCH DATE";
                }
            }
            DtDESPDATE.CustomFormat = "dd/MM/yyyy";
            TxELAPSED_TIME.Text = "";
        }

        private void DtINVOICE_REQUESTED_ValueChanged(object sender, EventArgs e)
        {
            if (TxDETAIL_ID.Text != "")
            {
                var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
                if (detailPO.INVOICE_REQUESTED != DtINVOICE_REQUESTED.Value)
                {
                    detailPO.INVOICE_REQUESTED = DtINVOICE_REQUESTED.Value;
                    toolStripStatusLabel.Text = "Edited INVOICE DATE";
                }
            }
            DtINVOICE_REQUESTED.CustomFormat = "dd/MM/yyyy";
        }

        private void DtINVOICE_REQUESTED_KeyDown(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                DtINVOICE_REQUESTED.CustomFormat = " ";
                detailPO.INVOICE_REQUESTED = null;
                toolStripStatusLabel.Text = "Edited INVOICE DATE";
            }
            if (e.KeyCode == Keys.Space)
            {
                DateTime CurrentDate = DateTime.Now.Date;
                if (detailPO.INVOICE_REQUESTED == null)
                {
                    detailPO.INVOICE_REQUESTED = CurrentDate;
                    DtINVOICE_REQUESTED.Value = CurrentDate;
                    toolStripStatusLabel.Text = "Edited INVOICE DATE";
                }
                DtINVOICE_REQUESTED.CustomFormat = "dd/MM/yyyy";
            }
        }

        private void DtBAESENT_ValueChanged(object sender, EventArgs e)
        {
            if (TxDETAIL_ID.Text != "")
            {
                var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
                if (detailPO.BAESENT != DtBAESENT.Value)
                {
                    detailPO.BAESENT = DtBAESENT.Value;
                    toolStripStatusLabel.Text = "Edited BAES PO DATE";
                }
            }
            DtBAESENT.CustomFormat = "dd/MM/yyyy";
        }

        private void DtBAESENT_KeyDown(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                DtBAESENT.CustomFormat = " ";
                detailPO.BAESENT = null;
                toolStripStatusLabel.Text = "Edited BAES PO DATE";
            }
            if (e.KeyCode == Keys.Space)
            {
                DateTime CurrentDate = DateTime.Now.Date;
                if (detailPO.BAESENT == null)
                {
                    detailPO.BAESENT = CurrentDate;
                    DtBAESENT.Value = CurrentDate;
                    toolStripStatusLabel.Text = "Edited BAES PO DATE";
                }
                DtBAESENT.CustomFormat = "dd/MM/yyyy";
            }
        }

        private void DtRECDATE_ValueChanged(object sender, EventArgs e)
        {
            DtRECDATE.CustomFormat = "dd/MM/yyyy";

            if (TxDETAIL_ID.Text != "")
            {
                var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
                if (detailPO.RECDATE != DtRECDATE.Value)
                {
                    detailPO.RECDATE = DtRECDATE.Value;
                    toolStripStatusLabel.Text = "Edited RECVD DATE";
                }
            }

            DateTime CurrentDate = DateTime.Now;
            DateTime ReceivedDate = DtRECDATE.CustomFormat == " " ? CurrentDate : DtRECDATE.Value;
            if (CurrentDate == ReceivedDate)
                TxELAPSED_TIME.Text = "";
            else
                TxELAPSED_TIME.Text = (DtDESPDATE.CustomFormat == " ") ? (CurrentDate - ReceivedDate).Days.ToString() : "";
        }

        private void DtRECDATE_KeyDown(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            DateTime CurrentDate = DateTime.Now;
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                DtRECDATE.CustomFormat = " ";
                detailPO.RECDATE = null;
                toolStripStatusLabel.Text = "Edited RECVD DATE";
            }
            if (e.KeyCode == Keys.Space)
            {
                if (detailPO.RECDATE == null)
                {
                    detailPO.RECDATE = CurrentDate;
                    DtRECDATE.Value = CurrentDate;
                    toolStripStatusLabel.Text = "Edited RECVD DATE";
                }
                DtRECDATE.CustomFormat = "dd/MM/yyyy";
            }
            DateTime ReceivedDate = DtRECDATE.CustomFormat == " " ? CurrentDate : DtRECDATE.Value;
            if (CurrentDate == ReceivedDate)
                TxELAPSED_TIME.Text = "";
            else
                TxELAPSED_TIME.Text = (DtDESPDATE.CustomFormat == " ") ? (CurrentDate - ReceivedDate).Days.ToString() : "";
        }

        private void DtQUOTE_REF_DATE_ValueChanged(object sender, EventArgs e)
        {
            if (TxDETAIL_ID.Text != "")
            {
                var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
                if (detailPO.QUOTE_REF_DATE != DtQUOTE_REF_DATE.Value)
                {
                    detailPO.QUOTE_REF_DATE = DtQUOTE_REF_DATE.Value;
                    toolStripStatusLabel.Text = "Edited QUOTE DATE";
                }
            }
            DtQUOTE_REF_DATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtQUOTE_REF_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                DtQUOTE_REF_DATE.CustomFormat = " ";
                detailPO.QUOTE_REF_DATE = null;
                toolStripStatusLabel.Text = "Edited QUOTE DATE";
            }
            if (e.KeyCode == Keys.Space)
            {
                DateTime CurrentDate = DateTime.Now.Date;
                if (detailPO.QUOTE_REF_DATE == null)
                {
                    detailPO.QUOTE_REF_DATE = CurrentDate;
                    DtQUOTE_REF_DATE.Value = CurrentDate;
                    toolStripStatusLabel.Text = "Edited QUOTE DATE";
                }
                DtQUOTE_REF_DATE.CustomFormat = "dd/MM/yyyy";
            }
        }

        private void DtCTRT_DATE_ValueChanged(object sender, EventArgs e)
        {
            if (TxDETAIL_ID.Text != "")
            {
                var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
                if (detailPO.CTRT_DATE != DtCTRT_DATE.Value)
                {
                    detailPO.CTRT_DATE = DtCTRT_DATE.Value;
                    toolStripStatusLabel.Text = "Edited CONTRACT DATE";
                }
            }
            DtCTRT_DATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtCTRT_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                DtCTRT_DATE.CustomFormat = " ";
                detailPO.CTRT_DATE = null;
                toolStripStatusLabel.Text = "Edited CONTRACT DATE";
            }
            if (e.KeyCode == Keys.Space)
            {
                DateTime CurrentDate = DateTime.Now.Date;
                if (detailPO.CTRT_DATE == null)
                {
                    detailPO.CTRT_DATE = CurrentDate;
                    DtCTRT_DATE.Value = CurrentDate;
                    toolStripStatusLabel.Text = "Edited CONTRACT DATE";
                }
                DtCTRT_DATE.CustomFormat = "dd/MM/yyyy";
            }
        }

        private void DtPROMISE_ValueChanged(object sender, EventArgs e)
        {
            if (TxDETAIL_ID.Text != "")
            {
                var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
                if (detailPO.PROMISE != DtPROMISE.Value)
                {
                    detailPO.PROMISE = DtPROMISE.Value;
                    toolStripStatusLabel.Text = "Edited PROMISE DATE";
                }
            }
            DtPROMISE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtPROMISE_KeyDown(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                DtPROMISE.CustomFormat = " ";
                detailPO.PROMISE = null;
                toolStripStatusLabel.Text = "Edited PROMISE DATE";
            }
            if (e.KeyCode == Keys.Space)
            {
                DateTime CurrentDate = DateTime.Now.Date;
                if (detailPO.PROMISE == null)
                {
                    detailPO.PROMISE = CurrentDate;
                    DtPROMISE.Value = CurrentDate;
                    toolStripStatusLabel.Text = "Edited PROMISE DATE";
                }
                DtPROMISE.CustomFormat = "dd/MM/yyyy";
            }
        }

        private void DtFLEX_DATE_ValueChanged(object sender, EventArgs e)
        {
            if (TxDETAIL_ID.Text != "")
            {
                var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
                if (detailPO.FLEX_DATE != DtFLEX_DATE.Value)
                {
                    detailPO.FLEX_DATE = DtFLEX_DATE.Value;
                    toolStripStatusLabel.Text = "Edited FLEX DATE";
                }
            }
            DtFLEX_DATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtFLEX_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                DtFLEX_DATE.CustomFormat = " ";
                detailPO.FLEX_DATE = null;
                toolStripStatusLabel.Text = "Edited FLEX DATE";
            }
            if (e.KeyCode == Keys.Space)
            {
                DateTime CurrentDate = DateTime.Now.Date;
                if (detailPO.FLEX_DATE == null)
                {
                    detailPO.FLEX_DATE = CurrentDate;
                    DtFLEX_DATE.Value = CurrentDate;
                    toolStripStatusLabel.Text = "Edited FLEX DATE";
                }
                DtFLEX_DATE.CustomFormat = "dd/MM/yyyy";
            }
        }
        private void DtPSIDATE_ValueChanged(object sender, EventArgs e)
        {
            if (TxDETAIL_ID.Text != "")
            {
                var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
                if (detailPO.PSIDATE != DtPSIDATE.Value)
                {
                    detailPO.PSIDATE = DtPSIDATE.Value;
                    toolStripStatusLabel.Text = "Edited DATE";
                }
            }
            DtPSIDATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtPSIDATE_KeyDown(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                DtPSIDATE.CustomFormat = " ";
                detailPO.PSIDATE = null;
                toolStripStatusLabel.Text = "Edited DATE";
            }
            if (e.KeyCode == Keys.Space)
            {
                DateTime CurrentDate = DateTime.Now.Date;
                if (detailPO.PSIDATE == null)
                {
                    detailPO.PSIDATE = CurrentDate;
                    DtPSIDATE.Value = CurrentDate;
                    toolStripStatusLabel.Text = "Edited DATE";
                }
                DtPSIDATE.CustomFormat = "dd/MM/yyyy";
            }
        }

        private void RsafDetailBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            long value;
            masterId = long.TryParse(TxMASTER_ID.Text, out value) ? value : 0;
            try
            {
                var master = rsafDbContext.RSAF_MASTER.Where(c => c.MASTER_ID == masterId).ToList();
                foreach (var x in master)
                {
                    CxTYPE.SelectedValue = x.TYPE;
                    CxSITE.SelectedValue = x.SITE;
                    TxDESCRIPTION.Text = x.DESCRIPTION;
                    TxBAEPART.Text = x.BAEPART;
                    TxBAEPO.Text = x.BAEPO;
                }
            }
            catch
            {

            }

            detailId = long.TryParse(TxDETAIL_ID.Text, out value) ? value : 0;

            if (detailId != 0)
            {
                RSAF_DETAIL detailPO;
                DateTime CurrentDate = DateTime.Now;
                DateTime ReceivedDate = CurrentDate;
                try
                {
                    detailPO = rsafDbContext.RSAF_DETAIL.Find(detailId);

                    ReceivedDate = detailPO.RECDATE == null ? ReceivedDate : detailPO.RECDATE.Value;
                    if (CurrentDate == ReceivedDate)
                        TxELAPSED_TIME.Text = "";
                    else
                        TxELAPSED_TIME.Text = (detailPO.DESPDATE == null) ? (CurrentDate - ReceivedDate).Days.ToString() : "";

                    if (detailPO.DESPDATE == null)
                        DtDESPDATE.CustomFormat = " ";
                    else
                        DtDESPDATE.CustomFormat = "dd/MM/yyyy";

                    if (detailPO.RECDATE == null)
                        DtRECDATE.CustomFormat = " ";
                    else
                        DtRECDATE.CustomFormat = "dd/MM/yyyy";

                    if (detailPO.BAESENT == null)
                        DtBAESENT.CustomFormat = " ";
                    else
                        DtBAESENT.CustomFormat = "dd/MM/yyyy";

                    if (detailPO.PSIDATE == null)
                        DtPSIDATE.CustomFormat = " ";
                    else
                        DtPSIDATE.CustomFormat = "dd/MM/yyyy";

                    if (detailPO.QUOTE_REF_DATE == null)
                        DtQUOTE_REF_DATE.CustomFormat = " ";
                    else
                        DtQUOTE_REF_DATE.CustomFormat = "dd/MM/yyyy";

                    if (detailPO.INVOICE_REQUESTED == null)
                        DtINVOICE_REQUESTED.CustomFormat = " ";
                    else
                        DtINVOICE_REQUESTED.CustomFormat = "dd/MM/yyyy";

                    if (detailPO.CTRT_DATE == null)
                        DtCTRT_DATE.CustomFormat = " ";
                    else
                        DtCTRT_DATE.CustomFormat = "dd/MM/yyyy";

                    if (detailPO.PROMISE == null)
                        DtPROMISE.CustomFormat = " ";
                    else
                        DtPROMISE.CustomFormat = "dd/MM/yyyy";

                    if (detailPO.FLEX_DATE == null)
                        DtFLEX_DATE.CustomFormat = " ";
                    else
                        DtFLEX_DATE.CustomFormat = "dd/MM/yyyy";


                }
                catch { }
            }

            if (this.CbARCHIVE.Checked == false)
            {
                TxPART_NO.ReadOnly = false;
                TxOONUM.ReadOnly = false;
                TxOUTPART.ReadOnly = false;
                TxRCP.ReadOnly = false;
                TxDESPTOBA.ReadOnly = false;
                CbINVOICE_PAID.Enabled = true;
                TxREMARKS.ReadOnly = false;
                TxRFR.ReadOnly = false;
                TxSERIAL.ReadOnly = false;
                TxPOITEM.ReadOnly = false;
                TxBAESER.ReadOnly = false;
                TxPSIREF.ReadOnly = false;
                TxQTYSCRP.ReadOnly = false;
                TxEURO.ReadOnly = false;
                DtDESPDATE.Enabled = true;
                DtINVOICE_REQUESTED.Enabled = true;
                TxBAEQTY.ReadOnly = false;
                DtBAESENT.Enabled = true;
                CbWARR.Enabled = true;
                TxELAPSED_TIME.ReadOnly = false;
                TxQUOTE_REF.ReadOnly = false;
                CbPOIC.Enabled = true;
                TxACC_STG.ReadOnly = false;
                TxPAEURO.ReadOnly = false;
                TxMODULE_TEXT.ReadOnly = false;
                TxMDR.ReadOnly = false;
                DtRECDATE.Enabled = true;
                TxENG_MARK.ReadOnly = false;
                TxHOURS_NEW.ReadOnly = false;
                TxHOURS_REP.ReadOnly = false;
                DtQUOTE_REF_DATE.Enabled = true;
                TxEX_ENGINE.ReadOnly = false;
                DtCTRT_DATE.Enabled = true;
                DtPROMISE.Enabled = true;
                DtFLEX_DATE.Enabled = true;
                TxMASTER_ID.ReadOnly = false;
                TxINVOICE_NO.ReadOnly = false;
                TxFLEX3.ReadOnly = false;
                TxVENDOR_MATERIAL_COST.ReadOnly = false;
                TxRR_PO.ReadOnly = false;
                TxSALES_DOCUMENT.ReadOnly = false;
                TxFLEX4.ReadOnly = false;
                TxVENDOR_LABOR_COST.ReadOnly = false;
                TxVENDOR_COFC.ReadOnly = false;
                TxFLEX1.ReadOnly = false;
                TxAWB_DETAILS.ReadOnly = false;
                TxQUALITY_NO.ReadOnly = false;
                TxVENDOR.ReadOnly = false;
                TxFLEX2.ReadOnly = false;
                TxSAP_SES.ReadOnly = false;
                TxPO_REQ.ReadOnly = false;
                DtPSIDATE.Enabled = true;
                TxQTYREC.ReadOnly = false;
            }
            else
            {
                TxPART_NO.ReadOnly = true;
                TxOONUM.ReadOnly = true;
                TxOUTPART.ReadOnly = true;
                TxRCP.ReadOnly = true;
                TxDESPTOBA.ReadOnly = true;
                CbINVOICE_PAID.Enabled = false;
                TxREMARKS.ReadOnly = true;
                TxRFR.ReadOnly = true;
                TxSERIAL.ReadOnly = true;
                TxPOITEM.ReadOnly = true;
                TxBAESER.ReadOnly = true;
                TxPSIREF.ReadOnly = true;
                TxQTYSCRP.ReadOnly = true;
                TxEURO.ReadOnly = true;
                DtDESPDATE.Enabled = false;
                DtINVOICE_REQUESTED.Enabled = false;
                TxBAEQTY.ReadOnly = true;
                DtBAESENT.Enabled = false;
                CbWARR.Enabled = false;
                TxELAPSED_TIME.ReadOnly = true;
                TxQUOTE_REF.ReadOnly = true;
                CbPOIC.Enabled = false;
                TxACC_STG.ReadOnly = true;
                TxPAEURO.ReadOnly = true;
                TxMODULE_TEXT.ReadOnly = true;
                TxMDR.ReadOnly = true;
                DtRECDATE.Enabled = false;
                TxENG_MARK.ReadOnly = true;
                TxHOURS_NEW.ReadOnly = true;
                TxHOURS_REP.ReadOnly = true;
                DtQUOTE_REF_DATE.Enabled = false;
                TxEX_ENGINE.ReadOnly = true;
                DtCTRT_DATE.Enabled = false;
                DtPROMISE.Enabled = false;
                DtFLEX_DATE.Enabled = false;
                TxMASTER_ID.ReadOnly = true;
                TxINVOICE_NO.ReadOnly = true;
                TxFLEX3.ReadOnly = true;
                TxVENDOR_MATERIAL_COST.ReadOnly = true;
                TxRR_PO.ReadOnly = true;
                TxSALES_DOCUMENT.ReadOnly = true;
                TxFLEX4.ReadOnly = true;
                TxVENDOR_LABOR_COST.ReadOnly = true;
                TxVENDOR_COFC.ReadOnly = true;
                TxFLEX1.ReadOnly = true;
                TxAWB_DETAILS.ReadOnly = true;
                TxQUALITY_NO.ReadOnly = true;
                TxVENDOR.ReadOnly = true;
                TxFLEX2.ReadOnly = true;
                TxSAP_SES.ReadOnly = true;
                TxPO_REQ.ReadOnly = true;
                DtPSIDATE.Enabled = false;
                TxQTYREC.ReadOnly = true;
            }
        }

        private void POSearchEditItemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rsafDbContext.Dispose();
        }


        private void LbBAEPART_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 0;
            searchForm.ShowDialog();
        }

        private void LbBAESER_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 1;
            searchForm.ShowDialog();
        }

        private void LbBAEQTY_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 2;
            searchForm.ShowDialog();
        }

        private void LbBAESENT_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 3;
            searchForm.ShowDialog();
        }

        private void LbBAEPO_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 4;
            searchForm.ShowDialog();
        }

        private void LbPOITEM_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 5;
            searchForm.ShowDialog();
        }

        private void LbWARR_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 6;
            searchForm.ShowDialog();
        }

        private void LbPOIC_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 7;
            searchForm.ShowDialog();
        }

        private void LbPART_NO_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 8;
            searchForm.ShowDialog();
        }

        private void LbSERIAL_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 9;
            searchForm.ShowDialog();
        }

        private void LbRECQTY_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 10;
            searchForm.ShowDialog();
        }

        private void LbRECDATE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 11;
            searchForm.ShowDialog();
        }

        private void LbOONUM_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 12;
            searchForm.ShowDialog();
        }

        private void LbPSIREF_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 13;
            searchForm.ShowDialog();
        }

        private void LbPSIDATE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 14;
            searchForm.ShowDialog();
        }

        private void LbEX_ENGINE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 15;
            searchForm.ShowDialog();
        }

        private void LbENG_MARK_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 16;
            searchForm.ShowDialog();
        }

        private void LbHOURS_NEW_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 17;
            searchForm.ShowDialog();
        }

        private void LbHOURS_REP_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 18;
            searchForm.ShowDialog();
        }

        private void LbSITE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 19;
            searchForm.ShowDialog();
        }

        private void LbTYPE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 20;
            searchForm.ShowDialog();
        }

        private void LbOUTPART_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 21;
            searchForm.ShowDialog();
        }

        private void LbQTYSCRP_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 22;
            searchForm.ShowDialog();
        }

        private void LbRCP_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 23;
            searchForm.ShowDialog();
        }

        private void LbEURO_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 24;
            searchForm.ShowDialog();
        }

        private void LbQUOTE_REF_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 25;
            searchForm.ShowDialog();
        }

        private void LbQUOTE_REF_DATE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 26;
            searchForm.ShowDialog();
        }

        private void LbARCHIVE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 27;
            searchForm.ShowDialog();
        }

        private void LbDESPTOBA_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 28;
            searchForm.ShowDialog();
        }

        private void LbDESPDATE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 29;
            searchForm.ShowDialog();
        }

        private void LbAWB_DETAILS_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 30;
            searchForm.ShowDialog();
        }

        private void LbINVOICE_REQUESTED_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 31;
            searchForm.ShowDialog();
        }

        private void LblINVOICE_NO_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 32;
            searchForm.ShowDialog();
        }

        private void LbCTRT_DATE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 33;
            searchForm.ShowDialog();
        }

        private void LbDESCRIPTION_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 34;
            searchForm.ShowDialog();
        }

        private void LbACC_STG_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 35;
            searchForm.ShowDialog();
        }

        private void LbPAEURO_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 36;
            searchForm.ShowDialog();
        }

        private void LbPROMISE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 37;
            searchForm.ShowDialog();
        }

        private void LbRFR_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 38;
            searchForm.ShowDialog();
        }

        private void LbMDR_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 39;
            searchForm.ShowDialog();
        }

        private void LbQUALITY_NO_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 40;
            searchForm.ShowDialog();
        }

        private void LbSALES_DOCUMENT_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 41;
            searchForm.ShowDialog();
        }

        private void LbSAP_SES_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 42;
            searchForm.ShowDialog();
        }

        private void LbROID_NO_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 43;
            searchForm.ShowDialog();
        }

        private void LbVENDOR_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 44;
            searchForm.ShowDialog();
        }

        private void LbVENDOR_COFC_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 45;
            searchForm.ShowDialog();
        }

        private void LbVENDOR_MATERIAL_COST_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 46;
            searchForm.ShowDialog();
        }

        private void LbVENDOR_LABOR_COST_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 47;
            searchForm.ShowDialog();
        }

        private void LbRR_PO_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 48;
            searchForm.ShowDialog();
        }

        private void LbPO_REQ_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 49;
            searchForm.ShowDialog();
        }

        private void LbINVOICE_PAID_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 50;
            searchForm.ShowDialog();
        }

        private void LbREMARKS_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 51;
            searchForm.ShowDialog();
        }

        private void LbMODULE_TEXT_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 52;
            searchForm.ShowDialog();
        }

        private void LbFLEX_DATE_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 53;
            searchForm.ShowDialog();
        }

        private void LbFLEX1_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 54;
            searchForm.ShowDialog();
        }

        private void LbFLEX2_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 55;
            searchForm.ShowDialog();
        }

        private void LbFLEX3_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 56;
            searchForm.ShowDialog();
        }

        private void LbFLEX4_DoubleClick(object sender, EventArgs e)
        {
            POSearchForm searchForm = new POSearchForm(this);
            searchForm.selectedFieldIndex = 57;
            searchForm.ShowDialog();
        }

        private void CbARCHIVE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CbARCHIVE.Checked == false)
            {
                TxPART_NO.ReadOnly = false;
                TxOONUM.ReadOnly = false;
                TxOUTPART.ReadOnly = false;
                TxRCP.ReadOnly = false;
                TxDESPTOBA.ReadOnly = false;
                CbINVOICE_PAID.Enabled = true;
                TxREMARKS.ReadOnly = false;
                TxRFR.ReadOnly = false;
                TxSERIAL.ReadOnly = false;
                TxPOITEM.ReadOnly = false;
                TxBAESER.ReadOnly = false;
                TxPSIREF.ReadOnly = false;
                TxQTYSCRP.ReadOnly = false;
                TxEURO.ReadOnly = false;
                DtDESPDATE.Enabled = true;
                DtINVOICE_REQUESTED.Enabled = true;
                TxBAEQTY.ReadOnly = false;
                DtBAESENT.Enabled = true;
                CbWARR.Enabled = true;
                TxELAPSED_TIME.ReadOnly = false;
                TxQUOTE_REF.ReadOnly = false;
                CbPOIC.Enabled = true;
                TxACC_STG.ReadOnly = false;
                TxPAEURO.ReadOnly = false;
                TxMODULE_TEXT.ReadOnly = false;
                TxMDR.ReadOnly = false;
                DtRECDATE.Enabled = true;
                TxENG_MARK.ReadOnly = false;
                TxHOURS_NEW.ReadOnly = false;
                TxHOURS_REP.ReadOnly = false;
                DtQUOTE_REF_DATE.Enabled = true;
                TxEX_ENGINE.ReadOnly = false;
                DtCTRT_DATE.Enabled = true;
                DtPROMISE.Enabled = true;
                DtFLEX_DATE.Enabled = true;
                TxMASTER_ID.ReadOnly = false;
                TxINVOICE_NO.ReadOnly = false;
                TxFLEX3.ReadOnly = false;
                TxVENDOR_MATERIAL_COST.ReadOnly = false;
                TxRR_PO.ReadOnly = false;
                TxSALES_DOCUMENT.ReadOnly = false;
                TxFLEX4.ReadOnly = false;
                TxVENDOR_LABOR_COST.ReadOnly = false;
                TxVENDOR_COFC.ReadOnly = false;
                TxFLEX1.ReadOnly = false;
                TxAWB_DETAILS.ReadOnly = false;
                TxQUALITY_NO.ReadOnly = false;
                TxVENDOR.ReadOnly = false;
                TxFLEX2.ReadOnly = false;
                TxSAP_SES.ReadOnly = false;
                TxPO_REQ.ReadOnly = false;
                DtPSIDATE.Enabled = true;
                TxQTYREC.ReadOnly = false;
            }
            else
            {
                TxPART_NO.ReadOnly = true;
                TxOONUM.ReadOnly = true;
                TxOUTPART.ReadOnly = true;
                TxRCP.ReadOnly = true;
                TxDESPTOBA.ReadOnly = true;
                CbINVOICE_PAID.Enabled = false;
                TxREMARKS.ReadOnly = true;
                TxRFR.ReadOnly = true;
                TxSERIAL.ReadOnly = true;
                TxPOITEM.ReadOnly = true;
                TxBAESER.ReadOnly = true;
                TxPSIREF.ReadOnly = true;
                TxQTYSCRP.ReadOnly = true;
                TxEURO.ReadOnly = true;
                DtDESPDATE.Enabled = false;
                DtINVOICE_REQUESTED.Enabled = false;
                TxBAEQTY.ReadOnly = true;
                DtBAESENT.Enabled = false;
                CbWARR.Enabled = false;
                TxELAPSED_TIME.ReadOnly = true;
                TxQUOTE_REF.ReadOnly = true;
                CbPOIC.Enabled = false;
                TxACC_STG.ReadOnly = true;
                TxPAEURO.ReadOnly = true;
                TxMODULE_TEXT.ReadOnly = true;
                TxMDR.ReadOnly = true;
                DtRECDATE.Enabled = false;
                TxENG_MARK.ReadOnly = true;
                TxHOURS_NEW.ReadOnly = true;
                TxHOURS_REP.ReadOnly = true;
                DtQUOTE_REF_DATE.Enabled = false;
                TxEX_ENGINE.ReadOnly = true;
                DtCTRT_DATE.Enabled = false;
                DtPROMISE.Enabled = false;
                DtFLEX_DATE.Enabled = false;
                TxMASTER_ID.ReadOnly = true;
                TxINVOICE_NO.ReadOnly = true;
                TxFLEX3.ReadOnly = true;
                TxVENDOR_MATERIAL_COST.ReadOnly = true;
                TxRR_PO.ReadOnly = true;
                TxSALES_DOCUMENT.ReadOnly = true;
                TxFLEX4.ReadOnly = true;
                TxVENDOR_LABOR_COST.ReadOnly = true;
                TxVENDOR_COFC.ReadOnly = true;
                TxFLEX1.ReadOnly = true;
                TxAWB_DETAILS.ReadOnly = true;
                TxQUALITY_NO.ReadOnly = true;
                TxVENDOR.ReadOnly = true;
                TxFLEX2.ReadOnly = true;
                TxSAP_SES.ReadOnly = true;
                TxPO_REQ.ReadOnly = true;
                DtPSIDATE.Enabled = false;
                TxQTYREC.ReadOnly = true;
            }
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (CbARCHIVE.Checked != detailPO.ARCHIVE)
            {
                detailPO.ARCHIVE = CbARCHIVE.Checked;
                toolStripStatusLabel.Text = "Edited ARCHIVE";
            }
        }

        private void BtRI_Click(object sender, EventArgs e)
        {
            POReportForm poReportForm = new POReportForm();
            poReportForm.ShowDialog();

        }

        private void TxSAP_SES_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited SAP SES";
        }

        private void TxBAEQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited BAES QTY";
        }

        private void TxEX_ENGINE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited EX ENGINE";
        }

        private void TxHOURS_NEW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited HOURS NEW";
        }

        private void TxENG_MARK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited ENG MK";
        }

        private void TxSALES_DOCUMENT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited SALES DOC No";
        }


        private void TxQTYSCRP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited SCRAP";
        }

        private void TxQTYREC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited RECVD QTY";
        }

        private void TxRR_PO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited RR PO";
        }

        private void TxPO_REQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                toolStripStatusLabel.Text = "Edited PO REQ";
        }

        private void TxSAP_SES_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxSAP_SES.Text == String.Empty && detailPO.SAP_SES != null)
                detailPO.SAP_SES = null;
            else
                try
                {
                    detailPO.SAP_SES = long.Parse(TxSAP_SES.Text);
                }
                catch (Exception OverflowException)
                {
                    TxSAP_SES.Text = detailPO.SAP_SES.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for SAP SES. Backed to old value.";
                }
        }

        private void TxBAEQTY_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxBAEQTY.Text == String.Empty)
                detailPO.BAEQTY = null;
            else
                try
                {
                    detailPO.BAEQTY = short.Parse(TxBAEQTY.Text);
                }
                catch (Exception OverflowException)
                {
                    TxBAEQTY.Text = detailPO.BAEQTY.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for BAES QTY. Backed to old value.";
                }
        }

        private void TxQTYREC_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxQTYREC.Text == String.Empty)
                detailPO.QTYREC = null;
            else
                try
                {
                    detailPO.QTYREC = short.Parse(TxQTYREC.Text);
                }
                catch (Exception OverflowException)
                {
                    TxQTYREC.Text = detailPO.QTYREC.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for RECVD QTY. Backed to old value.";
                }
        }

        private void TxQTYSCRP_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxQTYSCRP.Text == String.Empty)
                detailPO.QTYSCRP = null;
            else
                try
                {
                    detailPO.QTYSCRP = short.Parse(TxQTYSCRP.Text);
                }
                catch (Exception OverflowException)
                {
                    TxQTYSCRP.Text = detailPO.QTYSCRP.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for SCRAP. Backed to old value.";
                }
        }

        private void TxENG_MARK_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxENG_MARK.Text == String.Empty)
                detailPO.ENG_MARK = null;
            else
                try
                {
                    detailPO.ENG_MARK = int.Parse(TxENG_MARK.Text);
                }
                catch (Exception OverflowException)
                {
                    TxENG_MARK.Text = detailPO.ENG_MARK.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for ENG MK. Backed to old value.";
                }
        }

        private void TxHOURS_NEW_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxHOURS_NEW.Text == String.Empty)
                detailPO.HOURS_NEW = null;
            else
                try
                {
                    detailPO.HOURS_NEW = int.Parse(TxHOURS_NEW.Text);
                }
                catch (Exception OverflowException)
                {
                    TxHOURS_NEW.Text = detailPO.HOURS_NEW.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for HOURS NEW. Backed to old value.";
                }
        }

        private void TxEX_ENGINE_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxEX_ENGINE.Text == String.Empty)
                detailPO.EX_ENGINE = null;
            else
                try
                {
                    detailPO.EX_ENGINE = int.Parse(TxEX_ENGINE.Text);
                }
                catch (Exception OverflowException)
                {
                    TxEX_ENGINE.Text = detailPO.EX_ENGINE.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for EX ENGINE. Backed to old value.";
                }
        }

        private void TxSALES_DOCUMENT_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxSALES_DOCUMENT.Text == String.Empty)
                detailPO.SALES_DOCUMENT = null;
            else
                try
                {
                    detailPO.SALES_DOCUMENT = long.Parse(TxSALES_DOCUMENT.Text);
                }
                catch (Exception OverflowException)
                {
                    TxSALES_DOCUMENT.Text = detailPO.SALES_DOCUMENT.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for SALES DOC No. Backed to old value.";
                }
        }

        private void TxPO_REQ_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxPO_REQ.Text == String.Empty)
                detailPO.PO_REQ = null;
            else
                try
                {
                    detailPO.PO_REQ = long.Parse(TxPO_REQ.Text);
                }
                catch (Exception OverflowException)
                {
                    TxPO_REQ.Text = detailPO.PO_REQ.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for PO REQ. Backed to old value.";
                }
        }

        private void TxRR_PO_KeyUp(object sender, KeyEventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (TxRR_PO.Text == String.Empty)
                detailPO.RR_PO = null;
            else
                try
                {
                    detailPO.RR_PO = long.Parse(TxRR_PO.Text);
                }
                catch (Exception OverflowException)
                {
                    TxRR_PO.Text = detailPO.RR_PO.ToString();
                    toolStripStatusLabel.Text = "Value Overflow for RR PO. Backed to old value.";
                }
        }

        private void POSearchEditItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var change = false;
            var entries = rsafDbContext.ChangeTracker.Entries();
            foreach (var entry in entries)
                if (entry.State != System.Data.Entity.EntityState.Unchanged && entry.OriginalValues != entry.CurrentValues)
                {
                    //MessageBox.Show(entry.Entity.ToString()+":"+entry.State.ToString());
                    change = true;
                }
                    


            if (change)
            {
                toolStripStatusLabel.Text = "The Form Closing";
                DialogResult dialogResult = MessageBox.Show("Would you like to save changings before leaving?", "Save Changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    rsafDbContext.SaveChanges();
            }

        }


        private void TxPART_NO_KeyUp(object sender, KeyEventArgs e)
        {
            toolStripStatusLabel.Text = "Edited RECVD P/N";
        }

        private void TxOONUM_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited SAP NWA";
        }

        private void TxOUTPART_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited P/N EX REPAIR";
        }

        private void TxDESPTOBA_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited R.R. R/NOTE";
        }

        private void TxAWB_DETAILS_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited AWB DETAILS";
        }

        private void TxRFR_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited R.F.R";
        }

        private void TxVENDOR_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited VENDOR";
        }

        private void TxVENDOR_COFC_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited VENDOR CofC";
        }

        private void TxREMARKS_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited REMARKS";
        }

        private void TxFLEX1_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited FLEX1";
        }

        private void TxFLEX3_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited FLEX3";
        }

        private void TxFLEX2_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited FLEX2";
        }

        private void TxFLEX4_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited FLEX4";
        }

        private void TxBAESER_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited BAES S/N";
        }

        private void TxPOITEM_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited ITEM No";
        }

        private void TxSERIAL_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited RECVD S/N";
        }

        private void TxPSIREF_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited R.I. REF";
        }

        private void TxQUOTE_REF_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited QUOTE No";
        }

        private void TxHOURS_REP_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited HOURS REP";
        }

        private void TxINVOICE_NO_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited INVOICE No";
        }

        private void TxMDR_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited MDR";
        }

        private void TxQUALITY_NO_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited QUALITY No";
        }


        private void TxMODULE_TEXT_KeyUp(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Edited MODULE TEXT";
        }

        private void CbWARR_CheckedChanged(object sender, EventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (CbWARR.Checked != detailPO.WARR)
            {
                detailPO.WARR = CbWARR.Checked;
                toolStripStatusLabel.Text = "Edited WARRANTY";
            }
        }

        private void CbPOIC_CheckedChanged(object sender, EventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (CbPOIC.Checked != detailPO.POIC)
            {
                detailPO.POIC = CbPOIC.Checked;
                toolStripStatusLabel.Text = "Edited PO ITEM CLOSED";
            }
        }

        private void CbINVOICE_PAID_CheckedChanged(object sender, EventArgs e)
        {
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));
            if (CbINVOICE_PAID.Checked != detailPO.INVOICE_PAID)
            {
                detailPO.INVOICE_PAID = CbINVOICE_PAID.Checked;
                toolStripStatusLabel.Text = "Edited INVOICE PAID";
            }
        }

        private void TxRCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            else
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    e.Handled = true;
        }

        private void TxRCP_KeyUp(object sender, KeyEventArgs e)
        {
            bool isDecimal;
            decimal result;

            isDecimal = decimal.TryParse(TxRCP.Text, out result);
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));

            if (result != detailPO.RCP)
            {
                detailPO.RCP = result;
                toolStripStatusLabel.Text = "Edited REPAIR COST (£)";
            }
        }

        private void TxEURO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            else
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void TxEURO_KeyUp(object sender, KeyEventArgs e)
        {
            bool isDecimal;
            decimal result;

            isDecimal = decimal.TryParse(TxEURO.Text, out result);
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));

            if (result != detailPO.EURO)
            {
                detailPO.EURO = result;
                toolStripStatusLabel.Text = "Edited EURO";
            }
        }

        private void TxACC_STG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            else
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void TxACC_STG_KeyUp(object sender, KeyEventArgs e)
        {
            bool isDecimal;
            decimal result;

            isDecimal = decimal.TryParse(TxACC_STG.Text, out result);
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));

            if (result != detailPO.ACC_STG)
            {
                detailPO.ACC_STG = result;
                toolStripStatusLabel.Text = "Edited P or A STG";
            }
        }

        private void TxPAEURO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            else
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void TxPAEURO_KeyUp(object sender, KeyEventArgs e)
        {
            bool isDecimal;
            decimal result;

            isDecimal = decimal.TryParse(TxPAEURO.Text, out result);
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));

            if (result != detailPO.PAEURO)
            {
                detailPO.PAEURO = result;
                toolStripStatusLabel.Text = "Edited P or A EURO";
            }
        }

        private void TxVENDOR_MATERIAL_COST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            else
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void TxVENDOR_MATERIAL_COST_KeyUp(object sender, KeyEventArgs e)
        {
            bool isDecimal;
            decimal result;

            isDecimal = decimal.TryParse(TxVENDOR_MATERIAL_COST.Text, out result);
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));

            if (result != detailPO.VENDOR_MATERIAL_COST)
            {
                detailPO.VENDOR_MATERIAL_COST = result;
                toolStripStatusLabel.Text = "Edited VENDOR MAT COST";
            }
        }

        private void TxVENDOR_LABOR_COST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            else
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void TxVENDOR_LABOR_COST_KeyUp(object sender, KeyEventArgs e)
        {
            bool isDecimal;
            decimal result;

            isDecimal = decimal.TryParse(TxVENDOR_LABOR_COST.Text, out result);
            var detailPO = rsafDbContext.RSAF_DETAIL.Find(long.Parse(TxDETAIL_ID.Text));

            if (result != detailPO.VENDOR_LABOR_COST)
            {
                detailPO.VENDOR_LABOR_COST = result;
                toolStripStatusLabel.Text = "Edited VENDOR LAB COST";
            }
        }
    }
}
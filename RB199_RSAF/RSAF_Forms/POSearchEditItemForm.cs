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

            if (TxDETAIL_ID.Text!="")
                archiveForm.loadArchieve(long.Parse(TxDETAIL_ID.Text));
            archiveForm.ShowDialog();
        }

        private void POSearchEditItemForm_Load(object sender, EventArgs e)
        {
            List<RSAF_TYPE> listType = new List<RSAF_TYPE>();
            List<RSAF_SITE> listSite = new List<RSAF_SITE>();

            var detail = rsafDbContext.RSAF_DETAIL.Where(c => c.ARCHIVE == false)
                                                  .OrderBy(c=> c.POITEM)
                                                  .OrderBy(c => c.MASTER_ID)
                                                  .OrderByDescending(c => c.BAESENT)
                                                  .ToList();
            
            RsafDetailBindingSource.DataSource=detail;
 

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
            if (pDateValue.Value != null)
               vDateValue =  DateTime.Parse(pDateValue.Value.ToShortDateString());

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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.BAEPART.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.BAESER.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.BAEQTY.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 3://DtBAESENT
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.BAESENT.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 4://TxBAEPO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.BAEPO == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.BAEPO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.POITEM.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 6://CbWARR
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.WARR == pCheckboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 7://CbPOIC
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.POIC == pCheckboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 8://TxPART_NO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PART_NO == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PART_NO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.SERIAL.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QTYREC.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 11://DtRECDATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.RECDATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 12://TxOONUM
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.OONUM == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.OONUM.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PSIREF.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 14://DtPSIDATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.PSIDATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 15://TxEX_ENGINE
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.EX_ENGINE.ToString() == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.EX_ENGINE.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.ENG_MARK.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.HOURS_NEW.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.HOURS_REP.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 19://CxSITE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.SITE == pListboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 20://CxTYPE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.TYPE == pListboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 21://TxOUTPART
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.OUTPART == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.OUTPART.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QTYSCRP.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RCP.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.EURO.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QUOTE_REF.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 26://DtQUOTE_REF_DATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.QUOTE_REF_DATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 27://CbARCHIVE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.ARCHIVE == pCheckboxValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 28://TxDESPTOBA
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.DESPTOBA == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.DESPTOBA.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 29://DtDESPDATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.DESPDATE.Value == pDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 30://TxAWB_DETAILS
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.AWB_DETAILS == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.AWB_DETAILS.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 31://DtINVOICE_REQUESTED
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.INVOICE_REQUESTED.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 32://TxINVOICE_NO
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.INVOICE_NO == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.INVOICE_NO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 33://DtCTRT_DATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.CTRT_DATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 34://TxDESCRIPTION
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.DESCRIPTION == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.DESCRIPTION.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.ACC_STG.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PAEURO.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 37://DtPROMISE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.PROMISE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 38://TxRFR
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RFR == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RFR.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.MDR.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.QUALITY_NO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.SALES_DOCUMENT.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.SAP_SES.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RSAF_MASTER.ROID_NO.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR_COFC.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR_MATERIAL_COST.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.VENDOR_LABOR_COST.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.RR_PO.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.PO_REQ.ToString().Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 50://CbINVOICE_PAID
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.INVOICE_PAID == pCheckboxValue)
                                                 .OrderBy(c => c.POITEM)
                                                 .OrderBy(c => c.MASTER_ID)
                                                 .OrderByDescending(c => c.BAESENT)
                                                 .ToList();
                    break;
                case 51://TxREMARKS
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.REMARKS == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.REMARKS.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.MODULE_TEXT.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
                case 53://DtFLEX_DATE
                    query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX_DATE.Value == vDateValue)
                                                .OrderBy(c => c.POITEM)
                                                .OrderBy(c => c.MASTER_ID)
                                                .OrderByDescending(c => c.BAESENT)
                                                .ToList();
                    break;
                case 54://TxFLEX1
                    if (pSearchCriteria == "E")
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX1 == pTextValue)
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX1.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX2.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX3.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
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
                    }
                    else
                    {
                        query = rsafDbContext.RSAF_DETAIL.Where(c => c.FLEX4.Contains(pTextValue))
                                                    .OrderBy(c => c.POITEM)
                                                    .OrderBy(c => c.MASTER_ID)
                                                    .OrderByDescending(c => c.BAESENT)
                                                    .ToList();
                    }
                    break;
            }

            RsafDetailBindingSource.DataSource = query;
            var numberOfrecords= query.Count;
            if (numberOfrecords == 0)
                toolStripStatusLabel.Text = "No record found";
            else
            {
                if (numberOfrecords == 1)
                    toolStripStatusLabel.Text = "1 record found";
                else 
                    toolStripStatusLabel.Text = query.Count().ToString()+" records found";
            }
        }


        private void DtDESPDATE_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtDESPDATE.CustomFormat = " ";
            if (e.KeyCode == Keys.Space) 
                DtDESPDATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtDESPDATE_ValueChanged(object sender, EventArgs e)
        {
            DtDESPDATE.CustomFormat = "dd/MM/yyyy";
        }

        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            rsafDbContext.SaveChanges();
        }

        private void DtINVOICE_REQUESTED_ValueChanged(object sender, EventArgs e)
        {
            DtINVOICE_REQUESTED.CustomFormat = "dd/MM/yyyy";
        }

        private void DtINVOICE_REQUESTED_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtINVOICE_REQUESTED.CustomFormat = " ";
            if (e.KeyCode == Keys.Space)
                DtINVOICE_REQUESTED.CustomFormat = "dd/MM/yyyy";
        }

        private void DtBAESENT_ValueChanged(object sender, EventArgs e)
        {
            DtBAESENT.CustomFormat = "dd/MM/yyyy";
        }

        private void DtBAESENT_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtBAESENT.CustomFormat = " ";
            if (e.KeyCode == Keys.Space)
                DtBAESENT.CustomFormat = "dd/MM/yyyy";
        }

        private void DtRECDATE_ValueChanged(object sender, EventArgs e)
        {
            DtRECDATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtRECDATE_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtRECDATE.CustomFormat = " ";
            if (e.KeyCode == Keys.Space)
                DtRECDATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtQUOTE_REF_DATE_ValueChanged(object sender, EventArgs e)
        {
            DtQUOTE_REF_DATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtQUOTE_REF_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtQUOTE_REF_DATE.CustomFormat = " ";
            if (e.KeyCode == Keys.Space)
                DtQUOTE_REF_DATE.CustomFormat = "dd/MM/yyyy";
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

        private void DtPROMISE_ValueChanged(object sender, EventArgs e)
        {
            DtPROMISE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtPROMISE_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtPROMISE.CustomFormat = " ";
            if (e.KeyCode == Keys.Space)
                DtPROMISE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtFLEX_DATE_ValueChanged(object sender, EventArgs e)
        {
            DtFLEX_DATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtFLEX_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtFLEX_DATE.CustomFormat = " ";
            if (e.KeyCode == Keys.Space)
                DtFLEX_DATE.CustomFormat = "dd/MM/yyyy";
        }

        private void RsafDetailBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            long value;
            masterId = long.TryParse(TxMASTER_ID.Text, out value) ? value : 0;

            TxELAPSED_TIME.Text = (DtDESPDATE.Value == null) ? (DateTime.Now - DtRECDATE.Value).TotalDays.ToString(): "";

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

            if(this.CbARCHIVE.Checked==false)
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

        private void DtPSIDATE_ValueChanged(object sender, EventArgs e)
        {
            DtPSIDATE.CustomFormat = "dd/MM/yyyy";
        }

        private void DtPSIDATE_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                DtPSIDATE.CustomFormat = " ";
            if (e.KeyCode == Keys.Space)
                DtPSIDATE.CustomFormat = "dd/MM/yyyy";
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
        }

        private void BtRI_Click(object sender, EventArgs e)
        {
            POReportForm poReportForm = new POReportForm();
            poReportForm.ShowDialog();

        }
    }
}
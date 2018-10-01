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
    public partial class POSearchForm : Form
    {
        private POSearchEditItemForm searchEditForm;

        public POSearchForm(POSearchEditItemForm f)
        {
            InitializeComponent();
            searchEditForm = f;
        }

        public int selectedFieldIndex;

        private void ArrangeFields()
        {

            SearchFields x = CxSearchField.SelectedItem as SearchFields;

            List<SearchCriterias> textCriteria = new List<SearchCriterias>();
            textCriteria.Add(new SearchCriterias() { Id = "E", Name = "Equals"});
            textCriteria.Add(new SearchCriterias() { Id = "C", Name = "Contains" });
            List<SearchCriterias> otherCriteria = new List<SearchCriterias>();
            otherCriteria.Add(new SearchCriterias() { Id = "E", Name = "Equals" });

            TxValue.Text = "";
            CbValue.Checked = false;


            switch (x.ValueType)
            {
                case ValueTypes.Text:
                    CbValue.Visible = false;
                    CxValue.Visible = false;
                    DtValue.Visible = false;
                    TxValue.Visible = true;
                    CxSearchCriteria.DataSource = textCriteria;
                    CxSearchCriteria.ValueMember = "Id";
                    CxSearchCriteria.DisplayMember = "Name";
                    break;
                case ValueTypes.CheckBox:
                    CbValue.Visible = true;
                    CxValue.Visible = false;
                    DtValue.Visible = false;
                    TxValue.Visible = false;
                    CxSearchCriteria.DataSource = otherCriteria;
                    CxSearchCriteria.ValueMember = "Id";
                    CxSearchCriteria.DisplayMember = "Name";
                    break;
                case ValueTypes.ComboBox:
                    CbValue.Visible = false;
                    CxValue.Visible = true;
                    DtValue.Visible = false;
                    TxValue.Visible = false;
                    CxSearchCriteria.DataSource = otherCriteria;
                    CxSearchCriteria.ValueMember = "Id";
                    CxSearchCriteria.DisplayMember = "Name";
                    switch (x.Id)
                    {
                        case "TYPE":
                            List<RSAF_TYPE> listType = new List<RSAF_TYPE>();
                            var a = new RsafDbContext();
                            listType = a.RSAF_TYPE.ToList();
                            a.Dispose();
                            CxValue.DataSource = listType; 
                            CxValue.DisplayMember = "TYPE";
                            CxValue.ValueMember = "TYPE_CODE";
                            break;
                        case "SITE":
                            List<RSAF_SITE> listSite = new List<RSAF_SITE>();
                            var b = new RsafDbContext();
                            listSite = b.RSAF_SITE.ToList();
                            b.Dispose();
                            CxValue.DataSource = listSite;
                            CxValue.DisplayMember = "SITE";
                            CxValue.ValueMember = "SITE_CODE";
                            break;

                    }
                    break;
                case ValueTypes.DateTime:
                    CbValue.Visible = false;
                    CxValue.Visible = false;
                    DtValue.Visible = true;
                    DtValue.CustomFormat = "dd/MM/yyyy";
                    TxValue.Visible = false;
                    CxSearchCriteria.DataSource = otherCriteria;
                    CxSearchCriteria.ValueMember = "Id";
                    CxSearchCriteria.DisplayMember = "Name";
                    break;

            }

        }

        private void POSearchForm_Load(object sender, EventArgs e)
        {

            List<SearchFields> listSearchFields = new List<SearchFields>();
            listSearchFields.Add(new SearchFields() { Id = "BAEPART", Name = "BAe P/N", ValueType = ValueTypes.Text });                 //0
            listSearchFields.Add(new SearchFields() { Id = "BAESER", Name = "BAES S/N", ValueType = ValueTypes.Text });                 //1
            listSearchFields.Add(new SearchFields() { Id = "BAEQTY", Name = "BAES QTY", ValueType = ValueTypes.Text });                 //2
            listSearchFields.Add(new SearchFields() { Id = "BAESENT", Name = "BAES PO DATE", ValueType = ValueTypes.DateTime });        //3
            listSearchFields.Add(new SearchFields() { Id = "BAEPO", Name = "BAe Po No", ValueType = ValueTypes.Text });                 //4
            listSearchFields.Add(new SearchFields() { Id = "POITEM", Name = "ITEM No", ValueType = ValueTypes.Text });                  //5
            listSearchFields.Add(new SearchFields() { Id = "WARR", Name = "WARRANTY", ValueType = ValueTypes.CheckBox });               //6
            listSearchFields.Add(new SearchFields() { Id = "POIC", Name = "PO ITEM CLOSED", ValueType = ValueTypes.CheckBox });         //7
            listSearchFields.Add(new SearchFields() { Id = "PART_NO", Name = "RECVD P/N", ValueType = ValueTypes.Text });               //8
            listSearchFields.Add(new SearchFields() { Id = "SERIAL", Name = "RECVD S/N", ValueType = ValueTypes.Text });                //9
            listSearchFields.Add(new SearchFields() { Id = "QTYREC", Name = "RECVD QTY", ValueType = ValueTypes.Text });                //10
            listSearchFields.Add(new SearchFields() { Id = "RECDATE", Name = "RECVD DATE", ValueType = ValueTypes.DateTime });          //11
            listSearchFields.Add(new SearchFields() { Id = "OONUM", Name = "SAP NWA", ValueType = ValueTypes.Text });                   //12
            listSearchFields.Add(new SearchFields() { Id = "PSIREF", Name = "R.I. REF", ValueType = ValueTypes.Text });                 //13
            listSearchFields.Add(new SearchFields() { Id = "PSIDATE", Name = "DATE", ValueType = ValueTypes.DateTime });                //14
            listSearchFields.Add(new SearchFields() { Id = "EX_ENGINE", Name = "EX ENGINE", ValueType = ValueTypes.Text });             //15
            listSearchFields.Add(new SearchFields() { Id = "ENG_MARK", Name = "ENG MK", ValueType = ValueTypes.Text });                 //16
            listSearchFields.Add(new SearchFields() { Id = "HOURS_NEW", Name = "HOURS NEW", ValueType = ValueTypes.Text });             //17
            listSearchFields.Add(new SearchFields() { Id = "HOURS_REP", Name = "HOURS REP", ValueType = ValueTypes.Text });             //18
            listSearchFields.Add(new SearchFields() { Id = "SITE", Name = "SITE", ValueType = ValueTypes.ComboBox });                   //19
            listSearchFields.Add(new SearchFields() { Id = "TYPE", Name = "TYPE", ValueType = ValueTypes.ComboBox });                   //20
            listSearchFields.Add(new SearchFields() { Id = "OUTPART", Name = "P/N EX REPAIR", ValueType = ValueTypes.Text });           //21
            listSearchFields.Add(new SearchFields() { Id = "QTYSCRP", Name = "SCRAP", ValueType = ValueTypes.Text });                   //22
            listSearchFields.Add(new SearchFields() { Id = "RCP", Name = "REPAIR COST (£)", ValueType = ValueTypes.Text });             //23
            listSearchFields.Add(new SearchFields() { Id = "EURO", Name = "EURO", ValueType = ValueTypes.Text });                       //24
            listSearchFields.Add(new SearchFields() { Id = "QUOTE_REF", Name = "QUOTE No", ValueType = ValueTypes.Text });              //25
            listSearchFields.Add(new SearchFields() { Id = "QUOTE_REF_DATE", Name = "QUOTE DATE", ValueType = ValueTypes.DateTime });   //26
            listSearchFields.Add(new SearchFields() { Id = "ARCHIVE", Name = "ARCHIVED", ValueType = ValueTypes.CheckBox });            //27
            listSearchFields.Add(new SearchFields() { Id = "DESPTOBA", Name = "R.R. R/NOTE", ValueType = ValueTypes.Text });            //28
            listSearchFields.Add(new SearchFields() { Id = "DESPDATE", Name = "DESPATCH DATE", ValueType = ValueTypes.DateTime });      //29
            listSearchFields.Add(new SearchFields() { Id = "AWB_DETAILS", Name = "AWB DETAILS", ValueType = ValueTypes.Text });         //30
            listSearchFields.Add(new SearchFields() { Id = "INVOICE_REQUESTED", Name = "INVOICE DATE", ValueType = ValueTypes.DateTime });//31
            listSearchFields.Add(new SearchFields() { Id = "INVOICE_NO", Name = "INVOICE No", ValueType = ValueTypes.Text });           //32
            listSearchFields.Add(new SearchFields() { Id = "CTRT_DATE", Name = "CONTRACT DATE", ValueType = ValueTypes.DateTime });     //33
            listSearchFields.Add(new SearchFields() { Id = "DESCRIPTION", Name = "DESCRIPTION", ValueType = ValueTypes.Text });         //34
            listSearchFields.Add(new SearchFields() { Id = "ACC_STG", Name = "P or A STG", ValueType = ValueTypes.Text });              //35
            listSearchFields.Add(new SearchFields() { Id = "PAEURO", Name = "P or A EURO", ValueType = ValueTypes.Text });              //36
            listSearchFields.Add(new SearchFields() { Id = "PROMISE", Name = "PROMISE DATE", ValueType = ValueTypes.DateTime });        //37
            listSearchFields.Add(new SearchFields() { Id = "RFR", Name = "R.F.R", ValueType = ValueTypes.Text });                       //38
            listSearchFields.Add(new SearchFields() { Id = "MDR", Name = "MDR", ValueType = ValueTypes.Text });                         //39
            listSearchFields.Add(new SearchFields() { Id = "QUALITY_NO", Name = "QUALITY No", ValueType = ValueTypes.Text });           //40
            listSearchFields.Add(new SearchFields() { Id = "SALES_DOCUMENT", Name = "SALES DOC No", ValueType = ValueTypes.Text });     //41
            listSearchFields.Add(new SearchFields() { Id = "SAP_SES", Name = "SAP SES", ValueType = ValueTypes.Text });                 //42
            listSearchFields.Add(new SearchFields() { Id = "ROID_NO", Name = "ROID No", ValueType = ValueTypes.Text });                 //43
            listSearchFields.Add(new SearchFields() { Id = "VENDOR", Name = "VENDOR", ValueType = ValueTypes.Text });                   //44
            listSearchFields.Add(new SearchFields() { Id = "VENDOR_COFC", Name = "VENDOR CofC", ValueType = ValueTypes.Text });         //45
            listSearchFields.Add(new SearchFields() { Id = "VENDOR_MATERIAL_COST", Name = "VENDOR MAT COST", ValueType = ValueTypes.Text });//46
            listSearchFields.Add(new SearchFields() { Id = "VENDOR_LABOR_COST", Name = "VENDOR LAB COST", ValueType = ValueTypes.Text });//47
            listSearchFields.Add(new SearchFields() { Id = "RR_PO", Name = "RR PO", ValueType = ValueTypes.Text });                     //48
            listSearchFields.Add(new SearchFields() { Id = "PO_REQ", Name = "PO REQ", ValueType = ValueTypes.Text });                   //49
            listSearchFields.Add(new SearchFields() { Id = "INVOICE_PAID", Name = "INVOICE PAID", ValueType = ValueTypes.CheckBox });   //50
            listSearchFields.Add(new SearchFields() { Id = "REMARKS", Name = "REMARKS", ValueType = ValueTypes.Text });                 //51
            listSearchFields.Add(new SearchFields() { Id = "MODULE_TEXT", Name = "MODULE TEXT", ValueType = ValueTypes.Text });         //52
            listSearchFields.Add(new SearchFields() { Id = "FLEX_DATE", Name = "FLEX DATE", ValueType = ValueTypes.DateTime });          //53
            listSearchFields.Add(new SearchFields() { Id = "FLEX1", Name = "FLEX1", ValueType = ValueTypes.Text });                     //54
            listSearchFields.Add(new SearchFields() { Id = "FLEX2", Name = "FLEX2", ValueType = ValueTypes.Text });                     //55
            listSearchFields.Add(new SearchFields() { Id = "FLEX3", Name = "FLEX3", ValueType = ValueTypes.Text });                     //56
            listSearchFields.Add(new SearchFields() { Id = "FLEX4", Name = "FLEX4", ValueType = ValueTypes.Text });                     //57

            CxSearchField.DataSource = listSearchFields;

            CxSearchField.DisplayMember = "Name";
            CxSearchField.ValueMember = "Id";

            CxSearchField.SelectedIndex = selectedFieldIndex;
            ArrangeFields();
        }

        private void CxSearchField_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ArrangeFields();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSearch_Click(object sender, EventArgs e)
        {
            searchEditForm.postSearchCriteria(CxSearchField.SelectedIndex,
                               CbValue.Checked,
                               TxValue.Text,
                               CxValue.SelectedIndex == -1 ? "":CxValue.SelectedValue.ToString(),
                               DtValue.Value,
                               CxSearchCriteria.SelectedIndex == -1 ? "":CxSearchCriteria.SelectedValue.ToString());
            Close();
        }
    }
}

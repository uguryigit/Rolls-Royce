﻿using System;
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
    public partial class POMasterForm : Form
    {
        long masterId;
        PODetailForm DetailForm;
        public void SetValues(long pMASTER_ID,
                              string pBAEPART,
                              string pBAEPO,
                              int pSITE,
                              int pTYPE)
        {
            masterId = pMASTER_ID;
            TxBAEPART.Text = pBAEPART;
            TxBAEPO.Text = pBAEPO;
            CxSITE.SelectedIndex = pSITE;
            CxTYPE.SelectedIndex = pTYPE;
        }
        public POMasterForm(PODetailForm detailForm)
        {
            InitializeComponent();
            DetailForm = detailForm;
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

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            if (TxBAEPART.Text != "" && TxBAEPO.Text != "" && CxSITE.SelectedIndex != -1 && CxTYPE.SelectedIndex != -1)
            {
                ///////////////////////////////
                ///
                /// SAVE CHANGES
                /// 
                ///////////////////////////////
                if (DetailForm.TxBAEPART.Text == this.TxBAEPART.Text &&
                    DetailForm.TxBAEPO.Text == this.TxBAEPO.Text &&
                    DetailForm.CxSITE.SelectedIndex == this.CxSITE.SelectedIndex &&
                    DetailForm.CxTYPE.SelectedIndex == this.CxTYPE.SelectedIndex)
                    MessageBox.Show("There is no change!","Information");
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to change the PO header values?", "Confirm PO Header Changes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        long newmasterId = 0;
                        List<RSAF_MASTER> lMaster = new List<RSAF_MASTER>();
                        var b = new RsafDbContext();
                        lMaster = b.RSAF_MASTER.Where(c => c.BAEPART == this.TxBAEPART.Text.ToString()
                                                           && c.BAEPO == this.TxBAEPO.Text.ToString()
                                                           && c.SITE == this.CxSITE.SelectedValue.ToString()
                                                           && c.TYPE == this.CxTYPE.SelectedValue.ToString()).ToList();

                        if (lMaster != null)
                            foreach (var x in lMaster)
                                newmasterId = lMaster.First().MASTER_ID;
                        b.Dispose();

                        if (newmasterId == 0)
                        {

                            var a = new RsafDbContext();
                            var masterPO = a.RSAF_MASTER.Find(masterId);

                            if (DetailForm.TxBAEPART.Text != this.TxBAEPART.Text)
                                masterPO.BAEPART = this.TxBAEPART.Text;

                            if (DetailForm.TxBAEPO.Text != this.TxBAEPO.Text)
                                masterPO.BAEPO = this.TxBAEPO.Text;

                            if (DetailForm.CxSITE.SelectedIndex != this.CxSITE.SelectedIndex)
                                masterPO.SITE = this.CxSITE.SelectedValue.ToString();

                            if (DetailForm.CxTYPE.SelectedIndex != this.CxTYPE.SelectedIndex)
                                masterPO.TYPE = this.CxTYPE.SelectedValue.ToString();

                            a.SaveChanges();
                            a.Dispose();

                            DetailForm.TxBAEPART.Text = this.TxBAEPART.Text;
                            DetailForm.TxBAEPO.Text = this.TxBAEPO.Text;
                            DetailForm.CxSITE.SelectedIndex = this.CxSITE.SelectedIndex;
                            DetailForm.CxTYPE.SelectedIndex = this.CxTYPE.SelectedIndex;

                            MessageBox.Show( "PO header has been successfully updated!","Information");
                            DetailForm.toolStripStatusLabel.Text = "PO header has been changed.";
                            Close();
                        }
                        else
                            MessageBox.Show("PO header could not updated because there is already a PO which has the same header values. Check them first, please!", "Error");
                    }
                }
            }
        }
    }
}

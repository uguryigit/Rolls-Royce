using System;
namespace RSAF_Forms
{
    partial class POItemEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 

        public void SelectedRowValues(int SelectedRow, 
        string pPO_REQ,
        string pQUALITY_NO,
        string pVENDOR,
        string pRR_PO,
        string pSALES_DOCUMENT,
        string pQTYREC,
        DateTime pCTRT_DATE,
        string pEX_ENGINE,
        string pHOURS_REP,
        string pHOURS_NEW,
        string pENG_MARK,
        string pMDR,
        bool pWARR,
        DateTime pBAESENT,
        string pBAEQTY,
        string pPSIREF,
        string pBAESER,
        string pPOITEM,
        string pSERIAL,
        string pRFR,
        string pREMARKS,
        string pOUTPART,
        string pOONUM,
        string pPART_NO)
        {
        TxPO_REQ.Text = pPO_REQ;
        TxQUALITY_NO.Text= pQUALITY_NO;
        TxVENDOR.Text= pVENDOR;
        TxRR_PO.Text= pRR_PO;
        TxSALES_DOCUMENT.Text= pSALES_DOCUMENT;
        TxQTYREC.Text= pQTYREC;
        DtCTRT_DATE.Value=pCTRT_DATE;
        TxEX_ENGINE.Text= pEX_ENGINE;
        TxHOURS_REP.Text= pHOURS_REP;
        TxHOURS_NEW.Text= pHOURS_NEW;
        TxENG_MARK.Text= pENG_MARK;
        TxMDR.Text= pMDR;
        CbWARR.Checked=pWARR;
        DtBAESENT.Value=pBAESENT;
        TxBAEQTY.Text= pBAEQTY;
        TxPSIREF.Text= pPSIREF;
        TxBAESER.Text= pBAESER;
        TxPOITEM.Text= pPOITEM;
        TxSERIAL.Text= pSERIAL;
        TxRFR.Text= pRFR;
        TxREMARKS.Text= pREMARKS;
        TxOUTPART.Text= pOUTPART;
        TxOONUM.Text= pOONUM;
        TxPART_NO.Text= pPART_NO;
    }

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label LbPO_REQ;
            System.Windows.Forms.Label LbQUALITY_NO;
            System.Windows.Forms.Label LbVENDOR;
            System.Windows.Forms.Label LbRR_PO;
            System.Windows.Forms.Label LbSALES_DOCUMENT;
            System.Windows.Forms.Label LbRECQTY;
            System.Windows.Forms.Label LbCTRT_DATE;
            System.Windows.Forms.Label LbEX_ENGINE;
            System.Windows.Forms.Label LbHOURS_REP;
            System.Windows.Forms.Label LbHOURS_NEW;
            System.Windows.Forms.Label LbENG_MARK;
            System.Windows.Forms.Label LbMDR;
            System.Windows.Forms.Label LbWARR;
            System.Windows.Forms.Label bAESENTLabel;
            System.Windows.Forms.Label LbBAEQTY;
            System.Windows.Forms.Label LbPSIREF;
            System.Windows.Forms.Label LbBAESER;
            System.Windows.Forms.Label LbPOITEM;
            System.Windows.Forms.Label LbSERIAL;
            System.Windows.Forms.Label LbRFR;
            System.Windows.Forms.Label LbREMARKS;
            System.Windows.Forms.Label LbOUTPART;
            System.Windows.Forms.Label LbOONUM;
            System.Windows.Forms.Label LbPART_NO;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POItemEntryForm));
            this.TxPO_REQ = new System.Windows.Forms.TextBox();
            this.TxQUALITY_NO = new System.Windows.Forms.TextBox();
            this.TxVENDOR = new System.Windows.Forms.TextBox();
            this.TxRR_PO = new System.Windows.Forms.TextBox();
            this.TxSALES_DOCUMENT = new System.Windows.Forms.TextBox();
            this.TxQTYREC = new System.Windows.Forms.TextBox();
            this.DtCTRT_DATE = new System.Windows.Forms.DateTimePicker();
            this.TxEX_ENGINE = new System.Windows.Forms.TextBox();
            this.TxHOURS_REP = new System.Windows.Forms.TextBox();
            this.TxHOURS_NEW = new System.Windows.Forms.TextBox();
            this.TxENG_MARK = new System.Windows.Forms.TextBox();
            this.TxMDR = new System.Windows.Forms.TextBox();
            this.CbWARR = new System.Windows.Forms.CheckBox();
            this.DtBAESENT = new System.Windows.Forms.DateTimePicker();
            this.TxBAEQTY = new System.Windows.Forms.TextBox();
            this.TxPSIREF = new System.Windows.Forms.TextBox();
            this.TxBAESER = new System.Windows.Forms.TextBox();
            this.TxPOITEM = new System.Windows.Forms.TextBox();
            this.TxSERIAL = new System.Windows.Forms.TextBox();
            this.TxRFR = new System.Windows.Forms.TextBox();
            this.TxREMARKS = new System.Windows.Forms.TextBox();
            this.TxOUTPART = new System.Windows.Forms.TextBox();
            this.TxOONUM = new System.Windows.Forms.TextBox();
            this.TxPART_NO = new System.Windows.Forms.TextBox();
            this.BtReturn = new System.Windows.Forms.Button();
            LbPO_REQ = new System.Windows.Forms.Label();
            LbQUALITY_NO = new System.Windows.Forms.Label();
            LbVENDOR = new System.Windows.Forms.Label();
            LbRR_PO = new System.Windows.Forms.Label();
            LbSALES_DOCUMENT = new System.Windows.Forms.Label();
            LbRECQTY = new System.Windows.Forms.Label();
            LbCTRT_DATE = new System.Windows.Forms.Label();
            LbEX_ENGINE = new System.Windows.Forms.Label();
            LbHOURS_REP = new System.Windows.Forms.Label();
            LbHOURS_NEW = new System.Windows.Forms.Label();
            LbENG_MARK = new System.Windows.Forms.Label();
            LbMDR = new System.Windows.Forms.Label();
            LbWARR = new System.Windows.Forms.Label();
            bAESENTLabel = new System.Windows.Forms.Label();
            LbBAEQTY = new System.Windows.Forms.Label();
            LbPSIREF = new System.Windows.Forms.Label();
            LbBAESER = new System.Windows.Forms.Label();
            LbPOITEM = new System.Windows.Forms.Label();
            LbSERIAL = new System.Windows.Forms.Label();
            LbRFR = new System.Windows.Forms.Label();
            LbREMARKS = new System.Windows.Forms.Label();
            LbOUTPART = new System.Windows.Forms.Label();
            LbOONUM = new System.Windows.Forms.Label();
            LbPART_NO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LbPO_REQ
            // 
            LbPO_REQ.AutoSize = true;
            LbPO_REQ.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbPO_REQ.Location = new System.Drawing.Point(393, 190);
            LbPO_REQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbPO_REQ.Name = "LbPO_REQ";
            LbPO_REQ.Size = new System.Drawing.Size(63, 16);
            LbPO_REQ.TabIndex = 33;
            LbPO_REQ.Text = "PO REQ:";
            // 
            // LbQUALITY_NO
            // 
            LbQUALITY_NO.AutoSize = true;
            LbQUALITY_NO.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbQUALITY_NO.Location = new System.Drawing.Point(681, 286);
            LbQUALITY_NO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbQUALITY_NO.Name = "LbQUALITY_NO";
            LbQUALITY_NO.Size = new System.Drawing.Size(94, 16);
            LbQUALITY_NO.TabIndex = 45;
            LbQUALITY_NO.Text = "QUALITY No:";
            // 
            // LbVENDOR
            // 
            LbVENDOR.AutoSize = true;
            LbVENDOR.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbVENDOR.Location = new System.Drawing.Point(387, 221);
            LbVENDOR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbVENDOR.Name = "LbVENDOR";
            LbVENDOR.Size = new System.Drawing.Size(67, 16);
            LbVENDOR.TabIndex = 39;
            LbVENDOR.Text = "VENDOR:";
            // 
            // LbRR_PO
            // 
            LbRR_PO.AutoSize = true;
            LbRR_PO.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbRR_PO.Location = new System.Drawing.Point(403, 159);
            LbRR_PO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbRR_PO.Name = "LbRR_PO";
            LbRR_PO.Size = new System.Drawing.Size(53, 16);
            LbRR_PO.TabIndex = 27;
            LbRR_PO.Text = "RR PO:";
            // 
            // LbSALES_DOCUMENT
            // 
            LbSALES_DOCUMENT.AutoSize = true;
            LbSALES_DOCUMENT.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbSALES_DOCUMENT.Location = new System.Drawing.Point(19, 221);
            LbSALES_DOCUMENT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbSALES_DOCUMENT.Name = "LbSALES_DOCUMENT";
            LbSALES_DOCUMENT.Size = new System.Drawing.Size(111, 16);
            LbSALES_DOCUMENT.TabIndex = 37;
            LbSALES_DOCUMENT.Text = "SALES DOC No:";
            // 
            // LbRECQTY
            // 
            LbRECQTY.AutoSize = true;
            LbRECQTY.Location = new System.Drawing.Point(689, 97);
            LbRECQTY.Name = "LbRECQTY";
            LbRECQTY.Size = new System.Drawing.Size(89, 16);
            LbRECQTY.TabIndex = 17;
            LbRECQTY.Text = "RECVD QTY:";
            // 
            // LbCTRT_DATE
            // 
            LbCTRT_DATE.AutoSize = true;
            LbCTRT_DATE.Location = new System.Drawing.Point(652, 67);
            LbCTRT_DATE.Name = "LbCTRT_DATE";
            LbCTRT_DATE.Size = new System.Drawing.Size(126, 16);
            LbCTRT_DATE.TabIndex = 11;
            LbCTRT_DATE.Text = "CONTRACT DATE:";
            // 
            // LbEX_ENGINE
            // 
            LbEX_ENGINE.AutoSize = true;
            LbEX_ENGINE.Location = new System.Drawing.Point(696, 128);
            LbEX_ENGINE.Name = "LbEX_ENGINE";
            LbEX_ENGINE.Size = new System.Drawing.Size(82, 16);
            LbEX_ENGINE.TabIndex = 23;
            LbEX_ENGINE.Text = "EX ENGINE:";
            // 
            // LbHOURS_REP
            // 
            LbHOURS_REP.AutoSize = true;
            LbHOURS_REP.Location = new System.Drawing.Point(687, 221);
            LbHOURS_REP.Name = "LbHOURS_REP";
            LbHOURS_REP.Size = new System.Drawing.Size(91, 16);
            LbHOURS_REP.TabIndex = 41;
            LbHOURS_REP.Text = "HOURS REP:";
            // 
            // LbHOURS_NEW
            // 
            LbHOURS_NEW.AutoSize = true;
            LbHOURS_NEW.Location = new System.Drawing.Point(683, 190);
            LbHOURS_NEW.Name = "LbHOURS_NEW";
            LbHOURS_NEW.Size = new System.Drawing.Size(95, 16);
            LbHOURS_NEW.TabIndex = 35;
            LbHOURS_NEW.Text = "HOURS NEW:";
            // 
            // LbENG_MARK
            // 
            LbENG_MARK.AutoSize = true;
            LbENG_MARK.Location = new System.Drawing.Point(716, 159);
            LbENG_MARK.Name = "LbENG_MARK";
            LbENG_MARK.Size = new System.Drawing.Size(62, 16);
            LbENG_MARK.TabIndex = 29;
            LbENG_MARK.Text = "ENG MK:";
            // 
            // LbMDR
            // 
            LbMDR.AutoSize = true;
            LbMDR.Location = new System.Drawing.Point(714, 254);
            LbMDR.Name = "LbMDR";
            LbMDR.Size = new System.Drawing.Size(63, 16);
            LbMDR.TabIndex = 43;
            LbMDR.Text = "MDR No:";
            // 
            // LbWARR
            // 
            LbWARR.AutoSize = true;
            LbWARR.Location = new System.Drawing.Point(364, 67);
            LbWARR.Name = "LbWARR";
            LbWARR.Size = new System.Drawing.Size(90, 16);
            LbWARR.TabIndex = 9;
            LbWARR.Text = "WARRANTY:";
            // 
            // bAESENTLabel
            // 
            bAESENTLabel.AutoSize = true;
            bAESENTLabel.Location = new System.Drawing.Point(669, 37);
            bAESENTLabel.Name = "bAESENTLabel";
            bAESENTLabel.Size = new System.Drawing.Size(109, 16);
            bAESENTLabel.TabIndex = 5;
            bAESENTLabel.Text = "BAES PO DATE:";
            // 
            // LbBAEQTY
            // 
            LbBAEQTY.AutoSize = true;
            LbBAEQTY.Location = new System.Drawing.Point(376, 37);
            LbBAEQTY.Name = "LbBAEQTY";
            LbBAEQTY.Size = new System.Drawing.Size(78, 16);
            LbBAEQTY.TabIndex = 3;
            LbBAEQTY.Text = "BAES QTY:";
            // 
            // LbPSIREF
            // 
            LbPSIREF.AutoSize = true;
            LbPSIREF.Location = new System.Drawing.Point(397, 128);
            LbPSIREF.Name = "LbPSIREF";
            LbPSIREF.Size = new System.Drawing.Size(57, 16);
            LbPSIREF.TabIndex = 21;
            LbPSIREF.Text = "R.I REF:";
            // 
            // LbBAESER
            // 
            LbBAESER.AutoSize = true;
            LbBAESER.Location = new System.Drawing.Point(57, 37);
            LbBAESER.Name = "LbBAESER";
            LbBAESER.Size = new System.Drawing.Size(73, 16);
            LbBAESER.TabIndex = 1;
            LbBAESER.Text = "BAES S/N:";
            // 
            // LbPOITEM
            // 
            LbPOITEM.AutoSize = true;
            LbPOITEM.Location = new System.Drawing.Point(66, 67);
            LbPOITEM.Name = "LbPOITEM";
            LbPOITEM.Size = new System.Drawing.Size(64, 16);
            LbPOITEM.TabIndex = 7;
            LbPOITEM.Text = "ITEM No:";
            // 
            // LbSERIAL
            // 
            LbSERIAL.AutoSize = true;
            LbSERIAL.Location = new System.Drawing.Point(370, 97);
            LbSERIAL.Name = "LbSERIAL";
            LbSERIAL.Size = new System.Drawing.Size(84, 16);
            LbSERIAL.TabIndex = 15;
            LbSERIAL.Text = "RECVD S/N:";
            // 
            // LbRFR
            // 
            LbRFR.AutoSize = true;
            LbRFR.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbRFR.Location = new System.Drawing.Point(82, 190);
            LbRFR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbRFR.Name = "LbRFR";
            LbRFR.Size = new System.Drawing.Size(48, 16);
            LbRFR.TabIndex = 31;
            LbRFR.Text = "R.F.R:";
            // 
            // LbREMARKS
            // 
            LbREMARKS.AutoSize = true;
            LbREMARKS.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbREMARKS.Location = new System.Drawing.Point(55, 254);
            LbREMARKS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbREMARKS.Name = "LbREMARKS";
            LbREMARKS.Size = new System.Drawing.Size(75, 16);
            LbREMARKS.TabIndex = 47;
            LbREMARKS.Text = "REMARKS:";
            // 
            // LbOUTPART
            // 
            LbOUTPART.AutoSize = true;
            LbOUTPART.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbOUTPART.Location = new System.Drawing.Point(20, 159);
            LbOUTPART.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbOUTPART.Name = "LbOUTPART";
            LbOUTPART.Size = new System.Drawing.Size(110, 16);
            LbOUTPART.TabIndex = 25;
            LbOUTPART.Text = "P/N EX REPAIR:";
            // 
            // LbOONUM
            // 
            LbOONUM.AutoSize = true;
            LbOONUM.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbOONUM.Location = new System.Drawing.Point(54, 128);
            LbOONUM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbOONUM.Name = "LbOONUM";
            LbOONUM.Size = new System.Drawing.Size(76, 16);
            LbOONUM.TabIndex = 19;
            LbOONUM.Text = "SAP NWA:";
            // 
            // LbPART_NO
            // 
            LbPART_NO.AutoSize = true;
            LbPART_NO.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LbPART_NO.Location = new System.Drawing.Point(45, 97);
            LbPART_NO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LbPART_NO.Name = "LbPART_NO";
            LbPART_NO.Size = new System.Drawing.Size(85, 16);
            LbPART_NO.TabIndex = 13;
            LbPART_NO.Text = "RECVD P/N:";
            // 
            // TxPO_REQ
            // 
            this.TxPO_REQ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxPO_REQ.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxPO_REQ.Location = new System.Drawing.Point(459, 187);
            this.TxPO_REQ.Margin = new System.Windows.Forms.Padding(4);
            this.TxPO_REQ.Name = "TxPO_REQ";
            this.TxPO_REQ.Size = new System.Drawing.Size(160, 23);
            this.TxPO_REQ.TabIndex = 34;
            this.TxPO_REQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxPO_REQ_KeyPress);
            this.TxPO_REQ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxPO_REQ_KeyUp);
            // 
            // TxQUALITY_NO
            // 
            this.TxQUALITY_NO.BackColor = System.Drawing.SystemColors.Window;
            this.TxQUALITY_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxQUALITY_NO.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxQUALITY_NO.Location = new System.Drawing.Point(783, 280);
            this.TxQUALITY_NO.Margin = new System.Windows.Forms.Padding(4);
            this.TxQUALITY_NO.MaxLength = 25;
            this.TxQUALITY_NO.Name = "TxQUALITY_NO";
            this.TxQUALITY_NO.Size = new System.Drawing.Size(160, 23);
            this.TxQUALITY_NO.TabIndex = 48;
            // 
            // TxVENDOR
            // 
            this.TxVENDOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxVENDOR.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxVENDOR.Location = new System.Drawing.Point(459, 218);
            this.TxVENDOR.Margin = new System.Windows.Forms.Padding(4);
            this.TxVENDOR.MaxLength = 150;
            this.TxVENDOR.Name = "TxVENDOR";
            this.TxVENDOR.Size = new System.Drawing.Size(160, 23);
            this.TxVENDOR.TabIndex = 42;
            // 
            // TxRR_PO
            // 
            this.TxRR_PO.BackColor = System.Drawing.SystemColors.Window;
            this.TxRR_PO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxRR_PO.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxRR_PO.Location = new System.Drawing.Point(459, 156);
            this.TxRR_PO.Margin = new System.Windows.Forms.Padding(4);
            this.TxRR_PO.Name = "TxRR_PO";
            this.TxRR_PO.Size = new System.Drawing.Size(160, 23);
            this.TxRR_PO.TabIndex = 28;
            // 
            // TxSALES_DOCUMENT
            // 
            this.TxSALES_DOCUMENT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxSALES_DOCUMENT.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxSALES_DOCUMENT.Location = new System.Drawing.Point(136, 218);
            this.TxSALES_DOCUMENT.Margin = new System.Windows.Forms.Padding(4);
            this.TxSALES_DOCUMENT.Name = "TxSALES_DOCUMENT";
            this.TxSALES_DOCUMENT.Size = new System.Drawing.Size(160, 23);
            this.TxSALES_DOCUMENT.TabIndex = 40;
            this.TxSALES_DOCUMENT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxSALES_DOCUMENT_KeyPress);
            this.TxSALES_DOCUMENT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxSALES_DOCUMENT_KeyUp);
            // 
            // TxQTYREC
            // 
            this.TxQTYREC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxQTYREC.Location = new System.Drawing.Point(783, 94);
            this.TxQTYREC.Name = "TxQTYREC";
            this.TxQTYREC.Size = new System.Drawing.Size(160, 22);
            this.TxQTYREC.TabIndex = 18;
            this.TxQTYREC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxQTYREC_KeyPress);
            this.TxQTYREC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxQTYREC_KeyUp);
            // 
            // DtCTRT_DATE
            // 
            this.DtCTRT_DATE.CustomFormat = " ";
            this.DtCTRT_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtCTRT_DATE.Location = new System.Drawing.Point(783, 64);
            this.DtCTRT_DATE.Name = "DtCTRT_DATE";
            this.DtCTRT_DATE.Size = new System.Drawing.Size(160, 22);
            this.DtCTRT_DATE.TabIndex = 12;
            this.DtCTRT_DATE.ValueChanged += new System.EventHandler(this.DtCTRT_DATE_ValueChanged);
            this.DtCTRT_DATE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtCTRT_DATE_KeyDown);
            // 
            // TxEX_ENGINE
            // 
            this.TxEX_ENGINE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxEX_ENGINE.Location = new System.Drawing.Point(783, 125);
            this.TxEX_ENGINE.Name = "TxEX_ENGINE";
            this.TxEX_ENGINE.Size = new System.Drawing.Size(160, 22);
            this.TxEX_ENGINE.TabIndex = 24;
            this.TxEX_ENGINE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxEX_ENGINE_KeyPress);
            this.TxEX_ENGINE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxEX_ENGINE_KeyUp);
            // 
            // TxHOURS_REP
            // 
            this.TxHOURS_REP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxHOURS_REP.Location = new System.Drawing.Point(783, 218);
            this.TxHOURS_REP.MaxLength = 20;
            this.TxHOURS_REP.Name = "TxHOURS_REP";
            this.TxHOURS_REP.Size = new System.Drawing.Size(160, 22);
            this.TxHOURS_REP.TabIndex = 44;
            // 
            // TxHOURS_NEW
            // 
            this.TxHOURS_NEW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxHOURS_NEW.Location = new System.Drawing.Point(783, 187);
            this.TxHOURS_NEW.Name = "TxHOURS_NEW";
            this.TxHOURS_NEW.Size = new System.Drawing.Size(160, 22);
            this.TxHOURS_NEW.TabIndex = 36;
            this.TxHOURS_NEW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxHOURS_NEW_KeyPress);
            this.TxHOURS_NEW.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxHOURS_NEW_KeyUp);
            // 
            // TxENG_MARK
            // 
            this.TxENG_MARK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxENG_MARK.Location = new System.Drawing.Point(783, 156);
            this.TxENG_MARK.Name = "TxENG_MARK";
            this.TxENG_MARK.Size = new System.Drawing.Size(160, 22);
            this.TxENG_MARK.TabIndex = 30;
            this.TxENG_MARK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxENG_MARK_KeyPress);
            this.TxENG_MARK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxENG_MARK_KeyUp);
            // 
            // TxMDR
            // 
            this.TxMDR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxMDR.Location = new System.Drawing.Point(783, 249);
            this.TxMDR.MaxLength = 24;
            this.TxMDR.Name = "TxMDR";
            this.TxMDR.Size = new System.Drawing.Size(160, 22);
            this.TxMDR.TabIndex = 46;
            // 
            // CbWARR
            // 
            this.CbWARR.Location = new System.Drawing.Point(459, 63);
            this.CbWARR.Name = "CbWARR";
            this.CbWARR.Size = new System.Drawing.Size(160, 24);
            this.CbWARR.TabIndex = 10;
            this.CbWARR.UseVisualStyleBackColor = true;
            // 
            // DtBAESENT
            // 
            this.DtBAESENT.CustomFormat = " ";
            this.DtBAESENT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtBAESENT.Location = new System.Drawing.Point(783, 34);
            this.DtBAESENT.Name = "DtBAESENT";
            this.DtBAESENT.Size = new System.Drawing.Size(160, 22);
            this.DtBAESENT.TabIndex = 6;
            this.DtBAESENT.ValueChanged += new System.EventHandler(this.DtBAESENT_ValueChanged);
            this.DtBAESENT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtBAESENT_KeyDown);
            // 
            // TxBAEQTY
            // 
            this.TxBAEQTY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxBAEQTY.Location = new System.Drawing.Point(459, 34);
            this.TxBAEQTY.Name = "TxBAEQTY";
            this.TxBAEQTY.Size = new System.Drawing.Size(160, 22);
            this.TxBAEQTY.TabIndex = 4;
            this.TxBAEQTY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxBAEQTY_KeyPress);
            this.TxBAEQTY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxBAEQTY_KeyUp);
            // 
            // TxPSIREF
            // 
            this.TxPSIREF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxPSIREF.Location = new System.Drawing.Point(459, 125);
            this.TxPSIREF.MaxLength = 34;
            this.TxPSIREF.Name = "TxPSIREF";
            this.TxPSIREF.Size = new System.Drawing.Size(160, 22);
            this.TxPSIREF.TabIndex = 22;
            // 
            // TxBAESER
            // 
            this.TxBAESER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxBAESER.Location = new System.Drawing.Point(136, 34);
            this.TxBAESER.MaxLength = 30;
            this.TxBAESER.Name = "TxBAESER";
            this.TxBAESER.Size = new System.Drawing.Size(160, 22);
            this.TxBAESER.TabIndex = 2;
            // 
            // TxPOITEM
            // 
            this.TxPOITEM.BackColor = System.Drawing.SystemColors.Window;
            this.TxPOITEM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxPOITEM.Location = new System.Drawing.Point(136, 64);
            this.TxPOITEM.MaxLength = 8;
            this.TxPOITEM.Name = "TxPOITEM";
            this.TxPOITEM.Size = new System.Drawing.Size(160, 22);
            this.TxPOITEM.TabIndex = 8;
            // 
            // TxSERIAL
            // 
            this.TxSERIAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxSERIAL.Location = new System.Drawing.Point(459, 94);
            this.TxSERIAL.MaxLength = 20;
            this.TxSERIAL.Name = "TxSERIAL";
            this.TxSERIAL.Size = new System.Drawing.Size(160, 22);
            this.TxSERIAL.TabIndex = 16;
            // 
            // TxRFR
            // 
            this.TxRFR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxRFR.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxRFR.Location = new System.Drawing.Point(136, 187);
            this.TxRFR.Margin = new System.Windows.Forms.Padding(4);
            this.TxRFR.MaxLength = 500;
            this.TxRFR.Name = "TxRFR";
            this.TxRFR.Size = new System.Drawing.Size(160, 23);
            this.TxRFR.TabIndex = 32;
            // 
            // TxREMARKS
            // 
            this.TxREMARKS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxREMARKS.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxREMARKS.Location = new System.Drawing.Point(137, 249);
            this.TxREMARKS.Margin = new System.Windows.Forms.Padding(4);
            this.TxREMARKS.Multiline = true;
            this.TxREMARKS.Name = "TxREMARKS";
            this.TxREMARKS.Size = new System.Drawing.Size(483, 98);
            this.TxREMARKS.TabIndex = 50;
            // 
            // TxOUTPART
            // 
            this.TxOUTPART.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxOUTPART.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxOUTPART.Location = new System.Drawing.Point(136, 156);
            this.TxOUTPART.Margin = new System.Windows.Forms.Padding(4);
            this.TxOUTPART.MaxLength = 30;
            this.TxOUTPART.Name = "TxOUTPART";
            this.TxOUTPART.Size = new System.Drawing.Size(160, 23);
            this.TxOUTPART.TabIndex = 26;
            // 
            // TxOONUM
            // 
            this.TxOONUM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxOONUM.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxOONUM.Location = new System.Drawing.Point(136, 125);
            this.TxOONUM.Margin = new System.Windows.Forms.Padding(4);
            this.TxOONUM.MaxLength = 30;
            this.TxOONUM.Name = "TxOONUM";
            this.TxOONUM.Size = new System.Drawing.Size(160, 23);
            this.TxOONUM.TabIndex = 20;
            // 
            // TxPART_NO
            // 
            this.TxPART_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxPART_NO.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxPART_NO.Location = new System.Drawing.Point(136, 94);
            this.TxPART_NO.Margin = new System.Windows.Forms.Padding(4);
            this.TxPART_NO.MaxLength = 30;
            this.TxPART_NO.Name = "TxPART_NO";
            this.TxPART_NO.Size = new System.Drawing.Size(160, 23);
            this.TxPART_NO.TabIndex = 14;
            // 
            // BtReturn
            // 
            this.BtReturn.Location = new System.Drawing.Point(783, 311);
            this.BtReturn.Name = "BtReturn";
            this.BtReturn.Size = new System.Drawing.Size(160, 36);
            this.BtReturn.TabIndex = 51;
            this.BtReturn.Text = "Return";
            this.BtReturn.UseVisualStyleBackColor = true;
            this.BtReturn.Click += new System.EventHandler(this.BtReturn_Click);
            // 
            // POItemEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 394);
            this.Controls.Add(this.BtReturn);
            this.Controls.Add(LbPO_REQ);
            this.Controls.Add(this.TxPO_REQ);
            this.Controls.Add(LbQUALITY_NO);
            this.Controls.Add(this.TxQUALITY_NO);
            this.Controls.Add(LbVENDOR);
            this.Controls.Add(this.TxVENDOR);
            this.Controls.Add(LbRR_PO);
            this.Controls.Add(this.TxRR_PO);
            this.Controls.Add(LbSALES_DOCUMENT);
            this.Controls.Add(this.TxSALES_DOCUMENT);
            this.Controls.Add(LbRECQTY);
            this.Controls.Add(this.TxQTYREC);
            this.Controls.Add(LbCTRT_DATE);
            this.Controls.Add(this.DtCTRT_DATE);
            this.Controls.Add(LbEX_ENGINE);
            this.Controls.Add(this.TxEX_ENGINE);
            this.Controls.Add(LbHOURS_REP);
            this.Controls.Add(this.TxHOURS_REP);
            this.Controls.Add(LbHOURS_NEW);
            this.Controls.Add(this.TxHOURS_NEW);
            this.Controls.Add(LbENG_MARK);
            this.Controls.Add(this.TxENG_MARK);
            this.Controls.Add(LbMDR);
            this.Controls.Add(this.TxMDR);
            this.Controls.Add(LbWARR);
            this.Controls.Add(this.CbWARR);
            this.Controls.Add(bAESENTLabel);
            this.Controls.Add(this.DtBAESENT);
            this.Controls.Add(LbBAEQTY);
            this.Controls.Add(this.TxBAEQTY);
            this.Controls.Add(LbPSIREF);
            this.Controls.Add(this.TxPSIREF);
            this.Controls.Add(LbBAESER);
            this.Controls.Add(this.TxBAESER);
            this.Controls.Add(LbPOITEM);
            this.Controls.Add(this.TxPOITEM);
            this.Controls.Add(LbSERIAL);
            this.Controls.Add(this.TxSERIAL);
            this.Controls.Add(LbRFR);
            this.Controls.Add(this.TxRFR);
            this.Controls.Add(LbREMARKS);
            this.Controls.Add(this.TxREMARKS);
            this.Controls.Add(LbOUTPART);
            this.Controls.Add(this.TxOUTPART);
            this.Controls.Add(LbOONUM);
            this.Controls.Add(this.TxOONUM);
            this.Controls.Add(LbPART_NO);
            this.Controls.Add(this.TxPART_NO);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "POItemEntryForm";
            this.Text = "Purchase Order Item Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxPO_REQ;
        private System.Windows.Forms.TextBox TxQUALITY_NO;
        private System.Windows.Forms.TextBox TxVENDOR;
        private System.Windows.Forms.TextBox TxRR_PO;
        private System.Windows.Forms.TextBox TxSALES_DOCUMENT;
        private System.Windows.Forms.TextBox TxQTYREC;
        private System.Windows.Forms.DateTimePicker DtCTRT_DATE;
        private System.Windows.Forms.TextBox TxEX_ENGINE;
        private System.Windows.Forms.TextBox TxHOURS_REP;
        private System.Windows.Forms.TextBox TxHOURS_NEW;
        private System.Windows.Forms.TextBox TxENG_MARK;
        private System.Windows.Forms.TextBox TxMDR;
        private System.Windows.Forms.CheckBox CbWARR;
        private System.Windows.Forms.DateTimePicker DtBAESENT;
        private System.Windows.Forms.TextBox TxBAEQTY;
        private System.Windows.Forms.TextBox TxPSIREF;
        private System.Windows.Forms.TextBox TxBAESER;
        private System.Windows.Forms.TextBox TxPOITEM;
        private System.Windows.Forms.TextBox TxSERIAL;
        private System.Windows.Forms.TextBox TxRFR;
        private System.Windows.Forms.TextBox TxREMARKS;
        private System.Windows.Forms.TextBox TxOUTPART;
        private System.Windows.Forms.TextBox TxOONUM;
        private System.Windows.Forms.TextBox TxPART_NO;
        private System.Windows.Forms.Button BtReturn;
    }
}
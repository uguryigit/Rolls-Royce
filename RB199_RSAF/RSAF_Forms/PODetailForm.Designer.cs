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
    partial class PODetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label LbBAEPART;
            System.Windows.Forms.Label LbBAEPO;
            System.Windows.Forms.Label LbSITE;
            System.Windows.Forms.Label LbTYPE;
            System.Windows.Forms.Label LbDESCRIPTION;
            System.Windows.Forms.Label LbROID_NO;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PODetailForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TxBAEPART = new System.Windows.Forms.TextBox();
            this.TxBAEPO = new System.Windows.Forms.TextBox();
            this.CxSITE = new System.Windows.Forms.ComboBox();
            this.CxTYPE = new System.Windows.Forms.ComboBox();
            this.TxDESCRIPTION = new System.Windows.Forms.TextBox();
            this.BtAddNewItem = new System.Windows.Forms.Button();
            this.RsafDetailBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.RsafDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCopyButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripPasteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.RsafDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.DgCREATE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgUPDATE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgSTATUS = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgMASTER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgDETAIL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgPOITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgPART_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgSERIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgQTYREC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgWARR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgOONUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgMDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgCTRT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgBAEQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgBAESER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgBAESENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgVENDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgPSIREF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgOUTPART = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgRR_PO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgENG_MARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgHOURS_NEW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgHOURS_REP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgRFR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgEX_ENGINE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgSALES_DOCUMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgPO_REQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgREMARKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgQUALITY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TxROID_NO = new System.Windows.Forms.TextBox();
            LbBAEPART = new System.Windows.Forms.Label();
            LbBAEPO = new System.Windows.Forms.Label();
            LbSITE = new System.Windows.Forms.Label();
            LbTYPE = new System.Windows.Forms.Label();
            LbDESCRIPTION = new System.Windows.Forms.Label();
            LbROID_NO = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RsafDetailBindingNavigator)).BeginInit();
            this.RsafDetailBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RsafDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RsafDetailDataGridView)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbBAEPART
            // 
            LbBAEPART.AutoSize = true;
            LbBAEPART.Location = new System.Drawing.Point(82, 49);
            LbBAEPART.Name = "LbBAEPART";
            LbBAEPART.Size = new System.Drawing.Size(67, 16);
            LbBAEPART.TabIndex = 1;
            LbBAEPART.Text = "BAe P/N:";
            LbBAEPART.DoubleClick += new System.EventHandler(this.LbBAEPART_DoubleClick);
            // 
            // LbBAEPO
            // 
            LbBAEPO.AutoSize = true;
            LbBAEPO.Location = new System.Drawing.Point(370, 50);
            LbBAEPO.Name = "LbBAEPO";
            LbBAEPO.Size = new System.Drawing.Size(84, 16);
            LbBAEPO.TabIndex = 3;
            LbBAEPO.Text = "BAe PO No:";
            LbBAEPO.DoubleClick += new System.EventHandler(this.LbBAEPO_DoubleClick);
            // 
            // LbSITE
            // 
            LbSITE.AutoSize = true;
            LbSITE.Location = new System.Drawing.Point(726, 50);
            LbSITE.Name = "LbSITE";
            LbSITE.Size = new System.Drawing.Size(45, 16);
            LbSITE.TabIndex = 5;
            LbSITE.Text = "SITE:";
            LbSITE.DoubleClick += new System.EventHandler(this.LbSITE_DoubleClick);
            // 
            // LbTYPE
            // 
            LbTYPE.AutoSize = true;
            LbTYPE.Location = new System.Drawing.Point(1054, 50);
            LbTYPE.Name = "LbTYPE";
            LbTYPE.Size = new System.Drawing.Size(48, 16);
            LbTYPE.TabIndex = 7;
            LbTYPE.Text = "TYPE:";
            LbTYPE.DoubleClick += new System.EventHandler(this.LbTYPE_DoubleClick);
            // 
            // LbDESCRIPTION
            // 
            LbDESCRIPTION.AutoSize = true;
            LbDESCRIPTION.Location = new System.Drawing.Point(46, 88);
            LbDESCRIPTION.Name = "LbDESCRIPTION";
            LbDESCRIPTION.Size = new System.Drawing.Size(103, 16);
            LbDESCRIPTION.TabIndex = 9;
            LbDESCRIPTION.Text = "DESCRIPTION:";
            // 
            // LbROID_NO
            // 
            LbROID_NO.AutoSize = true;
            LbROID_NO.Location = new System.Drawing.Point(703, 88);
            LbROID_NO.Name = "LbROID_NO";
            LbROID_NO.Size = new System.Drawing.Size(68, 16);
            LbROID_NO.TabIndex = 11;
            LbROID_NO.Text = "ROID No:";
            // 
            // TxBAEPART
            // 
            this.TxBAEPART.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxBAEPART.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxBAEPART.Location = new System.Drawing.Point(155, 47);
            this.TxBAEPART.MaxLength = 30;
            this.TxBAEPART.Name = "TxBAEPART";
            this.TxBAEPART.Size = new System.Drawing.Size(163, 23);
            this.TxBAEPART.TabIndex = 2;
            this.TxBAEPART.TextChanged += new System.EventHandler(this.TxBAEPART_TextChanged);
            // 
            // TxBAEPO
            // 
            this.TxBAEPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxBAEPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxBAEPO.Location = new System.Drawing.Point(460, 47);
            this.TxBAEPO.MaxLength = 24;
            this.TxBAEPO.Name = "TxBAEPO";
            this.TxBAEPO.Size = new System.Drawing.Size(163, 23);
            this.TxBAEPO.TabIndex = 4;
            this.TxBAEPO.TextChanged += new System.EventHandler(this.TxBAEPO_TextChanged);
            // 
            // CxSITE
            // 
            this.CxSITE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CxSITE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CxSITE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CxSITE.Location = new System.Drawing.Point(777, 47);
            this.CxSITE.MaxLength = 24;
            this.CxSITE.Name = "CxSITE";
            this.CxSITE.Size = new System.Drawing.Size(163, 24);
            this.CxSITE.TabIndex = 6;
            this.CxSITE.SelectedIndexChanged += new System.EventHandler(this.CxSITE_SelectedIndexChanged);
            this.CxSITE.TextChanged += new System.EventHandler(this.CxSITE_TextChanged);
            // 
            // CxTYPE
            // 
            this.CxTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CxTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CxTYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CxTYPE.Location = new System.Drawing.Point(1108, 47);
            this.CxTYPE.MaxLength = 24;
            this.CxTYPE.Name = "CxTYPE";
            this.CxTYPE.Size = new System.Drawing.Size(163, 24);
            this.CxTYPE.TabIndex = 8;
            this.CxTYPE.SelectedIndexChanged += new System.EventHandler(this.CxTYPE_SelectedIndexChanged);
            this.CxTYPE.TextChanged += new System.EventHandler(this.CxTYPE_TextChanged);
            // 
            // TxDESCRIPTION
            // 
            this.TxDESCRIPTION.BackColor = System.Drawing.SystemColors.Window;
            this.TxDESCRIPTION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxDESCRIPTION.Location = new System.Drawing.Point(155, 85);
            this.TxDESCRIPTION.MaxLength = 510;
            this.TxDESCRIPTION.Name = "TxDESCRIPTION";
            this.TxDESCRIPTION.Size = new System.Drawing.Size(468, 23);
            this.TxDESCRIPTION.TabIndex = 10;
            this.TxDESCRIPTION.TextChanged += new System.EventHandler(this.TxDESCRIPTION_TextChanged);
            // 
            // BtAddNewItem
            // 
            this.BtAddNewItem.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAddNewItem.Location = new System.Drawing.Point(1108, 88);
            this.BtAddNewItem.Name = "BtAddNewItem";
            this.BtAddNewItem.Size = new System.Drawing.Size(163, 33);
            this.BtAddNewItem.TabIndex = 13;
            this.BtAddNewItem.Text = "Add New Item";
            this.BtAddNewItem.UseVisualStyleBackColor = true;
            this.BtAddNewItem.Click += new System.EventHandler(this.BtAddNewItem_Click);
            // 
            // RsafDetailBindingNavigator
            // 
            this.RsafDetailBindingNavigator.AddNewItem = null;
            this.RsafDetailBindingNavigator.BindingSource = this.RsafDetailBindingSource;
            this.RsafDetailBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.RsafDetailBindingNavigator.DeleteItem = null;
            this.RsafDetailBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripSaveButton,
            this.toolStripSeparator1,
            this.toolStripCopyButton,
            this.toolStripPasteButton,
            this.toolStripSeparator2,
            this.toolStripDeleteButton});
            this.RsafDetailBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.RsafDetailBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.RsafDetailBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.RsafDetailBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.RsafDetailBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.RsafDetailBindingNavigator.Name = "RsafDetailBindingNavigator";
            this.RsafDetailBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.RsafDetailBindingNavigator.Size = new System.Drawing.Size(1276, 25);
            this.RsafDetailBindingNavigator.TabIndex = 15;
            this.RsafDetailBindingNavigator.Text = "bindingNavigator1";
            // 
            // RsafDetailBindingSource
            // 
            this.RsafDetailBindingSource.DataSource = typeof(RSAF_Forms.RSAF_DETAIL);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSaveButton
            // 
            this.toolStripSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSaveButton.Image")));
            this.toolStripSaveButton.Name = "toolStripSaveButton";
            this.toolStripSaveButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripSaveButton.Text = "Save Data";
            this.toolStripSaveButton.Click += new System.EventHandler(this.RsafDetailBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripCopyButton
            // 
            this.toolStripCopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCopyButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCopyButton.Image")));
            this.toolStripCopyButton.Name = "toolStripCopyButton";
            this.toolStripCopyButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripCopyButton.Text = "Copy Record";
            this.toolStripCopyButton.Click += new System.EventHandler(this.toolStripCopyButton_Click);
            // 
            // toolStripPasteButton
            // 
            this.toolStripPasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPasteButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPasteButton.Image")));
            this.toolStripPasteButton.Name = "toolStripPasteButton";
            this.toolStripPasteButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripPasteButton.Text = "Save Data";
            this.toolStripPasteButton.ToolTipText = "Paste Record";
            this.toolStripPasteButton.Click += new System.EventHandler(this.toolStripPasteButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDeleteButton
            // 
            this.toolStripDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleteButton.Image")));
            this.toolStripDeleteButton.Name = "toolStripDeleteButton";
            this.toolStripDeleteButton.RightToLeftAutoMirrorImage = true;
            this.toolStripDeleteButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripDeleteButton.Text = "Delete";
            this.toolStripDeleteButton.Click += new System.EventHandler(this.toolStripDeleteButton_Click);
            // 
            // RsafDetailDataGridView
            // 
            this.RsafDetailDataGridView.AllowUserToAddRows = false;
            this.RsafDetailDataGridView.AllowUserToDeleteRows = false;
            this.RsafDetailDataGridView.AllowUserToResizeColumns = false;
            this.RsafDetailDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RsafDetailDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RsafDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RsafDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgCREATE_DATE,
            this.DgUPDATE_DATE,
            this.DgSTATUS,
            this.DgMASTER_ID,
            this.DgDETAIL_ID,
            this.DgPOITEM,
            this.DgPART_NO,
            this.DgSERIAL,
            this.DgQTYREC,
            this.DgWARR,
            this.DgOONUM,
            this.DgMDR,
            this.DgCTRT_DATE,
            this.DgBAEQTY,
            this.DgBAESER,
            this.DgBAESENT,
            this.DgVENDOR,
            this.DgPSIREF,
            this.DgOUTPART,
            this.DgRR_PO,
            this.DgENG_MARK,
            this.DgHOURS_NEW,
            this.DgHOURS_REP,
            this.DgRFR,
            this.DgEX_ENGINE,
            this.DgSALES_DOCUMENT,
            this.DgPO_REQ,
            this.DgREMARKS,
            this.DgQUALITY_NO});
            this.RsafDetailDataGridView.Location = new System.Drawing.Point(32, 157);
            this.RsafDetailDataGridView.MultiSelect = false;
            this.RsafDetailDataGridView.Name = "RsafDetailDataGridView";
            this.RsafDetailDataGridView.ReadOnly = true;
            this.RsafDetailDataGridView.Size = new System.Drawing.Size(1278, 420);
            this.RsafDetailDataGridView.TabIndex = 14;
            this.RsafDetailDataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RsafDetailDataGridView_RowHeaderMouseDoubleClick);
            // 
            // DgCREATE_DATE
            // 
            this.DgCREATE_DATE.Frozen = true;
            this.DgCREATE_DATE.HeaderText = "CREATE_DATE";
            this.DgCREATE_DATE.Name = "DgCREATE_DATE";
            this.DgCREATE_DATE.ReadOnly = true;
            this.DgCREATE_DATE.Visible = false;
            // 
            // DgUPDATE_DATE
            // 
            this.DgUPDATE_DATE.Frozen = true;
            this.DgUPDATE_DATE.HeaderText = "UPDATE_DATE";
            this.DgUPDATE_DATE.Name = "DgUPDATE_DATE";
            this.DgUPDATE_DATE.ReadOnly = true;
            this.DgUPDATE_DATE.Visible = false;
            // 
            // DgSTATUS
            // 
            this.DgSTATUS.Frozen = true;
            this.DgSTATUS.HeaderText = "STATUS";
            this.DgSTATUS.Name = "DgSTATUS";
            this.DgSTATUS.ReadOnly = true;
            this.DgSTATUS.Visible = false;
            // 
            // DgMASTER_ID
            // 
            this.DgMASTER_ID.Frozen = true;
            this.DgMASTER_ID.HeaderText = "MASTER_ID";
            this.DgMASTER_ID.Name = "DgMASTER_ID";
            this.DgMASTER_ID.ReadOnly = true;
            this.DgMASTER_ID.Visible = false;
            // 
            // DgDETAIL_ID
            // 
            this.DgDETAIL_ID.Frozen = true;
            this.DgDETAIL_ID.HeaderText = "DETAIL_ID";
            this.DgDETAIL_ID.Name = "DgDETAIL_ID";
            this.DgDETAIL_ID.ReadOnly = true;
            this.DgDETAIL_ID.Visible = false;
            // 
            // DgPOITEM
            // 
            this.DgPOITEM.Frozen = true;
            this.DgPOITEM.HeaderText = "ITEM No";
            this.DgPOITEM.Name = "DgPOITEM";
            this.DgPOITEM.ReadOnly = true;
            this.DgPOITEM.Width = 60;
            // 
            // DgPART_NO
            // 
            this.DgPART_NO.Frozen = true;
            this.DgPART_NO.HeaderText = "RECVD P/N";
            this.DgPART_NO.Name = "DgPART_NO";
            this.DgPART_NO.ReadOnly = true;
            this.DgPART_NO.Width = 140;
            // 
            // DgSERIAL
            // 
            this.DgSERIAL.Frozen = true;
            this.DgSERIAL.HeaderText = "RECVD S/N";
            this.DgSERIAL.Name = "DgSERIAL";
            this.DgSERIAL.ReadOnly = true;
            this.DgSERIAL.Width = 140;
            // 
            // DgQTYREC
            // 
            this.DgQTYREC.Frozen = true;
            this.DgQTYREC.HeaderText = "RECVD QTY";
            this.DgQTYREC.Name = "DgQTYREC";
            this.DgQTYREC.ReadOnly = true;
            this.DgQTYREC.Width = 65;
            // 
            // DgWARR
            // 
            this.DgWARR.Frozen = true;
            this.DgWARR.HeaderText = "WARRANTY";
            this.DgWARR.Name = "DgWARR";
            this.DgWARR.ReadOnly = true;
            this.DgWARR.Width = 85;
            // 
            // DgOONUM
            // 
            this.DgOONUM.Frozen = true;
            this.DgOONUM.HeaderText = "SAP NWA";
            this.DgOONUM.Name = "DgOONUM";
            this.DgOONUM.ReadOnly = true;
            this.DgOONUM.Width = 140;
            // 
            // DgMDR
            // 
            this.DgMDR.Frozen = true;
            this.DgMDR.HeaderText = "MDR";
            this.DgMDR.Name = "DgMDR";
            this.DgMDR.ReadOnly = true;
            // 
            // DgCTRT_DATE
            // 
            this.DgCTRT_DATE.Frozen = true;
            this.DgCTRT_DATE.HeaderText = "CONTRACT DATE";
            this.DgCTRT_DATE.Name = "DgCTRT_DATE";
            this.DgCTRT_DATE.ReadOnly = true;
            // 
            // DgBAEQTY
            // 
            this.DgBAEQTY.Frozen = true;
            this.DgBAEQTY.HeaderText = "BAES QTY";
            this.DgBAEQTY.Name = "DgBAEQTY";
            this.DgBAEQTY.ReadOnly = true;
            this.DgBAEQTY.Width = 65;
            // 
            // DgBAESER
            // 
            this.DgBAESER.Frozen = true;
            this.DgBAESER.HeaderText = "BAES S/N";
            this.DgBAESER.Name = "DgBAESER";
            this.DgBAESER.ReadOnly = true;
            // 
            // DgBAESENT
            // 
            this.DgBAESENT.Frozen = true;
            this.DgBAESENT.HeaderText = "BAES PO DATE";
            this.DgBAESENT.Name = "DgBAESENT";
            this.DgBAESENT.ReadOnly = true;
            // 
            // DgVENDOR
            // 
            this.DgVENDOR.Frozen = true;
            this.DgVENDOR.HeaderText = "VENDOR";
            this.DgVENDOR.Name = "DgVENDOR";
            this.DgVENDOR.ReadOnly = true;
            this.DgVENDOR.Width = 140;
            // 
            // DgPSIREF
            // 
            this.DgPSIREF.Frozen = true;
            this.DgPSIREF.HeaderText = "PSIREF";
            this.DgPSIREF.Name = "DgPSIREF";
            this.DgPSIREF.ReadOnly = true;
            this.DgPSIREF.Visible = false;
            // 
            // DgOUTPART
            // 
            this.DgOUTPART.Frozen = true;
            this.DgOUTPART.HeaderText = "OUTPART";
            this.DgOUTPART.Name = "DgOUTPART";
            this.DgOUTPART.ReadOnly = true;
            this.DgOUTPART.Visible = false;
            // 
            // DgRR_PO
            // 
            this.DgRR_PO.Frozen = true;
            this.DgRR_PO.HeaderText = "RR_PO";
            this.DgRR_PO.Name = "DgRR_PO";
            this.DgRR_PO.ReadOnly = true;
            this.DgRR_PO.Visible = false;
            // 
            // DgENG_MARK
            // 
            this.DgENG_MARK.HeaderText = "ENG_MARK";
            this.DgENG_MARK.Name = "DgENG_MARK";
            this.DgENG_MARK.ReadOnly = true;
            this.DgENG_MARK.Visible = false;
            // 
            // DgHOURS_NEW
            // 
            this.DgHOURS_NEW.HeaderText = "HOURS_NEW";
            this.DgHOURS_NEW.Name = "DgHOURS_NEW";
            this.DgHOURS_NEW.ReadOnly = true;
            this.DgHOURS_NEW.Visible = false;
            // 
            // DgHOURS_REP
            // 
            this.DgHOURS_REP.HeaderText = "HOURS_REP";
            this.DgHOURS_REP.Name = "DgHOURS_REP";
            this.DgHOURS_REP.ReadOnly = true;
            this.DgHOURS_REP.Visible = false;
            // 
            // DgRFR
            // 
            this.DgRFR.HeaderText = "RFR";
            this.DgRFR.Name = "DgRFR";
            this.DgRFR.ReadOnly = true;
            this.DgRFR.Visible = false;
            // 
            // DgEX_ENGINE
            // 
            this.DgEX_ENGINE.HeaderText = "EX_ENGINE";
            this.DgEX_ENGINE.Name = "DgEX_ENGINE";
            this.DgEX_ENGINE.ReadOnly = true;
            this.DgEX_ENGINE.Visible = false;
            // 
            // DgSALES_DOCUMENT
            // 
            this.DgSALES_DOCUMENT.HeaderText = "SALES_DOCUMENT";
            this.DgSALES_DOCUMENT.Name = "DgSALES_DOCUMENT";
            this.DgSALES_DOCUMENT.ReadOnly = true;
            this.DgSALES_DOCUMENT.Visible = false;
            // 
            // DgPO_REQ
            // 
            this.DgPO_REQ.HeaderText = "PO_REQ";
            this.DgPO_REQ.Name = "DgPO_REQ";
            this.DgPO_REQ.ReadOnly = true;
            this.DgPO_REQ.Visible = false;
            // 
            // DgREMARKS
            // 
            this.DgREMARKS.HeaderText = "REMARKS";
            this.DgREMARKS.Name = "DgREMARKS";
            this.DgREMARKS.ReadOnly = true;
            this.DgREMARKS.Visible = false;
            // 
            // DgQUALITY_NO
            // 
            this.DgQUALITY_NO.HeaderText = "QUALITY_NO";
            this.DgQUALITY_NO.Name = "DgQUALITY_NO";
            this.DgQUALITY_NO.ReadOnly = true;
            this.DgQUALITY_NO.Visible = false;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 609);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1276, 22);
            this.StatusStrip.TabIndex = 16;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // TxROID_NO
            // 
            this.TxROID_NO.BackColor = System.Drawing.SystemColors.Window;
            this.TxROID_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxROID_NO.Location = new System.Drawing.Point(777, 85);
            this.TxROID_NO.MaxLength = 24;
            this.TxROID_NO.Name = "TxROID_NO";
            this.TxROID_NO.Size = new System.Drawing.Size(163, 23);
            this.TxROID_NO.TabIndex = 12;
            this.TxROID_NO.TextChanged += new System.EventHandler(this.TxROID_NO_TextChanged);
            // 
            // PODetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 631);
            this.Controls.Add(LbROID_NO);
            this.Controls.Add(this.TxROID_NO);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.RsafDetailDataGridView);
            this.Controls.Add(this.RsafDetailBindingNavigator);
            this.Controls.Add(this.BtAddNewItem);
            this.Controls.Add(LbDESCRIPTION);
            this.Controls.Add(this.TxDESCRIPTION);
            this.Controls.Add(LbTYPE);
            this.Controls.Add(this.CxTYPE);
            this.Controls.Add(LbSITE);
            this.Controls.Add(this.CxSITE);
            this.Controls.Add(LbBAEPO);
            this.Controls.Add(this.TxBAEPO);
            this.Controls.Add(LbBAEPART);
            this.Controls.Add(this.TxBAEPART);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PODetailForm";
            this.Text = "New Purchase Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PODetailForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PODetailForm_FormClosed);
            this.Load += new System.EventHandler(this.NewPurchaseOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RsafDetailBindingNavigator)).EndInit();
            this.RsafDetailBindingNavigator.ResumeLayout(false);
            this.RsafDetailBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RsafDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RsafDetailDataGridView)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox TxBAEPART; 
        public System.Windows.Forms.TextBox TxBAEPO;
        public System.Windows.Forms.ComboBox CxSITE;
        public System.Windows.Forms.ComboBox CxTYPE;
        private System.Windows.Forms.TextBox TxDESCRIPTION;
        private System.Windows.Forms.Button BtAddNewItem;
        private System.Windows.Forms.BindingSource RsafDetailBindingSource;
        private System.Windows.Forms.BindingNavigator RsafDetailBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripSaveButton;
        public System.Windows.Forms.DataGridView RsafDetailDataGridView;
        public System.Windows.Forms.StatusStrip StatusStrip;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripCopyButton;
        private System.Windows.Forms.ToolStripButton toolStripPasteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripDeleteButton;
        private System.Windows.Forms.TextBox TxROID_NO;
        public DataGridViewTextBoxColumn DgCREATE_DATE;
        public DataGridViewTextBoxColumn DgUPDATE_DATE;
        public DataGridViewCheckBoxColumn DgSTATUS;
        public DataGridViewTextBoxColumn DgMASTER_ID;
        public DataGridViewTextBoxColumn DgDETAIL_ID;
        public DataGridViewTextBoxColumn DgPOITEM;
        public DataGridViewTextBoxColumn DgPART_NO;
        public DataGridViewTextBoxColumn DgSERIAL;
        public DataGridViewTextBoxColumn DgQTYREC;
        public DataGridViewCheckBoxColumn DgWARR;
        public DataGridViewTextBoxColumn DgOONUM;
        public DataGridViewTextBoxColumn DgMDR;
        public DataGridViewTextBoxColumn DgCTRT_DATE;
        public DataGridViewTextBoxColumn DgBAEQTY;
        public DataGridViewTextBoxColumn DgBAESER;
        public DataGridViewTextBoxColumn DgBAESENT;
        public DataGridViewTextBoxColumn DgVENDOR;
        public DataGridViewTextBoxColumn DgPSIREF;
        public DataGridViewTextBoxColumn DgOUTPART;
        public DataGridViewTextBoxColumn DgRR_PO;
        public DataGridViewTextBoxColumn DgENG_MARK;
        public DataGridViewTextBoxColumn DgHOURS_NEW;
        public DataGridViewTextBoxColumn DgHOURS_REP;
        public DataGridViewTextBoxColumn DgRFR;
        public DataGridViewTextBoxColumn DgEX_ENGINE;
        public DataGridViewTextBoxColumn DgSALES_DOCUMENT;
        public DataGridViewTextBoxColumn DgPO_REQ;
        public DataGridViewTextBoxColumn DgREMARKS;
        public DataGridViewTextBoxColumn DgQUALITY_NO;
    }
}
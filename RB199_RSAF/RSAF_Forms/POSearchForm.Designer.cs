namespace RSAF_Forms
{
    partial class POSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSearchForm));
            this.BtSearch = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.LbSearchField = new System.Windows.Forms.Label();
            this.LbSearchValue = new System.Windows.Forms.Label();
            this.LbSearchCriteria = new System.Windows.Forms.Label();
            this.CxSearchField = new System.Windows.Forms.ComboBox();
            this.CxSearchCriteria = new System.Windows.Forms.ComboBox();
            this.TxValue = new System.Windows.Forms.TextBox();
            this.DtValue = new System.Windows.Forms.DateTimePicker();
            this.CxValue = new System.Windows.Forms.ComboBox();
            this.CbValue = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BtSearch
            // 
            this.BtSearch.Location = new System.Drawing.Point(97, 157);
            this.BtSearch.Name = "BtSearch";
            this.BtSearch.Size = new System.Drawing.Size(99, 35);
            this.BtSearch.TabIndex = 0;
            this.BtSearch.Text = "Search";
            this.BtSearch.UseVisualStyleBackColor = true;
            this.BtSearch.Click += new System.EventHandler(this.BtSearch_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Location = new System.Drawing.Point(315, 157);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(99, 35);
            this.BtCancel.TabIndex = 1;
            this.BtCancel.Text = "Cancel";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // LbSearchField
            // 
            this.LbSearchField.AutoSize = true;
            this.LbSearchField.Location = new System.Drawing.Point(63, 42);
            this.LbSearchField.Name = "LbSearchField";
            this.LbSearchField.Size = new System.Drawing.Size(95, 16);
            this.LbSearchField.TabIndex = 2;
            this.LbSearchField.Text = "Search Field:";
            // 
            // LbSearchValue
            // 
            this.LbSearchValue.AutoSize = true;
            this.LbSearchValue.Location = new System.Drawing.Point(57, 108);
            this.LbSearchValue.Name = "LbSearchValue";
            this.LbSearchValue.Size = new System.Drawing.Size(101, 16);
            this.LbSearchValue.TabIndex = 3;
            this.LbSearchValue.Text = "Search Value:";
            // 
            // LbSearchCriteria
            // 
            this.LbSearchCriteria.AutoSize = true;
            this.LbSearchCriteria.Location = new System.Drawing.Point(46, 75);
            this.LbSearchCriteria.Name = "LbSearchCriteria";
            this.LbSearchCriteria.Size = new System.Drawing.Size(112, 16);
            this.LbSearchCriteria.TabIndex = 4;
            this.LbSearchCriteria.Text = "Search Criteria:";
            // 
            // CxSearchField
            // 
            this.CxSearchField.FormattingEnabled = true;
            this.CxSearchField.Location = new System.Drawing.Point(164, 39);
            this.CxSearchField.Name = "CxSearchField";
            this.CxSearchField.Size = new System.Drawing.Size(199, 24);
            this.CxSearchField.TabIndex = 5;
            this.CxSearchField.SelectionChangeCommitted += new System.EventHandler(this.CxSearchField_SelectionChangeCommitted);
            // 
            // CxSearchCriteria
            // 
            this.CxSearchCriteria.FormattingEnabled = true;
            this.CxSearchCriteria.Location = new System.Drawing.Point(164, 72);
            this.CxSearchCriteria.Name = "CxSearchCriteria";
            this.CxSearchCriteria.Size = new System.Drawing.Size(199, 24);
            this.CxSearchCriteria.TabIndex = 6;
            // 
            // TxValue
            // 
            this.TxValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxValue.Location = new System.Drawing.Point(164, 105);
            this.TxValue.Name = "TxValue";
            this.TxValue.Size = new System.Drawing.Size(199, 23);
            this.TxValue.TabIndex = 8;
            // 
            // DtValue
            // 
            this.DtValue.CustomFormat = "dd/MM/yyyy";
            this.DtValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtValue.Location = new System.Drawing.Point(165, 105);
            this.DtValue.Name = "DtValue";
            this.DtValue.Size = new System.Drawing.Size(198, 23);
            this.DtValue.TabIndex = 9;
            // 
            // CxValue
            // 
            this.CxValue.FormattingEnabled = true;
            this.CxValue.Location = new System.Drawing.Point(164, 105);
            this.CxValue.Name = "CxValue";
            this.CxValue.Size = new System.Drawing.Size(199, 24);
            this.CxValue.TabIndex = 10;
            // 
            // CbValue
            // 
            this.CbValue.AutoSize = true;
            this.CbValue.Location = new System.Drawing.Point(164, 110);
            this.CbValue.Name = "CbValue";
            this.CbValue.Size = new System.Drawing.Size(15, 14);
            this.CbValue.TabIndex = 11;
            this.CbValue.UseVisualStyleBackColor = true;
            // 
            // POSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 221);
            this.ControlBox = false;
            this.Controls.Add(this.CbValue);
            this.Controls.Add(this.CxValue);
            this.Controls.Add(this.DtValue);
            this.Controls.Add(this.TxValue);
            this.Controls.Add(this.CxSearchCriteria);
            this.Controls.Add(this.CxSearchField);
            this.Controls.Add(this.LbSearchCriteria);
            this.Controls.Add(this.LbSearchValue);
            this.Controls.Add(this.LbSearchField);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtSearch);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(300, 300);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POSearchForm";
            this.Text = "Searching";
            this.Load += new System.EventHandler(this.POSearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtSearch;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.Label LbSearchField;
        private System.Windows.Forms.Label LbSearchValue;
        private System.Windows.Forms.Label LbSearchCriteria;
        private System.Windows.Forms.ComboBox CxSearchField;
        private System.Windows.Forms.ComboBox CxSearchCriteria;
        private System.Windows.Forms.TextBox TxValue;
        private System.Windows.Forms.DateTimePicker DtValue;
        private System.Windows.Forms.ComboBox CxValue;
        private System.Windows.Forms.CheckBox CbValue;
    }
}
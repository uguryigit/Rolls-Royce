namespace RSAF_Forms
{
    partial class POAboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POAboutForm));
            this.LbApps = new System.Windows.Forms.Label();
            this.LbAllRights = new System.Windows.Forms.Label();
            this.LxTechs = new System.Windows.Forms.ListBox();
            this.LbCompany = new System.Windows.Forms.Label();
            this.LbDevelopBy = new System.Windows.Forms.Label();
            this.LbProvidedBy = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbVersion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbApps
            // 
            this.LbApps.AutoSize = true;
            this.LbApps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbApps.Location = new System.Drawing.Point(15, 16);
            this.LbApps.Name = "LbApps";
            this.LbApps.Size = new System.Drawing.Size(293, 15);
            this.LbApps.TabIndex = 23;
            this.LbApps.Text = "RB199-RSAF 4th Line Database Applications";
            // 
            // LbAllRights
            // 
            this.LbAllRights.AutoSize = true;
            this.LbAllRights.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbAllRights.Location = new System.Drawing.Point(60, 107);
            this.LbAllRights.Name = "LbAllRights";
            this.LbAllRights.Size = new System.Drawing.Size(106, 15);
            this.LbAllRights.TabIndex = 22;
            this.LbAllRights.Text = "All rights reserved.";
            // 
            // LxTechs
            // 
            this.LxTechs.AccessibleDescription = "Technologies  In-Use";
            this.LxTechs.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.LxTechs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LxTechs.FormattingEnabled = true;
            this.LxTechs.ItemHeight = 15;
            this.LxTechs.Items.AddRange(new object[] {
            "Visual C# Windows Forms App",
            ". NET Framework 4.6.1",
            "Entity Framework 6.x",
            "Microsoft SQL Server 2017",
            "SQL Server Integration Services",
            "SQL Server Reporting Services",
            "Microsoft ReportViewer 12.0"});
            this.LxTechs.Location = new System.Drawing.Point(45, 170);
            this.LxTechs.Name = "LxTechs";
            this.LxTechs.Size = new System.Drawing.Size(321, 139);
            this.LxTechs.TabIndex = 21;
            // 
            // LbCompany
            // 
            this.LbCompany.AutoSize = true;
            this.LbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbCompany.Location = new System.Drawing.Point(60, 87);
            this.LbCompany.Name = "LbCompany";
            this.LbCompany.Size = new System.Drawing.Size(147, 16);
            this.LbCompany.TabIndex = 20;
            this.LbCompany.Text = "© 2018 Rolls-Royce Plc";
            // 
            // LbDevelopBy
            // 
            this.LbDevelopBy.AutoSize = true;
            this.LbDevelopBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbDevelopBy.Location = new System.Drawing.Point(216, 312);
            this.LbDevelopBy.Name = "LbDevelopBy";
            this.LbDevelopBy.Size = new System.Drawing.Size(150, 13);
            this.LbDevelopBy.TabIndex = 19;
            this.LbDevelopBy.Text = "Developed by Goaltech IT Ltd";
            // 
            // LbProvidedBy
            // 
            this.LbProvidedBy.AutoSize = true;
            this.LbProvidedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbProvidedBy.Location = new System.Drawing.Point(60, 126);
            this.LbProvidedBy.Name = "LbProvidedBy";
            this.LbProvidedBy.Size = new System.Drawing.Size(144, 15);
            this.LbProvidedBy.TabIndex = 18;
            this.LbProvidedBy.Text = "Provided by Altran UK Ltd";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LbApps);
            this.panel1.Location = new System.Drawing.Point(45, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 48);
            this.panel1.TabIndex = 24;
            // 
            // LbVersion
            // 
            this.LbVersion.AutoSize = true;
            this.LbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbVersion.Location = new System.Drawing.Point(334, 87);
            this.LbVersion.Name = "LbVersion";
            this.LbVersion.Size = new System.Drawing.Size(32, 16);
            this.LbVersion.TabIndex = 25;
            this.LbVersion.Text = "v2.0";
            // 
            // POAboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 344);
            this.Controls.Add(this.LbVersion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LbAllRights);
            this.Controls.Add(this.LxTechs);
            this.Controls.Add(this.LbCompany);
            this.Controls.Add(this.LbDevelopBy);
            this.Controls.Add(this.LbProvidedBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POAboutForm";
            this.Tag = "";
            this.Text = "About Applications";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbApps;
        private System.Windows.Forms.Label LbAllRights;
        private System.Windows.Forms.ListBox LxTechs;
        private System.Windows.Forms.Label LbCompany;
        private System.Windows.Forms.Label LbDevelopBy;
        private System.Windows.Forms.Label LbProvidedBy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LbVersion;
    }
}
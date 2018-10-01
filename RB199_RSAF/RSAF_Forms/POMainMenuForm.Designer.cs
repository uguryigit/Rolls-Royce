namespace RSAF_Forms
{
    partial class POMainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POMainMenuForm));
            this.menuStripRSAF = new System.Windows.Forms.MenuStrip();
            this.purchaseOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPurchaseOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSearchPOItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wondowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripRSAF.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripRSAF
            // 
            this.menuStripRSAF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseOrdersToolStripMenuItem,
            this.wondowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripRSAF.Location = new System.Drawing.Point(0, 0);
            this.menuStripRSAF.Name = "menuStripRSAF";
            this.menuStripRSAF.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripRSAF.Size = new System.Drawing.Size(1276, 24);
            this.menuStripRSAF.TabIndex = 0;
            this.menuStripRSAF.Text = "menuStripRSAF";
            // 
            // purchaseOrdersToolStripMenuItem
            // 
            this.purchaseOrdersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPurchaseOrderToolStripMenuItem,
            this.editSearchPOItemsToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.purchaseOrdersToolStripMenuItem.Name = "purchaseOrdersToolStripMenuItem";
            this.purchaseOrdersToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.purchaseOrdersToolStripMenuItem.Text = "Purchase Orders";
            // 
            // newPurchaseOrderToolStripMenuItem
            // 
            this.newPurchaseOrderToolStripMenuItem.Name = "newPurchaseOrderToolStripMenuItem";
            this.newPurchaseOrderToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newPurchaseOrderToolStripMenuItem.Text = "New Purchase Order";
            this.newPurchaseOrderToolStripMenuItem.Click += new System.EventHandler(this.newPurchaseOrderToolStripMenuItem_Click);
            // 
            // editSearchPOItemsToolStripMenuItem
            // 
            this.editSearchPOItemsToolStripMenuItem.Name = "editSearchPOItemsToolStripMenuItem";
            this.editSearchPOItemsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.editSearchPOItemsToolStripMenuItem.Text = "Search/Edit PO Items";
            this.editSearchPOItemsToolStripMenuItem.Click += new System.EventHandler(this.editSearchPOItemsToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // wondowToolStripMenuItem
            // 
            this.wondowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileToolStripMenuItem,
            this.cascadeToolStripMenuItem});
            this.wondowToolStripMenuItem.Name = "wondowToolStripMenuItem";
            this.wondowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.wondowToolStripMenuItem.Text = "Window";
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.tileToolStripMenuItem.Text = "Tile";
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.tileToolStripMenuItem_Click);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.aboutToolStripMenuItem.Text = "About Apps";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // POMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 741);
            this.Controls.Add(this.menuStripRSAF);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripRSAF;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "POMainMenuForm";
            this.Text = "RB199 RSAF 4th Line Repair Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStripRSAF.ResumeLayout(false);
            this.menuStripRSAF.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripRSAF;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPurchaseOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSearchPOItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wondowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}


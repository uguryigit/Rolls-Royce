namespace RSAF_Forms
{
    partial class POMasterForm
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
            System.Windows.Forms.Label LbTYPE;
            System.Windows.Forms.Label LbSITE;
            System.Windows.Forms.Label LbBAEPO;
            System.Windows.Forms.Label LbBAEPART;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POMasterForm));
            this.CxTYPE = new System.Windows.Forms.ComboBox();
            this.CxSITE = new System.Windows.Forms.ComboBox();
            this.TxBAEPO = new System.Windows.Forms.TextBox();
            this.TxBAEPART = new System.Windows.Forms.TextBox();
            this.BtUpdate = new System.Windows.Forms.Button();
            LbTYPE = new System.Windows.Forms.Label();
            LbSITE = new System.Windows.Forms.Label();
            LbBAEPO = new System.Windows.Forms.Label();
            LbBAEPART = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LbTYPE
            // 
            LbTYPE.AutoSize = true;
            LbTYPE.Location = new System.Drawing.Point(75, 135);
            LbTYPE.Name = "LbTYPE";
            LbTYPE.Size = new System.Drawing.Size(47, 16);
            LbTYPE.TabIndex = 20;
            LbTYPE.Text = "TYPE:";
            // 
            // LbSITE
            // 
            LbSITE.AutoSize = true;
            LbSITE.Location = new System.Drawing.Point(81, 105);
            LbSITE.Name = "LbSITE";
            LbSITE.Size = new System.Drawing.Size(41, 16);
            LbSITE.TabIndex = 18;
            LbSITE.Text = "SITE:";
            // 
            // LbBAEPO
            // 
            LbBAEPO.AutoSize = true;
            LbBAEPO.Location = new System.Drawing.Point(42, 76);
            LbBAEPO.Name = "LbBAEPO";
            LbBAEPO.Size = new System.Drawing.Size(80, 16);
            LbBAEPO.TabIndex = 16;
            LbBAEPO.Text = "BAe PO No:";
            // 
            // LbBAEPART
            // 
            LbBAEPART.AutoSize = true;
            LbBAEPART.Location = new System.Drawing.Point(59, 48);
            LbBAEPART.Name = "LbBAEPART";
            LbBAEPART.Size = new System.Drawing.Size(63, 16);
            LbBAEPART.TabIndex = 15;
            LbBAEPART.Text = "BAe P/N:";
            // 
            // CxTYPE
            // 
            this.CxTYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CxTYPE.Location = new System.Drawing.Point(127, 131);
            this.CxTYPE.MaxLength = 24;
            this.CxTYPE.Name = "CxTYPE";
            this.CxTYPE.Size = new System.Drawing.Size(163, 24);
            this.CxTYPE.TabIndex = 22;
            this.CxTYPE.TextChanged += new System.EventHandler(this.CxTYPE_TextChanged);
            // 
            // CxSITE
            // 
            this.CxSITE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CxSITE.Location = new System.Drawing.Point(127, 101);
            this.CxSITE.MaxLength = 24;
            this.CxSITE.Name = "CxSITE";
            this.CxSITE.Size = new System.Drawing.Size(163, 24);
            this.CxSITE.TabIndex = 21;
            this.CxSITE.TextChanged += new System.EventHandler(this.CxSITE_TextChanged);
            // 
            // TxBAEPO
            // 
            this.TxBAEPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxBAEPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxBAEPO.Location = new System.Drawing.Point(127, 73);
            this.TxBAEPO.MaxLength = 24;
            this.TxBAEPO.Name = "TxBAEPO";
            this.TxBAEPO.Size = new System.Drawing.Size(163, 22);
            this.TxBAEPO.TabIndex = 19;
            // 
            // TxBAEPART
            // 
            this.TxBAEPART.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxBAEPART.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxBAEPART.Location = new System.Drawing.Point(127, 45);
            this.TxBAEPART.MaxLength = 30;
            this.TxBAEPART.Name = "TxBAEPART";
            this.TxBAEPART.Size = new System.Drawing.Size(163, 22);
            this.TxBAEPART.TabIndex = 17;
            // 
            // BtUpdate
            // 
            this.BtUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtUpdate.Location = new System.Drawing.Point(127, 161);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(163, 33);
            this.BtUpdate.TabIndex = 23;
            this.BtUpdate.Text = "Update";
            this.BtUpdate.UseVisualStyleBackColor = true;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // POMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 248);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(LbTYPE);
            this.Controls.Add(this.CxTYPE);
            this.Controls.Add(LbSITE);
            this.Controls.Add(this.CxSITE);
            this.Controls.Add(LbBAEPO);
            this.Controls.Add(this.TxBAEPO);
            this.Controls.Add(LbBAEPART);
            this.Controls.Add(this.TxBAEPART);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POMasterForm";
            this.Text = "Purchase Order Header Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CxTYPE;
        private System.Windows.Forms.ComboBox CxSITE;
        private System.Windows.Forms.TextBox TxBAEPO;
        private System.Windows.Forms.TextBox TxBAEPART;
        private System.Windows.Forms.Button BtUpdate;
    }
}
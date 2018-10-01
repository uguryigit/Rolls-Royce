namespace RSAF_Forms
{
    partial class POReportForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POReportForm));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RSAF_ProdDataSet = new RSAF_Forms.RSAF_ProdDataSet();
            this.RSAF_DETAILTableAdapter = new RSAF_Forms.RSAF_ProdDataSetTableAdapters.RSAF_DETAILTableAdapter();
            this.RSAF_DETAILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rSAFDETAILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RSAF_MASTERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.RSAF_ProdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSAF_DETAILBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSAFDETAILBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSAF_MASTERBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RSAF_Forms.RIA.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.ReportPath = "http://rr-desktop01/Reports/report/Reports/RSAF/ACCESSORY%20WIP";
            this.reportViewer1.Size = new System.Drawing.Size(810, 501);
            this.reportViewer1.TabIndex = 0;
            // 
            // RSAF_ProdDataSet
            // 
            this.RSAF_ProdDataSet.DataSetName = "RSAF_ProdDataSet";
            this.RSAF_ProdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RSAF_DETAILTableAdapter
            // 
            this.RSAF_DETAILTableAdapter.ClearBeforeFill = true;
            // 
            // RSAF_DETAILBindingSource
            // 
            this.RSAF_DETAILBindingSource.DataMember = "RSAF_DETAIL";
            this.RSAF_DETAILBindingSource.DataSource = this.RSAF_ProdDataSet;
            // 
            // rSAFDETAILBindingSource
            // 
            this.rSAFDETAILBindingSource.DataSource = typeof(RSAF_Forms.RSAF_DETAIL);
            // 
            // RSAF_MASTERBindingSource
            // 
            this.RSAF_MASTERBindingSource.DataMember = "RSAF_DETAIL";
            this.RSAF_MASTERBindingSource.DataSource = typeof(RSAF_Forms.RSAF_MASTER);
            // 
            // POReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 554);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "POReportForm";
            this.Text = "Repair Instructions";
            this.Load += new System.EventHandler(this.POReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RSAF_ProdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSAF_DETAILBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSAFDETAILBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSAF_MASTERBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private RSAF_ProdDataSet RSAF_ProdDataSet;
        private RSAF_ProdDataSetTableAdapters.RSAF_DETAILTableAdapter RSAF_DETAILTableAdapter;
        private System.Windows.Forms.BindingSource RSAF_DETAILBindingSource;
        private System.Windows.Forms.BindingSource rSAFDETAILBindingSource;
        private System.Windows.Forms.BindingSource RSAF_MASTERBindingSource;
    }
}
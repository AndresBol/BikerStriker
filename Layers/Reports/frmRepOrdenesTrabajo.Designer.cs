namespace BikerStriker.Layers.Reports
{
    partial class frmRepOrdenesTrabajo
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsBikerStrikerOrdenTrabajo = new BikerStriker.dsBikerStrikerOrdenTrabajo();
            this.ordenTrabajoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ordenTrabajoTableAdapter = new BikerStriker.dsBikerStrikerOrdenTrabajoTableAdapters.OrdenTrabajoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsBikerStrikerOrdenTrabajo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenTrabajoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetOrdenTrabajo";
            reportDataSource1.Value = this.ordenTrabajoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BikerStriker.Layers.Reports.repOrdenTrabajo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsBikerStrikerOrdenTrabajo
            // 
            this.dsBikerStrikerOrdenTrabajo.DataSetName = "dsBikerStrikerOrdenTrabajo";
            this.dsBikerStrikerOrdenTrabajo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordenTrabajoBindingSource
            // 
            this.ordenTrabajoBindingSource.DataMember = "OrdenTrabajo";
            this.ordenTrabajoBindingSource.DataSource = this.dsBikerStrikerOrdenTrabajo;
            // 
            // ordenTrabajoTableAdapter
            // 
            this.ordenTrabajoTableAdapter.ClearBeforeFill = true;
            // 
            // frmRepOrdenesTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRepOrdenesTrabajo";
            this.Text = "frmRepOrdenesTrabajo";
            this.Load += new System.EventHandler(this.frmRepOrdenesTrabajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsBikerStrikerOrdenTrabajo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenTrabajoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsBikerStrikerOrdenTrabajo dsBikerStrikerOrdenTrabajo;
        private System.Windows.Forms.BindingSource ordenTrabajoBindingSource;
        private dsBikerStrikerOrdenTrabajoTableAdapters.OrdenTrabajoTableAdapter ordenTrabajoTableAdapter;
    }
}
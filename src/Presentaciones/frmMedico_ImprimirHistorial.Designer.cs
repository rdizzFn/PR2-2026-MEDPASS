namespace DiseñoReservasMedicas.Presentaciones
{
    partial class frmMedico_ImprimirHistorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedico_ImprimirHistorial));
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPaginaAnterior = new Guna.UI2.WinForms.Guna2Button();
            this.btnPaginaSiguiente = new Guna.UI2.WinForms.Guna2Button();
            this.btnZoomMas = new Guna.UI2.WinForms.Guna2Button();
            this.btnZoomMenos = new Guna.UI2.WinForms.Guna2Button();
            this.btnImprimir = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(632, 761);
            this.printPreviewControl1.TabIndex = 56;
            this.printPreviewControl1.UseAntiAlias = true;
            this.printPreviewControl1.Zoom = 1D;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnPaginaAnterior
            // 
            this.btnPaginaAnterior.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPaginaAnterior.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPaginaAnterior.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPaginaAnterior.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPaginaAnterior.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPaginaAnterior.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPaginaAnterior.ForeColor = System.Drawing.Color.White;
            this.btnPaginaAnterior.Location = new System.Drawing.Point(23, 688);
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.Size = new System.Drawing.Size(106, 27);
            this.btnPaginaAnterior.TabIndex = 57;
            this.btnPaginaAnterior.Text = "Pag. Anterior";
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            // 
            // btnPaginaSiguiente
            // 
            this.btnPaginaSiguiente.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPaginaSiguiente.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPaginaSiguiente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPaginaSiguiente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPaginaSiguiente.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPaginaSiguiente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPaginaSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnPaginaSiguiente.Location = new System.Drawing.Point(150, 688);
            this.btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.Size = new System.Drawing.Size(106, 27);
            this.btnPaginaSiguiente.TabIndex = 58;
            this.btnPaginaSiguiente.Text = "Pag. Siguiente";
            this.btnPaginaSiguiente.Click += new System.EventHandler(this.btnPaginaSiguiente_Click);
            // 
            // btnZoomMas
            // 
            this.btnZoomMas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnZoomMas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnZoomMas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnZoomMas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnZoomMas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnZoomMas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnZoomMas.ForeColor = System.Drawing.Color.White;
            this.btnZoomMas.Location = new System.Drawing.Point(541, 688);
            this.btnZoomMas.Name = "btnZoomMas";
            this.btnZoomMas.Size = new System.Drawing.Size(38, 27);
            this.btnZoomMas.TabIndex = 59;
            this.btnZoomMas.Text = "+";
            this.btnZoomMas.Click += new System.EventHandler(this.btnZoomMas_Click);
            // 
            // btnZoomMenos
            // 
            this.btnZoomMenos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnZoomMenos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnZoomMenos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnZoomMenos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnZoomMenos.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnZoomMenos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnZoomMenos.ForeColor = System.Drawing.Color.White;
            this.btnZoomMenos.Location = new System.Drawing.Point(490, 688);
            this.btnZoomMenos.Name = "btnZoomMenos";
            this.btnZoomMenos.Size = new System.Drawing.Size(38, 27);
            this.btnZoomMenos.TabIndex = 60;
            this.btnZoomMenos.Text = "-";
            this.btnZoomMenos.Click += new System.EventHandler(this.btnZoomMenos_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImprimir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImprimir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImprimir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImprimir.FillColor = System.Drawing.Color.Maroon;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(459, 8);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(145, 45);
            this.btnImprimir.TabIndex = 61;
            this.btnImprimir.Text = "🖨 Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(12, 649);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 87);
            this.panel1.TabIndex = 62;
            // 
            // frmMedico_ImprimirHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 761);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnZoomMenos);
            this.Controls.Add(this.btnZoomMas);
            this.Controls.Add(this.btnPaginaSiguiente);
            this.Controls.Add(this.btnPaginaAnterior);
            this.Controls.Add(this.printPreviewControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMedico_ImprimirHistorial";
            this.Text = "frmMedico_ImprimirHistorial";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Guna.UI2.WinForms.Guna2Button btnPaginaAnterior;
        private Guna.UI2.WinForms.Guna2Button btnPaginaSiguiente;
        private Guna.UI2.WinForms.Guna2Button btnZoomMas;
        private Guna.UI2.WinForms.Guna2Button btnZoomMenos;
        private Guna.UI2.WinForms.Guna2Button btnImprimir;
        private System.Windows.Forms.Panel panel1;
    }
}
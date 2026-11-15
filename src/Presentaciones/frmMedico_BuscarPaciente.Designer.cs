namespace DiseñoReservasMedicas.Presentaciones
{
    partial class frmMedico_BuscarPaciente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2Button();
            this.dgvPaciente = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtBuscarPaciente = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnImprimirHistorial = new Guna.UI2.WinForms.Guna2Button();
            this.btnRegistrarHistorialClinico = new Guna.UI2.WinForms.Guna2Button();
            this.btnModificarHistorialClinico = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuscar.FillColor = System.Drawing.Color.Teal;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(742, 150);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(180, 45);
            this.btnBuscar.TabIndex = 52;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvPaciente
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPaciente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvPaciente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaciente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaciente.ColumnHeadersHeight = 20;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaciente.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaciente.GridColor = System.Drawing.Color.Black;
            this.dgvPaciente.Location = new System.Drawing.Point(30, 232);
            this.dgvPaciente.Name = "dgvPaciente";
            this.dgvPaciente.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaciente.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaciente.RowHeadersVisible = false;
            this.dgvPaciente.RowHeadersWidth = 80;
            this.dgvPaciente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPaciente.Size = new System.Drawing.Size(941, 247);
            this.dgvPaciente.TabIndex = 51;
            this.dgvPaciente.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPaciente.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvPaciente.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dgvPaciente.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPaciente.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPaciente.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvPaciente.ThemeStyle.ReadOnly = true;
            this.dgvPaciente.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvPaciente.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPaciente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaciente_CellClick);
            // 
            // txtBuscarPaciente
            // 
            this.txtBuscarPaciente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarPaciente.DefaultText = "";
            this.txtBuscarPaciente.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscarPaciente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscarPaciente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarPaciente.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarPaciente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarPaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscarPaciente.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarPaciente.Location = new System.Drawing.Point(30, 152);
            this.txtBuscarPaciente.Name = "txtBuscarPaciente";
            this.txtBuscarPaciente.PlaceholderText = "";
            this.txtBuscarPaciente.SelectedText = "";
            this.txtBuscarPaciente.Size = new System.Drawing.Size(633, 43);
            this.txtBuscarPaciente.TabIndex = 50;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(30, 119);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(389, 27);
            this.guna2HtmlLabel2.TabIndex = 49;
            this.guna2HtmlLabel2.Text = "Buscar Pacientes por CI o NOMBRE:";
            this.guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.guna2HtmlLabel2.Click += new System.EventHandler(this.guna2HtmlLabel2_Click);
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(359, 28);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(291, 44);
            this.guna2HtmlLabel8.TabIndex = 38;
            this.guna2HtmlLabel8.Text = "Buscar Paciente";
            this.guna2HtmlLabel8.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Maroon;
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel8);
            this.guna2Panel2.Location = new System.Drawing.Point(-1, 1);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1014, 100);
            this.guna2Panel2.TabIndex = 53;
            // 
            // btnImprimirHistorial
            // 
            this.btnImprimirHistorial.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImprimirHistorial.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImprimirHistorial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImprimirHistorial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImprimirHistorial.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnImprimirHistorial.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirHistorial.ForeColor = System.Drawing.Color.White;
            this.btnImprimirHistorial.Location = new System.Drawing.Point(820, 518);
            this.btnImprimirHistorial.Name = "btnImprimirHistorial";
            this.btnImprimirHistorial.Size = new System.Drawing.Size(180, 64);
            this.btnImprimirHistorial.TabIndex = 54;
            this.btnImprimirHistorial.Text = "Imprimir Historial";
            this.btnImprimirHistorial.Click += new System.EventHandler(this.btnImprimirHistorial_Click);
            // 
            // btnRegistrarHistorialClinico
            // 
            this.btnRegistrarHistorialClinico.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRegistrarHistorialClinico.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRegistrarHistorialClinico.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRegistrarHistorialClinico.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRegistrarHistorialClinico.FillColor = System.Drawing.Color.Teal;
            this.btnRegistrarHistorialClinico.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarHistorialClinico.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarHistorialClinico.Location = new System.Drawing.Point(470, 518);
            this.btnRegistrarHistorialClinico.Name = "btnRegistrarHistorialClinico";
            this.btnRegistrarHistorialClinico.Size = new System.Drawing.Size(222, 45);
            this.btnRegistrarHistorialClinico.TabIndex = 55;
            this.btnRegistrarHistorialClinico.Text = "Registrar Historial";
            this.btnRegistrarHistorialClinico.Click += new System.EventHandler(this.btnRegistrarHistorialClinico_Click_1);
            // 
            // btnModificarHistorialClinico
            // 
            this.btnModificarHistorialClinico.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnModificarHistorialClinico.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnModificarHistorialClinico.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnModificarHistorialClinico.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnModificarHistorialClinico.FillColor = System.Drawing.Color.Teal;
            this.btnModificarHistorialClinico.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarHistorialClinico.ForeColor = System.Drawing.Color.White;
            this.btnModificarHistorialClinico.Location = new System.Drawing.Point(137, 518);
            this.btnModificarHistorialClinico.Name = "btnModificarHistorialClinico";
            this.btnModificarHistorialClinico.Size = new System.Drawing.Size(222, 45);
            this.btnModificarHistorialClinico.TabIndex = 56;
            this.btnModificarHistorialClinico.Text = "Modificar Historial";
            this.btnModificarHistorialClinico.Click += new System.EventHandler(this.btnModificarHistorialClinico_Click);
            // 
            // frmMedico_BuscarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 594);
            this.Controls.Add(this.btnModificarHistorialClinico);
            this.Controls.Add(this.btnRegistrarHistorialClinico);
            this.Controls.Add(this.btnImprimirHistorial);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvPaciente);
            this.Controls.Add(this.txtBuscarPaciente);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Name = "frmMedico_BuscarPaciente";
            this.Text = "frmMedico_BuscarPaciente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnBuscar;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPaciente;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscarPaciente;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnImprimirHistorial;
        private Guna.UI2.WinForms.Guna2Button btnRegistrarHistorialClinico;
        private Guna.UI2.WinForms.Guna2Button btnModificarHistorialClinico;
    }
}
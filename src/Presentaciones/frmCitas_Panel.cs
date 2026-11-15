using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmCitas_Panel : Form
    {
        public frmCitas_Panel()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panelCitas.Controls.Clear();

            frmCitas_Nueva formulario = new frmCitas_Nueva();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelCitas.Controls.Add(formulario);
            formulario.Show();
        }

        private void btnVerCitas_Click(object sender, EventArgs e)
        {
            panelCitas.Controls.Clear();

            frmCitas_Programadas formulario = new frmCitas_Programadas();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelCitas.Controls.Add(formulario);
            formulario.Show();
        }

        private void btnReprogramar_Click(object sender, EventArgs e)
        {
            panelCitas.Controls.Clear();

            frmCitas_HistorialClinico formulario = new frmCitas_HistorialClinico();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelCitas.Controls.Add(formulario);
            formulario.Show();
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            panelCitas.Controls.Clear();

            frmCitas_Cancelar formulario = new frmCitas_Cancelar();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelCitas.Controls.Add(formulario);
            formulario.Show();
        }
    }
}

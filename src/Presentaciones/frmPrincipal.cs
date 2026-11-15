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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            AbrirFormulario(new frmInicio());
        }

        private void AbrirFormulario(Form formulario)
        {
            panelContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);
            formulario.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            panelContenido.Visible = true;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();

            frmInicio formulario = new frmInicio();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);

            formulario.Show();

        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();

            frmCitas_Panel formulario = new frmCitas_Panel();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);

            formulario.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();

            frmMiPerfil formulario = new frmMiPerfil();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);

            formulario.Show();
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();

            frmCitas formulario = new frmCitas();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);

            formulario.Show();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            frmPagos formulario = new frmPagos();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formulario);

            formulario.Show();
        }
    }
}

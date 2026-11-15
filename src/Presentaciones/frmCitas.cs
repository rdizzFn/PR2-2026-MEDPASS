
using DiseñoReservasMedicas.Presentaciones;
using System;
using System.Windows.Forms;

namespace DiseñoReservasMedicas
{
    public partial class frmCitas : Form
    {
        private int idPacienteSeleccionado = 0;

        public frmCitas()
        {
            InitializeComponent();
        }

        public void SeleccionarPaciente(int idPaciente)
        {
            idPacienteSeleccionado = idPaciente;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
        }



        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Primero selecciona un paciente desde la lista en Ver Pacientes.",
                    "Paciente no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            panelCitas.Controls.Clear();

            frmCitas_AñadirInformacion formulario =
                new frmCitas_AñadirInformacion(idPacienteSeleccionado);

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelCitas.Controls.Add(formulario);
            formulario.Show();
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panelCitas.Controls.Clear();

            frmCitas_AñadirPaciente formulario =
                new frmCitas_AñadirPaciente();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelCitas.Controls.Add(formulario);
            formulario.Show();
        }

       
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelCitas.Controls.Clear();

            frmVerPacientes formulario = new frmVerPacientes();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelCitas.Controls.Add(formulario);
            formulario.Show();
        }
    }
}

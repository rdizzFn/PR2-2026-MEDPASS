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
    public partial class frmMedico : Form
    {
        private int idUsuario;

        public int IdUsuario
        {
            get { return idUsuario; }
        }

        public frmMedico(int idUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            AbrirFormulario(new frmMedico_Inicio(idUsuario));

            CargarDatosMedico();

            lblFecha.Text = DateTime.Now.ToString(
            "dddd dd 'de' MMMM 'de' yyyy",
            new System.Globalization.CultureInfo("es-ES")
            );
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");


        }

        public void AbrirFormulario(Form formulario)
        {
            panelContenidoMedico.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenidoMedico.Controls.Add(formulario);

            formulario.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmMedico_Inicio(idUsuario));
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void btnPaciente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmMedico_Citas(this));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void CargarDatosMedico()
        {
            ConexionBD conexionBD = new ConexionBD();

            DataTable datos = conexionBD.ObtenerDatosMedico(idUsuario);

            if (datos.Rows.Count > 0)
            {
                DataRow medico = datos.Rows[0];

                lblNombre.Text = medico["nombre"].ToString();
                lblEspecialidad.Text = medico["especialidad"].ToString();
            }
        }

        

        private void btnPacientes_Click_1(object sender, EventArgs e)
        {
            ConexionBD conexionBD = new ConexionBD();

            int idMedico = conexionBD.ObtenerIdMedico(this.IdUsuario);

            AbrirFormulario(
                new frmMedico_MisHorarios(idMedico)
            );
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            AbrirFormulario(
        new frmMedico_Pacientes(this)
            );
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

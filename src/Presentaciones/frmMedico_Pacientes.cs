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
    public partial class frmMedico_Pacientes : Form
    {
        private frmMedico formularioPrincipal;
        private ConexionBD conexion = new ConexionBD();
        private int idMedico;

        public frmMedico_Pacientes(frmMedico formularioPrincipal)
        {
            InitializeComponent();

            this.formularioPrincipal = formularioPrincipal;


        }

        private void btnBuscarPacientes_Click(object sender, EventArgs e)
        {
            ConexionBD conexionBD = new ConexionBD();

            int idMedico = conexionBD.ObtenerIdMedico(formularioPrincipal.IdUsuario);

            formularioPrincipal.AbrirFormulario(
                new frmMedico_BuscarPaciente(idMedico)
            );
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            ConexionBD conexionBD = new ConexionBD();

            int idMedico = conexionBD.ObtenerIdMedico(formularioPrincipal.IdUsuario);

            formularioPrincipal.AbrirFormulario(
                new frmMedico_DerivarPaciente(idMedico)
            );
        }
    }
}

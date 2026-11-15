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
    public partial class frmMedico_Citas : Form
    {
        public frmMedico_Citas()
        {
            InitializeComponent();
        }

        private frmMedico formularioPrincipal;

        private int idMedico;

        public frmMedico_Citas(frmMedico formularioPrincipal)
        {
            InitializeComponent();

            this.formularioPrincipal = formularioPrincipal;

            ConexionBD conexionBD = new ConexionBD();

            idMedico = conexionBD.ObtenerIdMedico(formularioPrincipal.IdUsuario);
        }

        private void btnCitasHoy_Click(object sender, EventArgs e)
{
    formularioPrincipal.AbrirFormulario(new frmMedico_CitasHoy(formularioPrincipal));
}

private void guna2ImageButton2_Click(object sender, EventArgs e)
{
    formularioPrincipal.AbrirFormulario(
        new frmMedico_ProximasCitas(formularioPrincipal.IdUsuario)
    );
}

private void guna2ImageButton3_Click(object sender, EventArgs e)
{
    formularioPrincipal.AbrirFormulario(
        new frmMedico_HistorialClinico(formularioPrincipal)
    );
}
    }
}

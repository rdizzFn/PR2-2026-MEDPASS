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
    public partial class frmMedico_Inicio : Form
    {
        private int idUsuario;

        public frmMedico_Inicio(int idUsuario)
        {
            InitializeComponent();
            

            this.idUsuario = idUsuario;
            CargarNombreMedico();
        }

        private void CargarNombreMedico()
        {
            ConexionBD conexionBD = new ConexionBD();

            DataTable datos = conexionBD.ObtenerDatosMedico(idUsuario);

            if (datos.Rows.Count > 0)
            {
                lblDoctor.Text = datos.Rows[0]["nombre"].ToString();
            }
        }
    }
}


using System;
using System.Data;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmVerPacientes : Form
    {
        private int idPacienteSeleccionado;

        public frmVerPacientes()
        {
            InitializeComponent();
            CargarPacientes();
            dgvPacientes.CellClick += dgvPacientes_CellClick_1;
        }

        private void CargarPacientes()
        {
            ConexionBD conexionBD = new ConexionBD();

            dgvPacientes.DataSource = conexionBD.ObtenerPacientes();

            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.MultiSelect = false;
            dgvPacientes.ReadOnly = true;
            dgvPacientes.AllowUserToAddRows = false;
        }






        private void dgvPacientes_CellClick_1(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object valorId = dgvPacientes.Rows[e.RowIndex].Cells["ID"].Value;

            if (valorId == null || valorId == DBNull.Value)
                return;

            idPacienteSeleccionado = Convert.ToInt32(valorId);

            Control controlActual = this.Parent;

            while (controlActual != null && !(controlActual is frmCitas))
            {
                controlActual = controlActual.Parent;
            }

            frmCitas formularioCitas = controlActual as frmCitas;

            if (formularioCitas != null)
            {
                formularioCitas.SeleccionarPaciente(idPacienteSeleccionado);
            }
        }





    }
}

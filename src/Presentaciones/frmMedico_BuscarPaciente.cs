using System;
using System.Data;
using System.Windows.Forms;
using DiseñoReservasMedicas;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmMedico_BuscarPaciente : Form
    {
        private int idMedico;
        private ConexionBD conexion = new ConexionBD();
        private int idPacienteSeleccionado = 0;

        public frmMedico_BuscarPaciente(int idMedico)
        {
            InitializeComponent();

            this.idMedico = idMedico;

            btnImprimirHistorial.Enabled = false;
            btnModificarHistorialClinico.Enabled = false;
            btnRegistrarHistorialClinico.Enabled = false;

           
            txtBuscarPaciente.Clear();
            CargarPacientes();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
        }

        private void CargarPacientes()
        {
            try
            {
                string buscar = txtBuscarPaciente.Text.Trim();

                DataTable pacientes =
                    conexion.ObtenerPacientesAtendidosPorMedico(
                        idMedico,
                        buscar
                    );

                dgvPaciente.DataSource = pacientes;

                if (dgvPaciente.Columns.Contains("id_paciente"))
                    dgvPaciente.Columns["id_paciente"].HeaderText = "ID";

                if (dgvPaciente.Columns.Contains("nombre"))
                    dgvPaciente.Columns["nombre"].HeaderText = "Nombre";

                if (dgvPaciente.Columns.Contains("apellido"))
                    dgvPaciente.Columns["apellido"].HeaderText = "Apellido";

                if (dgvPaciente.Columns.Contains("ci"))
                    dgvPaciente.Columns["ci"].HeaderText = "CI";

                if (dgvPaciente.Columns.Contains("telefono"))
                    dgvPaciente.Columns["telefono"].HeaderText = "Teléfono";

             
                idPacienteSeleccionado = 0;

                btnImprimirHistorial.Enabled = false;
                btnModificarHistorialClinico.Enabled = false;
                btnRegistrarHistorialClinico.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los pacientes:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPacientes();
        }

        private void dgvPaciente_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                idPacienteSeleccionado = Convert.ToInt32(
                    dgvPaciente.Rows[e.RowIndex]
                        .Cells["id_paciente"].Value
                );

                bool tieneHistorial =
                    conexion.TieneHistorialClinico(
                        idPacienteSeleccionado
                    );

                btnImprimirHistorial.Enabled = true;
                btnModificarHistorialClinico.Enabled = tieneHistorial;
                btnRegistrarHistorialClinico.Enabled = !tieneHistorial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al seleccionar el paciente:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnVerHistorialClinico_Click(
            object sender,
            EventArgs e)
        {
            if (idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un paciente.");
                return;
            }

            bool tieneHistorial =
                conexion.TieneHistorialClinico(
                    idPacienteSeleccionado
                );

            if (!tieneHistorial)
            {
                MessageBox.Show(
                    "El paciente aún no tiene un historial clínico registrado.",
                    "Historial clínico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            MessageBox.Show(
                "El paciente tiene un historial clínico registrado.",
                "Historial clínico",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnRegistrarHistorialClinico_Click(
            object sender,
            EventArgs e)
        {
            if (idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un paciente.");
                return;
            }

            frmMedico_HistorialPaciente formulario =
                new frmMedico_HistorialPaciente(
                    idPacienteSeleccionado
                );

            formulario.ShowDialog();
        }

        private void btnRegistrarHistorialClinico_Click_1(
            object sender,
            EventArgs e)
        {
            btnRegistrarHistorialClinico_Click(sender, e);
        }

        private void btnModificarHistorialClinico_Click(
            object sender,
            EventArgs e)
        {
            if (idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un paciente.");
                return;
            }

            frmMedico_HistorialPaciente formulario =
                new frmMedico_HistorialPaciente(
                    idPacienteSeleccionado,
                    true
                );

            formulario.ShowDialog();
        }

        private void btnImprimirHistorial_Click(
            object sender,
            EventArgs e)
        {
            if (idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un paciente.");
                return;
            }

            frmMedico_ImprimirHistorial formulario =
                new frmMedico_ImprimirHistorial(
                    idPacienteSeleccionado
                );

            formulario.ShowDialog();
        }
    }
}


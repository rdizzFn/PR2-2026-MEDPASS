using System.Collections.Generic;
using System;
using System.Data;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmMedico_HistorialClinico : Form
    {
        private frmMedico formularioPrincipal;
        private int idMedico;

        public frmMedico_HistorialClinico(frmMedico formularioPrincipal)
        {
            InitializeComponent();
            CargarListaPacientes();
            ConfigurarAutocompletadoPacientes();
            txtBuscarPaciente.TextChanged += txtBuscarPaciente_TextChanged;


            this.formularioPrincipal = formularioPrincipal;

            ConexionBD conexionBD = new ConexionBD();

            idMedico = conexionBD.ObtenerIdMedico(
                formularioPrincipal.IdUsuario
            );
            CargarTodosLosHistoriales();

            dgvHistorialCitas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistorialCitas.ScrollBars = ScrollBars.Vertical;

            dgvHistorialCitas.AllowUserToAddRows = false;
            dgvHistorialCitas.ReadOnly = true;
            dgvHistorialCitas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHistorialCitas.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
        }


        private DataTable tablaPacientes;

        private void CargarListaPacientes()
        {
            ConexionBD conexionBD = new ConexionBD();
            tablaPacientes = conexionBD.ObtenerPacientes();
        }

        private void txtBuscarPaciente_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscarPaciente.Text.Trim();

            AutoCompleteStringCollection sugerencias =
                new AutoCompleteStringCollection();

            if (string.IsNullOrWhiteSpace(texto))
            {
                txtBuscarPaciente.AutoCompleteCustomSource = sugerencias;
                return;
            }

            if (tablaPacientes == null)
            {
                CargarListaPacientes();
            }

            foreach (DataRow fila in tablaPacientes.Rows)
            {
                string nombre = fila["Nombre"].ToString().Trim();
                string apellido = fila["Apellido"].ToString().Trim();

                string nombreCompleto = nombre + " " + apellido;

                if (nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    apellido.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    nombreCompleto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    sugerencias.Add(nombreCompleto);
                }
            }

            txtBuscarPaciente.AutoCompleteCustomSource = sugerencias;
            txtBuscarPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscarPaciente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }


        private void ConfigurarAutocompletadoPacientes()
        {
            ConexionBD conexionBD = new ConexionBD();
            DataTable tablaPacientes = conexionBD.ObtenerPacientes();

            AutoCompleteStringCollection nombresPacientes =
                new AutoCompleteStringCollection();

            foreach (DataRow fila in tablaPacientes.Rows)
            {
                string nombre = fila["Nombre"].ToString().Trim();
                string apellido = fila["Apellido"].ToString().Trim();

                string nombreCompleto = nombre + " " + apellido;

                nombresPacientes.Add(nombreCompleto);
            }

            txtBuscarPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscarPaciente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBuscarPaciente.AutoCompleteCustomSource = nombresPacientes;
        }
        private void CargarHistorial()
        {
            ConexionBD conexionBD = new ConexionBD();

            DataTable tabla = conexionBD.ObtenerHistorialCitasMedico(
                idMedico,
                txtBuscarPaciente.Text.Trim(),
                dtpDesde.Value,
                dtpHasta.Value
            );

            dgvHistorialCitas.DataSource = tabla;

            ConfigurarColumnasHistorial();
        }


        private void CargarTodosLosHistoriales()
        {
            ConexionBD conexionBD = new ConexionBD();

            DataTable tabla = conexionBD.ObtenerHistorialCitasMedico(
                idMedico,
                "",
                new DateTime(1753, 1, 1),
                new DateTime(9998, 12, 31)
            );

            dgvHistorialCitas.DataSource = tabla;

            ConfigurarColumnasHistorial();
        }

        private void ConfigurarColumnasHistorial()
        {
            
            if (dgvHistorialCitas.Columns.Contains("id_cita"))
            {
                dgvHistorialCitas.Columns["id_cita"].HeaderText =
                    "N.º de cita";
            }

            if (dgvHistorialCitas.Columns.Contains("fecha_cita"))
            {
                dgvHistorialCitas.Columns["fecha_cita"].HeaderText =
                    "Fecha";
            }

            if (dgvHistorialCitas.Columns.Contains("hora_cita"))
            {
                dgvHistorialCitas.Columns["hora_cita"].HeaderText =
                    "Hora";
            }

            if (dgvHistorialCitas.Columns.Contains("paciente"))
            {
                dgvHistorialCitas.Columns["paciente"].HeaderText =
                    "Paciente";
            }

            if (dgvHistorialCitas.Columns.Contains("estado"))
            {
                dgvHistorialCitas.Columns["estado"].HeaderText =
                    "Estado";
            }

            if (dgvHistorialCitas.Columns.Contains("medico"))
            {
                dgvHistorialCitas.Columns["medico"].HeaderText =
                    "Médico";
            }
            if (dgvHistorialCitas.Columns.Contains("tratamiento"))
            {
                dgvHistorialCitas.Columns["tratamiento"].HeaderText = "Tratamiento";
            }


            dgvHistorialCitas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha Desde no puede ser mayor que la fecha Hasta.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            CargarHistorial();
        }
    }
}
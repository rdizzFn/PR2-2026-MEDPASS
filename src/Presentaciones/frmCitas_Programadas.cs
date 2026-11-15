using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmCitas_Programadas : Form
    {
        private string cadenaConexion = @"Server=localhost;Database=BD_ReservasMedicas;Integrated Security=True;";

        public frmCitas_Programadas()
        {
            InitializeComponent();
            CargarCitas();
            ConfigurarTabla();
            CargarMedicos();
        }

        private void CargarCitas()
        {
            string consulta = @"
                SELECT
                    c.id_cita,
                    c.fecha_cita,
                    c.hora_cita,
                    c.piso,
                    p.nombre + ' ' + p.apellido AS paciente,
                    m.nombre AS medico,
                    e.nombre AS especialidad,
                    c.motivo,
                    c.estado
                FROM TB_CITA AS c
                INNER JOIN TB_PACIENTE AS p
                    ON c.id_paciente = p.id_paciente
                INNER JOIN TB_MEDICO AS m
                    ON c.id_medico = m.id_medico
                INNER JOIN TB_ESPECIALIDAD AS e
                    ON m.id_especialidad = e.id_especialidad
                WHERE 
                    (p.nombre LIKE @busqueda
                     OR p.apellido LIKE @busqueda)
                    AND (@idMedico IS NULL OR c.id_medico = @idMedico)
                ORDER BY c.fecha_cita, c.hora_cita;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                {
                    string textoBusqueda = txtBuscarPacientes.Text.Trim();

                    adaptador.SelectCommand.Parameters.AddWithValue(
                        "@busqueda", "%" + textoBusqueda + "%");

                    if (cmbMedico.SelectedIndex == -1)
                    {
                        adaptador.SelectCommand.Parameters.AddWithValue(
                            "@idMedico", DBNull.Value);
                    }
                    else
                    {
                        adaptador.SelectCommand.Parameters.AddWithValue(
                            "@idMedico", cmbMedico.SelectedValue);
                    }

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dgvCitas.DataSource = tabla;
                }
            }

            ConfigurarTabla();
        }

        private void CargarMedicos()
        {
            string consulta = @"
        SELECT id_medico, nombre
        FROM TB_MEDICO
        ORDER BY nombre;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    cmbMedico.DataSource = tabla;
                    cmbMedico.DisplayMember = "nombre";
                    cmbMedico.ValueMember = "id_medico";
                    cmbMedico.SelectedIndex = -1;
                }
            }
        }

        private void BuscarPacientes()
        {
            string textoBusqueda = txtBuscarPacientes.Text.Trim();

            string consulta = @"
        SELECT
            c.id_cita,
            c.fecha_cita,
            c.hora_cita,
            c.piso,
            p.nombre + ' ' + p.apellido AS paciente,
            m.nombre AS medico,
            e.nombre AS especialidad,
            c.estado
        FROM TB_CITA AS c
        INNER JOIN TB_PACIENTE AS p
            ON c.id_paciente = p.id_paciente
        INNER JOIN TB_MEDICO AS m
            ON c.id_medico = m.id_medico
        INNER JOIN TB_ESPECIALIDAD AS e
            ON m.id_especialidad = e.id_especialidad
        WHERE p.nombre LIKE @busqueda
           OR p.apellido LIKE @busqueda
        ORDER BY c.fecha_cita, c.hora_cita;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue(
                        "@busqueda", "%" + textoBusqueda + "%");

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dgvCitas.DataSource = tabla;
                }
            }

            ConfigurarTabla();
        }

        private void ConfigurarTabla()
        {
            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCitas.AllowUserToAddRows = false;
            dgvCitas.AllowUserToDeleteRows = false;
            dgvCitas.ReadOnly = true;
            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCitas.MultiSelect = false;

            dgvCitas.Columns["id_cita"].Visible = false;

            dgvCitas.Columns["fecha_cita"].HeaderText = "Fecha";
            dgvCitas.Columns["hora_cita"].HeaderText = "Hora";
            dgvCitas.Columns["piso"].HeaderText = "Piso";
            dgvCitas.Columns["paciente"].HeaderText = "Paciente";
            dgvCitas.Columns["medico"].HeaderText = "Médico";
            dgvCitas.Columns["especialidad"].HeaderText = "Especialidad";
            dgvCitas.Columns["motivo"].HeaderText = "Motivo";
            dgvCitas.Columns["estado"].HeaderText = "Estado";
        }

        private void ColorearCitas()
        {
            foreach (DataGridViewRow fila in dgvCitas.Rows)
            {
                if (fila.Cells["estado"].Value != null &&
                    fila.Cells["estado"].Value.ToString() == "Cancelada")
                {
                    fila.DefaultCellStyle.ForeColor = Color.Red;
                    fila.DefaultCellStyle.SelectionForeColor = Color.Red;
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBuscarPacientes_TextChanged(object sender, EventArgs e)
        {
            CargarCitas();
        }

        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCitas();
        }

        

        private void dgvCitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            frmCitas_HistorialClinico formulario =
                new frmCitas_HistorialClinico();

            formulario.ShowDialog();
        }

        private void dgvCitas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ColorearCitas();
        }
    }


}
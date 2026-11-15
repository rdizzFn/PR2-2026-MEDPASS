using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmCitas_HistorialClinico : Form
    {
        private string cadenaConexion = @"Server=localhost;Database=BD_ReservasMedicas;Integrated Security=True;";
        

        public frmCitas_HistorialClinico()
        {
            InitializeComponent();

            CargarPacientes();
            CargarMedicos();
            CargarHorarios();
            CargarNuevaHora();
        }

        private void CargarPacientes()
        {
            string consulta = @"
                SELECT id_paciente, nombre + ' ' + apellido AS paciente
                FROM TB_PACIENTE
                ORDER BY nombre, apellido;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                {
                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    cmbPaciente.DataSource = tabla;
                    cmbPaciente.DisplayMember = "paciente";
                    cmbPaciente.ValueMember = "id_paciente";
                    cmbPaciente.SelectedIndex = -1;
                }
            }
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

        private void CargarHorarios()
        {
            cmbHorario.Items.Clear();

            cmbHorario.Items.Add("08:00");
            cmbHorario.Items.Add("09:00");
            cmbHorario.Items.Add("10:00");
            cmbHorario.Items.Add("11:00");
            cmbHorario.Items.Add("12:00");
            cmbHorario.Items.Add("14:00");
            cmbHorario.Items.Add("15:00");
            cmbHorario.Items.Add("16:00");
            cmbHorario.Items.Add("17:00");

            cmbHorario.SelectedIndex = -1;
        }

        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedico.SelectedIndex == -1)
            {
                lblEspecialidad.Text = "";
                return;
            }

            string consulta = @"
                    SELECT e.nombre
                    FROM TB_MEDICO AS m
                    INNER JOIN TB_ESPECIALIDAD AS e
                        ON m.id_especialidad = e.id_especialidad
                    WHERE m.id_medico = @idMedico;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idMedico",
                        cmbMedico.SelectedValue
                    );

                    conexion.Open();

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        lblEspecialidad.Text = resultado.ToString();
                    }
                    CargarCitaActual();
                }
            }
        }

        private void btnReprogramar_Click(object sender, EventArgs e)
        {
            if (cmbPaciente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un paciente.");
                cmbPaciente.Focus();
                return;
            }

            if (cmbMedico.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un médico.");
                cmbMedico.Focus();
                return;
            }

            if (cmbNuevaHora.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una nueva hora.");
                cmbNuevaHora.Focus();
                return;
            }

       
            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Ingrese el motivo de la reprogramación.");
                txtMotivo.Focus();
                return;
            }

            int idPaciente = Convert.ToInt32(cmbPaciente.SelectedValue);
            int idMedico = Convert.ToInt32(cmbMedico.SelectedValue);

            DateTime nuevaFecha = dtpNuevaFecha.Value.Date;
            TimeSpan nuevaHora = TimeSpan.Parse(cmbNuevaHora.Text);

            DateTime fechaActual = dtpFechaCita.Value.Date;
            TimeSpan horaActual = TimeSpan.Parse(cmbHorario.Text);

            if (!HorarioDisponible(
                    idPaciente,
                    idMedico,
                    fechaActual,
                    horaActual,
                    nuevaFecha,
                    nuevaHora))
            {
                MessageBox.Show("El médico ya tiene una cita en ese horario.");
                return;
            }

            string consulta = @"
        UPDATE TB_CITA
        SET fecha_cita = @nuevaFecha,
            hora_cita = @nuevaHora,
            motivo_reprogramacion = @motivo
        WHERE id_paciente = @idPaciente
          AND id_medico = @idMedico;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nuevaFecha", nuevaFecha);
                    comando.Parameters.AddWithValue("@nuevaHora", nuevaHora);
                    comando.Parameters.AddWithValue("@motivo", txtMotivo.Text);
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente);
                    comando.Parameters.AddWithValue("@idMedico", idMedico);

                    conexion.Open();

                    comando.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cita reprogramada correctamente.");

            cmbPaciente.SelectedIndex = -1;
            cmbMedico.SelectedIndex = -1;
            cmbNuevaHora.SelectedIndex = -1;

            dtpNuevaFecha.Value = DateTime.Now;

            txtMotivo.Clear();

            lblEspecialidad.Text = "";
        }

        private void CargarNuevaHora()
        {
            cmbNuevaHora.Items.Clear();

            cmbNuevaHora.Items.Add("08:00");
            cmbNuevaHora.Items.Add("09:00");
            cmbNuevaHora.Items.Add("10:00");
            cmbNuevaHora.Items.Add("11:00");
            cmbNuevaHora.Items.Add("12:00");
            cmbNuevaHora.Items.Add("14:00");
            cmbNuevaHora.Items.Add("15:00");
            cmbNuevaHora.Items.Add("16:00");
            cmbNuevaHora.Items.Add("17:00");

            cmbNuevaHora.SelectedIndex = -1;
        }

        private void CargarCitaActual()
        {
            if (cmbPaciente.SelectedIndex == -1 ||
                cmbMedico.SelectedIndex == -1)
            {
                return;
            }

            if (cmbPaciente.SelectedValue == null ||
                cmbMedico.SelectedValue == null)
            {
                return;
            }

            string consulta = @"
        SELECT TOP 1 fecha_cita, hora_cita
        FROM TB_CITA
        WHERE id_paciente = @idPaciente
          AND id_medico = @idMedico
        ORDER BY fecha_cita, hora_cita;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idPaciente",
                        Convert.ToInt32(cmbPaciente.SelectedValue)
                    );

                    comando.Parameters.AddWithValue(
                        "@idMedico",
                        Convert.ToInt32(cmbMedico.SelectedValue)
                    );

                    conexion.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            dtpFechaCita.Value =
                                Convert.ToDateTime(lector["fecha_cita"]);

                            cmbHorario.Text =
                                lector["hora_cita"].ToString();
                        }
                    }
                }
            }
        }

        private void cmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCitaActual();

            
        }

        private bool HorarioDisponible(
    int idPaciente,
    int idMedico,
    DateTime fechaActual,
    TimeSpan horaActual,
    DateTime nuevaFecha,
    TimeSpan nuevaHora)
        {
            string consulta = @"
        SELECT COUNT(*)
        FROM TB_CITA
        WHERE id_medico = @idMedico
          AND fecha_cita = @nuevaFecha
          AND hora_cita = @nuevaHora
          AND NOT (
              id_paciente = @idPaciente
              AND fecha_cita = @fechaActual
              AND hora_cita = @horaActual
          );";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente);
                    comando.Parameters.AddWithValue("@fechaActual", fechaActual);
                    comando.Parameters.AddWithValue("@horaActual", horaActual);
                    comando.Parameters.AddWithValue("@nuevaFecha", nuevaFecha);
                    comando.Parameters.AddWithValue("@nuevaHora", nuevaHora);

                    conexion.Open();

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    return cantidad == 0;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbPaciente.SelectedIndex = -1;
            cmbMedico.SelectedIndex = -1;
            cmbNuevaHora.SelectedIndex = -1;

            dtpNuevaFecha.Value = DateTime.Now;

            txtMotivo.Clear();

            lblEspecialidad.Text = "";
        }
    }
}
    

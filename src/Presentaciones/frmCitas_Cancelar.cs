using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmCitas_Cancelar : Form
    {
        private string cadenaConexion = @"Server=localhost;Database=BD_ReservasMedicas;Integrated Security=True;";
        private int idCita;

        public frmCitas_Cancelar()
        {
            InitializeComponent();

            CargarPacientes();
            CargarMedicos();
            CargarHorarios();
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

        private void cmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCitaActual();
        }

        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCitaActual();
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
          AND estado <> 'Cancelada'
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

        private void btnCancelarCita_Click(object sender, EventArgs e)
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

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Ingrese el motivo de la cancelación.");
                txtMotivo.Focus();
                return;
            }

            int idPaciente = Convert.ToInt32(cmbPaciente.SelectedValue);
            int idMedico = Convert.ToInt32(cmbMedico.SelectedValue);

            DateTime fechaCita = dtpFechaCita.Value.Date;
            TimeSpan horaCita = TimeSpan.Parse(cmbHorario.Text);

            string consulta = @"
        UPDATE TB_CITA
        SET estado = 'Cancelada',
            motivo_reprogramacion = @motivo
        WHERE id_paciente = @idPaciente
          AND id_medico = @idMedico
          AND fecha_cita = @fechaCita
          AND hora_cita = @horaCita
          AND estado <> 'Cancelada';";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@motivo", txtMotivo.Text);
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente);
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@fechaCita", fechaCita);
                    comando.Parameters.AddWithValue("@horaCita", horaCita);

                    conexion.Open();

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        MessageBox.Show("No se encontró una cita para cancelar.");
                        return;
                    }
                }
            }

            MessageBox.Show("Cita cancelada correctamente.");

            cmbPaciente.SelectedIndex = -1;
            cmbMedico.SelectedIndex = -1;
            cmbHorario.SelectedIndex = -1;

            dtpFechaCita.Value = DateTime.Now;

            txtMotivo.Clear();
        }
    }
}

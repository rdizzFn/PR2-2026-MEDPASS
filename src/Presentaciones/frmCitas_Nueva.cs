using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmCitas_Nueva : Form
    {
        private string cadenaConexion = @"Server=localhost;Database=BD_ReservasMedicas;Integrated Security=True;";

        public frmCitas_Nueva()
        {
            InitializeComponent();

            dtpFecha.MinDate = DateTime.Today;


            CargarPacientes();
            CargarMedicos();
            CargarPisos();

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

        private void CargarEspecialidad()
        {
            if (cmbMedico.SelectedIndex == -1 ||
                cmbMedico.SelectedValue == null)
            {
                cmbEspecialidad.Text = "";
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
                        Convert.ToInt32(cmbMedico.SelectedValue)
                    );

                    conexion.Open();

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        cmbEspecialidad.Text = resultado.ToString();
                    }
                }
            }
        }

        private void CargarHorarios()
        {
            cmbHora.Items.Clear();

            if (cmbMedico.SelectedIndex == -1 ||
                cmbMedico.SelectedValue == null)
            {
                return;
            }

            int idMedico = Convert.ToInt32(cmbMedico.SelectedValue);
            DateTime fecha = dtpFecha.Value.Date;

            string diaSemana;

            switch (fecha.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    diaSemana = "Lunes";
                    break;

                case DayOfWeek.Tuesday:
                    diaSemana = "Martes";
                    break;

                case DayOfWeek.Wednesday:
                    diaSemana = "Miércoles";
                    break;

                case DayOfWeek.Thursday:
                    diaSemana = "Jueves";
                    break;

                case DayOfWeek.Friday:
                    diaSemana = "Viernes";
                    break;

                default:
                    cmbHora.SelectedIndex = -1;
                    return;
            }

            string consulta = @"
        SELECT hora_inicio, hora_fin
        FROM TB_HORARIO_MEDICO
        WHERE id_medico = @idMedico
          AND dia_semana = @diaSemana;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@diaSemana", diaSemana);

                    conexion.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            TimeSpan horaInicio =
                                (TimeSpan)lector["hora_inicio"];

                            TimeSpan horaFin =
                                (TimeSpan)lector["hora_fin"];

                            TimeSpan horaActual = horaInicio;

                            while (horaActual < horaFin)
                            {
                                if (HorarioDisponible(idMedico, fecha, horaActual))
                                {
                                    cmbHora.Items.Add(
                                        horaActual.ToString(@"hh\:mm")
                                    );
                                }

                                horaActual = horaActual.Add(
                                    TimeSpan.FromMinutes(30)
                                );
                            }
                        }
                    }
                }
            }

            cmbHora.SelectedIndex = -1;
        }

        private void CargarPisos()
        {
            cmbPiso.Items.Clear();

            cmbPiso.Items.Add("Piso 1");
            cmbPiso.Items.Add("Piso 2");
            cmbPiso.Items.Add("Piso 3");

            cmbPiso.SelectedIndex = -1;
        }

        private bool HorarioDisponible(int idMedico, DateTime fecha, TimeSpan hora)
        {
            string consulta = @"
        SELECT COUNT(*)
        FROM TB_CITA
        WHERE id_medico = @idMedico
          AND fecha_cita = @fecha
          AND hora_cita = @hora
          AND estado <> 'Cancelada';";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@fecha", fecha);
                    comando.Parameters.AddWithValue("@hora", hora);

                    conexion.Open();

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    return cantidad == 0;
                }
            }
        }



        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEspecialidad();
            CargarHorarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

            if (cmbEspecialidad.Text == "")
            {
                MessageBox.Show("No se pudo obtener la especialidad del médico.");
                return;
            }

            if (cmbHora.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una hora.");
                cmbHora.Focus();
                return;
            }

            if (cmbPiso.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un piso.");
                cmbPiso.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Ingrese el motivo de la consulta.");
                txtMotivo.Focus();
                return;
            }

            int idPaciente = Convert.ToInt32(cmbPaciente.SelectedValue);
            int idMedico = Convert.ToInt32(cmbMedico.SelectedValue);

            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = TimeSpan.Parse(cmbHora.Text);

            if (!HorarioDisponible(idMedico, fecha, hora))
            {
                MessageBox.Show("El médico ya tiene una cita en ese horario.");
                cmbHora.Focus();
                return;
            }

            string consultaCita = @"
        INSERT INTO TB_CITA
        (
            estado,
            fecha_cita,
            hora_cita,
            piso,
            id_paciente,
            id_medico,
            motivo
        )
        VALUES
        (
            'Pendiente',
            @fecha,
            @hora,
            @piso,
            @idPaciente,
            @idMedico,
            @motivo
        );

        SELECT SCOPE_IDENTITY();";

            string consultaPago = @"
        INSERT INTO TB_PAGO
        (
            monto,
            moneda,
            metodo_pago,
            estado_pago,
            fecha_pago,
            id_cita,
            concepto
        )
        VALUES
        (
            @monto,
            'Bs',
            NULL,
            'Pendiente',
            NULL,
            @idCita,
            @concepto
        );";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    int idCita;

                    // 1. Registrar la cita
                    using (SqlCommand comandoCita = new SqlCommand(
                        consultaCita, conexion, transaccion))
                    {
                        comandoCita.Parameters.AddWithValue("@fecha", fecha);
                        comandoCita.Parameters.AddWithValue("@hora", hora);
                        comandoCita.Parameters.AddWithValue("@piso", cmbPiso.Text);
                        comandoCita.Parameters.AddWithValue("@idPaciente", idPaciente);
                        comandoCita.Parameters.AddWithValue("@idMedico", idMedico);
                        comandoCita.Parameters.AddWithValue("@motivo", txtMotivo.Text);

                        idCita = Convert.ToInt32(comandoCita.ExecuteScalar());
                    }

                    // 2. Crear automáticamente el pago pendiente
                    using (SqlCommand comandoPago = new SqlCommand(
                        consultaPago, conexion, transaccion))
                    {
                        comandoPago.Parameters.AddWithValue("@monto", 150.00m);
                        comandoPago.Parameters.AddWithValue("@idCita", idCita);
                        comandoPago.Parameters.AddWithValue(
                            "@concepto",
                            "Consulta médica"
                        );

                        comandoPago.ExecuteNonQuery();
                    }

                    // 3. Confirmar ambos registros
                    transaccion.Commit();

                    MessageBox.Show(
                        "Cita registrada correctamente.\n" +
                        "Se generó el pago pendiente."
                    );

                    cmbPaciente.SelectedIndex = -1;
                    cmbMedico.SelectedIndex = -1;
                    cmbEspecialidad.Text = "";
                    cmbHora.SelectedIndex = -1;
                    cmbPiso.SelectedIndex = -1;
                    txtMotivo.Clear();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();

                    MessageBox.Show(
                        "No se pudo registrar la cita y el pago.\n\n" +
                        "Error: " + ex.Message
                    );
                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarHorarios();
        }
    }

}
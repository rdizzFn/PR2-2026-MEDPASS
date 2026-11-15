
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using DiseñoReservasMedicas;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmCitas_AñadirInformacion : Form
    {
        private readonly int idPaciente;

        private readonly string cadenaConexion =
            "Server=localhost;Database=BD_ReservasMedicas;Integrated Security=True;";

        public frmCitas_AñadirInformacion(int idPaciente)
        {
            InitializeComponent();

            this.idPaciente = idPaciente;

            txtImc.ReadOnly = true;

            btnGuardar.Click += btnGuardar_Click;
            txtPeso.TextChanged += CalcularImc;
            txtEstatura.TextChanged += CalcularImc;

            CargarInformacionPaciente();
        }

        private void CargarInformacionPaciente()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consultaPaciente = @"
                        SELECT nombre, apellido
                        FROM TB_PACIENTE
                        WHERE id_paciente = @idPaciente";

                    using (SqlCommand comando = new SqlCommand(consultaPaciente, conexion))
                    {
                        comando.Parameters.Add("@idPaciente", SqlDbType.Int).Value = idPaciente;

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (!lector.Read())
                            {
                                MessageBox.Show(
                                    "No se encontró el paciente seleccionado.",
                                    "Paciente no encontrado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                Close();
                                return;
                            }

                            string nombrePaciente =
                                lector["nombre"].ToString() + " " +
                                lector["apellido"].ToString();

                            lblPacienteSeleccionado.Text =
                                "Paciente: " + nombrePaciente +
                                " | ID: " + idPaciente;
                        }
                    }

                    string consultaHistorial = @"
                        SELECT TOP 1
                            estatura,
                            peso,
                            presion_arterial,
                            imc,
                            grupo_sanguineo
                        FROM TB_HISTORIALCLINICO
                        WHERE id_paciente = @idPaciente
                        ORDER BY fecha_actualizacion DESC, id_historial DESC";

                    using (SqlCommand comando = new SqlCommand(consultaHistorial, conexion))
                    {
                        comando.Parameters.Add("@idPaciente", SqlDbType.Int).Value = idPaciente;

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                txtEstatura.Text = ValorTexto(lector, "estatura");
                                txtPeso.Text = ValorTexto(lector, "peso");
                                txtPresionArterial.Text = ValorTexto(lector, "presion_arterial");
                                txtImc.Text = ValorTexto(lector, "imc");
                                txtGrupoSanguineo.Text = ValorTexto(lector, "grupo_sanguineo");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la información del paciente.\n\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string ValorTexto(SqlDataReader lector, string columna)
        {
            if (lector[columna] == DBNull.Value)
                return "";

            return Convert.ToString(lector[columna], CultureInfo.CurrentCulture);
        }

        private void CalcularImc(object sender, EventArgs e)
        {
            decimal peso;
            decimal estatura;

            if (IntentarDecimal(txtPeso.Text, out peso) &&
                IntentarDecimal(txtEstatura.Text, out estatura) &&
                peso > 0 && estatura > 0)
            {
                decimal imc = peso / (estatura * estatura);

                txtImc.Text = imc.ToString("0.00", CultureInfo.CurrentCulture);
            }
            else
            {
                txtImc.Clear();
            }
        }

        private bool IntentarDecimal(string texto, out decimal valor)
        {
            return decimal.TryParse(
                       texto,
                       NumberStyles.Number,
                       CultureInfo.CurrentCulture,
                       out valor)
                   || decimal.TryParse(
                       texto,
                       NumberStyles.Number,
                       CultureInfo.InvariantCulture,
                       out valor);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal peso;
            decimal estatura;

            decimal? pesoGuardar = null;
            decimal? estaturaGuardar = null;
            decimal? imcGuardar = null;

            if (!string.IsNullOrWhiteSpace(txtPeso.Text))
            {
                if (!IntentarDecimal(txtPeso.Text, out peso) || peso <= 0)
                {
                    MessageBox.Show(
                        "Introduce un peso válido en kilogramos.",
                        "Dato incorrecto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPeso.Focus();
                    return;
                }

                pesoGuardar = peso;
            }

            if (!string.IsNullOrWhiteSpace(txtEstatura.Text))
            {
                if (!IntentarDecimal(txtEstatura.Text, out estatura) || estatura <= 0)
                {
                    MessageBox.Show(
                        "Introduce una estatura válida en metros, por ejemplo 1,70.",
                        "Dato incorrecto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtEstatura.Focus();
                    return;
                }

                estaturaGuardar = estatura;
            }

            if (pesoGuardar.HasValue && estaturaGuardar.HasValue)
            {
                decimal imc = pesoGuardar.Value /
                              (estaturaGuardar.Value * estaturaGuardar.Value);

                imcGuardar = Math.Round(imc, 2);

                txtImc.Text = imcGuardar.Value.ToString(
                    "0.00", CultureInfo.CurrentCulture);
            }
            else
            {
                txtImc.Clear();
            }

            string presion = txtPresionArterial.Text.Trim();
            string grupoSanguineo = txtGrupoSanguineo.Text.Trim();

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = @"
                        IF EXISTS (
                            SELECT 1
                            FROM TB_HISTORIALCLINICO
                            WHERE id_paciente = @idPaciente
                        )
                        BEGIN
                            UPDATE TB_HISTORIALCLINICO
                            SET estatura = @estatura,
                                peso = @peso,
                                presion_arterial = @presion,
                                imc = @imc,
                                grupo_sanguineo = @grupo,
                                fecha_actualizacion = @fecha
                            WHERE id_paciente = @idPaciente;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO TB_HISTORIALCLINICO
                            (
                                id_paciente,
                                estatura,
                                peso,
                                presion_arterial,
                                imc,
                                grupo_sanguineo,
                                fecha_actualizacion
                            )
                            VALUES
                            (
                                @idPaciente,
                                @estatura,
                                @peso,
                                @presion,
                                @imc,
                                @grupo,
                                @fecha
                            );
                        END";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.Add("@idPaciente", SqlDbType.Int).Value = idPaciente;

                        comando.Parameters.Add("@estatura", SqlDbType.Decimal).Value =
                            (object)estaturaGuardar ?? DBNull.Value;
                        comando.Parameters["@estatura"].Precision = 5;
                        comando.Parameters["@estatura"].Scale = 2;

                        comando.Parameters.Add("@peso", SqlDbType.Decimal).Value =
                            (object)pesoGuardar ?? DBNull.Value;
                        comando.Parameters["@peso"].Precision = 5;
                        comando.Parameters["@peso"].Scale = 2;

                        comando.Parameters.Add("@presion", SqlDbType.VarChar, 20).Value =
                            string.IsNullOrWhiteSpace(presion)
                                ? (object)DBNull.Value
                                : presion;

                        comando.Parameters.Add("@imc", SqlDbType.Decimal).Value =
                            (object)imcGuardar ?? DBNull.Value;
                        comando.Parameters["@imc"].Precision = 5;
                        comando.Parameters["@imc"].Scale = 2;

                        comando.Parameters.Add("@grupo", SqlDbType.VarChar, 10).Value =
                            string.IsNullOrWhiteSpace(grupoSanguineo)
                                ? (object)DBNull.Value
                                : grupoSanguineo;

                        comando.Parameters.Add("@fecha", SqlDbType.Date).Value =
                            DateTime.Today;

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "La información del paciente se guardó correctamente.",
                    "Guardado exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "No se pudo guardar la información en la base de datos.\n\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
        }
    }
}

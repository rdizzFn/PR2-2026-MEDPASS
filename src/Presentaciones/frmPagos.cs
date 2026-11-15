using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmPagos : Form
    {
        private string cadenaConexion =
            @"Server=localhost;Database=BD_ReservasMedicas;Integrated Security=True;";

        public frmPagos()
        {
            InitializeComponent();

            CargarPagosPendientes();
            CargarPacientesPendientes();

            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta");
            cmbMetodoPago.Items.Add("QR");
            cmbMetodoPago.Items.Add("Transferencia");

            cmbMetodoPago.SelectedIndex = -1;
        }

        private void CargarPagosPendientes(string buscar = "")
        {
            string consulta = @"
                SELECT
                    p.id_pago,
                    pa.nombre + ' ' + pa.apellido AS paciente,
                    p.concepto,
                    c.fecha_cita,
                    p.monto,
                    p.moneda,
                    m.nombre + ' ' + m.apellido AS medico
                FROM TB_PAGO AS p
                INNER JOIN TB_CITA AS c
                    ON p.id_cita = c.id_cita
                INNER JOIN TB_PACIENTE AS pa
                    ON c.id_paciente = pa.id_paciente
                INNER JOIN TB_MEDICO AS m
                    ON c.id_medico = m.id_medico
                WHERE p.estado_pago = 'Pendiente'
                  AND (pa.nombre + ' ' + pa.apellido) LIKE @buscar
                ORDER BY c.fecha_cita;";

            using (SqlConnection conexion =
                new SqlConnection(cadenaConexion))
            {
                using (SqlDataAdapter adaptador =
                    new SqlDataAdapter(consulta, conexion))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue(
                        "@buscar",
                        "%" + buscar + "%"
                    );

                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    dgvPagosPendientes.DataSource = tabla;
                }
            }
        }

        private void txtBuscarPaciente_TextChanged(object sender, EventArgs e)
        {
            CargarPagosPendientes(txtBuscarPaciente.Text.Trim());
        }

        private void CargarPacientesPendientes()
        {
            string consulta = @"
        SELECT DISTINCT
            pa.id_paciente,
            pa.nombre + ' ' + pa.apellido AS paciente
        FROM TB_PAGO AS p
        INNER JOIN TB_CITA AS c
            ON p.id_cita = c.id_cita
        INNER JOIN TB_PACIENTE AS pa
            ON c.id_paciente = pa.id_paciente
        WHERE p.estado_pago = 'Pendiente'
        ORDER BY paciente;";

            using (SqlConnection conexion =
                new SqlConnection(cadenaConexion))
            {
                using (SqlDataAdapter adaptador =
                    new SqlDataAdapter(consulta, conexion))
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

        private void cmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaciente.SelectedIndex == -1)
                return;

            if (cmbPaciente.SelectedValue == null)
                return;

            if (cmbPaciente.SelectedValue is DataRowView)
                return;

            int idPaciente;

            if (!int.TryParse(cmbPaciente.SelectedValue.ToString(), out idPaciente))
                return;

            string consulta = @"
                SELECT TOP 1
                    p.id_pago,
                    p.concepto,
                    p.monto
                FROM TB_PAGO AS p
                INNER JOIN TB_CITA AS c
                    ON p.id_cita = c.id_cita
                WHERE c.id_paciente = @idPaciente
                  AND p.estado_pago = 'Pendiente'
                ORDER BY c.fecha_cita;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@idPaciente", SqlDbType.Int).Value = idPaciente;

                    conexion.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            cmbConcepto.Items.Clear();

                            cmbConcepto.Items.Add(
                                lector["concepto"].ToString()
                            );

                            cmbConcepto.SelectedIndex = 0;

                            txtMonto.Text = lector["monto"].ToString();
                        }
                        else
                        {
                            cmbConcepto.Items.Clear();
                            txtMonto.Clear();
                        }
                    }
                }
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (cmbPaciente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un paciente.");
                return;
            }

            if (cmbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un método de pago.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("El monto no está disponible.");
                return;
            }

            int idPaciente = Convert.ToInt32(cmbPaciente.SelectedValue);

            string consulta = @"
        UPDATE TB_PAGO
        SET
            estado_pago = 'Pagado',
            fecha_pago = GETDATE(),
            metodo_pago = @metodoPago,
            moneda = 'Bs'
        WHERE id_pago = (
            SELECT TOP 1 p.id_pago
            FROM TB_PAGO AS p
            INNER JOIN TB_CITA AS c
                ON p.id_cita = c.id_cita
            WHERE c.id_paciente = @idPaciente
              AND p.estado_pago = 'Pendiente'
            ORDER BY c.fecha_cita
        );";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@idPaciente", SqlDbType.Int).Value = idPaciente;

                    comando.Parameters.Add("@metodoPago", SqlDbType.VarChar, 50).Value =
                        cmbMetodoPago.SelectedItem.ToString();

                    conexion.Open();

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show(
                            "Pago registrado correctamente.",
                            "Pago",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        CargarPagosPendientes();
                        CargarPacientesPendientes();

                        cmbPaciente.SelectedIndex = -1;
                        cmbConcepto.Items.Clear();
                        txtMonto.Clear();
                        cmbMetodoPago.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un pago pendiente.");
                    }
                }
            }
        }
    }
}
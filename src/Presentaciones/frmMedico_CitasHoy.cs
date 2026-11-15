using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmMedico_CitasHoy : Form
    {
        private frmMedico formularioPrincipal;
        private int idMedico;

        public frmMedico_CitasHoy(frmMedico formularioPrincipal)
        {
            InitializeComponent();

            this.formularioPrincipal = formularioPrincipal;

            ConexionBD conexionBD = new ConexionBD();

            idMedico = conexionBD.ObtenerIdMedico(
                formularioPrincipal.IdUsuario);

            lblFecha.Text = DateTime.Today.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy");

            CargarCitasHoy();
        }

        private void CargarCitasHoy()
        {
            ConexionBD conexionBD = new ConexionBD();

            DataTable tabla =
                conexionBD.ObtenerCitasHoyMedico(idMedico);

            int totalCitas = tabla.Rows.Count;
            int pendientes = 0;
            int atendidas = 0;

            foreach (DataRow fila in tabla.Rows)
            {
                string estado = fila["estado"].ToString();

                if (estado.Equals(
                    "Pendiente",
                    StringComparison.OrdinalIgnoreCase))
                {
                    pendientes++;
                }
                else if (estado.Equals(
                    "Atendida",
                    StringComparison.OrdinalIgnoreCase))
                {
                    atendidas++;
                }
            }

            lblTotalCitas.Text = totalCitas.ToString();
            lblTotalPendientes.Text = pendientes.ToString();
            lblTotalAtendidas.Text = atendidas.ToString();

            MostrarCita(
                tabla, 0,
                lblHora1, lblNombre1, lblConsulta1,
                lblPiso1, lblEstado1);

            MostrarCita(
                tabla, 1,
                lblHora2, lblNombre2, lblConsulta2,
                lblPiso2, lblEstado2);

            MostrarCita(
                tabla, 2,
                lblHora3, lblNombre3, lblConsulta3,
                lblPiso3, lblEstado3);
        }

        private void MostrarCita(
            DataTable tabla,
            int indice,
            Guna.UI2.WinForms.Guna2HtmlLabel lblHora,
            Guna.UI2.WinForms.Guna2HtmlLabel lblNombre,
            Guna.UI2.WinForms.Guna2HtmlLabel lblConsulta,
            Guna.UI2.WinForms.Guna2HtmlLabel lblPiso,
            Guna.UI2.WinForms.Guna2HtmlLabel lblEstado)
        {
            if (indice >= tabla.Rows.Count)
            {
                lblHora.Text = "--:--";
                lblNombre.Text = "Sin citas";
                lblConsulta.Text = "";
                lblPiso.Text = "";
                lblEstado.Text = "";

                return;
            }

            DataRow fila = tabla.Rows[indice];

            lblHora.Text = Convert.ToDateTime(
                fila["hora_cita"].ToString()).ToString("HH:mm");

            lblNombre.Text = fila["paciente"].ToString();
            lblConsulta.Text = fila["motivo"].ToString();
            lblPiso.Text = fila["piso"].ToString();

            string estado = fila["estado"].ToString();

            lblEstado.Text = estado;

            // Color según el estado de la cita.
            if (estado.Equals(
                "Atendida",
                StringComparison.OrdinalIgnoreCase))
            {
                lblEstado.ForeColor = Color.Green;
            }
            else if (estado.Equals(
                "Pendiente",
                StringComparison.OrdinalIgnoreCase))
            {
                lblEstado.ForeColor = Color.DarkOrange;
            }
            else if (estado.Equals(
                "Confirmada",
                StringComparison.OrdinalIgnoreCase))
            {
                lblEstado.ForeColor = Color.RoyalBlue;
            }
            else
            {
                lblEstado.ForeColor = Color.DimGray;
            }
        }
    }
}


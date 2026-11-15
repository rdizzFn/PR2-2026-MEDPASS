
using System;
using System.Data;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmMedico_ProximasCitas : Form
    {
        private int idUsuario;
        private int idMedico;
        private DateTime inicioSemana;
        private bool actualizandoCheckBox = false;

        private ConexionBD conexionBD = new ConexionBD();

        public frmMedico_ProximasCitas(int idUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            idMedico = conexionBD.ObtenerIdMedico(idUsuario);

            inicioSemana = ObtenerLunes(DateTime.Today);

            btnSemanaAnterior.Click += btnSemanaAnterior_Click;
            btnSemanaSiguiente.Click += btnSemanaSiguiente_Click;

            ActualizarEtiquetaSemana();

            OcultarCitas();

            btnVerCita1.Click += VerCita_Click;
            btnVerCita2.Click += VerCita_Click;
            btnVerCita3.Click += VerCita_Click;
            btnVerCita4.Click += VerCita_Click;

            chkAtendida1.CheckedChanged += chkAtendida_CheckedChanged;
            chkAtendida2.CheckedChanged += chkAtendida_CheckedChanged;
            chkAtendida3.CheckedChanged += chkAtendida_CheckedChanged;
            chkAtendida4.CheckedChanged += chkAtendida_CheckedChanged;
        }

        private DateTime ObtenerLunes(DateTime fecha)
        {
            int diferencia = ((int)fecha.DayOfWeek + 6) % 7;
            return fecha.Date.AddDays(-diferencia);
        }

        private void ActualizarEtiquetaSemana()
        {
            DateTime finSemana = inicioSemana.AddDays(6);

            lblSemanaActual.Text =
                "Semana del " +
                inicioSemana.ToString("dd/MM/yyyy") +
                " al " +
                finSemana.ToString("dd/MM/yyyy");
        }

        private void btnSemanaAnterior_Click(object sender, EventArgs e)
        {
            inicioSemana = inicioSemana.AddDays(-7);

            ActualizarEtiquetaSemana();
            OcultarCitas();
        }

        private void btnSemanaSiguiente_Click(object sender, EventArgs e)
        {
            inicioSemana = inicioSemana.AddDays(7);

            ActualizarEtiquetaSemana();
            OcultarCitas();
        }

        private void OcultarCitas()
        {
            pnlCita1.Visible = false;
            pnlCita2.Visible = false;
            pnlCita3.Visible = false;
            pnlCita4.Visible = false;
        }

        private DateTime ObtenerFechaDeLaSemana(DayOfWeek dia)
        {
            int diferencia = ((int)dia + 6) % 7;

            return inicioSemana.AddDays(diferencia);
        }

        private void CargarCitasPorFecha(DateTime fecha)
        {
            DataTable citas =
                conexionBD.ObtenerCitasMedicoPorFecha(idMedico, fecha);

            OcultarCitas();

            for (int i = 0; i < citas.Rows.Count && i < 4; i++)
            {
                DataRow cita = citas.Rows[i];

                switch (i)
                {
                    case 0:
                        MostrarCita(
                            pnlCita1, lblHoraCita1, lblFechaCita1,
                            lblPacienteCita1, lblEspecialidadCita1,
                            btnVerCita1, chkAtendida1, cita);
                        break;

                    case 1:
                        MostrarCita(
                            pnlCita2, lblHoraCita2, lblFechaCita2,
                            lblPacienteCita2, lblEspecialidadCita2,
                            btnVerCita2, chkAtendida2, cita);
                        break;

                    case 2:
                        MostrarCita(
                            pnlCita3, lblHoraCita3, lblFechaCita3,
                            lblPacienteCita3, lblEspecialidadCita3,
                            btnVerCita3, chkAtendida3, cita);
                        break;

                    case 3:
                        MostrarCita(
                            pnlCita4, lblHoraCita4, lblFechaCita4,
                            lblPacienteCita4, lblEspecialidadCita4,
                            btnVerCita4, chkAtendida4, cita);
                        break;
                }
            }
        }

        private void MostrarCita(
            Guna.UI2.WinForms.Guna2Panel panel,
            Guna.UI2.WinForms.Guna2HtmlLabel lblHora,
            Guna.UI2.WinForms.Guna2HtmlLabel lblFecha,
            Guna.UI2.WinForms.Guna2HtmlLabel lblPaciente,
            Guna.UI2.WinForms.Guna2HtmlLabel lblEspecialidad,
            Guna.UI2.WinForms.Guna2Button btnVerCita,
            Guna.UI2.WinForms.Guna2CustomCheckBox chkAtendida,
            DataRow cita)
        {
            TimeSpan hora = (TimeSpan)cita["hora_cita"];

            DateTime fecha =
                Convert.ToDateTime(cita["fecha_cita"]).Date;

            lblHora.Text = hora.ToString(@"hh\:mm");

            lblFecha.Text = fecha.ToString(
                "dddd dd 'de' MMMM",
                new System.Globalization.CultureInfo("es-ES"));

            lblPaciente.Text = cita["paciente"].ToString();
            lblEspecialidad.Text = cita["especialidad"].ToString();

            int idCita = Convert.ToInt32(cita["id_cita"]);
            string estado = cita["estado"].ToString();

            btnVerCita.Tag = idCita;
            chkAtendida.Tag = idCita;

            DateTime fechaHoraCita = fecha.Add(hora);

            bool citaYaPaso = fechaHoraCita < DateTime.Now;

            bool estadoValido =
                estado == "Pendiente" ||
                estado == "Confirmada" ||
                estado == "Atendida";

            actualizandoCheckBox = true;

            chkAtendida.Checked = estado == "Atendida";

            chkAtendida.Visible = citaYaPaso && estadoValido;

         
            chkAtendida.Enabled =
                citaYaPaso &&
                (estado == "Pendiente" || estado == "Confirmada");

            actualizandoCheckBox = false;

            panel.Visible = true;
        }

        private void chkAtendida_CheckedChanged(object sender, EventArgs e)
        {
            if (actualizandoCheckBox)
                return;

            Guna.UI2.WinForms.Guna2CustomCheckBox chk =
                (Guna.UI2.WinForms.Guna2CustomCheckBox)sender;

            if (!chk.Checked)
                return;

            int idCita = Convert.ToInt32(chk.Tag);

            DateTime fechaHoraCita = ObtenerFechaHoraCita(idCita);

            if (fechaHoraCita >= DateTime.Now)
            {
                MessageBox.Show(
                    "Solo puedes marcar como atendidas las citas que ya pasaron.",
                    "Cita no finalizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                actualizandoCheckBox = true;
                chk.Checked = false;
                actualizandoCheckBox = false;

                return;
            }

            if (conexionBD.MarcarCitaAtendida(idCita))
            {
                chk.Enabled = false;

                MessageBox.Show(
                    "La cita se ha marcado como atendida correctamente.",
                    "Estado actualizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                actualizandoCheckBox = true;
                chk.Checked = false;
                actualizandoCheckBox = false;

                MessageBox.Show(
                    "No se pudo actualizar la cita. Comprueba su estado en la base de datos.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private DateTime ObtenerFechaHoraCita(int idCita)
        {
            DataTable tabla = conexionBD.ObtenerCitaPorId(idCita);

            if (tabla.Rows.Count == 0)
                return DateTime.MaxValue;

            DataRow fila = tabla.Rows[0];

            DateTime fecha =
                Convert.ToDateTime(fila["fecha_cita"]).Date;

            TimeSpan hora = (TimeSpan)fila["hora_cita"];

            return fecha.Add(hora);
        }

        private void btnLunes_Click(object sender, EventArgs e)
        {
            CargarCitasPorFecha(
                ObtenerFechaDeLaSemana(DayOfWeek.Monday));
        }

        private void btnMartes_Click(object sender, EventArgs e)
        {
            CargarCitasPorFecha(
                ObtenerFechaDeLaSemana(DayOfWeek.Tuesday));
        }

        private void btnMiercoles_Click(object sender, EventArgs e)
        {
            CargarCitasPorFecha(
                ObtenerFechaDeLaSemana(DayOfWeek.Wednesday));
        }

        private void btnJueves_Click(object sender, EventArgs e)
        {
            CargarCitasPorFecha(
                ObtenerFechaDeLaSemana(DayOfWeek.Thursday));
        }

        private void btnViernes_Click(object sender, EventArgs e)
        {
            CargarCitasPorFecha(
                ObtenerFechaDeLaSemana(DayOfWeek.Friday));
        }

        private void VerCita_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button boton =
                (Guna.UI2.WinForms.Guna2Button)sender;

            int idCita = Convert.ToInt32(boton.Tag);

            DataTable cita = conexionBD.ObtenerCitaPorId(idCita);

            if (cita.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la cita.");
                return;
            }

            DataRow fila = cita.Rows[0];

            TimeSpan hora = (TimeSpan)fila["hora_cita"];

            string informacion =
                "DETALLE DE LA CITA\n\n" +
                "Paciente: " + fila["paciente"] + "\n" +
                "Fecha: " +
                Convert.ToDateTime(fila["fecha_cita"])
                    .ToString("dd/MM/yyyy") + "\n" +
                "Hora: " + hora.ToString(@"hh\:mm") + "\n" +
                "Especialidad: " + fila["especialidad"] + "\n" +
                "Piso: " + fila["piso"] + "\n" +
                "Estado: " + fila["estado"];

            MessageBox.Show(informacion, "Detalle de la Cita");
        }
    }
}
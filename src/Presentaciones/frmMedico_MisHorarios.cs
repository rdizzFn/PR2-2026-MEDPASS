using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmMedico_MisHorarios : Form
    {
        private ConexionBD conexion = new ConexionBD();
        private int idMedico;

        public frmMedico_MisHorarios(int idMedico)
        {
            InitializeComponent();

            this.idMedico = idMedico;

            CargarHoras();
            ActualizarEstadoHorarios();
            CargarHorariosGuardados();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox3_Click(object sender, EventArgs e)
        {
            ActualizarEstadoHorarios();
        }

        private void guna2Separator4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void CargarHoras()
        {
            ComboBox[] combosInicio =
            {
                cmbInicioLunes,
                cmbInicioMartes,
                cmbInicioMiercoles,
                cmbInicioJueves,
                cmbInicioViernes
            };

            ComboBox[] combosFin =
            {
                    cmbFinLunes,
                    cmbFinMartes,
                    cmbFinMiercoles,
                    cmbFinJueves,
                    cmbFinViernes
                };

            foreach (ComboBox combo in combosInicio)
            {
                combo.Items.Clear();

                for (int hora = 7; hora <= 19; hora++)
                {
                    combo.Items.Add($"{hora:00}:00");
                    combo.Items.Add($"{hora:00}:30");
                }
            }

            foreach (ComboBox combo in combosFin)
            {
                combo.Items.Clear();

                for (int hora = 7; hora <= 19; hora++)
                {
                    combo.Items.Add($"{hora:00}:00");
                    combo.Items.Add($"{hora:00}:30");
                }
            }
        }

        private void CargarHorariosGuardados()
        {
            DataTable horarios = conexion.ObtenerHorariosMedico(idMedico);

            foreach (DataRow fila in horarios.Rows)
            {
                string dia = fila["dia_semana"].ToString();
                string horaInicio = fila["hora_inicio"].ToString().Substring(0, 5);
                string horaFin = fila["hora_fin"].ToString().Substring(0, 5);

                switch (dia)
                {
                    case "Lunes":
                        chkLunes.Checked = true;
                        cmbInicioLunes.Text = horaInicio;
                        cmbFinLunes.Text = horaFin;
                        break;

                    case "Martes":
                        chkMartes.Checked = true;
                        cmbInicioMartes.Text = horaInicio;
                        cmbFinMartes.Text = horaFin;
                        break;

                    case "Miércoles":
                        chkMiercoles.Checked = true;
                        cmbInicioMiercoles.Text = horaInicio;
                        cmbFinMiercoles.Text = horaFin;
                        break;

                    case "Jueves":
                        chkJueves.Checked = true;
                        cmbInicioJueves.Text = horaInicio;
                        cmbFinJueves.Text = horaFin;
                        break;

                    case "Viernes":
                        chkViernes.Checked = true;
                        cmbInicioViernes.Text = horaInicio;
                        cmbFinViernes.Text = horaFin;
                        break;
                }
            }

            ActualizarEstadoHorarios();
        }

        private void ActualizarEstadoHorarios()
        {
            cmbInicioLunes.Enabled = chkLunes.Checked;
            cmbFinLunes.Enabled = chkLunes.Checked;

            cmbInicioMartes.Enabled = chkMartes.Checked;
            cmbFinMartes.Enabled = chkMartes.Checked;

            cmbInicioMiercoles.Enabled = chkMiercoles.Checked;
            cmbFinMiercoles.Enabled = chkMiercoles.Checked;

            cmbInicioJueves.Enabled = chkJueves.Checked;
            cmbFinJueves.Enabled = chkJueves.Checked;

            cmbInicioViernes.Enabled = chkViernes.Checked;
            cmbFinViernes.Enabled = chkViernes.Checked;
        }

        private void chkLunes_Click_1(object sender, EventArgs e)
        {
            ActualizarEstadoHorarios();
        }

        private void chkMartes_Click(object sender, EventArgs e)
        {
            ActualizarEstadoHorarios();
        }

        private void chkMiercoles_Click(object sender, EventArgs e)
        {
            ActualizarEstadoHorarios();
        }

        private void chkViernes_Click(object sender, EventArgs e)
        {
            ActualizarEstadoHorarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool eliminado = conexion.EliminarHorariosMedico(idMedico);

            if (!eliminado)
            {
                MessageBox.Show(
                    "No se pudieron actualizar los horarios.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (chkLunes.Checked)
            {
                conexion.GuardarHorarioMedico(
                    idMedico,
                    "Lunes",
                    cmbInicioLunes.Text,
                    cmbFinLunes.Text
                );
            }

            if (chkMartes.Checked)
            {
                conexion.GuardarHorarioMedico(
                    idMedico,
                    "Martes",
                    cmbInicioMartes.Text,
                    cmbFinMartes.Text
                );
            }

            if (chkMiercoles.Checked)
            {
                conexion.GuardarHorarioMedico(
                    idMedico,
                    "Miércoles",
                    cmbInicioMiercoles.Text,
                    cmbFinMiercoles.Text
                );
            }

            if (chkJueves.Checked)
            {
                conexion.GuardarHorarioMedico(
                    idMedico,
                    "Jueves",
                    cmbInicioJueves.Text,
                    cmbFinJueves.Text
                );
            }

            if (chkViernes.Checked)
            {
                conexion.GuardarHorarioMedico(
                    idMedico,
                    "Viernes",
                    cmbInicioViernes.Text,
                    cmbFinViernes.Text
                );
            }

            MessageBox.Show(
                "Horarios guardados correctamente.",
                "Horarios",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

    }
}


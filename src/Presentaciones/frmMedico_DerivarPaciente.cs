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
    public partial class frmMedico_DerivarPaciente : Form
    {
        private ConexionBD conexion = new ConexionBD();
        private int idMedico;

        public frmMedico_DerivarPaciente(int idMedico)
        {
            InitializeComponent();

            this.idMedico = idMedico;

            CargarPacientes();
            CargarEspecialidades();
        }

        private void CargarPacientes()
        {
            DataTable pacientes =
                conexion.ObtenerPacientesDisponiblesParaDerivar(idMedico);

            cmbPaciente.DataSource = pacientes;
            cmbPaciente.DisplayMember = "nombre";
            cmbPaciente.ValueMember = "id_paciente";

            cmbPaciente.SelectedIndex = -1;
        }

        private void CargarEspecialidades()
        {
            DataTable especialidades = conexion.ObtenerEspecialidades();

            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.DisplayMember = "nombre";
            cmbEspecialidad.ValueMember = "id_especialidad";

            cmbEspecialidad.SelectedIndex = -1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbPaciente.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione un paciente.",
                    "Derivación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (cmbEspecialidad.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione una especialidad.",
                    "Derivación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (cmbMedico.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione el médico de destino.",
                    "Derivación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show(
                    "Ingrese el motivo de la derivación.",
                    "Derivación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idPaciente = Convert.ToInt32(cmbPaciente.SelectedValue);
            int idMedicoDestino = Convert.ToInt32(cmbMedico.SelectedValue);

            DateTime fechaDerivacion = dtpFecha.Value;
            string motivo = txtMotivo.Text.Trim();

            bool registrado = conexion.RegistrarDerivacion(
                idPaciente,
                idMedico,
                idMedicoDestino,
                fechaDerivacion,
                motivo
            );

            if (registrado)
            {
                MessageBox.Show(
                    "La derivación se registró correctamente.",
                    "Derivación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtMotivo.Clear();
                cmbPaciente.SelectedIndex = -1;
                cmbMedico.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar la derivación.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarMedicosPorEspecialidad()
        {
            if (cmbEspecialidad.SelectedValue == null)
            {
                cmbMedico.DataSource = null;
                return;
            }

            int idEspecialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue);

            DataTable medicos =
                conexion.ObtenerMedicosPorEspecialidad(
                    idEspecialidad,
                    idMedico
                );

            cmbMedico.DataSource = medicos;
            cmbMedico.DisplayMember = "medico";
            cmbMedico.ValueMember = "id_medico";

            cmbMedico.SelectedIndex = -1;
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMedicosPorEspecialidad();
        }
    }
}

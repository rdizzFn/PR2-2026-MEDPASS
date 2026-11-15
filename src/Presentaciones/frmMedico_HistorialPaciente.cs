using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiseñoReservasMedicas;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmMedico_HistorialPaciente : Form
    {
        private int idPaciente;
        private ConexionBD conexion = new ConexionBD();
        private bool modificar;

        public frmMedico_HistorialPaciente(int idPaciente)
        {
            InitializeComponent();

            this.idPaciente = idPaciente;

            cmbGrupoSanguineo.Items.Add("A+");
            cmbGrupoSanguineo.Items.Add("A-");
            cmbGrupoSanguineo.Items.Add("B+");
            cmbGrupoSanguineo.Items.Add("B-");
            cmbGrupoSanguineo.Items.Add("AB+");
            cmbGrupoSanguineo.Items.Add("AB-");
            cmbGrupoSanguineo.Items.Add("O+");
            cmbGrupoSanguineo.Items.Add("O-");
        }

        public frmMedico_HistorialPaciente(int idPaciente, bool modificar)
        {
            InitializeComponent();

            this.idPaciente = idPaciente;
            this.modificar = modificar;

            cmbGrupoSanguineo.Items.Add("A+");
            cmbGrupoSanguineo.Items.Add("A-");
            cmbGrupoSanguineo.Items.Add("B+");
            cmbGrupoSanguineo.Items.Add("B-");
            cmbGrupoSanguineo.Items.Add("AB+");
            cmbGrupoSanguineo.Items.Add("AB-");
            cmbGrupoSanguineo.Items.Add("O+");
            cmbGrupoSanguineo.Items.Add("O-");

            if (modificar)
            {
                CargarHistorial();
            }
        }

        private void CargarHistorial()
        {
            DataTable historial = conexion.ObtenerHistorialClinico(idPaciente);

            if (historial.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró el historial clínico del paciente.",
                    "Historial clínico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataRow fila = historial.Rows[0];

            txtAntecedentes.Text = fila["antecedentes_medicos"].ToString();
            txtAntecedentesFamiliares.Text = fila["antecedentes_familiares"].ToString();
            txtAlergias.Text = fila["alergias"].ToString();
            txtEnfermedadesPrevias.Text = fila["enfermedades_previas"].ToString();
            txtCirugias.Text = fila["cirugias"].ToString();
            txtMedicacionHabitual.Text = fila["medicacion_habitual"].ToString();
            txtAntecedentesPersonales.Text = fila["antecedentes_personales"].ToString();
            cmbGrupoSanguineo.Text = fila["grupo_sanguineo"].ToString();
            txtDiscapacidad.Text = fila["discapacidad"].ToString();
            txtObservaciones.Text = fila["observaciones"].ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string grupoSanguineo = cmbGrupoSanguineo.Text;

            bool resultado;

            if (modificar)
            {
                resultado = conexion.ModificarHistorialClinico(
                    idPaciente,
                    txtAntecedentes.Text,
                    txtAntecedentesFamiliares.Text,
                    txtAlergias.Text,
                    txtEnfermedadesPrevias.Text,
                    txtCirugias.Text,
                    txtMedicacionHabitual.Text,
                    txtAntecedentesPersonales.Text,
                    grupoSanguineo,
                    txtDiscapacidad.Text,
                    txtObservaciones.Text
                );
            }
            else
            {
                resultado = conexion.RegistrarHistorialClinico(
                    idPaciente,
                    txtAntecedentes.Text,
                    txtAntecedentesFamiliares.Text,
                    txtAlergias.Text,
                    txtEnfermedadesPrevias.Text,
                    txtCirugias.Text,
                    txtMedicacionHabitual.Text,
                    txtAntecedentesPersonales.Text,
                    grupoSanguineo,
                    txtDiscapacidad.Text,
                    txtObservaciones.Text
                );
            }

            if (resultado)
            {
                MessageBox.Show(
                    modificar
                        ? "Historial clínico modificado correctamente."
                        : "Historial clínico registrado correctamente.",
                    modificar
                        ? "Modificación exitosa"
                        : "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    modificar
                        ? "No se pudo modificar el historial clínico."
                        : "No se pudo registrar el historial clínico.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
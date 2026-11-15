using System;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmCitas_AñadirPaciente : Form
    {
        public frmCitas_AñadirPaciente()
        {
            InitializeComponent();

            CargarProvincias();
        }

        private void CargarProvincias()
        {
            cmbProvinciaNacimiento.Items.Clear();

            cmbProvinciaNacimiento.Items.Add("La Paz");
            cmbProvinciaNacimiento.Items.Add("Cochabamba");
            cmbProvinciaNacimiento.Items.Add("Santa Cruz");
            cmbProvinciaNacimiento.Items.Add("Oruro");
            cmbProvinciaNacimiento.Items.Add("Potosí");
            cmbProvinciaNacimiento.Items.Add("Chuquisaca");
            cmbProvinciaNacimiento.Items.Add("Tarija");
            cmbProvinciaNacimiento.Items.Add("Beni");
            cmbProvinciaNacimiento.Items.Add("Pando");

            cmbProvinciaNacimiento.SelectedIndex = -1;
        }

        private void cmbProvinciaNacimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCiudadNacimiento.Items.Clear();

            if (cmbProvinciaNacimiento.SelectedItem == null)
                return;

            string provincia = cmbProvinciaNacimiento.SelectedItem.ToString();

            if (provincia == "La Paz")
            {
                cmbCiudadNacimiento.Items.Add("La Paz");
                cmbCiudadNacimiento.Items.Add("El Alto");
                cmbCiudadNacimiento.Items.Add("Copacabana");
            }
            else if (provincia == "Cochabamba")
            {
                cmbCiudadNacimiento.Items.Add("Cochabamba");
                cmbCiudadNacimiento.Items.Add("Quillacollo");
                cmbCiudadNacimiento.Items.Add("Sacaba");
                cmbCiudadNacimiento.Items.Add("Tiquipaya");
                cmbCiudadNacimiento.Items.Add("Colcapirhua");
            }
            else if (provincia == "Santa Cruz")
            {
                cmbCiudadNacimiento.Items.Add("Santa Cruz de la Sierra");
                cmbCiudadNacimiento.Items.Add("Montero");
                cmbCiudadNacimiento.Items.Add("Warnes");
            }
            else if (provincia == "Oruro")
            {
                cmbCiudadNacimiento.Items.Add("Oruro");
                cmbCiudadNacimiento.Items.Add("Huanuni");
                cmbCiudadNacimiento.Items.Add("Challapata");
            }
            else if (provincia == "Potosí")
            {
                cmbCiudadNacimiento.Items.Add("Potosí");
                cmbCiudadNacimiento.Items.Add("Uyuni");
                cmbCiudadNacimiento.Items.Add("Villazón");
            }
            else if (provincia == "Chuquisaca")
            {
                cmbCiudadNacimiento.Items.Add("Sucre");
                cmbCiudadNacimiento.Items.Add("Monteagudo");
                cmbCiudadNacimiento.Items.Add("Padilla");
            }
            else if (provincia == "Tarija")
            {
                cmbCiudadNacimiento.Items.Add("Tarija");
                cmbCiudadNacimiento.Items.Add("Yacuiba");
                cmbCiudadNacimiento.Items.Add("Bermejo");
            }
            else if (provincia == "Beni")
            {
                cmbCiudadNacimiento.Items.Add("Trinidad");
                cmbCiudadNacimiento.Items.Add("Riberalta");
                cmbCiudadNacimiento.Items.Add("Guayaramerín");
            }
            else if (provincia == "Pando")
            {
                cmbCiudadNacimiento.Items.Add("Cobija");
                cmbCiudadNacimiento.Items.Add("Porvenir");
                cmbCiudadNacimiento.Items.Add("Bolpebra");
            }

            cmbCiudadNacimiento.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del paciente.");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Ingrese el apellido del paciente.");
                txtApellido.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono del paciente.");
                txtTelefono.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCI.Text))
            {
                MessageBox.Show("Ingrese el CI del paciente.");
                txtCI.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el género del paciente.");
                comboBox1.Focus();
                return;
            }

            if (cmbProvinciaNacimiento.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la provincia de nacimiento.");
                cmbProvinciaNacimiento.Focus();
                return;
            }

            if (cmbCiudadNacimiento.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la ciudad de nacimiento.");
                cmbCiudadNacimiento.Focus();
                return;
            }

            DateTime fechaNacimiento;

            if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            {
                MessageBox.Show(
                    "Ingrese una fecha de nacimiento válida. Ejemplo: 14/05/2002."
                );

                txtFechaNacimiento.Focus();
                return;
            }

            ConexionBD conexionBD = new ConexionBD();

            conexionBD.AgregarPaciente(
                txtNombre.Text,
                txtApellido.Text,
                txtTelefono.Text,
                fechaNacimiento,
                txtCI.Text,
                comboBox1.Text,
                cmbProvinciaNacimiento.Text,
                cmbCiudadNacimiento.Text

            );

            MessageBox.Show("Paciente registrado correctamente.");

            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtFechaNacimiento.Clear();
            txtCI.Clear();

            comboBox1.SelectedIndex = -1;
            cmbProvinciaNacimiento.SelectedIndex = -1;
            cmbCiudadNacimiento.Items.Clear();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
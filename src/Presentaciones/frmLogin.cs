using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmLogin : Form
    {
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        
        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(
            IntPtr hWnd,
            IntPtr hRgn,
            bool bRedraw
        );

        public frmLogin()
        {
            InitializeComponent();

           
            this.FormBorderStyle = FormBorderStyle.None;

            
            IntPtr region = CreateRoundRectRgn(
                0,
                0,
                this.Width,
                this.Height,
                20,
                20
            );

            SetWindowRgn(this.Handle, region, true);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtClave.Text;

            ConexionBD conexionBD = new ConexionBD();

            string rol = conexionBD.ObtenerRolUsuario(usuario, contraseña);
            int idUsuario = conexionBD.ObtenerIdUsuario(usuario, contraseña);

            if (rol != null)
            {
                MessageBox.Show(
                    "Bienvenido " + usuario + "\nRol: " + rol,
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (rol == "Médico")
                {
                    frmMedico medico = new frmMedico(idUsuario);
                    medico.Show();
                    this.Hide();
                }
                else if (rol == "Recepcionista")
                {
                    frmPrincipal principal = new frmPrincipal();
                    principal.Show();
                    this.Hide();
                }
                else if (rol == "Administrador")
                {
                    frmAdmin admin = new frmAdmin();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
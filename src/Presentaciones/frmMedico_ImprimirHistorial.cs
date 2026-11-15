using System;
using System.Data;
using System.Windows.Forms;

namespace DiseñoReservasMedicas.Presentaciones
{
    public partial class frmMedico_ImprimirHistorial : Form
    {
        private int idPaciente;
        private ConexionBD conexion = new ConexionBD();

        private int indiceConsulta = 0;

        private bool primeraPagina = true;
        private int paginaActual = 0;

        public frmMedico_ImprimirHistorial(int idPaciente)
        {
            InitializeComponent();

            this.idPaciente = idPaciente;

            printPreviewControl1.Document = printDocument1;

            CargarDatos();
        }

        private DataTable datosHistorial;

        private void CargarDatos()
        {
            datosHistorial =
                conexion.ObtenerHistorialCompletoPaciente(idPaciente);

            if (datosHistorial.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontraron datos del paciente.",
                    "Historial clínico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private float DibujarTexto(
    System.Drawing.Graphics grafico,
    string texto,
    System.Drawing.Font fuente,
    System.Drawing.Brush pincel,
    float x,
    float y,
    float ancho)
        {
            System.Drawing.RectangleF area =
                new System.Drawing.RectangleF(
                    x,
                    y,
                    ancho,
                    1000
                );

            grafico.DrawString(
                texto,
                fuente,
                pincel,
                area
            );

            System.Drawing.SizeF tamaño =
                grafico.MeasureString(
                    texto,
                    fuente,
                    (int)ancho
                );

            return y + tamaño.Height + 10;
        }

        private void btnZoomMas_Click(object sender, EventArgs e)
        {
            if (printPreviewControl1.Zoom < 2.0)
            {
                printPreviewControl1.Zoom += 0.1;
            }
        }

        private void btnZoomMenos_Click(object sender, EventArgs e)
        {
            if (printPreviewControl1.Zoom > 0.2)
            {
                printPreviewControl1.Zoom -= 0.1;
            }
        }

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                printPreviewControl1.StartPage = paginaActual;
            }
        }

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            paginaActual++;

            printPreviewControl1.StartPage = paginaActual;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (datosHistorial == null || datosHistorial.Rows.Count == 0)
            {
                e.HasMorePages = false;
                return;
            }

            System.Drawing.Graphics grafico = e.Graphics;

            float x = 60;
            float y = 50;
            float ancho = e.PageBounds.Width - 120;

            System.Drawing.Font titulo =
                new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);

            System.Drawing.Font subtitulo =
                new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            System.Drawing.Font texto =
                new System.Drawing.Font("Arial", 10);

            System.Drawing.Brush pincel =
                System.Drawing.Brushes.Black;

            DataRow fila = datosHistorial.Rows[indiceConsulta];

            // Título
            // Logo
            System.Drawing.Image logo = Properties.Resources.gemini_svg_20_281_29;

            grafico.DrawImage(
                logo,
                x,
                y,
                200,
                60
            );

            // Título al lado del logo, centrado verticalmente
            y = DibujarTexto(
                grafico,
                "HISTORIAL CLÍNICO",
                titulo,
                pincel,
                x + 230,
                y + 15,
                ancho - 220
            );

            y += 20;

            // DATOS DEL PACIENTE
            y = DibujarTexto(
                grafico,
                "DATOS DEL PACIENTE",
                subtitulo,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Paciente: " + fila["nombre"].ToString() + " " + fila["apellido"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "CI: " + fila["ci"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Fecha de nacimiento: " + fila["fecha_nacimiento"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Género: " + fila["genero"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Teléfono: " + fila["telefono"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y += 10;

            // ANTECEDENTES MÉDICOS
            y = DibujarTexto(
                grafico,
                "ANTECEDENTES MÉDICOS",
                subtitulo,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Antecedentes médicos: " + fila["antecedentes_medicos"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Antecedentes familiares: " + fila["antecedentes_familiares"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Alergias: " + fila["alergias"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Enfermedades previas: " + fila["enfermedades_previas"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Cirugías: " + fila["cirugias"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Medicación habitual: " + fila["medicacion_habitual"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Antecedentes personales: " + fila["antecedentes_personales"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Grupo sanguíneo: " + fila["grupo_sanguineo"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Discapacidad: " + fila["discapacidad"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Observaciones: " + fila["observaciones"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y += 10;

            // DATOS DE LA CONSULTA
            y = DibujarTexto(
                grafico,
                "DATOS DE LA CONSULTA",
                subtitulo,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Fecha de consulta: " + fila["fecha_consulta"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Motivo: " + fila["motivo"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Síntomas: " + fila["sintomas"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Diagnóstico: " + fila["diagnostico"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Descripción: " + fila["descripcion"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y += 10;

            // MÉDICO
            y = DibujarTexto(
                grafico,
                "MÉDICO",
                subtitulo,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Médico: " + fila["nombre_medico"].ToString() + " " + fila["apellido_medico"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Especialidad: " + fila["especialidad"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y += 10;

            // TRATAMIENTO
            y = DibujarTexto(
                grafico,
                "TRATAMIENTO",
                subtitulo,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Tratamiento: " + fila["tratamiento"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            y = DibujarTexto(
                grafico,
                "Duración: " + fila["duracion_tratamiento"].ToString(),
                texto,
                pincel,
                x,
                y,
                ancho
            );

            indiceConsulta++;

            if (indiceConsulta < datosHistorial.Rows.Count)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                indiceConsulta = 0;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            using (PrintDialog dialogo = new PrintDialog())
            {
                dialogo.Document = printDocument1;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }
    }
    }
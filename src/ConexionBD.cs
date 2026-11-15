using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiseñoReservasMedicas
{
    internal class ConexionBD
    {
        private string cadenaConexion = "Server=DESKTOP-V08UIA0;Database=BD_ReservasMedicas;Integrated Security=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        public bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void ConsultarMedicos()
        {
            string consulta = "SELECT * FROM TB_MEDICO";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Console.WriteLine(lector["nombre"]);
                        }
                    }
                }
            }
        }

            public DataTable ObtenerPacientes()
            {
                string consulta = @"SELECT 
                            id_paciente AS ID,
                            nombre AS Nombre,
                            apellido AS Apellido,
                            fecha_nacimiento AS 'Fecha de nacimiento',
                            telefono AS Teléfono,
                            ci AS CI,
                            genero AS Género,
                            ciudad_nacimiento AS Ciudad,
                            provincia_nacimiento AS Provincia
                        FROM TB_PACIENTE";

                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }

        public string ObtenerRolUsuario(string usuario, string contraseña)
        {
            string consulta = "SELECT rol FROM TB_USUARIO " +
                              "WHERE usuario = @usuario " +
                              "AND contraseña = @contraseña " +
                              "AND estado = 1";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        return resultado.ToString();
                    }

                    return null;
                }
            }
        }

        public int ObtenerIdUsuario(string usuario, string contraseña)
        {
            string consulta = "SELECT id_usuario FROM TB_USUARIO " +
                              "WHERE usuario = @usuario " +
                              "AND contraseña = @contraseña " +
                              "AND estado = 1";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado);
                    }

                    return 0;
                }
            }
        }

        public int ObtenerIdMedico(int idUsuario)
        {
            string consulta = "SELECT id_medico FROM TB_MEDICO " +
                              "WHERE id_usuario = @idUsuario";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado);
                    }

                    return 0;
                }
            }
        }

        public DataTable ObtenerCitasMedico(int idMedico)
        {
            string consulta = @"
        SELECT 
            C.id_cita,
            C.fecha_cita,
            C.hora_cita,
            C.piso,
            P.nombre + ' ' + P.apellido AS paciente,
            E.nombre AS especialidad,
            C.estado
        FROM TB_CITA C
        INNER JOIN TB_PACIENTE P 
            ON C.id_paciente = P.id_paciente
        INNER JOIN TB_MEDICO M 
            ON C.id_medico = M.id_medico
        INNER JOIN TB_ESPECIALIDAD E 
            ON M.id_especialidad = E.id_especialidad
        WHERE C.id_medico = @idMedico
        ORDER BY C.fecha_cita, C.hora_cita";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }

        
    public DataTable ObtenerCitasHoyMedico(int idMedico)
        {
            string consulta = @"
            SELECT 
                C.id_cita,
                C.fecha_cita,
                C.hora_cita,
                C.piso,
                P.nombre + ' ' + P.apellido AS paciente,
                E.nombre AS especialidad,
                C.motivo AS motivo,
                C.estado
            FROM TB_CITA C
            INNER JOIN TB_PACIENTE P 
                ON C.id_paciente = P.id_paciente
            INNER JOIN TB_MEDICO M 
                ON C.id_medico = M.id_medico
            INNER JOIN TB_ESPECIALIDAD E 
                ON M.id_especialidad = E.id_especialidad
            WHERE C.id_medico = @idMedico
            AND C.fecha_cita = CAST(GETDATE() AS DATE)
            ORDER BY C.hora_cita";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }



        public void AgregarPaciente(
            string nombre,
            string apellido,
            string telefono,
            DateTime fechaNacimiento,
            string ci,
            string genero,
            string provinciaNacimiento,
            string ciudadNacimiento)
        {
            string consulta = @"INSERT INTO TB_PACIENTE
                        (nombre, apellido, fecha_nacimiento, telefono, ci, genero, provincia_nacimiento, ciudad_nacimiento)
                        VALUES
                        (@nombre, @apellido, @fechaNacimiento, @telefono, @ci, @genero, @provinciaNacimiento, @ciudadNacimiento)";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@apellido", apellido);
                    comando.Parameters.AddWithValue("@telefono", telefono);
                    comando.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                    comando.Parameters.AddWithValue("@ci", ci);
                    comando.Parameters.AddWithValue("@genero", genero);
                    comando.Parameters.AddWithValue("@provinciaNacimiento", provinciaNacimiento);
                    comando.Parameters.AddWithValue("@ciudadNacimiento", ciudadNacimiento);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerDetalleCita(int idCita)
        {
            string consulta = @"
        SELECT
            C.id_cita,
            P.nombre + ' ' + P.apellido AS paciente,
            P.ci,
            P.fecha_nacimiento,
            P.telefono,
            P.genero,
            M.nombre + ' ' + M.apellido AS medico,
            E.nombre AS especialidad,
            C.fecha_cita,
            C.hora_cita,
            C.piso,
            C.estado
        FROM TB_CITA C
        INNER JOIN TB_PACIENTE P
            ON C.id_paciente = P.id_paciente
        INNER JOIN TB_MEDICO M
            ON C.id_medico = M.id_medico
        INNER JOIN TB_ESPECIALIDAD E
            ON M.id_especialidad = E.id_especialidad
        WHERE C.id_cita = @idCita";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idCita", idCita);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }

        public DataTable ObtenerHistorialCitasMedico(
        int idMedico,
        string paciente,
        DateTime fechaDesde,
        DateTime fechaHasta)
        {
            string consulta = @"
                SELECT
                    C.id_cita,
                    C.fecha_cita,
                    C.hora_cita,
                    P.nombre + ' ' + P.apellido AS paciente,
                    E.nombre AS especialidad,
                    C.piso,
                    C.estado,
                    ISNULL(
                        STUFF(
                            (
                                SELECT '; ' + T.descripcion
                                FROM TB_TRATAMIENTO T
                                WHERE T.id_cita = C.id_cita
                                FOR XML PATH('')
                            ), 1, 2, ''
                        ),
                        'Sin tratamiento registrado'
                    ) AS tratamiento
                FROM TB_CITA C
                INNER JOIN TB_PACIENTE P
                    ON C.id_paciente = P.id_paciente
                INNER JOIN TB_MEDICO M
                    ON C.id_medico = M.id_medico
                INNER JOIN TB_ESPECIALIDAD E
                    ON M.id_especialidad = E.id_especialidad
                WHERE C.id_medico = @idMedico
                AND C.estado IN ('Atendida', 'Cancelada')
                AND C.fecha_cita >= @fechaDesde
                AND C.fecha_cita <= @fechaHasta
                AND (
                    @paciente = ''
                    OR P.nombre + ' ' + P.apellido LIKE '%' + @paciente + '%'
                )
                ORDER BY C.fecha_cita DESC, C.hora_cita DESC";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@paciente", paciente);
                    comando.Parameters.AddWithValue("@fechaDesde", fechaDesde.Date);
                    comando.Parameters.AddWithValue("@fechaHasta", fechaHasta.Date);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }

        public DataTable ObtenerCitasMedicoPorFecha(int idMedico, DateTime fecha)
        {
            string consulta = @"
                SELECT 
                    C.id_cita,
                    C.fecha_cita,
                    C.hora_cita,
                    C.piso,
                    P.nombre + ' ' + P.apellido AS paciente,
                    E.nombre AS especialidad,
                    C.estado
                FROM TB_CITA C
                INNER JOIN TB_PACIENTE P 
                    ON C.id_paciente = P.id_paciente
                INNER JOIN TB_MEDICO M 
                    ON C.id_medico = M.id_medico
                INNER JOIN TB_ESPECIALIDAD E 
                    ON M.id_especialidad = E.id_especialidad
                WHERE C.id_medico = @idMedico
                AND C.fecha_cita = @fecha
                ORDER BY C.hora_cita";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@fecha", fecha.Date);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }

        public DataTable ObtenerCitaPorId(int idCita)
        {
            string consulta = @"
        SELECT
            C.id_cita,
            C.fecha_cita,
            C.hora_cita,
            C.piso,
            C.estado,
            P.nombre + ' ' + P.apellido AS paciente,
            E.nombre AS especialidad
        FROM TB_CITA C
        INNER JOIN TB_PACIENTE P
            ON C.id_paciente = P.id_paciente
        INNER JOIN TB_MEDICO M
            ON C.id_medico = M.id_medico
        INNER JOIN TB_ESPECIALIDAD E
            ON M.id_especialidad = E.id_especialidad
        WHERE C.id_cita = @idCita";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idCita", idCita);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }

        public DataTable ObtenerDatosMedico(int idUsuario)
        {
            string consulta = @"
        SELECT
            M.nombre + ' ' + M.apellido AS nombre,
            E.nombre AS especialidad
        FROM TB_MEDICO M
        INNER JOIN TB_ESPECIALIDAD E
            ON M.id_especialidad = E.id_especialidad
        WHERE M.id_usuario = @idUsuario";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }

        public DataTable ObtenerPacientesAtendidosPorMedico(int idMedico, string buscar)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
                SELECT DISTINCT
                    p.id_paciente,
                    p.nombre,
                    p.apellido,
                    p.ci,
                    p.telefono,

                    CASE
                        WHEN EXISTS
                        (
                            SELECT 1
                            FROM TB_DERIVACION d
                            WHERE d.id_paciente = p.id_paciente
                              AND d.id_medico_destino = @idMedico
                        )
                        THEN 'Sí'
                        ELSE 'No'
                    END AS derivado

                FROM TB_PACIENTE p
                INNER JOIN TB_CITA c
                    ON p.id_paciente = c.id_paciente
                WHERE c.id_medico = @idMedico
                  AND c.estado = 'Atendida'
                  AND (
                        p.nombre LIKE '%' + @buscar + '%'
                        OR p.apellido LIKE '%' + @buscar + '%'
                        OR p.ci LIKE '%' + @buscar + '%'
                        OR (p.nombre + ' ' + p.apellido) LIKE '%' + @buscar + '%'
                      )
                ORDER BY p.apellido, p.nombre;";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@buscar", buscar);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        public bool TieneHistorialClinico(int idPaciente)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT COUNT(*)
            FROM TB_HISTORIALCLINICO
            WHERE id_paciente = @idPaciente";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente);

                    conexion.Open();

                    int cantidad = (int)comando.ExecuteScalar();

                    return cantidad > 0;
                }
            }
        }

        public bool RegistrarHistorialClinico(
            int idPaciente,
            string antecedentesMedicos,
            string antecedentesFamiliares,
            string alergias,
            string enfermedadesPrevias,
            string cirugias,
            string medicacionHabitual,
            string antecedentesPersonales,
            string grupoSanguineo,
            string discapacidad,
            string observaciones)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
            INSERT INTO TB_HISTORIALCLINICO
            (
                id_paciente,
                antecedentes_medicos,
                antecedentes_familiares,
                alergias,
                enfermedades_previas,
                cirugias,
                medicacion_habitual,
                antecedentes_personales,
                grupo_sanguineo,
                discapacidad,
                observaciones,
                fecha_actualizacion
            )
            VALUES
            (
                @idPaciente,
                @antecedentesMedicos,
                @antecedentesFamiliares,
                @alergias,
                @enfermedadesPrevias,
                @cirugias,
                @medicacionHabitual,
                @antecedentesPersonales,
                @grupoSanguineo,
                @discapacidad,
                @observaciones,
                GETDATE()
            );";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente);
                    comando.Parameters.AddWithValue("@antecedentesMedicos", antecedentesMedicos);
                    comando.Parameters.AddWithValue("@antecedentesFamiliares", antecedentesFamiliares);
                    comando.Parameters.AddWithValue("@alergias", alergias);
                    comando.Parameters.AddWithValue("@enfermedadesPrevias", enfermedadesPrevias);
                    comando.Parameters.AddWithValue("@cirugias", cirugias);
                    comando.Parameters.AddWithValue("@medicacionHabitual", medicacionHabitual);
                    comando.Parameters.AddWithValue("@antecedentesPersonales", antecedentesPersonales);
                    comando.Parameters.AddWithValue("@grupoSanguineo", grupoSanguineo);
                    comando.Parameters.AddWithValue("@discapacidad", discapacidad);
                    comando.Parameters.AddWithValue("@observaciones", observaciones);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable ObtenerHistorialClinico(int idPaciente)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT
                antecedentes_medicos,
                antecedentes_familiares,
                alergias,
                enfermedades_previas,
                cirugias,
                medicacion_habitual,
                antecedentes_personales,
                grupo_sanguineo,
                discapacidad,
                observaciones
            FROM TB_HISTORIALCLINICO
            WHERE id_paciente = @idPaciente;";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        public bool ModificarHistorialClinico(
    int idPaciente,
    string antecedentesMedicos,
    string antecedentesFamiliares,
    string alergias,
    string enfermedadesPrevias,
    string cirugias,
    string medicacionHabitual,
    string antecedentesPersonales,
    string grupoSanguineo,
    string discapacidad,
    string observaciones)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
                UPDATE TB_HISTORIALCLINICO
                SET
                    antecedentes_medicos = @antecedentesMedicos,
                    antecedentes_familiares = @antecedentesFamiliares,
                    alergias = @alergias,
                    enfermedades_previas = @enfermedadesPrevias,
                    cirugias = @cirugias,
                    medicacion_habitual = @medicacionHabitual,
                    antecedentes_personales = @antecedentesPersonales,
                    grupo_sanguineo = @grupoSanguineo,
                    discapacidad = @discapacidad,
                    observaciones = @observaciones,
                    fecha_actualizacion = GETDATE()
                WHERE id_paciente = @idPaciente;";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente);
                    comando.Parameters.AddWithValue("@antecedentesMedicos", antecedentesMedicos);
                    comando.Parameters.AddWithValue("@antecedentesFamiliares", antecedentesFamiliares);
                    comando.Parameters.AddWithValue("@alergias", alergias);
                    comando.Parameters.AddWithValue("@enfermedadesPrevias", enfermedadesPrevias);
                    comando.Parameters.AddWithValue("@cirugias", cirugias);
                    comando.Parameters.AddWithValue("@medicacionHabitual", medicacionHabitual);
                    comando.Parameters.AddWithValue("@antecedentesPersonales", antecedentesPersonales);
                    comando.Parameters.AddWithValue("@grupoSanguineo", grupoSanguineo);
                    comando.Parameters.AddWithValue("@discapacidad", discapacidad);
                    comando.Parameters.AddWithValue("@observaciones", observaciones);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable ObtenerHistorialCompletoPaciente(int idPaciente)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
                SELECT
                    p.id_paciente,
                    p.nombre,
                    p.apellido,
                    p.ci,
                    p.fecha_nacimiento,
                    p.genero,
                    p.telefono,

                    h.antecedentes_medicos,
                    h.antecedentes_familiares,
                    h.alergias,
                    h.enfermedades_previas,
                    h.cirugias,
                    h.medicacion_habitual,
                    h.antecedentes_personales,
                    h.grupo_sanguineo,
                    h.discapacidad,
                    h.observaciones,

                    c.id_consulta,
                    c.fecha_consulta,
                    c.motivo,
                    c.sintomas,
                    c.diagnostico,
                    c.descripcion,

                    m.nombre AS nombre_medico,
                    m.apellido AS apellido_medico,

                    e.nombre AS especialidad,

                    t.descripcion AS tratamiento,
                    t.duracion AS duracion_tratamiento

                FROM TB_PACIENTE p

                LEFT JOIN TB_HISTORIALCLINICO h
                    ON p.id_paciente = h.id_paciente

                LEFT JOIN TB_CONSULTA c
                    ON p.id_paciente = c.id_paciente

                LEFT JOIN TB_MEDICO m
                    ON c.id_medico = m.id_medico

                LEFT JOIN TB_ESPECIALIDAD e
                    ON m.id_especialidad = e.id_especialidad

                LEFT JOIN TB_TRATAMIENTO t
                    ON c.id_cita = t.id_cita

                WHERE p.id_paciente = @idPaciente

                ORDER BY c.fecha_consulta DESC;";
                    
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        public bool RegistrarDerivacion(
        int idPaciente,
        int idMedicoOrigen,
        int idMedicoDestino,
        DateTime fechaDerivacion,
        string motivo)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
            INSERT INTO TB_DERIVACION
            (
                fecha_derivacion,
                motivo,
                id_paciente,
                id_medico_origen,
                id_medico_destino
            )
            VALUES
            (
                @fecha_derivacion,
                @motivo,
                @id_paciente,
                @id_medico_origen,
                @id_medico_destino
            )";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@fecha_derivacion", fechaDerivacion);
                    comando.Parameters.AddWithValue("@motivo", motivo);
                    comando.Parameters.AddWithValue("@id_paciente", idPaciente);
                    comando.Parameters.AddWithValue("@id_medico_origen", idMedicoOrigen);
                    comando.Parameters.AddWithValue("@id_medico_destino", idMedicoDestino);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable ObtenerEspecialidades()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT
                id_especialidad,
                nombre
            FROM TB_ESPECIALIDAD
            ORDER BY nombre";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        public DataTable ObtenerMedicosPorEspecialidad(
            int idEspecialidad,
            int idMedicoOrigen)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT
                id_medico,
                nombre + ' ' + apellido AS medico
            FROM TB_MEDICO
            WHERE id_especialidad = @id_especialidad
              AND disponible = 1
              AND id_medico <> @id_medico_origen
            ORDER BY nombre, apellido";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@id_especialidad",
                        idEspecialidad
                    );

                    comando.Parameters.AddWithValue(
                        "@id_medico_origen",
                        idMedicoOrigen
                    );

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        public DataTable ObtenerPacientesDisponiblesParaDerivar(int idMedico)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
        SELECT DISTINCT
            p.id_paciente,
            p.nombre,
            p.apellido
        FROM TB_PACIENTE p
        INNER JOIN TB_CITA c
            ON p.id_paciente = c.id_paciente
        WHERE c.id_medico = @idMedico
          AND c.estado = 'Atendida'
          AND NOT EXISTS
          (
              SELECT 1
              FROM TB_DERIVACION d
              WHERE d.id_paciente = p.id_paciente
                AND d.id_medico_origen = @idMedico
          )
        ORDER BY p.apellido, p.nombre;";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        public bool GuardarHorarioMedico(int idMedico, string diaSemana, string horaInicio, string horaFin)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    string consulta = @"
                INSERT INTO TB_HORARIO_MEDICO
                (id_medico, dia_semana, hora_inicio, hora_fin)
                VALUES
                (@idMedico, @diaSemana, @horaInicio, @horaFin)";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idMedico", idMedico);
                        comando.Parameters.AddWithValue("@diaSemana", diaSemana);
                        comando.Parameters.AddWithValue("@horaInicio", horaInicio);
                        comando.Parameters.AddWithValue("@horaFin", horaFin);

                        conexion.Open();
                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarHorariosMedico(int idMedico)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    string consulta = @"
                DELETE FROM TB_HORARIO_MEDICO
                WHERE id_medico = @idMedico";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idMedico", idMedico);

                        conexion.Open();
                        comando.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable ObtenerHorariosMedico(int idMedico)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT dia_semana, hora_inicio, hora_fin
            FROM TB_HORARIO_MEDICO
            WHERE id_medico = @idMedico";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }


        public bool MarcarCitaAtendida(int idCita)
        {
            string consulta = @"
        UPDATE TB_CITA
        SET estado = 'Atendida'
        WHERE id_cita = @idCita
        AND estado IN ('Pendiente', 'Confirmada')";

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idCita", idCita);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
    
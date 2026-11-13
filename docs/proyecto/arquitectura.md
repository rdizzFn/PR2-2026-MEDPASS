# Arquitectura del Sistema MedPass

## 1. Introducción

MedPass es una aplicación de escritorio desarrollada en C# utilizando Windows Forms y .NET Framework 4.7.2. Su arquitectura permite gestionar las diferentes funciones del sistema mediante formularios y una conexión con una base de datos SQL Server.

## 2. Arquitectura general

El sistema está organizado en tres partes principales:

- **Interfaz de usuario:** contiene los formularios de Windows Forms mediante los cuales los usuarios interactúan con el sistema.
- **Acceso a datos:** se encuentra centralizado principalmente en la clase `ConexionBD.cs`, que permite ejecutar consultas y operaciones sobre la base de datos.
- **Base de datos:** utiliza SQL Server para almacenar la información de pacientes, médicos, citas, pagos y demás registros del sistema.

## 3. Tecnologías utilizadas

| Tecnología | Uso |
|---|---|
| C# | Lenguaje de programación |
| Windows Forms | Desarrollo de interfaces gráficas |
| .NET Framework 4.7.2 | Plataforma de ejecución |
| SQL Server | Administración de la base de datos |
| ADO.NET | Comunicación entre la aplicación y la base de datos |
| Visual Studio | Entorno de desarrollo |

## 4. Organización del código

El proyecto contiene diferentes formularios organizados según las funciones del sistema.

### Acceso y navegación
- `Program.cs`: punto de entrada de la aplicación.
- `frmLogin.cs`: formulario de inicio de sesión.
- `frmInicio.cs`: formulario de inicio.
- `frmPrincipal.cs`: formulario principal.

### Administración
- `frmAdmin.cs`: funciones de administración.

### Gestión de citas
- `frmCitas.cs`
- `frmCitas_Panel.cs`
- `frmCitas_Nueva.cs`
- `frmCitas_Programadas.cs`
- `frmCitas_Cancelar.cs`
- `frmCitas_HistorialClinico.cs`
- `frmCitas_AñadirPaciente.cs`
- `frmCitas-AñadirInformacion.cs`

### Gestión médica
- `frmMedico.cs`
- `frmMedico_Inicio.cs`
- `frmMedico_Citas.cs`
- `frmMedico_CitasHoy.cs`
- `frmMedico_ProximasCitas.cs`
- `frmMedico_Pacientes.cs`
- `frmMedico_BuscarPaciente.cs`
- `frmMedico_HistorialClinico.cs`
- `frmMedico_HistorialPaciente.cs`
- `frmMedico_ImprimirHistorial.cs`
- `frmMedico_DerivarPaciente.cs`
- `frmMedico_MisHorarios.cs`

### Otros formularios
- `frmMiPerfil.cs`: gestión del perfil del usuario.
- `frmPagos.cs`: gestión de pagos.
- `frmVerPacientes.cs`: consulta de pacientes.

### Acceso a datos
- `ConexionBD.cs`: administra la conexión con SQL Server y contiene métodos para consultar y modificar información.

## 5. Conexión con la base de datos

La aplicación utiliza ADO.NET para comunicarse con SQL Server.

La clase `ConexionBD.cs` contiene la cadena de conexión y los métodos necesarios para abrir conexiones y ejecutar operaciones sobre las tablas.

Entre los componentes utilizados se encuentran:

- `SqlConnection`: establece la conexión con SQL Server.
- `SqlCommand`: ejecuta instrucciones SQL.
- `SqlDataAdapter`: obtiene información y la carga en objetos `DataTable`.
- `SqlDataReader`: permite leer los resultados de consultas.
- `DataTable`: almacena temporalmente los resultados obtenidos.

La conexión utiliza autenticación integrada de Windows.

## 6. Base de datos

El sistema utiliza una base de datos denominada `BD_ReservasMedicas`, compuesta por las siguientes tablas principales:

- TB_CITA
- TB_CONSULTA
- TB_DERIVACION
- TB_ESPECIALIDAD
- TB_HISTORIALCLINICO
- TB_HORARIO_MEDICO
- TB_MEDICO
- TB_PACIENTE
- TB_PAGO
- TB_RECEPCIONISTA
- TB_TRATAMIENTO
- TB_USUARIO

Las tablas se relacionan mediante claves primarias y foráneas para mantener la relación entre pacientes, médicos, citas y demás registros.

## 7. Funcionamiento general

El funcionamiento del sistema sigue este proceso:

1. El usuario inicia la aplicación.
2. Accede mediante el formulario de inicio de sesión.
3. El sistema verifica las credenciales y el estado del usuario en la base de datos.
4. Según el rol, se habilitan las funciones correspondientes.
5. El

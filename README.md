## Funcionalidades del sistema

MedPass contempla los siguientes módulos:

- Inicio de sesión y control de acceso según el tipo de usuario.
- Gestión de pacientes.
- Gestión de médicos y especialidades.
- Registro y administración de citas médicas.
- Consulta de horarios de los médicos.
- Gestión de consultas e historiales clínicos.
- Derivación de pacientes.
- Administración de pagos.
- Gestión de perfiles de usuario.

## Estructura del repositorio

```text
PR2-2026-MEDPASS/
├── .github/
│   ├── ISSUE_TEMPLATE/
│   └── PULL_REQUEST_TEMPLATE.md
├── docs/
│   ├── equipo/
│   ├── planificacion/
│   └── proyecto/
├── equipo/
├── README.md
├── .gitignore
├── .editorconfig
├── CONTRIBUTING.md
├── CHANGELOG.md
└── SECURITY.md
```

## Documentación del proyecto

- [Visión y alcance](docs/proyecto/vision-y-alcance.md)
- [Requisitos](docs/proyecto/requisitos.md)
- [Arquitectura](docs/proyecto/arquitectura.md)
- [Modelo de datos](docs/proyecto/modelo-de-datos.md)
- [Informe del proyecto](docs/proyecto/Informe-Proyecto%20Final%20(1).pdf)
- [Flujograma](docs/proyecto/flujograma.pdf)
- [Planificación](docs/planificacion/planificacion.md)
- [Cronograma Gantt](docs/planificacion/gantt.pdf)
- [Seguimiento](docs/planificacion/seguimiento.md)
- [Integrantes y roles](docs/equipo/integrantes-y-roles.md)
- [Acuerdos de trabajo](docs/equipo/acuerdos-de-trabajo.md)

## Requisitos del entorno

Para ejecutar el sistema se requiere:

- Windows.
- Visual Studio.
- .NET Framework 4.7.2.
- Microsoft SQL Server.
- SQL Server Management Studio.

## Base de datos

El sistema utiliza SQL Server y una base de datos denominada `BD_ReservasMedicas`.

La aplicación utiliza ADO.NET para establecer la conexión y realizar operaciones con la base de datos.

La cadena de conexión debe adaptarse a la instancia de SQL Server del equipo donde se ejecute el proyecto.

## Instalación y ejecución

Las instrucciones de instalación, configuración de la base de datos y ejecución se completarán junto con la incorporación de los archivos del proyecto y los scripts de SQL Server al repositorio.

## Estado del proyecto

El sistema cuenta con módulos desarrollados en C# Windows Forms y una base de datos implementada en SQL Server.

Actualmente se está trabajando en la organización del repositorio, la documentación técnica y la preparación de los archivos necesarios para facilitar su instalación, ejecución y mantenimiento.

Actualmente se está trabajando en la organización del repositorio, la documentación técnica y la preparación de los archivos necesarios para facilitar su instalación, ejecución y mantenimiento.

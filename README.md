# MEDPASS - Sistema de Gestión de Reservas Médicas

## Problema

En muchos centros médicos, la gestión de reservas se realiza mediante llamadas, mensajes o registros manuales. Esto puede generar errores, duplicación de citas y problemas con los horarios disponibles de los médicos.

## Propósito

MedPass busca centralizar la gestión de pacientes, médicos, horarios, citas, historiales médicos y pagos en un solo sistema.

## Usuarios

El sistema está dirigido principalmente a:

- Administradores
- Recepcionistas
- Médicos

También está orientado a clínicas y consultorios médicos.

## Objetivo

Desarrollar un sistema que permita organizar pacientes y médicos, consultar horarios disponibles, registrar citas y facilitar la modificación o cancelación de reservas.

## Descripción general

MedPass será desarrollado utilizando C# y .NET Framework, con SQL Server para la gestión de la base de datos.

El sistema contempla diferentes roles:

- **Administrador:** gestión de usuarios y médicos.
- **Recepcionista:** gestión de pacientes, citas y pagos.
- **Médico:** consulta de citas, pacientes, horarios e historiales médicos.

## Integrantes

| **Integrante** | **Rol** |
|---|---|
| Rodrigo Castillo | Backend y Base de Datos |
| Andres Martinez | Frontend |

## Tecnologías

- C#
- Visual Studio
- .NET Framework 4.7.2
- SQL Server
- SQL Server Management Studio
- Draw.io
- GitHub

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
├── database/
│   ├── BD_ReservasMedicas.sql
│   └── README.md
├── docs/
│   ├── equipo/
│   ├── planificacion/
│   ├── presentaciones/
│   └── proyecto/
├── equipo/
├── src/
│   ├── Presentaciones/
│   ├── Properties/
│   ├── Resources/
│   ├── App.config
│   ├── ConexionBD.cs
│   ├── DiseñoReservasMedicas.csproj
│   ├── DiseñoReservasMedicas.slnx
│   ├── Program.cs
│   ├── packages.config
│   └── README.md
├── .editorconfig
├── .gitignore
├── README.md
├── CONTRIBUTING.md
├── CHANGELOG.md
└── SECURITY.md
```

## Documentación

La documentación del proyecto se encuentra organizada en la carpeta `docs`.

- `docs/proyecto/` - Informe del proyecto, flujograma y documentación técnica.
- `docs/planificacion/` - Gantt, planificación y seguimiento del proyecto.
- `docs/presentaciones/` - Presentación del proyecto.
- `docs/equipo/` - Integrantes, roles y acuerdos de trabajo.

### Documentación técnica

- [Visión y alcance](docs/proyecto/vision-y-alcance.md)
- [Requisitos funcionales y no funcionales](docs/proyecto/requisitos.md)
- [Arquitectura del sistema](docs/proyecto/arquitectura.md)
- [Modelo de datos](docs/proyecto/modelo-de-datos.md)
- [Informe del proyecto](docs/proyecto/Informe-Proyecto%20Final%20(1).pdf)
- [Flujograma](docs/proyecto/flujograma.pdf)

### Planificación

- [Planificación del proyecto](docs/planificacion/planificacion.md)
- [Cronograma Gantt](docs/planificacion/gantt.pdf)
- [Seguimiento del proyecto](docs/planificacion/seguimiento.md)

### Equipo de trabajo

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

El repositorio incluye los archivos del código fuente y el script de la base de datos. Para preparar el entorno, se requiere Visual Studio con soporte para .NET Framework 4.7.2 y Microsoft SQL Server. La base de datos se administra mediante SQL Server Management Studio y la aplicación se ejecuta desde el entorno de desarrollo.

## Estado actual

El sistema cuenta con módulos desarrollados en C# Windows Forms y una base de datos implementada en SQL Server.

Actualmente se está trabajando en la organización del repositorio, la documentación técnica y la preparación de los archivos necesarios para facilitar su instalación, ejecución y mantenimiento.

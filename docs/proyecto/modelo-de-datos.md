# Modelo de Datos – MedPass

## 1. Descripción general

La base de datos de MedPass se denomina `BD_ReservasMedicas` y está implementada en SQL Server. Su propósito es almacenar y organizar la información necesaria para gestionar usuarios, pacientes, médicos, citas, consultas, historiales clínicos, horarios y pagos.

El modelo utiliza tablas relacionadas mediante claves primarias y claves foráneas para mantener la relación entre los diferentes registros.

## 2. Tablas de la base de datos

La base de datos cuenta con las siguientes tablas principales:

| Tabla | Descripción |
|---|---|
| `TB_USUARIO` | Almacena la información de los usuarios del sistema |
| `TB_RECEPCIONISTA` | Registra la información de los recepcionistas |
| `TB_MEDICO` | Almacena los datos de los médicos |
| `TB_ESPECIALIDAD` | Registra las especialidades médicas |
| `TB_PACIENTE` | Almacena la información de los pacientes |
| `TB_CITA` | Registra las citas médicas |
| `TB_CONSULTA` | Almacena información de las consultas médicas |
| `TB_DERIVACION` | Registra las derivaciones de pacientes entre médicos |
| `TB_HISTORIALCLINICO` | Almacena los historiales clínicos de los pacientes |
| `TB_HORARIO_MEDICO` | Registra los horarios de atención de los médicos |
| `TB_PAGO` | Almacena los pagos relacionados con las citas |
| `TB_TRATAMIENTO` | Registra los tratamientos asociados a las citas |

## 3. Relaciones entre las tablas

Las relaciones identificadas mediante claves foráneas son las siguientes:

- `TB_CITA` se relaciona con `TB_PACIENTE` mediante `id_paciente`.
- `TB_CITA` se relaciona con `TB_MEDICO` mediante `id_medico`.
- `TB_CONSULTA` se relaciona con `TB_PACIENTE` mediante `id_paciente`.
- `TB_CONSULTA` se relaciona con `TB_MEDICO` mediante `id_medico`.
- `TB_CONSULTA` se relaciona con `TB_CITA` mediante `id_cita`.
- `TB_DERIVACION` se relaciona con `TB_PACIENTE` mediante `id_paciente`.
- `TB_DERIVACION` se relaciona con `TB_MEDICO` mediante `id_medico_origen` y `id_medico_destino`.
- `TB_HISTORIALCLINICO` se relaciona con `TB_PACIENTE` mediante `id_paciente`.
- `TB_HORARIO_MEDICO` se relaciona con `TB_MEDICO` mediante `id_medico`.
- `TB_MEDICO` se relaciona con `TB_USUARIO` mediante `id_usuario`.
- `TB_MEDICO` se relaciona con `TB_ESPECIALIDAD` mediante `id_especialidad`.
- `TB_PAGO` se relaciona con `TB_CITA` mediante `id_cita`.
- `TB_RECEPCIONISTA` se relaciona con `TB_USUARIO` mediante `id_usuario`.
- `TB_TRATAMIENTO` se relaciona con `TB_CITA` mediante `id_cita`.

## 4. Integridad de los datos

Las claves foráneas permiten relacionar los registros de las diferentes tablas y ayudan a mantener la integridad referencial de la información.

Por ejemplo, una cita está relacionada con un paciente y un médico registrados en el sistema. De igual manera, los pagos y tratamientos se vinculan con las citas correspondientes.

## 5. Gestor de base de datos

- **Sistema gestor:** Microsoft SQL Server.
- **Nombre de la base de datos:** `BD_ReservasMedicas`.
- **Herramienta de administración:** SQL Server Management Studio (SSMS).
- **Acceso desde la aplicación:** C# mediante ADO.NET.

## 6. Observaciones

La estructura descrita corresponde a las tablas y relaciones identificadas en la base de datos durante su revisión.

La tabla `sysdiagrams` también aparece en SQL Server, pero corresponde a un objeto auxiliar utilizado para almacenar diagramas y no forma parte de las tablas principales del sistema MedPass.

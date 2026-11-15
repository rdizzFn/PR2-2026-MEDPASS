# Requisitos del Sistema MedPass

## 1. Introducción

Este documento describe los requisitos funcionales y no funcionales del sistema MedPass, una aplicación de escritorio destinada a la gestión de reservas médicas.

Los requisitos establecen las funciones que debe ofrecer el sistema y las condiciones que debe cumplir durante su funcionamiento.

## 2. Requisitos funcionales

| Código | Requisito | Descripción |
|---|---|---|
| RF01 | Inicio de sesión | El sistema debe permitir que los usuarios ingresen mediante usuario y contraseña registrados. |
| RF02 | Control de acceso | El sistema debe identificar el rol del usuario y permitir el acceso a las funciones correspondientes. |
| RF03 | Gestión de pacientes | El sistema debe permitir registrar, consultar y actualizar la información de los pacientes. |
| RF04 | Gestión de médicos | El sistema debe permitir registrar, consultar y administrar la información de los médicos. |
| RF05 | Gestión de especialidades | El sistema debe permitir registrar y consultar las especialidades médicas. |
| RF06 | Gestión de citas | El sistema debe permitir registrar y consultar las citas médicas. |
| RF07 | Modificación y cancelación | El sistema debe permitir modificar o cancelar citas registradas. |
| RF08 | Gestión de horarios | El sistema debe permitir consultar y administrar los horarios disponibles de los médicos. |
| RF09 | Historiales clínicos | El sistema debe permitir consultar los historiales clínicos asociados a los pacientes. |
| RF10 | Gestión de pagos | El sistema debe permitir registrar y consultar los pagos relacionados con las citas médicas. |
| RF11 | Administración de usuarios | El administrador debe poder registrar, consultar y administrar los usuarios del sistema. |

## 3. Requisitos no funcionales

Los siguientes requisitos establecen condiciones de calidad y funcionamiento que debe cumplir el sistema:

| Código | Requisito | Descripción |
|---|---|---|
| RNF01 | Seguridad | El sistema debe solicitar credenciales para permitir el ingreso y restringir las funciones según el rol del usuario. |
| RNF02 | Privacidad | El acceso a la información personal y médica de los pacientes debe limitarse a los usuarios autorizados. |
| RNF03 | Integridad de datos | La base de datos debe mantener las relaciones entre sus tablas mediante claves primarias y foráneas, evitando registros relacionados inválidos. |
| RNF04 | Usabilidad | Los formularios deben presentar campos identificables y mensajes que indiquen errores o resultados de las operaciones. |
| RNF05 | Compatibilidad | El sistema debe ejecutarse en Windows con el entorno .NET Framework 4.7.2 instalado. |
| RNF06 | Mantenimiento | El código fuente debe estar organizado en archivos y componentes que faciliten su revisión y modificación. |

## 4. Relación con los usuarios

Los requisitos se distribuyen según los roles definidos para el sistema:

- **Administrador:** administración de usuarios y médicos.
- **Recepcionista:** gestión de pacientes, citas y pagos.
- **Médico:** consulta de citas, pacientes, horarios e historiales clínicos.

## 5. Verificación de requisitos

Los requisitos funcionales se verificarán mediante pruebas de las operaciones disponibles en cada módulo, comprobando que los registros y consultas produzcan los resultados esperados.

Los requisitos no funcionales se verificarán mediante revisiones de acceso por roles, validación de datos, comprobación de la integridad de la base de datos y pruebas de ejecución en el entorno establecido.

## 6. Observaciones

Los requisitos descritos representan las funciones y condiciones previstas para MedPass. Su cumplimiento deberá comprobarse durante las pruebas del sistema y ajustarse según el avance de su implementación.

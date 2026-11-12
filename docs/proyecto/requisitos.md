# Requisitos del Sistema MedPass

## 1. Introducción

Este documento describe los requisitos funcionales y no funcionales del sistema MedPass, una aplicación de escritorio destinada a la gestión de reservas médicas.

## 2. Requisitos funcionales

| Código | Requisito | Descripción |
|---|---|---|
| RF01 | Inicio de sesión | El sistema debe permitir que los usuarios ingresen mediante usuario y contraseña. |
| RF02 | Control de acceso | El sistema debe identificar el rol del usuario y mostrar las funciones correspondientes. |
| RF03 | Gestión de pacientes | El sistema debe permitir registrar y consultar información de pacientes. |
| RF04 | Gestión de médicos | El sistema debe permitir administrar la información de los médicos. |
| RF05 | Gestión de especialidades | El sistema debe permitir gestionar las especialidades médicas. |
| RF06 | Gestión de citas | El sistema debe permitir registrar y consultar citas médicas. |
| RF07 | Modificación y cancelación | El sistema debe facilitar la modificación y cancelación de citas. |
| RF08 | Gestión de horarios | El sistema debe permitir consultar y gestionar los horarios disponibles de los médicos. |
| RF09 | Historiales clínicos | El sistema debe permitir consultar los historiales clínicos de los pacientes. |
| RF10 | Gestión de pagos | El sistema debe permitir registrar y gestionar los pagos relacionados con las citas. |
| RF11 | Administración de usuarios | El administrador debe poder gestionar los usuarios del sistema. |

## 3. Requisitos no funcionales

Los siguientes requisitos se plantean como condiciones que debe cumplir el sistema:

| Código | Requisito | Descripción |
|---|---|---|
| RNF01 | Seguridad | El acceso a las funciones debe estar controlado según el rol del usuario. |
| RNF02 | Privacidad | La información personal y médica de los pacientes debe mantenerse protegida. |
| RNF03 | Integridad de datos | La información almacenada debe conservar sus relaciones y consistencia en la base de datos. |
| RNF04 | Usabilidad | La interfaz debe permitir que los usuarios puedan utilizar las funciones de manera sencilla. |
| RNF05 | Compatibilidad | El sistema debe funcionar en el entorno de escritorio para el que fue desarrollado, utilizando C# y .NET Framework. |
| RNF06 | Mantenimiento | El código debe mantener una estructura organizada que facilite futuras modificaciones. |

## 4. Relación con los usuarios

Los requisitos se distribuyen según los roles definidos para el sistema:

- **Administrador:** administración de usuarios y médicos.
- **Recepcionista:** gestión de pacientes, citas y pagos.
- **Médico:** consulta de citas, pacientes, horarios e historiales clínicos.

## 5. Observaciones

Los requisitos descritos representan las funciones y condiciones previstas para MedPass. Los requisitos no funcionales deberán verificarse durante las pruebas del sistema y ajustarse según su implementación real.

# Política de seguridad – MedPass

## 1. Objetivo

Este documento establece recomendaciones para identificar y comunicar posibles vulnerabilidades de seguridad en el sistema MedPass.

## 2. Reporte de vulnerabilidades

Si algún integrante identifica un problema de seguridad, debe comunicarlo al equipo de desarrollo para su revisión y corrección.

Se recomienda no publicar información sensible ni detalles que puedan facilitar la explotación de una vulnerabilidad.

## 3. Protección de la información

Durante el desarrollo se deben seguir estas recomendaciones:

- No almacenar contraseñas ni credenciales en el repositorio.
- Evitar publicar cadenas de conexión que contengan información privada.
- Utilizar consultas SQL parametrizadas para reducir riesgos de inyección SQL.
- Restringir el acceso a la información según el rol del usuario.
- Proteger los datos personales y médicos de los pacientes.

## 4. Corrección de problemas

Los problemas identificados deben revisarse, documentarse y corregirse antes de incorporar los cambios correspondientes al proyecto.

## 5. Alcance

Esta política se aplica al código fuente, la base de datos, la documentación y los archivos relacionados con MedPass.

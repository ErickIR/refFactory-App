# HACKATON 2020

## REQUERIMIENTOS

  * Reporte y consulta de incidentes/eventos relacionados con los servicios municipales
 
  * Consulta directorio de Junta de Vecinos

  **Bonus**
  
  * Consulta registro de regidores, regidoras, alcaldes pedáneos y cualquier autoridad
    municipal que aplique.
  * Acceso a normativa municipal (Leyes y reglamentos)

## Topics

 **1 - Alcance de la aplicacion*s*
 
 **2 - Arquitectura de la aplicacion**
 
    - Tecnologias
    
    - Ambientes
    
    - Diseño de pantallas
    
    - Modelos de Datos
    
    - Flujo del aplicativo
    
 **3 - Disponibilidad de cada quien y definicion de roles**

 **4 - Gestion de Tareas**
 
 **5 - Planificacion y administracion de escalas de tiempo**
 
 **6 - Resultados esperado**

## Desarrollo de Topics

### 1 - Alcance de la aplicacion y gestion de tiempos

La aplicacion consitira en una sola aplicacion desarrollada en PWA, que contara con los modulos siguiente:

#### Ciudadano
El ciudadano contara con las siguientes funciones:
  - El ciudadano se registrara insertando su cedula para asi traer el informacion perteneciente al ciudadano y de querer actualizar su sector perteneciente traido de la informacion del padron, este lo podra cambiar y proceder a registrarse con su correo y contrasena.
  - El ciudadano contara con un modulo de reporte de incidencias de su sector registrado, las incidencias seran paraametrizadas para que este pueda elegir la que mas se adapte a su condicion y poder tirar una foto para demostrar la incidencia. 
  - Si la incidencia fue reportada el ciudadano podra votar por la incidencia ya que tambien esta le afecta de igual manera y no crear una incidencia con el mismo motivo de otra.
  - El ciudadano contara con un modulo de consulta de las incidencias mas votadas, las incidencias que estan trabajandose y las incidencias que ya estam completada.
  - El ciudadano contara con otro modulo para hacer consultas de los datos de perteneciente a las juntas de vecinos, este podra consultar cualquier junto de vecinos, pero le aparecera primeramente la cual pertene.

#### Administrador
El administrador contara con las siguientes funciones:
  - Este contara con un modulo de reportes de incidencias mas especifico.
  - El administrador podra cambiar el estatus de las incidencias solicitadas por el ciudadano, ya que, luego que se le envio a la persona que hara el trabajo esta se pasara a en proceso y de ser completada la persona indicara que su trabajo fue completado y se pasara a completado y se subira una nueva imagen de la obra completada.
  - El adminstrador podra editar los datos de la junta de vecinos y podra agregar nuevas juntas de vecinos al sistema.

### 2 - Arquitectura del aplicativo

#### Tecnologias

Las tecnologias que pueden ser utilizadas para realizar PWA:

- Flask-PWA y Django-PWA (Python)
- .Net Core PWA (C#)
- React
- Angular
- Vue

Las tecnologias que pueden ser utilizadas para el desarrollo de backend:

- .Net Core
- Django y Flask (Python)



      
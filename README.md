# Aplicacion de Gestion de Incidencias Municipales

Esta app es un MVP creado durante el Hackaton Municipal de Julio 2020, con la finalidad de desarrollar una app 
que permita la posibilidad de comunicación entre la comunidad y las instituciones municipales, asi como el reporte 
de las diferentes incidencias municipales que ocurran en los barrios o urbanizaciones. El proyecto esta desarrollado en C#
bajo diversas tecnologías, tales como Xamarin Forms y ASP .NET Core MVC.


## REQUERIMIENTOS

  * Reporte y consulta de incidentes/eventos relacionados con los servicios municipales
 
  * Consulta directorio de Junta de Vecinos

  **Bonus**

  * Consulta registro de regidores, regidoras, alcaldes pedáneos y cualquier autoridad
    municipal que aplique.
  * Acceso a normativa municipal (Leyes y reglamentos)

## Contenidos

1. [Alcance de la aplicacion](#alcance)

## Desarrollo de Contenidos

### 1 - Alcance de la aplicacion y gestion de tiempos <a name="alcance"></a>

La aplicacion consitira en una sola aplicacion desarrollada en PWA, que contara con los modulos siguiente:

#### Usuario no registrado: 
El usuario no registrado contará con las siguientes funciones: 
  - Visualización de un listado de las incidencias por provincias, municipios, distritos municipales y sectores.
  - Visualización de las juntas de vecinos de los sectores.

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



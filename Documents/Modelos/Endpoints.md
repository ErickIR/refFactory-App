## METODOS GET

### INCIDENCIAS

- `Incidencias/BarrioId` --> Obtiene todas las incidencias en el barrio seleccionado.

- `Incidencias/IncidenciaId` --> Obtiene el registro de incidencia con el Id Seleccionado.

- `Incidencias/BarrioId&StatusIncidenciaId` --> Obtiene todas las incidencias de ese barrio con  el estado seleccionado.

- `Incidencias/BarrioId&TipoIncidenciaId` --> Obtiene todas las incidencias de ese barrio con el tipo seleccionado.

- `Incidencias/UserId` --> Obtiene las incidencias registradas por el usuario seleccionado.

- `IncidenciaUsuario/IncidenciaId` --> Obtiene todas las interacciones de apoyo de esa incidencia.

### ARCHIVOS

- `Archivos/IncidenciaId` --> Obtiene todos los archivos de la incidencia seleccionada.

- `Archivos/TipoArchivoId` --> Obtiene el ULTIMO de los archivos de ese tipo.

### TIPOS INCIDENCIA

- `TiposIncidencia/` --> Obtiene todos los tipos de incidencias.

### STATUS INCIDENCIA

- `StatusIncidencia/` --> Obtiene todos los status de las incidencias.

### JUNTA DE VECINOS

- `JuntaDeVecinoByBarrio/BarrioId` --> Obtiene la junta de vecinos registrada en ese barrio y sus integrantes.

- `JuntaDeVecinos/MunicipioId` --> Obtiene las juntas de vecinos que se encuentran en los barrios del municipio seleccionado.
 
- `JuntaDeVecinos/BarrioId` --> Obtiene la junta de vecinos en base al barrioId.

- `JuntaDeVecinos/NombreBarrio` --> Obtiene la junta de vecinos en base al nombre del barrio al que pertenece.

- `IntegrantesJdV/JuntaDeVecinosId` --> Obtiene los integrantes de la junta de vecinos.

### ENTIDADES MUNICIPALES

- `EntidadMunicipalByMunicipio/Municipio` --> Obtiene todas las entidades municipales del municipio seleccionado.

- `EntidadesMunicipales/MunicipioId` --> Obtiene todos las entidades municipales del municipio.

### LOCALIDADES

- `Barrios/SectorId` --> Obtiene todos los barrios en el sector seleccionado.

- `Sectores/SeccionId` --> Obtiene todos los sectores en la seccion seleccionado.

- `Secciones/DistritosMunicipalesId` --> Obtiene todos los Secciones en el distrito municipal seleccionado.

- `DistritosMunicipales/MunicipioId` --> Obtiene todos los distritos municipales en el municipio seleccionado.

- `Municipio/BarrioId` --> Obtiene el municipio al que pertenece el barrio seleccionado.



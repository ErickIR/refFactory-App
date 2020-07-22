## METODOS GET

### INCIDENCIAS

- `/api/incidencia/barrio/{barrioId}` --> Obtiene todas las incidencias en el barrio seleccionado.

- `/api/incidencia/{incidenciaId}` --> Obtiene el registro de incidencia con el Id Seleccionado.

- `/api/incidencia/barrio/{barrioId}/status-incidencia/{statusIncidenciaId}` --> Obtiene todas las incidencias de ese barrio con  el estado seleccionado.

- `/api/incidencia/barrio/{barrioId}/tipo-incidencia/{tipoIncidenciaId}` --> Obtiene todas las incidencias de ese barrio con el tipo seleccionado.

- `/api/incidencia/usuario/{usuarioId}` --> Obtiene las incidencias registradas por el usuario seleccionado.

- `/api/incidencia-usuario/incidencia/{incidenciaId}` --> Obtiene todas las interacciones de apoyo de esa incidencia.


### TIPOS INCIDENCIA

- `/api/tipo-incidencia` --> Obtiene todos los tipos de incidencias.

### STATUS INCIDENCIA

- `/api/status-incidencia` --> Obtiene todos los status de las incidencias.

### JUNTA DE VECINOS

- `JuntaDeVecinoByBarrio/BarrioId` --> Obtiene la junta de vecinos registrada en ese barrio y sus integrantes.

- `JuntaDeVecinos/DistritoMunicipalId` --> Obtiene las juntas de vecinos que se encuentran en los barrios del distrito municipal seleccionado.

- `IntegrantesJdV/JuntaDeVecinosId` --> Obtiene los integrantes de la junta de vecinos.

### ENTIDADES MUNICIPALES


- `/api/entidad-municipal/municipio/{municipioId}` --> Obtiene todos las entidades municipales del municipio.

### LOCALIDADES

- `/api/barrio/sector/{sectorId}` --> Obtiene todos los barrios en el sector seleccionado.

- `/api/sector/seccion/{seccionId}` --> Obtiene todos los sectores en la seccion seleccionado.

- `/api/seccion/distrito-municipal/{distritoMunicipalId}` --> Obtiene todos los Secciones en el distrito municipal seleccionado.

- `/api/distrito-municipal/municipio/{municipioId}` --> Obtiene todos los distritos municipales en el municipio seleccionado.

- `/api/municipio/barrio/{barrioId}` --> Obtiene el municipio al que pertenece el barrio seleccionado.

- `/api/barrio/distrito-municipal/{distritoMunicipalId}` --> Obtiene todos los barrio de un distrito-municipal.



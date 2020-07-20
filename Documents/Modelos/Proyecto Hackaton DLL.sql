

create table Region(
	RegionId	int	not null primary key identity(1,1),
	Nombre		varchar(20) not null
);

create table Provincia(
	ProvinciaId int	not null primary key identity(1,1),
	RegionId	int not null references Region(RegionId),
	Nombre		varchar(20) not null
);

create table Municipio (
	MunicipioId int	not null primary key identity(1,1),
	ProvinciaId	int not null references Provincia(ProvinciaId),
	Nombre		varchar(20) not null
); 

create table DistritoMunicipal (
	DistritoMunicipalId int	not null primary key identity(1,1),
	MunicipioId	int not null references Municipio(MunicipioId),
	Nombre		varchar(20) not null
);

create table Seccion (
	SeccionId int	not null primary key identity(1,1),
	DistritoMunicipalId	int not null references DistritoMunicipal(DistritoMunicipalId),
	Nombre		varchar(20) not null
);

create table Sector (
	SectorId int	not null primary key identity(1,1),
	SeccionId	int not null references Seccion(SeccionId),
	Nombre		varchar(20) not null
);

create table Barrio (
	BarrioId int	not null primary key identity(1,1),
	SectorId	int not null references Sector(SectorId),
	Nombre		varchar(20) not null
);


create table TipoUsuario(
	TipoUsuarioId int	not null primary key identity(1,1),
	Descripccion  varchar(20) not null
);

create table TipoDocumento(
	TipoDocumentoId int	not null primary key identity(1,1),
	Descripccion  varchar(20) not null
);

create table Usuario(
	UsuarioId	  int	not null primary key identity(1,1),
	TipoUsuarioId int	not null references TipoUsuario(TipoUsuarioId),
	BarrioId	  int	not null references Barrio(BarrioId),
	TipoDocumentoId int	not null references TipoDocumento(TipoDocumentoId),
	Nombres		varchar(30) not null,
	Apellidos	varchar(30) not null,
	Documento	varchar(15) not null unique,
	Email		varchar(40) not null unique,
	HashPassword text not null
);

create table TipoIncidencia(
	TipoIncidenciaId int	not null primary key identity(1,1),
	Descripccion  varchar(20) not null
);

create table StatusIncidencia(
	StatusIncidenciaId int	not null primary key identity(1,1),
	Descripccion  varchar(20) not null
);

create table TipoArchivo(
	TipoArchivoId int	not null primary key identity(1,1),
	Descripccion  varchar(20) not null
);

create table ExtensionArchivo(
	ExtensionArchivoId int	not null primary key identity(1,1),
	Descripccion  varchar(20) not null
);

create table Incidencia(
	IncidenciaId  int	not null primary key identity(1,1),
	EmpleadoId	int	not null references Usuario(UsuarioId),
	UsuarioId	int	not null references Usuario(UsuarioId),
	StatusId	int	not null references StatusIncidencia(StatusIncidenciaId),
	TipoId		int	not null references TipoIncidencia(TipoIncidenciaId),
	BarrioId	int	not null references Barrio(BarrioId),
	Titulo		varchar(30) not null,
	Descripccion text not null
);

create table Archivo(
	ArchivoId		int	not null primary key identity(1,1),
	ExtensionId		int	not null references ExtensionArchivo(ExtensionArchivoId),
	IncidenciaId	int	not null references Incidencia(IncidenciaId),
	TipoId			int	not null references TipoIncidencia(TipoIncidenciaId),
	Nombre			varchar(30)  not null,
	Fichero			varbinary(max),
	FechaCreado		date DEFAULT GETDATE()
);

create table IncidenciaUsuario(
	IncidenciaUsuarioId int	not null primary key identity(1,1),
	UsuarioId		int	not null references Usuario(UsuarioId),
	IncidenciaId	int	not null references Incidencia(IncidenciaId)
);

Create table Rol(
	RolId int	not null primary key identity(1,1),
	Descripccion  varchar(20) not null
);

Create table JuntaDeVecinos(
	JuntaDeVecinosId  int	not null primary key identity(1,1),
	BarrioId		int	not null references Barrio(BarrioId),
	Nombre			varchar(30)  not null,
	Latitud			varchar(30)  not null,
	Longitud			varchar(30)  not null
);

create table IntegranteJdV(
	IntegranteId  int	not null primary key identity(1,1),
	UsuarioId	int	not null references Usuario(UsuarioId) unique,
	JuntaDeVecinosId	int	not null references JuntaDeVecinos(JuntaDeVecinosId),
	RolId	int	not null references Rol(RolId)
);

create table Cargo(
	CargoId  int	not null primary key identity(1,1),
	Descripccion  varchar(20) not null
);

create table EntidadMunicipal(
	EntidadMunicipalId  int	not null primary key identity(1,1),
	CargoId	int	not null references Cargo(CargoId),
	TipoDocumentoId int	not null references TipoDocumento(TipoDocumentoId),
	MunicipioId	int not null references Municipio(MunicipioId),
	Nombres		varchar(30) not null,
	Apellidos	varchar(30) not null,
	Documento	varchar(15) not null unique,
	Telefono	varchar(11) not null
);
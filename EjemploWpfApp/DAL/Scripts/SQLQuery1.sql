Create Database PersonasDb
go

Use PersonasDb
Go

Create Table Personas
(
PersonaId int primary key identity,
Nombres varchar(30),
Telefono varchar(13),
Cedula varchar(11),
Direccion varchar(max),
FechaNacimiento Date default GetDate(),
);
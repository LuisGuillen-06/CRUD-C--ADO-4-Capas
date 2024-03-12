--Insertar Datos

Create proc SP_Mostrar
as
select * from Personas

-- Insertar Datos

create proc SP_Insertar
@ID int,
@Nombre nvarchar(30),
@Apellido nvarchar(30),
@Sexo nvarchar (12)
as
insert into Personas values (@ID,@Nombre,@Apellido,@Sexo)
go

--Actualizar Datos

create proc SP_Modificar
@ID int,
@Nombre nvarchar(30),
@Apellido nvarchar(30),
@Sexo nvarchar (12)
as
update Personas set Nombre = @Nombre, Apellido = @Apellido, Sexo = @Sexo
where ID = @ID
go

--Eliminar Dato del Registro

create proc SP_Eliminar
@ID int
as
delete Personas where ID = @ID
go

--Buscar Datos

create proc SP_Buscar
@Buscar nvarchar(30)
as
select * from Personas
where Nombre LIKE @Buscar + '%'
go
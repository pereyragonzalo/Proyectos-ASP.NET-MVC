use Negocios2022

create or alter procedure spU_Listar_Clientes
as
select c.IdCliente,c.NombreCia, c.Direccion, p.NombrePais, c.Telefono
	from Clientes c
	inner join paises p on c.Idpais = p.Idpais
go
spU_Listar_Clientes
-----------------------------------------------------------------------------------------------------

 create or alter procedure spU_Listar_Productos
 as
 select p.IdProducto, p.NomProducto, c.NombreCategoria, p.PrecioUnidad, p.UnidadesEnExistencia
	from Productos p 
	inner join Categorias c on p.IdCategoria = c.IdCategoria
go

spU_Listar_Productos
-----------------------------------------------------------------------------------------------------

create or alter procedure spU_Pedidos_Year
@y int
as
select pedidoscabe.IdPedido, pedidoscabe.FechaPedido, Clientes.NombreCia, pedidoscabe.DirDestinatario, pedidoscabe.CiuDestinatario
	from Clientes 
	INNER JOIN pedidoscabe on Clientes.IdCliente = pedidoscabe.IdCliente
		where YEAR(pedidoscabe.FechaPedido) = @y
go
spU_Pedidos_Year 1996
---------------------------------------------------------------------------------------------------------------------------------------

create or alter procedure spU_Pedidos_Entre_Fechas
@f1 date, @f2 date
as
select pedidoscabe.IdPedido, pedidoscabe.FechaPedido, Clientes.NombreCia, pedidoscabe.DirDestinatario, pedidoscabe.CiuDestinatario
	from Clientes 
	INNER JOIN pedidoscabe on Clientes.IdCliente = pedidoscabe.IdCliente
		where pedidoscabe.FechaPedido between @f1 and @f2
go
spU_Pedidos_Entre_Fechas '04-10-2010', '05-10-2010'
---------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE spU_Listar_Clientes
AS
SELECT Clientes.IdCliente, Clientes.NombreCia, Clientes.Direccion, paises.NombrePais, Clientes.Telefono
	FROM  Clientes 
	INNER JOIN paises ON Clientes.Idpais = paises.Idpais
GO
spU_Listar_Clientes
-----------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE spU_Listar_Productos
AS
SELECT Productos.IdProducto, Productos.NomProducto, Categorias.NombreCategoria, Productos.PrecioUnidad, Productos.UnidadesEnExistencia
	FROM Productos 
	INNER JOIN Categorias ON Productos.IdCategoria = Categorias.IdCategoria
GO
spU_Listar_Productos
-----------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER  PROCEDURE spU_Pedidos_General
AS
SELECT pedidoscabe.IdPedido, pedidoscabe.FechaPedido, Clientes.NombreCia, pedidoscabe.DirDestinatario, pedidoscabe.CiuDestinatario
	FROM   Clientes
	INNER JOIN pedidoscabe ON Clientes.IdCliente = pedidoscabe.IdCliente
GO

spU_Pedidos_General
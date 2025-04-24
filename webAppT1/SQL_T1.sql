use Northwind

create or alter procedure usp_Consulta_pedidos_Cliente 
@y varchar(40)
as
SELECT c.company_name, o.order_id, o.order_date, o.freight, o.ship_address, o.ship_city
	FROM orders o
	INNER JOIN customers c ON o.customer_id = c.customer_id
	where company_name like @y + '%'
go
usp_Consulta_pedidos_Cliente "A"

------------------------------------------------------------------------------------------------

create or alter procedure usp_Consulta_Pedidos_Fechas
@fec1 date, @fec2 date
as
SELECT o.order_id, o.order_date, e.last_name, e.first_name, o.freight, o.ship_address, o.ship_city
	FROM orders o
	INNER JOIN employees e ON o.employee_id = e.employee_id
		where o.order_date between @fec1 and @fec2
go
usp_Consulta_Pedidos_Fechas '04-07-1996', '08-07-1996'

---------------------------------------------------------------------------------------------------





create or alter procedure usp_Consulta_Pedidos_Anio_Empleado
@idemp int, @y int
as
SELECT o.order_id, o.order_date, o.employee_id, c.company_name, o.freight, o.ship_address, o.ship_city
	FROM orders o
	INNER JOIN customers c ON o.customer_id = c.customer_id
	WHERE o.employee_id = @idemp AND YEAR(o.order_date) = @y
go
usp_Consulta_Pedidos_Anio_Empleado 3, 1996

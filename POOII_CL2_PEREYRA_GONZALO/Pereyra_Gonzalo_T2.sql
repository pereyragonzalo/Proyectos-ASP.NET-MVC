USE Northwind
GO
--------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_Listar_Productos
AS
BEGIN
    SELECT p.ProductID, p.ProductName, p.CategoryID, p.UnitPrice, p.UnitsInStock, c.CategoryName, p.Discontinued
    FROM Products p
    INNER JOIN Categories c ON p.CategoryID = c.CategoryID;
END;

sp_Listar_Productos
GO
--------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_Listar_Categorias
AS
BEGIN
    SELECT CategoryID, CategoryName
    FROM Categories;
END;

sp_Listar_Categorias
GO
--------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_Agregar_Producto
    @ProductName NVARCHAR(40),
    @CategoryID INT,
    @UnitPrice MONEY,
    @UnitsInStock SMALLINT
AS
BEGIN
    INSERT INTO Products (ProductName, CategoryID, UnitPrice, UnitsInStock)
    VALUES (@ProductName, @CategoryID, @UnitPrice, @UnitsInStock);
END;
GO
--------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_Actualizar_Producto
    @ProductID INT,
    @ProductName NVARCHAR(40),
    @CategoryID INT,
    @UnitPrice MONEY,
    @UnitsInStock SMALLINT
AS
BEGIN
    UPDATE Products SET 
        ProductName = @ProductName,
        CategoryID = @CategoryID,
        UnitPrice = @UnitPrice,
        UnitsInStock = @UnitsInStock
    WHERE ProductID = @ProductID;
END;
GO
--------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_Eliminar_Producto
    @ProductID INT
AS
BEGIN
    UPDATE Products
    SET Discontinued = 1
    WHERE ProductID = @ProductID;
END;
GO

CREATE OR ALTER PROC spU_Cargar_Proveedores
AS
	SELECT IdProveedor, NomProveedor FROM Proveedores
	ORDER BY NomProveedor
GO
spU_Cargar_Proveedores
GO
--------------------------------------------------------------
CREATE TABLE Insumos(
	idInsumo		INT	PRIMARY KEY,
	nomInsumo		VARCHAR(40),
	IdProveedor		INT 
			REFERENCES Proveedores(IdProveedor),
	preUnitario		DECIMAL(10,2),
	stockUnitario	SMALLINT,
	flagEstado		CHAR(1)
)
GO
--------------------------------------------------------------
CREATE OR ALTER PROC sp_Insertar_Insumos
@idInsumo		INT,
@nomInsumo		VARCHAR(40),
@IdProveedor	INT,
@preUnitario	DECIMAL(10,2),
@stockUnitario	SMALLINT
AS
	INSERT INTO Insumos(idInsumo,nomInsumo,IdProveedor,preUnitario,stockUnitario, flagEstado)
		VALUES(@idInsumo,@nomInsumo,@IdProveedor,@preUnitario,@stockUnitario,'1')
GO

sp_Insertar_Insumos 1,'LIMÓN PIURANITO', 5, 1.9, 5000
SELECT * FROM Insumos
GO

--------------------------------------------------------------
CREATE OR ALTER PROC sp_Alterar_Insumos
@idInsumo		INT,
@nomInsumo		VARCHAR(40),
@IdProveedor	INT,
@preUnitario	DECIMAL(10,2),
@stockUnitario	SMALLINT
AS
	UPDATE Insumos SET 
			nomInsumo		= @nomInsumo,
			IdProveedor		= @IdProveedor,
			preUnitario		= @preUnitario,
			stockUnitario	= @stockUnitario
		WHERE idInsumo = @idInsumo
GO

sp_Alterar_Insumos 1,'LIMÓN CHANCHAMAYITO', 5, 1.9, 5000
SELECT * FROM Insumos
GO

--------------------------------------------------------------
CREATE OR ALTER PROC sp_Eliminar_Insumos
@idInsumo		INT
AS
	UPDATE Insumos SET flagEstado = '0'
		WHERE idInsumo = @idInsumo
GO

sp_Eliminar_Insumos 1
SELECT * FROM Insumos
GO

CREATE OR ALTER PROC spU_Listar_Insumos
AS
	SELECT Insumos.idInsumo, Insumos.nomInsumo, 
		   Proveedores.NomProveedor, Insumos.preUnitario, Insumos.stockUnitario
	FROM Proveedores 
	INNER JOIN Insumos ON Proveedores.IdProveedor = Insumos.IdProveedor
	WHERE Insumos.flagEstado = '1'
GO

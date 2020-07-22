CREATE DATABASE Store
GO
USE Store

CREATE TABLE Productos 
(
Id int identity (1,1) primary key,
Nombre nvarchar (100),
Descripcion nvarchar (100),
Marca nvarchar (100),
Precio float,
Stock int
)

INSERT INTO Productos 
VALUES
('Gaseosa','3 litros','marcacola',7.5,24),
('Chocolate','Tableta 100 gramos','iberica',12.5,36)

SELECT * FROM Productos

---PROCEDIMIENTOS ALMACENADOS 
------------MOSTRAR-----------
CREATE PROCEDURE spMostrarProductos
AS
SELECT * FROM Productos
GO
--EXEC spMostrarProductos
------------INSERTAR---------
CREATE PROCEDURE spInsetarProductos
@nombre nvarchar (100),
@descrip nvarchar (100),
@marca nvarchar (100),
@precio float,
@stock int
AS
INSERT INTO Productos VALUES (@nombre,@descrip,@marca,@precio,@stock)
GO
--EXEC spInsetarProductos 

------------ELIMINAR----------
CREATE PROCEDURE spEliminarProducto
@idpro int
AS
DELETE FROM  Productos WHERE Id=@idpro
GO
--EXEC spEliminarProducto
------------EDITAR------------
CREATE PROCEDURE spEditarProductos
@nombre nvarchar (100),
@descrip nvarchar (100),
@marca nvarchar (100),
@precio float,
@stock int,
@id int
AS
UPDATE Productos SET Nombre=@nombre, Descripcion=@descrip, Marca=@marca, Precio=@precio, Stock=@stock WHERE Id=@id
GO
--EXEC spEditarProductos
CREATE DATABASE TestSol
USE TestSol
GO
CREATE TABLE Area(IdArea TINYINT PRIMARY KEY IDENTITY(1,1),
				  Nombre VARCHAR(100))

INSERT INTO Area (Nombre) VALUES('Dirección')
INSERT INTO Area (Nombre) VALUES('Recursos Humanos')
INSERT INTO Area (Nombre) VALUES('Contabilidad')
INSERT INTO Area (Nombre) VALUES('Marketing')
INSERT INTO Area (Nombre) VALUES('Atención al Cliente')
INSERT INTO Area (Nombre) VALUES('Tecnología')

GO

CREATE TABLE Empleado(IdEmpleado INT PRIMARY KEY IDENTITY(1,1),
					  Nombre VARCHAR(50),
					  ApellidoPaterno VARCHAR(50),
					  ApellidoMaterno VARCHAR(50),
					  IdArea TINYINT FOREIGN KEY REFERENCES Area(IdArea),
					  FechaDeNacimiento DATE,
					  Sueldo DECIMAL(8,2))

SELECT * FROM Empleado
INSERT INTO Empleado(Nombre,ApellidoPaterno,ApellidoMaterno,IdArea,FechaDeNacimiento,Sueldo) VALUES('Isaac','Espinoza','Ocampo',1,CONVERT(DATE,'10-10-1998',105),18000)
GO

DROP TABLE Empleado




CREATE PROCEDURE AreaGetAll
AS
	SELECT IdArea,
		   Nombre
		   FROM Area
GO

ALTER PROCEDURE EmpleadoAdd
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@IdArea TINYINT,
@FechaDeNacimiento VARCHAR(10),
@Sueldo DECIMAL(8,2)
AS
	INSERT INTO Empleado(Nombre,ApellidoPaterno,ApellidoMaterno,IdArea,FechaDeNacimiento,Sueldo)
	VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@IdArea,CONVERT(DATE,@FechaDeNacimiento,105),@Sueldo)
GO

ALTER PROCEDURE EmpleadoGetAll
AS
	SELECT	IdEmpleado,
			Empleado.Nombre,
			ApellidoPaterno,
			ApellidoMaterno,
			Empleado.IdArea,
			Area.Nombre AS NombreArea,
			CONVERT(DATE,FechaDeNacimiento,105) AS FechaDeNacimiento,
			Sueldo
			FROM Empleado
			INNER JOIN Area ON Empleado.IdArea = Area.IdArea

GO

ALTER PROCEDURE EmpleadoGetById
@IdEmpleado INT
AS
	SELECT	IdEmpleado,
			Empleado.Nombre,
			ApellidoPaterno,
			ApellidoMaterno,
			Empleado.IdArea,
			Area.Nombre AS NombreArea,
			CONVERT(DATE,FechaDeNacimiento,105) AS FechaDeNacimiento,
			Sueldo
			FROM Empleado
			INNER JOIN Area ON Empleado.IdArea = Area.IdArea
			WHERE Empleado.IdEmpleado = @IdEmpleado

GO

CREATE PROCEDURE EmpleadoDelete
@IdEmpleado INT
AS
	DELETE FROM Empleado WHERE IdEmpleado = @IdEmpleado

GO

ALTER PROCEDURE EmpleadoUpdate
@IdEmpleado INT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@IdArea TINYINT,
@FechaDeNacimiento VARCHAR(10),
@Sueldo DECIMAL(8,2)

AS
	UPDATE Empleado SET Nombre=@Nombre,
						ApellidoPaterno=@ApellidoPaterno,
						ApellidoMaterno=@ApellidoMaterno,
						IdArea=@IdArea,
						FechaDeNacimiento=@FechaDeNacimiento,
						Sueldo=@Sueldo
						WHERE IdEmpleado = @IdEmpleado
GO
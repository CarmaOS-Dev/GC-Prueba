CREATE DATABASE IF NOT EXISTS 'GC-Empleados' /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE 'GC-Empleados';
-----------------------------------------------------------
CREATE TABLE 'T-EMPLEADOS';
(
    'Id_NumEmp' INT NOT NULL AUTO_INCREMENT,
    'Nombre' VARCHAR(50) NOT NULL,
    'Apellidos' VARCHAR(50) NOT NULL,
    'Edad' INT NOT NULL,
    'Puesto' INT NOT NULL,
    'Estatus' VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Empleado PRIMARY KEY ('Id_NumEmp')
);

CREATE TABLE 'T-CAT-PUESTOS';
(
    'Id_Puesto' INT NOT NULL AUTO_INCREMENT,
    'Puesto' VARCHAR(50) NOT NULL,
    'Descripcion' VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Puesto PRIMARY KEY ('Id_Puesto')
);

ALTER TABLE 'T-EMPLEADOS' ADD CONSTRAINT FK_Empleado_Puesto FOREIGN KEY ('Puesto') REFERENCES 'T-CAT-PUESTOS' ('Id_Puesto');
-----------------------------------------------------------
INSERT INTO 'T-CAT-PUESTOS' ('Puesto', 'Descripcion') VALUES ('Gerente', 'Encargado de la administración de la empresa');
INSERT INTO 'T-CAT-PUESTOS' ('Puesto', 'Descripcion') VALUES ('Supervisor', 'Encargado de supervisar el trabajo de los empleados');
INSERT INTO 'T-CAT-PUESTOS' ('Puesto', 'Descripcion') VALUES ('Empleado', 'Encargado de realizar las actividades asignadas');
-----------------------------------------------------------
INSERT INTO 'T-EMPLEADOS' ('Nombre', 'Apellidos', 'Edad', 'Puesto', 'Estatus') VALUES ('Juan', 'Perez', 30, 1, 'Activo');
INSERT INTO 'T-EMPLEADOS' ('Nombre', 'Apellidos', 'Edad', 'Puesto', 'Estatus') VALUES ('Maria', 'Lopez', 25, 2, 'Activo');
INSERT INTO 'T-EMPLEADOS' ('Nombre', 'Apellidos', 'Edad', 'Puesto', 'Estatus') VALUES ('Pedro', 'Ramirez', 20, 3, 'Activo');
INSERT INTO 'T-EMPLEADOS' ('Nombre', 'Apellidos', 'Edad', 'Puesto', 'Estatus') VALUES ('Ana', 'Garcia', 35, 3, 'Activo');
INSERT INTO 'T-EMPLEADOS' ('Nombre', 'Apellidos', 'Edad', 'Puesto', 'Estatus') VALUES ('Luis', 'Martinez', 40, 3, 'Activo');
INSERT INTO 'T-EMPLEADOS' ('Nombre', 'Apellidos', 'Edad', 'Puesto', 'Estatus') VALUES ('Rosa', 'Gonzalez', 45, 3, 'Activo');
INSERT INTO 'T-EMPLEADOS' ('Nombre', 'Apellidos', 'Edad', 'Puesto', 'Estatus') VALUES ('Carlos', 'Hernandez', 50, 3, 'Activo');
-----------------------------------------------------------
CREATE PROCEDURE dbo.SP_CONSULTA_EMPLEADOS
(
      @Puesto INT = NULL
)
AS
BEGIN
    SELECT E.Id_NumEmp, E.Nombre, E.Apellidos, E.Edad, P.Puesto, E.Estatus
    FROM T-EMPLEADOS E
    INNER JOIN T-CAT-PUESTOS P ON E.Puesto = P.Id_Puesto
    WHERE P.Id_Puesto = @Puesto OR @Puesto IS NULL;
END;
-----------------------------------------------------------
CREATE PROCEDURE dbo.SP_CONSULTA_PUESTOS
(
      @Id_Puesto INT = NULL
)
AS
BEGIN
    SELECT Id_Puesto, Puesto, Descripcion
    FROM T-CAT-PUESTOS
    WHERE Id_Puesto = @Id_Puesto OR @Id_Puesto IS NULL;
END;
-----------------------------------------------------------
CREATE PROCEDURE dbo.SP_INSERTA_EMPLEADO
(
      @Nombre VARCHAR(50),
      @Apellidos VARCHAR(50),
      @Edad INT,
      @Puesto INT,
      @Estatus VARCHAR(50)
)
AS
BEGIN
    INSERT INTO T-EMPLEADOS (Nombre, Apellidos, Edad, Puesto, Estatus)
    VALUES (@Nombre, @Apellidos, @Edad, @Puesto, @Estatus);
END;
-----------------------------------------------------------
CREATE PROCEDURE dbo.SP_INSERTA_PUESTO
(
      @Puesto VARCHAR(50),
      @Descripcion VARCHAR(50)
)
AS
BEGIN
    INSERT INTO T-CAT-PUESTOS (Puesto, Descripcion)
    VALUES (@Puesto, @Descripcion);
END;
-----------------------------------------------------------
CREATE PROCEDURE dbo.SP_ACTUALIZA_EMPLEADO
(
      @Id_NumEmp INT,
      @Nombre VARCHAR(50),
      @Apellidos VARCHAR(50),
      @Edad INT,
      @Puesto INT,
      @Estatus VARCHAR(50)
)
AS
BEGIN
    UPDATE T-EMPLEADOS
    SET Nombre = @Nombre, Apellidos = @Apellidos, Edad = @Edad, Puesto = @Puesto, Estatus = @Estatus
    WHERE Id_NumEmp = @Id_NumEmp;
END;
-----------------------------------------------------------
CREATE PROCEDURE dbo.SP_ACTUALIZA_PUESTO
(
      @Id_Puesto INT,
      @Puesto VARCHAR(50),
      @Descripcion VARCHAR(50)
)
AS
BEGIN
    UPDATE T-CAT-PUESTOS
    SET Puesto = @Puesto, Descripcion = @Descripcion
    WHERE Id_Puesto = @Id_Puesto;
END;
-----------------------------------------------------------
CREATE PROCEDURE dbo.SP_ELIMINA_EMPLEADO
(
      @Id_NumEmp INT
)
AS
BEGIN
    DELETE FROM T-EMPLEADOS
    WHERE Id_NumEmp = @Id_NumEmp;
END;
-----------------------------------------------------------
CREATE PROCEDURE dbo.SP_ELIMINA_PUESTO
(
      @Id_Puesto INT
)
AS
BEGIN
    DELETE FROM T-CAT-PUESTOS
    WHERE Id_Puesto = @Id_Puesto;
END;
-----------------------------------------------------------
```
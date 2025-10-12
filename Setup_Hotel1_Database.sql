-- ============================================
-- Script de Configuración para Base de Datos Hotel1
-- Sistema de Gestión Hotelera - Hotel California
-- ============================================

USE Hotel1;
GO

-- ============================================
-- 1. CREAR TABLA ROL
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rol]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Rol] (
        [id_rol] INT PRIMARY KEY IDENTITY(1,1),
        [nombre_rol] NVARCHAR(50) NOT NULL UNIQUE
    );
    PRINT 'Tabla Rol creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'Tabla Rol ya existe.';
END
GO

-- ============================================
-- 2. INSERTAR ROLES PREDETERMINADOS
-- ============================================
IF NOT EXISTS (SELECT * FROM Rol WHERE nombre_rol = 'Administrador')
BEGIN
    INSERT INTO Rol (nombre_rol) VALUES ('Administrador');
    PRINT 'Rol Administrador insertado.';
END

IF NOT EXISTS (SELECT * FROM Rol WHERE nombre_rol = 'Supervisor')
BEGIN
    INSERT INTO Rol (nombre_rol) VALUES ('Supervisor');
    PRINT 'Rol Supervisor insertado.';
END

IF NOT EXISTS (SELECT * FROM Rol WHERE nombre_rol = 'Recepcion')
BEGIN
    INSERT INTO Rol (nombre_rol) VALUES ('Recepcion');
    PRINT 'Rol Recepcion insertado.';
END
GO

-- ============================================
-- 3. CREAR TABLA EMPLEADO
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Empleado]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Empleado] (
        [legajo] INT PRIMARY KEY IDENTITY(1,1),
        [nombre] NVARCHAR(50) NOT NULL,
        [apellido] NVARCHAR(50) NOT NULL,
        [telefono] NVARCHAR(20),
        [email] NVARCHAR(100),
        [activo] BIT NOT NULL DEFAULT 1
    );
    PRINT 'Tabla Empleado creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'Tabla Empleado ya existe.';
END
GO

-- ============================================
-- 4. CREAR TABLA USUARIO
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Usuario] (
        [id_usuario] INT PRIMARY KEY IDENTITY(1,1),
        [username] NVARCHAR(50) NOT NULL UNIQUE,
        [password] NVARCHAR(255) NOT NULL,
        [id_rol] INT NOT NULL,
        [legajo] INT,
        [activo] BIT NOT NULL DEFAULT 1,
        CONSTRAINT FK_Usuario_Rol FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
        CONSTRAINT FK_Usuario_Empleado FOREIGN KEY (legajo) REFERENCES Empleado(legajo)
    );
    PRINT 'Tabla Usuario creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'Tabla Usuario ya existe.';
END
GO

-- ============================================
-- 5. CREAR ÍNDICES PARA MEJORAR RENDIMIENTO
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Usuario_Username')
BEGIN
    CREATE INDEX IX_Usuario_Username ON Usuario(username);
    PRINT 'Índice IX_Usuario_Username creado.';
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Usuario_Activo')
BEGIN
    CREATE INDEX IX_Usuario_Activo ON Usuario(activo);
    PRINT 'Índice IX_Usuario_Activo creado.';
END
GO

-- ============================================
-- 6. INSERTAR USUARIOS DE PRUEBA
-- ============================================

-- Usuario Administrador
DECLARE @legajo_admin INT;

IF NOT EXISTS (SELECT * FROM Empleado WHERE email = 'admin@hotelcalifornia.com')
BEGIN
    INSERT INTO Empleado (nombre, apellido, telefono, email, activo)
    VALUES ('Administrador', 'del Sistema', '011-0000-0000', 'admin@hotelcalifornia.com', 1);
    
    SET @legajo_admin = SCOPE_IDENTITY();
    
    INSERT INTO Usuario (username, password, id_rol, legajo, activo)
    VALUES ('admin', 'admin123', 1, @legajo_admin, 1);
    
    PRINT 'Usuario administrador creado: admin / admin123';
END
ELSE
BEGIN
    PRINT 'Usuario administrador ya existe.';
END
GO

-- Usuario Supervisor
DECLARE @legajo_supervisor INT;

IF NOT EXISTS (SELECT * FROM Empleado WHERE email = 'supervisor@hotelcalifornia.com')
BEGIN
    INSERT INTO Empleado (nombre, apellido, telefono, email, activo)
    VALUES ('Carlos', 'Supervisor', '011-1111-1111', 'supervisor@hotelcalifornia.com', 1);
    
    SET @legajo_supervisor = SCOPE_IDENTITY();
    
    INSERT INTO Usuario (username, password, id_rol, legajo, activo)
    VALUES ('supervisor1', 'super123', 2, @legajo_supervisor, 1);
    
    PRINT 'Usuario supervisor creado: supervisor1 / super123';
END
ELSE
BEGIN
    PRINT 'Usuario supervisor ya existe.';
END
GO

-- Usuario Recepcionista
DECLARE @legajo_recepcion INT;

IF NOT EXISTS (SELECT * FROM Empleado WHERE email = 'recepcion@hotelcalifornia.com')
BEGIN
    INSERT INTO Empleado (nombre, apellido, telefono, email, activo)
    VALUES ('María', 'Recepcionista', '011-2222-2222', 'recepcion@hotelcalifornia.com', 1);
    
    SET @legajo_recepcion = SCOPE_IDENTITY();
    
    INSERT INTO Usuario (username, password, id_rol, legajo, activo)
    VALUES ('recepcion1', 'recepcion123', 3, @legajo_recepcion, 1);
    
    PRINT 'Usuario recepcionista creado: recepcion1 / recepcion123';
END
ELSE
BEGIN
    PRINT 'Usuario recepcionista ya existe.';
END
GO

-- ============================================
-- 7. VERIFICAR DATOS INSERTADOS
-- ============================================
PRINT '';
PRINT '============================================';
PRINT 'RESUMEN DE CONFIGURACIÓN';
PRINT '============================================';

SELECT 'Roles' AS Tabla, COUNT(*) AS Total FROM Rol;
SELECT 'Empleados' AS Tabla, COUNT(*) AS Total FROM Empleado;
SELECT 'Usuarios' AS Tabla, COUNT(*) AS Total FROM Usuario;

PRINT '';
PRINT '============================================';
PRINT 'USUARIOS DISPONIBLES PARA LOGIN';
PRINT '============================================';

SELECT 
    u.username AS 'Usuario',
    u.password AS 'Contraseña',
    r.nombre_rol AS 'Rol',
    e.nombre + ' ' + e.apellido AS 'Nombre Completo',
    CASE WHEN u.activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS 'Estado'
FROM Usuario u
INNER JOIN Rol r ON u.id_rol = r.id_rol
LEFT JOIN Empleado e ON u.legajo = e.legajo
ORDER BY r.id_rol;

PRINT '';
PRINT '============================================';
PRINT 'CONFIGURACIÓN COMPLETADA';
PRINT '============================================';
PRINT 'La base de datos Hotel1 está lista para usar.';
PRINT 'Puede iniciar sesión con cualquiera de los usuarios listados arriba.';
PRINT '';
PRINT 'IMPORTANTE: Las contraseñas están en texto plano.';
PRINT 'Se recomienda implementar hashing antes de producción.';
GO

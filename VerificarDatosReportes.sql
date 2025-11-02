-- =============================================
-- Script de Verificación y Datos de Prueba
-- Sistema de Reportes y Estadísticas
-- =============================================

-- =============================================
-- PARTE 1: VERIFICACIÓN DE DATOS EXISTENTES
-- =============================================

PRINT '========================================='
PRINT 'VERIFICACIÓN DE DATOS EXISTENTES'
PRINT '========================================='

-- Verificar Clientes
PRINT ''
PRINT '1. CLIENTES:'
SELECT COUNT(*) as 'Total Clientes' FROM Cliente WHERE activo = 1
SELECT TOP 5 
    id_cliente, 
nombre + ' ' + apellido as 'Nombre Completo',
    dni,
    email
FROM Cliente 
WHERE activo = 1
ORDER BY id_cliente

-- Verificar Métodos de Pago
PRINT ''
PRINT '2. MÉTODOS DE PAGO:'
SELECT * FROM MetodoPago ORDER BY id_metodoPago

-- Verificar Reservas
PRINT ''
PRINT '3. RESERVAS POR ESTADO:'
SELECT 
    CASE 
        WHEN id_estado = 1 THEN 'Confirmada'
        WHEN id_estado = 2 THEN 'En Espera'
        WHEN id_estado = 3 THEN 'Terminada'
        ELSE 'Otro'
    END as 'Estado',
    COUNT(*) as 'Cantidad',
    SUM(ISNULL(total, 0)) as 'Total Ingresos'
FROM Reserva
GROUP BY id_estado

-- Verificar Pagos
PRINT ''
PRINT '4. PAGOS POR MÉTODO:'
SELECT 
    mp.descripcion as 'Método',
    COUNT(*) as 'Cantidad',
    SUM(ISNULL(p.monto, 0)) as 'Total'
FROM Pago p
INNER JOIN MetodoPago mp ON p.id_metodoPago = mp.id_metodoPago
GROUP BY mp.descripcion
ORDER BY SUM(ISNULL(p.monto, 0)) DESC

-- Verificar Habitaciones Reservadas
PRINT ''
PRINT '5. HABITACIONES MÁS RESERVADAS (TOP 10):'
SELECT TOP 10
    th.nombre as 'Tipo Habitación',
    COUNT(*) as 'Cantidad Reservas',
    SUM(ISNULL(rh.subtotal, 0)) as 'Ingresos'
FROM ReservaHabitacion rh
INNER JOIN Habitacion h ON rh.numero_hab = h.numero_hab AND rh.piso = h.piso
INNER JOIN TipoHabitacion th ON h.id_tipo = th.id_tipo
GROUP BY th.nombre
ORDER BY COUNT(*) DESC

-- Verificar Ingresos Mensuales (año actual)
PRINT ''
PRINT '6. INGRESOS MENSUALES ' + CAST(YEAR(GETDATE()) AS VARCHAR) + ':'
SELECT 
    MONTH(fecha_inicio) as 'Mes',
    DATENAME(MONTH, fecha_inicio) as 'Nombre Mes',
    COUNT(*) as 'Cant. Reservas',
    SUM(ISNULL(total, 0)) as 'Ingresos'
FROM Reserva
WHERE YEAR(fecha_inicio) = YEAR(GETDATE())
GROUP BY MONTH(fecha_inicio), DATENAME(MONTH, fecha_inicio)
ORDER BY MONTH(fecha_inicio)

-- Verificar Top Clientes
PRINT ''
PRINT '7. TOP 10 CLIENTES:'
SELECT TOP 10
    c.nombre + ' ' + c.apellido as 'Cliente',
    c.email as 'Email',
    COUNT(*) as 'Cant. Reservas',
    SUM(ISNULL(r.total, 0)) as 'Total Gastado'
FROM Cliente c
INNER JOIN Reserva r ON c.id_cliente = r.id_cliente
GROUP BY c.nombre, c.apellido, c.email
ORDER BY COUNT(*) DESC

PRINT ''
PRINT '========================================='
PRINT 'VERIFICACIÓN COMPLETADA'
PRINT '========================================='
PRINT ''

-- =============================================
-- PARTE 2: GENERAR DATOS DE PRUEBA (OPCIONAL)
-- =============================================
-- Descomenta la sección siguiente SOLO si necesitas generar datos de prueba

/*
PRINT '========================================='
PRINT 'GENERANDO DATOS DE PRUEBA...'
PRINT '========================================='

-- Solo ejecutar si no hay suficientes datos
IF (SELECT COUNT(*) FROM Reserva) < 10
BEGIN
    PRINT 'Generando reservas de prueba...'
    
    DECLARE @ClienteId INT
    DECLARE @FechaInicio DATE
DECLARE @FechaFin DATE
    DECLARE @Total DECIMAL(10,2)
    DECLARE @i INT = 1
    
    WHILE @i <= 20
    BEGIN
-- Seleccionar cliente aleatorio
        SELECT TOP 1 @ClienteId = id_cliente FROM Cliente ORDER BY NEWID()
        
     -- Fecha aleatoria en los últimos 6 meses
        SET @FechaInicio = DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 180), GETDATE())
        SET @FechaFin = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 7) + 1, @FechaInicio)
        SET @Total = CAST((ABS(CHECKSUM(NEWID()) % 5000) + 1000) AS DECIMAL(10,2))
        
        -- Estado aleatorio (1=Confirmada, 2=En Espera, 3=Terminada)
        DECLARE @Estado INT = (ABS(CHECKSUM(NEWID()) % 3) + 1)
        
   -- Insertar reserva
        INSERT INTO Reserva (id_cliente, fecha_inicio, fecha_fin, total, id_estado)
        VALUES (@ClienteId, @FechaInicio, @FechaFin, @Total, @Estado)
        
        PRINT 'Reserva ' + CAST(@i AS VARCHAR) + ' creada'
        SET @i = @i + 1
    END
    
    PRINT 'Reservas de prueba creadas exitosamente'
END
ELSE
BEGIN
    PRINT 'Ya existen suficientes reservas'
END

-- Generar pagos de prueba
IF (SELECT COUNT(*) FROM Pago) < 10
BEGIN
    PRINT 'Generando pagos de prueba...'
    
    DECLARE @ReservaId INT
    DECLARE @Monto DECIMAL(10,2)
    DECLARE @MetodoId INT
    DECLARE @j INT = 1
    
    -- Cursor para recorrer reservas sin pago
    DECLARE curReservas CURSOR FOR
    SELECT TOP 15 id_reserva, total 
    FROM Reserva 
    WHERE id_reserva NOT IN (SELECT id_reserva FROM Pago)
    AND total > 0
    
    OPEN curReservas
    FETCH NEXT FROM curReservas INTO @ReservaId, @Monto
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Método de pago aleatorio (1-3: Efectivo, Tarjeta, Transferencia)
        SET @MetodoId = (ABS(CHECKSUM(NEWID()) % 3) + 1)
        
     -- Insertar pago
INSERT INTO Pago (id_reserva, monto, fecha, id_metodoPago)
    VALUES (@ReservaId, @Monto, GETDATE(), @MetodoId)
        
        PRINT 'Pago ' + CAST(@j AS VARCHAR) + ' creado'
        SET @j = @j + 1
  
        FETCH NEXT FROM curReservas INTO @ReservaId, @Monto
    END
    
    CLOSE curReservas
    DEALLOCATE curReservas
    
    PRINT 'Pagos de prueba creados exitosamente'
END
ELSE
BEGIN
    PRINT 'Ya existen suficientes pagos'
END

-- Generar relaciones ReservaHabitacion si faltan
IF (SELECT COUNT(*) FROM ReservaHabitacion) < 10
BEGIN
    PRINT 'Generando relaciones Reserva-Habitación de prueba...'
    
    DECLARE @NumHab INT
    DECLARE @Piso INT
    DECLARE @Subtotal DECIMAL(10,2)
    DECLARE @k INT = 1
    
    -- Cursor para reservas sin habitaciones
    DECLARE curReservasHab CURSOR FOR
    SELECT TOP 15 id_reserva, total 
    FROM Reserva 
    WHERE id_reserva NOT IN (SELECT id_reserva FROM ReservaHabitacion)
    
    OPEN curReservasHab
    FETCH NEXT FROM curReservasHab INTO @ReservaId, @Subtotal
    
  WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Seleccionar habitación aleatoria
        SELECT TOP 1 @NumHab = numero_hab, @Piso = piso 
        FROM Habitacion 
  ORDER BY NEWID()
        
        -- Insertar relación
        INSERT INTO ReservaHabitacion (id_reserva, numero_hab, piso, subtotal)
        VALUES (@ReservaId, @NumHab, @Piso, @Subtotal)
        
   PRINT 'Relación Reserva-Habitación ' + CAST(@k AS VARCHAR) + ' creada'
        SET @k = @k + 1
        
   FETCH NEXT FROM curReservasHab INTO @ReservaId, @Subtotal
    END
    
    CLOSE curReservasHab
    DEALLOCATE curReservasHab
    
    PRINT 'Relaciones creadas exitosamente'
END
ELSE
BEGIN
 PRINT 'Ya existen suficientes relaciones'
END

PRINT ''
PRINT '========================================='
PRINT 'DATOS DE PRUEBA GENERADOS'
PRINT '========================================='
*/

-- =============================================
-- PARTE 3: CONSULTAS PARA VERIFICAR REPORTES
-- =============================================

PRINT ''
PRINT '========================================='
PRINT 'CONSULTAS DE VERIFICACIÓN PARA REPORTES'
PRINT '========================================='

-- Reporte de Reservas (simulando la función GetReporteReservas)
PRINT ''
PRINT 'REPORTE DE RESERVAS (últimos 30 días):'
SELECT 
    r.id_reserva AS 'ID',
    c.nombre + ' ' + c.apellido AS 'Cliente',
    c.dni AS 'DNI',
    r.fecha_inicio AS 'Fecha Inicio',
    r.fecha_fin AS 'Fecha Fin',
    DATEDIFF(DAY, r.fecha_inicio, r.fecha_fin) AS 'Días',
    CASE 
        WHEN r.id_estado = 1 THEN 'Confirmada'
   WHEN r.id_estado = 2 THEN 'En Espera'
        WHEN r.id_estado = 3 THEN 'Terminada'
        ELSE 'Desconocido'
    END AS 'Estado',
    ISNULL(r.total, 0) AS 'Total'
FROM Reserva r
INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
WHERE r.fecha_inicio >= DATEADD(DAY, -30, GETDATE())
ORDER BY r.fecha_inicio DESC

-- Reporte de Pagos (simulando la función GetReportePagos)
PRINT ''
PRINT 'REPORTE DE PAGOS (últimos 30 días):'
SELECT 
    p.id_pago AS 'ID Pago',
    p.id_reserva AS 'Reserva',
    c.nombre + ' ' + c.apellido AS 'Cliente',
    ISNULL(p.monto, 0) AS 'Monto',
    p.fecha AS 'Fecha Pago',
    mp.descripcion AS 'Método'
FROM Pago p
INNER JOIN Reserva r ON p.id_reserva = r.id_reserva
INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
INNER JOIN MetodoPago mp ON p.id_metodoPago = mp.id_metodoPago
WHERE p.fecha >= DATEADD(DAY, -30, GETDATE())
ORDER BY p.fecha DESC

PRINT ''
PRINT '========================================='
PRINT 'SCRIPT COMPLETADO'
PRINT '========================================='

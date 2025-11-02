-- =============================================
-- TEST RÁPIDO - Verificar que la consulta funciona
-- Ejecutar esto en SQL Server Management Studio
-- =============================================

USE Hotel1
GO

PRINT '========================================='
PRINT 'TEST RÁPIDO DE CONSULTA HABITACIONES'
PRINT '========================================='

-- 1. Verificar estructura de ReservaHabitacion
PRINT ''
PRINT '1. COLUMNAS DE ReservaHabitacion:'
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ReservaHabitacion'
ORDER BY ORDINAL_POSITION

-- 2. Contar registros
PRINT ''
PRINT '2. CONTEO DE REGISTROS:'
SELECT 
    (SELECT COUNT(*) FROM TipoHabitacion) AS 'Tipos Habitación',
    (SELECT COUNT(*) FROM Habitacion) AS 'Habitaciones',
    (SELECT COUNT(*) FROM ReservaHabitacion) AS 'Reservas Habitación'

-- 3. Ejecutar la consulta CORREGIDA (la que usa la aplicación)
PRINT ''
PRINT '3. RESULTADO DE LA CONSULTA CORREGIDA:'
SELECT TOP 10
    th.nombre AS 'Tipo',
    COUNT(rh.id_reserva) AS 'Reservas',
    ISNULL(SUM(rh.subtotal), 0) AS 'Ingresos'
FROM TipoHabitacion th
INNER JOIN Habitacion h ON th.id_tipo = h.id_tipo
LEFT JOIN ReservaHabitacion rh ON h.numero_hab = rh.numero_hab
GROUP BY th.nombre
ORDER BY COUNT(rh.id_reserva) DESC

-- 4. Detalle por tipo
PRINT ''
PRINT '4. DETALLE POR TIPO DE HABITACIÓN:'
SELECT 
    th.nombre AS 'Tipo',
    COUNT(DISTINCT h.numero_hab) AS 'Cant. Habitaciones',
    COUNT(rh.id_reserva) AS 'Cant. Reservas',
    ISNULL(SUM(rh.subtotal), 0) AS 'Ingresos Totales',
    CASE 
     WHEN COUNT(rh.id_reserva) > 0 
   THEN ISNULL(SUM(rh.subtotal), 0) / COUNT(rh.id_reserva)
        ELSE 0 
    END AS 'Promedio por Reserva'
FROM TipoHabitacion th
INNER JOIN Habitacion h ON th.id_tipo = h.id_tipo
LEFT JOIN ReservaHabitacion rh ON h.numero_hab = rh.numero_hab
GROUP BY th.nombre
ORDER BY COUNT(rh.id_reserva) DESC

PRINT ''
PRINT '========================================='
PRINT 'TEST COMPLETADO'
PRINT '========================================='
PRINT ''
PRINT 'Si ves 3 tipos de habitación con sus reservas,'
PRINT 'entonces la consulta funciona correctamente.'
PRINT ''

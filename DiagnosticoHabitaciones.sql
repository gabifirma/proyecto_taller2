-- =============================================
-- SCRIPT DE DIAGNÓSTICO RÁPIDO
-- Verificar datos de Habitaciones y Tipos
-- =============================================

PRINT '========================================='
PRINT 'DIAGNÓSTICO DE HABITACIONES'
PRINT '========================================='

-- 1. Verificar Tipos de Habitación
PRINT ''
PRINT '1. TIPOS DE HABITACIÓN:'
SELECT COUNT(*) AS 'Total Tipos' FROM TipoHabitacion
SELECT * FROM TipoHabitacion

-- 2. Verificar Habitaciones
PRINT ''
PRINT '2. HABITACIONES:'
SELECT COUNT(*) AS 'Total Habitaciones' FROM Habitacion
SELECT TOP 10 
    h.numero_hab, 
    h.piso, 
    h.id_tipo,
    t.nombre AS 'Tipo',
    h.id_estado
FROM Habitacion h
LEFT JOIN TipoHabitacion t ON h.id_tipo = t.id_tipo

-- 3. Verificar ReservaHabitacion
PRINT ''
PRINT '3. RESERVAS DE HABITACIONES:'
SELECT COUNT(*) AS 'Total Reservas Habitacion' FROM ReservaHabitacion
SELECT TOP 5 * FROM ReservaHabitacion

-- VERIFICAR ESTRUCTURA DE ReservaHabitacion
PRINT ''
PRINT '3B. ESTRUCTURA DE ReservaHabitacion:'
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ReservaHabitacion'
ORDER BY ORDINAL_POSITION

-- 4. Ejecutar la consulta exacta del método GetHabitacionesPopulares (CORREGIDA)
PRINT ''
PRINT '4. CONSULTA GetHabitacionesPopulares (CORREGIDA):'
-- NOTA: ReservaHabitacion NO tiene columna 'piso', solo 'numero_hab'
SELECT TOP 10
    th.nombre AS 'Tipo',
    COUNT(rh.id_reserva) AS 'Reservas',
    ISNULL(SUM(rh.subtotal), 0) AS 'Ingresos'
FROM TipoHabitacion th
INNER JOIN Habitacion h ON th.id_tipo = h.id_tipo
LEFT JOIN ReservaHabitacion rh ON h.numero_hab = rh.numero_hab
GROUP BY th.nombre
ORDER BY COUNT(rh.id_reserva) DESC

PRINT ''
PRINT '========================================='
PRINT 'DIAGNÓSTICO COMPLETADO'
PRINT '========================================='

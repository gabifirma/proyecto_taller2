-- =============================================
-- SCRIPT CORREGIDO DE VERIFICACIÓN
-- Sistema de Reportes y Estadísticas
-- =============================================

PRINT '========================================='
PRINT 'VERIFICACIÓN DE DATOS EXISTENTES'
PRINT '========================================='

-- Verificar Clientes
PRINT ''
PRINT '1. CLIENTES:'
SELECT COUNT(*) as 'Total Clientes' FROM Cliente
SELECT TOP 5 
    id_cliente, 
    nombre + ' ' + apellido as 'Nombre Completo',
    dni,
    email
FROM Cliente 
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
-- CORREGIDO: ReservaHabitacion NO tiene columna 'piso', solo 'numero_hab'
SELECT TOP 10
    th.nombre as 'Tipo Habitación',
    COUNT(*) as 'Cantidad Reservas',
    SUM(ISNULL(rh.subtotal, 0)) as 'Ingresos'
FROM ReservaHabitacion rh
INNER JOIN Habitacion h ON rh.numero_hab = h.numero_hab
INNER JOIN TipoHabitacion th ON h.id_tipo = th.id_tipo
GROUP BY th.nombre
ORDER BY COUNT(*) DESC

-- Verificar usando LEFT JOIN (muestra TODOS los tipos aunque no tengan reservas)
PRINT ''
PRINT '5B. TODOS LOS TIPOS DE HABITACIÓN (con o sin reservas):'
SELECT 
    th.nombre as 'Tipo Habitación',
    COUNT(rh.id_reserva) as 'Cantidad Reservas',
    ISNULL(SUM(rh.subtotal), 0) as 'Ingresos'
FROM TipoHabitacion th
INNER JOIN Habitacion h ON th.id_tipo = h.id_tipo
LEFT JOIN ReservaHabitacion rh ON h.numero_hab = rh.numero_hab
GROUP BY th.nombre
ORDER BY COUNT(rh.id_reserva) DESC

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

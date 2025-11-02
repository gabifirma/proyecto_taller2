# ?? DIAGNÓSTICO: Gráfico de Habitaciones Vacío

## Problema
El gráfico de "Habitaciones Más Reservadas" muestra el mensaje "No hay datos de habitaciones" aunque existen habitaciones cargadas.

## Causa Probable
El problema puede deberse a una de estas causas:

1. **No hay tipos de habitación en la tabla `TipoHabitacion`**
2. **No hay habitaciones asociadas a tipos existentes**
3. **Error en la consulta SQL o la conexión**

## ? Solución Implementada

### 1. Corrección en `DatabaseHelper.cs`
Se modificó el método `GetHabitacionesPopulares()` para:
- Usar `LEFT JOIN` en lugar de `INNER JOIN` con `ReservaHabitacion`
- Mostrar TODOS los tipos de habitación aunque no tengan reservas
- Agregar diagnóstico detallado con `Debug.WriteLine`

**Consulta corregida:**
```sql
SELECT TOP 10
    th.nombre AS 'Tipo',
    COUNT(rh.id_reserva) AS 'Reservas',
    ISNULL(SUM(rh.subtotal), 0) AS 'Ingresos'
FROM TipoHabitacion th
INNER JOIN Habitacion h ON th.id_tipo = h.id_tipo
LEFT JOIN ReservaHabitacion rh ON h.numero_hab = rh.numero_hab AND h.piso = rh.piso
GROUP BY th.nombre
ORDER BY COUNT(rh.id_reserva) DESC
```

### 2. Diagnóstico en `FormReportesEstadisticas.cs`
Se agregó logging detallado en `GenerarGraficoHabitacionesPopulares()` para ver:
- Cantidad de filas retornadas
- Columnas disponibles
- Datos de cada fila

## ?? Cómo Diagnosticar

### Paso 1: Ejecutar Script de Diagnóstico SQL
Ejecuta el archivo `DiagnosticoHabitaciones.sql` en SQL Server Management Studio o tu herramienta de BD.

Esto verificará:
- ? Cantidad de tipos de habitación
- ? Cantidad de habitaciones
- ? Cantidad de reservas de habitaciones
- ? Resultado de la consulta exacta del método

### Paso 2: Ver Output de Debug en Visual Studio
1. Ejecuta la aplicación en **modo Debug** (F5)
2. Abre el módulo de Reportes y Estadísticas
3. Selecciona "Habitaciones Más Reservadas" y genera el gráfico
4. Ve a **Ver > Salida** (o Ctrl+Alt+O)
5. Busca líneas que empiecen con:
   ```
   [DatabaseHelper] Tipos de habitación encontrados: X
   [DatabaseHelper] Habitaciones encontradas: X
   [DatabaseHelper] Filas retornadas por la consulta: X
   === DIAGNÓSTICO HABITACIONES POPULARES ===
   ```

### Paso 3: Verificar Datos en la Base de Datos

#### Verificar Tipos de Habitación:
```sql
SELECT * FROM TipoHabitacion
```
**Debe tener al menos:**
- Single (id_tipo = 1)
- Doble (id_tipo = 2)
- Suite (id_tipo = 3)

#### Verificar Habitaciones:
```sql
SELECT COUNT(*) FROM Habitacion
SELECT TOP 5 * FROM Habitacion
```
**Debe tener habitaciones con números como 101, 102, 201, etc.**

## ?? Soluciones según el diagnóstico

### Si NO hay tipos de habitación:
```sql
-- Insertar tipos básicos
INSERT INTO TipoHabitacion (id_tipo, nombre, capacidad, descripcion, base_precio)
VALUES 
(1, 'Single', 1, 'Habitación individual', 5000.00),
(2, 'Doble', 2, 'Habitación doble', 7000.00),
(3, 'Suite', 4, 'Suite de lujo', 12000.00)
```

### Si NO hay habitaciones:
```sql
-- Insertar habitaciones de ejemplo
INSERT INTO Habitacion (numero_hab, piso, id_tipo, id_estado)
VALUES 
(101, 1, 1, 1),
(102, 1, 2, 1),
(103, 1, 3, 1),
(201, 2, 1, 1),
(202, 2, 2, 1)
```

### Si hay datos pero sigue sin mostrar:
1. Verifica que la aplicación esté conectada a la BD correcta
2. Revisa el Output de Debug para ver mensajes de error
3. Verifica que no haya excepciones silenciosas

## ?? Resultado Esperado

Después de aplicar las correcciones:

? El gráfico mostrará TODOS los tipos de habitación
? Si no tienen reservas, aparecerán con "Reservas = 0"
? Si tienen reservas, mostrará la cantidad correcta
? Ya NO aparecerá el mensaje "No hay datos"

## ?? Siguiente Paso

Ejecuta el script `DiagnosticoHabitaciones.sql` y verifica los resultados. Luego:

1. Si hay datos ? Ejecuta la app en Debug y revisa el Output
2. Si NO hay datos ? Ejecuta los INSERT de arriba
3. Si persiste el error ? Comparte el Output de Debug para más ayuda

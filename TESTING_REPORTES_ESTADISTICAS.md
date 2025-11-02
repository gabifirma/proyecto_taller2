# Guía de Pruebas - Reportes y Estadísticas

## Cambios Realizados

### 1. Correcciones en DatabaseHelper.cs
- ? **GetMetodosPago()**: Ahora obtiene los métodos de pago directamente desde la tabla `MetodoPago` de la base de datos
- ? **GetReportePagos()**: Corregido para usar JOIN con la tabla `MetodoPago` correctamente
- ? **GetEstadisticasPagosPorMetodo()**: Corregido para usar la columna `descripcion` de `MetodoPago`
- ? **GetHabitacionesPopulares()**: Verificado y funcional (obtiene TOP 10 habitaciones por tipo más reservadas)

### 2. Correcciones en FormReportesEstadisticas.cs
- ? **Filtro de métodos de pago**: Ahora utiliza comparación con "Todos" y filtra correctamente
- ? **Cálculo de totales por método**: Mejorado para usar búsqueda flexible con `Contains()` para manejar diferentes formatos de nombres
- ? **Inicialización**: Simplificado y más robusto

---

## Plan de Pruebas Completo

### PESTAÑA 1: REPORTES DE RESERVAS

#### Prueba 1.1: Búsqueda básica
1. Abrir formulario de Reportes y Estadísticas
2. Ir a pestaña "Reportes de Reservas"
3. Hacer clic en **"Buscar"** sin filtros
4. **Resultado esperado**: Debe mostrar todas las reservas del sistema

#### Prueba 1.2: Filtro por fechas
1. Marcar checkbox "Filtrar por fechas"
2. Seleccionar un rango de fechas (ej: último mes)
3. Hacer clic en **"Buscar"**
4. **Resultado esperado**: Solo reservas dentro del rango de fechas

#### Prueba 1.3: Filtro por estado
1. Seleccionar un estado específico del combo (ej: "Confirmada")
2. Hacer clic en **"Buscar"**
3. **Resultado esperado**: Solo reservas con ese estado

#### Prueba 1.4: Búsqueda por texto
1. Escribir nombre, apellido o DNI de un cliente en el campo de búsqueda
2. Hacer clic en **"Buscar"**
3. **Resultado esperado**: Solo reservas que coincidan con el texto

#### Prueba 1.5: Combinación de filtros
1. Activar filtro de fechas + seleccionar estado + escribir texto
2. Hacer clic en **"Buscar"**
3. **Resultado esperado**: Resultados que cumplan todos los criterios

#### Prueba 1.6: Cálculos y totales
1. Realizar una búsqueda con resultados
2. Verificar que aparezca:
   - **Total de registros**: ?? Total de registros: [número]
   - **Total Ingresos**: ?? Total Ingresos: [monto]
3. **Resultado esperado**: Los totales deben ser correctos

#### Prueba 1.7: Exportación
1. Realizar una búsqueda con resultados
2. Hacer clic en **"Exportar"**
3. Seleccionar formato (CSV o HTML)
4. Guardar archivo
5. **Resultado esperado**: Archivo se crea correctamente y se ofrece abrirlo

#### Prueba 1.8: Limpiar filtros
1. Aplicar varios filtros
2. Hacer clic en **"Limpiar Filtros"**
3. **Resultado esperado**: Todos los filtros se resetean

---

### PESTAÑA 2: REPORTES DE PAGOS

#### Prueba 2.1: Búsqueda básica
1. Ir a pestaña "Reportes de Pagos"
2. Hacer clic en **"Buscar"** sin filtros
3. **Resultado esperado**: Debe mostrar todos los pagos del sistema con columnas:
   - ID Pago
   - Reserva
   - Cliente
   - Monto
   - Fecha Pago
   - Método

#### Prueba 2.2: Filtro por fechas
1. Marcar checkbox "Filtrar por fechas"
2. Seleccionar un rango de fechas
3. Hacer clic en **"Buscar"**
4. **Resultado esperado**: Solo pagos dentro del rango

#### Prueba 2.3: Filtro por método de pago
1. Seleccionar "Efectivo" del combo de métodos
2. Hacer clic en **"Buscar"**
3. **Resultado esperado**: Solo pagos en efectivo
4. Repetir con "Tarjeta" y "Transferencia"

#### Prueba 2.4: Búsqueda por texto
1. Escribir nombre de cliente o ID de reserva
2. Hacer clic en **"Buscar"**
3. **Resultado esperado**: Pagos que coincidan

#### Prueba 2.5: Totales por método
1. Realizar búsqueda con múltiples métodos de pago
2. Verificar la línea de totales:
   - ?? Efectivo: [monto]
   - ?? Tarjeta: [monto]
   - ?? Transfer.: [monto]
   - ?? TOTAL: [monto total]
3. **Resultado esperado**: Los totales deben sumar correctamente

#### Prueba 2.6: Exportación de pagos
1. Realizar una búsqueda con resultados
2. Hacer clic en **"Exportar"**
3. Seleccionar formato y guardar
4. **Resultado esperado**: Archivo se exporta correctamente

#### Prueba 2.7: Limpiar filtros
1. Aplicar filtros
2. Hacer clic en **"Limpiar Filtros"**
3. **Resultado esperado**: Todo se resetea

---

### PESTAÑA 3: ESTADÍSTICAS Y GRÁFICOS

#### Prueba 3.1: Gráfico de Ocupación
1. Ir a pestaña "Estadísticas"
2. Seleccionar radio button **"Reservas por Estado"**
3. Hacer clic en **"Generar Estadísticas"**
4. **Resultado esperado**: 
   - Se muestra un gráfico de torta (pie chart)
   - Muestra cantidades por estado: Confirmada, En Espera, Terminada
   - Cada sección tiene porcentaje

#### Prueba 3.2: Gráfico de Ingresos Mensuales
1. Seleccionar radio button **"Ingresos Mensuales"**
2. Ajustar el año en el NumericUpDown
3. Hacer clic en **"Generar Estadísticas"**
4. **Resultado esperado**:
   - Gráfico de barras verticales (columnas)
   - Muestra ingresos por mes
   - Los valores están formateados como moneda

#### Prueba 3.3: Gráfico de Pagos por Método
1. Seleccionar radio button **"Pagos por Método de Pago"**
2. Hacer clic en **"Generar Estadísticas"**
3. **Resultado esperado**:
 - Gráfico de torta
   - Muestra distribución: Efectivo, Tarjeta, Transferencia
   - Cada sección muestra monto y porcentaje

#### Prueba 3.4: Gráfico de Habitaciones Populares
1. Seleccionar radio button **"Habitaciones Más Reservadas"**
2. Hacer clic en **"Generar Estadísticas"**
3. **Resultado esperado**:
   - Gráfico de barras horizontales
   - Muestra TOP 10 tipos de habitación
   - Ordenados por cantidad de reservas

#### Prueba 3.5: Exportar gráfico
1. Generar cualquier gráfico
2. Hacer clic en **"Exportar Gráfico"**
3. Seleccionar formato (PNG o JPEG)
4. Guardar archivo
5. **Resultado esperado**: Imagen se guarda correctamente

#### Prueba 3.6: Top 10 Clientes
1. Hacer clic en botón **"Top 10 Clientes"**
2. **Resultado esperado**:
   - Se abre una ventana modal
 - Muestra lista de los 10 clientes con más reservas
   - Columnas: Cliente, Email, Reservas, Total Gastado
   - Los montos están formateados

---

## Casos de Error a Probar

### Error 1: Sin datos
1. Buscar con filtros que no devuelvan resultados
2. **Resultado esperado**: Mensaje amigable "No hay datos para mostrar"

### Error 2: Fechas inválidas
1. Seleccionar fecha "Desde" mayor que fecha "Hasta"
2. Hacer clic en Buscar
3. **Resultado esperado**: Mensaje de validación

### Error 3: Exportar sin datos
1. Sin realizar búsqueda, hacer clic en "Exportar"
2. **Resultado esperado**: Mensaje "No hay datos para exportar"

### Error 4: Exportar gráfico sin generar
1. Sin generar gráfico, hacer clic en "Exportar Gráfico"
2. **Resultado esperado**: Mensaje "Primero genere un gráfico"

---

## Verificaciones en la Base de Datos

Para que todas las funciones trabajen correctamente, verifica que existan datos en:

### Tabla Reserva
```sql
SELECT COUNT(*) FROM Reserva
-- Debe tener al menos algunas reservas
```

### Tabla Pago
```sql
SELECT COUNT(*) FROM Pago
-- Debe tener pagos registrados
```

### Tabla MetodoPago
```sql
SELECT * FROM MetodoPago
-- Debe contener: Efectivo, Tarjeta de Crédito, Transferencia, etc.
```

### Tabla ReservaHabitacion
```sql
SELECT COUNT(*) FROM ReservaHabitacion
-- Debe tener relaciones entre reservas y habitaciones
```

---

## Problemas Conocidos y Soluciones

### Problema: "Top 10 Habitaciones no funciona"
**Solución aplicada**: 
- La consulta en `GetHabitacionesPopulares()` está correcta
- Verifica que existan registros en `ReservaHabitacion`
- El gráfico se genera desde los tipos de habitación más reservados

### Problema: "Métodos de pago no filtran correctamente"
**Solución aplicada**:
- Cambiado a usar la tabla `MetodoPago` directamente
- La columna `descripcion` de `MetodoPago` se usa para filtrado
- Se usa `Contains()` en lugar de `==` para mayor flexibilidad

### Problema: "Totales no cuadran en pagos"
**Solución aplicada**:
- Mejorado el cálculo usando `Contains()` para detectar el tipo de método
- Ahora funciona con cualquier formato de nombre en la descripción

---

## Checklist Final

- [ ] Todos los reportes muestran datos correctamente
- [ ] Los filtros funcionan de forma individual
- [ ] Los filtros funcionan combinados
- [ ] Los totales y cálculos son correctos
- [ ] La exportación a CSV funciona
- [ ] La exportación a HTML funciona
- [ ] Los 4 gráficos se generan correctamente
- [ ] La exportación de gráficos funciona
- [ ] El Top 10 Clientes se muestra correctamente
- [ ] Los mensajes de error son apropiados
- [ ] El formulario no tiene errores de compilación
- [ ] El scroll funciona correctamente

---

## Notas Adicionales

### Formato de Moneda
- Todos los montos se muestran con formato: `$1,234.56`
- En gráficos se usa formato simplificado: `$1,235`

### Formato de Fechas
- Todas las fechas se muestran como: `dd/MM/yyyy`
- Ejemplo: `15/01/2025`

### Performance
- Las consultas están optimizadas con índices en la BD
- El cursor cambia a "WaitCursor" durante operaciones largas
- Los botones se deshabilitan temporalmente para evitar clics múltiples

---

## Contacto para Soporte
Si encuentras algún problema durante las pruebas, revisa:
1. Los logs de Visual Studio (Output window)
2. Que la conexión a la base de datos esté activa
3. Que existan datos de prueba en las tablas relevantes

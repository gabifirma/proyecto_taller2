# ?? Guía Rápida - Testing de Reportes

## ? Verificación Rápida (5 minutos)

### 1. Reportes de Reservas ?
```
1. Abrir formulario ? Pestaña "Reportes de Reservas"
2. Click en "Buscar" (sin filtros)
3. Verificar: Se muestran reservas con totales abajo
```

### 2. Reportes de Pagos ?
```
1. Pestaña "Reportes de Pagos"
2. Click en "Buscar"
3. Verificar: Se muestran pagos con totales por método
```

### 3. Estadísticas - Habitaciones Populares ?
```
1. Pestaña "Estadísticas"
2. Seleccionar: "Habitaciones Más Reservadas"
3. Click en "Generar Estadísticas"
4. Verificar: Aparece gráfico de barras con TOP 10
```

### 4. Todos los Gráficos ??
```
Prueba cada radio button:
? Reservas por Estado ? Gráfico de torta
? Ingresos Mensuales ? Gráfico de barras
? Pagos por Método ? Gráfico de torta
? Habitaciones Más Reservadas ? Gráfico de barras horizontal
```

### 5. Top 10 Clientes ??
```
1. Click en botón "Top 10 Clientes"
2. Verificar: Se abre ventana con lista de clientes
```

---

## ?? Si algo falla

### No hay datos:
```sql
-- Ejecutar en SQL Server:
SELECT COUNT(*) FROM Reserva;
SELECT COUNT(*) FROM Pago;
SELECT COUNT(*) FROM ReservaHabitacion;
```

### Generar datos de prueba:
```
1. Abrir: VerificarDatosReportes.sql
2. Descomentar sección "PARTE 2"
3. Ejecutar script
```

---

## ? Checklist Mínimo

- [ ] Reportes de Reservas muestra datos
- [ ] Reportes de Pagos muestra datos y totales
- [ ] Gráfico de Habitaciones Populares funciona
- [ ] Todos los 4 gráficos se generan
- [ ] Top 10 Clientes abre correctamente
- [ ] Exportar a CSV funciona
- [ ] Los filtros responden

---

## ?? Archivos Creados

1. **TESTING_REPORTES_ESTADISTICAS.md** - Guía completa de pruebas
2. **VerificarDatosReportes.sql** - Script de verificación
3. **RESUMEN_CORRECCIONES.md** - Documentación técnica
4. **QUICK_TEST.md** (este archivo) - Referencia rápida

---

## ?? Correcciones Aplicadas

| Función | Estado | Fix |
|---------|--------|-----|
| GetMetodosPago() | ? | Ahora lee desde BD |
| GetReportePagos() | ? | JOIN correcto con MetodoPago |
| GetHabitacionesPopulares() | ? | Ya estaba correcto, verificado |
| Filtro de pagos | ? | Comparación mejorada |
| Totales por método | ? | Usa Contains() |

---

## ?? Comandos Útiles

### Ver estado de datos:
```sql
-- Copiar y pegar en SQL Server Management Studio
SELECT 'Reservas' as Tabla, COUNT(*) as Total FROM Reserva
UNION ALL
SELECT 'Pagos', COUNT(*) FROM Pago
UNION ALL
SELECT 'Reserva-Hab', COUNT(*) FROM ReservaHabitacion
```

### Verificar métodos de pago:
```sql
SELECT * FROM MetodoPago
```

---

## ?? Problemas Comunes

### "Top 10 Habitaciones no muestra nada"
**Causa**: No hay datos en ReservaHabitacion
**Solución**: Ejecutar script de prueba o verificar BD

### "Filtro de método no funciona"
**Causa**: Ya está corregido en el código
**Solución**: Recompilar proyecto

### "Exportar no hace nada"
**Causa**: No hay datos en el grid
**Solución**: Hacer búsqueda primero

---

## ? Resultado Esperado

Todas las funciones de reportes y estadísticas deben:
- ? Mostrar datos correctamente
- ? Filtrar apropiadamente
- ? Calcular totales precisos
- ? Generar gráficos visuales
- ? Exportar a CSV/HTML
- ? Manejar errores elegantemente

---

**¡Listo para probar!** ??

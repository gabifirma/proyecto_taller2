# Hotel California - Sistema de Gestión Hotelera

Sistema de gestión hotelera desarrollado en C# con Windows Forms que incluye autenticación basada en roles, gestión de reservas y pagos con datos en memoria.

## Características Implementadas

- **Autenticación por roles**: Administrador, Supervisor, Recepcionista
- **Menú de navegación dinámico** según el rol del usuario
- **Sistema de reservas** con validaciones y datos de ejemplo
- **Sistema de pagos** vinculado a reservas
- **Gestión de empleados, habitaciones y clientes**
- **Datos en memoria** para reservas y pagos (sin persistencia en BD)
- **Interfaz actualizada** con encabezado dinámico y botón de cierre de sesión

## Credenciales de Acceso

### Administrador (Acceso completo)
- **Usuario**: `admin`
- **Contraseña**: `admin123`
- **Permisos**: Todos los módulos disponibles

### Supervisor (Acceso a empleados y reservas)
- **Usuario**: `supervisor1`
- **Contraseña**: `super123`
- **Permisos**: Empleados, Reservas, Pagos, Clientes, Habitaciones

### Recepcionista (Sin acceso a empleados)
- **Usuario**: `recepcion1`
- **Contraseña**: `recepcion123`
- **Permisos**: Reservas, Pagos, Clientes, Habitaciones (NO Empleados)

## Datos de Ejemplo Precargados

### Reservas (3 registros)
1. **R1** - Juan Pérez - Check-In: 10/09/2025 - Check-Out: 12/09/2025 - Habitación Doble - Estado: Anulada - $1,200.00
2. **R2** - María Gómez - Check-In: 05/10/2025 - Check-Out: 08/10/2025 - Suite - Estado: Confirmada - $4,500.00
3. **R3** - Carlos Ruiz - Check-In: 01/11/2025 - Check-Out: 03/11/2025 - Habitación Individual - Estado: Pendiente - $900.00

### Pagos (3 registros)
1. **P1** - Reserva R1 - Fecha: 09/09/2025 - $1,200.00 - Tarjeta - Estado: Reembolsado
2. **P2** - Reserva R2 - Fecha: 30/09/2025 - $4,500.00 - Efectivo - Estado: Confirmado
3. **P3** - Reserva R3 - Fecha: 30/10/2025 - $900.00 - Transferencia - Estado: Pendiente

## Ubicación de Datos en Memoria

Los datos se inicializan automáticamente en:
- **Archivo**: `Services/DataService.cs`
- **Método**: `InitializeData()`
- **Clases de modelo**: `Models/Reserva.cs` y `Models/Pago.cs`

## Cómo Ejecutar la Aplicación

### Opción 1: Usar el archivo compilar.bat
```bash
cd "Proyecto_Hotel_California"
compilar.bat
```

### Opción 2: Compilar manualmente
```bash
cd "Proyecto_Hotel_California"
csc /target:winexe /reference:System.Windows.Forms.dll,System.Drawing.dll *.cs Models\*.cs Services\*.cs
```

### Opción 3: Visual Studio
1. Abrir `Proyecto_Hotel_California.sln`
2. Presionar F5 o Build > Start Debugging

## Funcionalidades por Módulo

### Reservas
- **Crear Nueva Reserva**: Formulario con validaciones completas
- **Filtros**: Por cliente, rango de fechas, estado
- **Validaciones**: Fechas, disponibilidad, campos obligatorios
- **Ver Pagos**: Desde la vista de reservas

### Pagos
- **Registrar Nuevo Pago**: Vinculado a reservas existentes
- **Filtros**: Por cliente, fecha, estado, método de pago
- **Validaciones**: Monto, compatibilidad con reserva
- **Vista Integrada**: Muestra cliente asociado a cada pago

### Autenticación
- **Login**: Validación de credenciales
- **Sesiones**: Manejo de estado del usuario
- **Cierre de Sesión**: Botón siempre visible, limpia estado
- **Permisos**: Control de acceso por rol

## Checklist de Pruebas

### ✅ Autenticación y Roles
- [x] Login con credenciales de Administrador muestra todos los módulos
- [x] Login con credenciales de Supervisor muestra todos los módulos
- [x] Login con credenciales de Recepcionista NO muestra "Ver Empleados"
- [x] Encabezado muestra "Hotel California — ROL_ACTUAL"
- [x] Botón "Cerrar Sesión" limpia estado y redirige a Login

### ✅ Reservas
- [x] Se cargan 3 reservas de ejemplo al iniciar
- [x] Filtro por cliente funciona correctamente
- [x] Filtro por rango de fechas funciona correctamente
- [x] Filtro por estado funciona correctamente
- [x] Botón "Nueva Reserva" abre formulario de creación
- [x] Formulario de creación tiene todas las validaciones
- [x] Se puede ver pagos asociados desde "Ver Pagos"

### ✅ Pagos
- [x] Se cargan 3 pagos de ejemplo al iniciar
- [x] Filtro por cliente funciona correctamente
- [x] Filtro por fecha funciona correctamente
- [x] Filtro por estado funciona correctamente
- [x] Filtro por método de pago funciona correctamente
- [x] Botón "Nuevo Pago" abre formulario de creación
- [x] Formulario vincula pagos a reservas existentes

### ✅ Validaciones y UX
- [x] Campos obligatorios muestran mensajes de error
- [x] Validaciones de fechas funcionan correctamente
- [x] Botones se bloquean durante procesamiento
- [x] Mensajes de confirmación se muestran correctamente
- [x] Colores de estado en las grillas funcionan

### ✅ Interfaz
- [x] Tipografía y estilos se mantienen consistentes
- [x] No hay espacios vacíos innecesarios
- [x] Elementos están bien alineados
- [x] Formularios tienen tamaño apropiado

## Arquitectura del Proyecto

```
Proyecto_Hotel_California/
├── Models/
│   ├── Reserva.cs          # Modelo de datos para reservas
│   └── Pago.cs             # Modelo de datos para pagos
├── Services/
│   └── DataService.cs      # Servicio de datos en memoria
├── Forms/
│   ├── LoginForm.cs        # Formulario de login
│   ├── Main.cs             # Formulario principal con menú
│   ├── Reservas.cs         # Gestión de reservas
│   ├── Pagos.cs            # Gestión de pagos
│   ├── CrearReservaForm.cs # Crear nueva reserva
│   └── CrearPagoForm.cs    # Crear nuevo pago
├── UserSession.cs          # Manejo de sesión de usuario
└── Usuario.cs              # Modelo de usuario
```

## Notas Técnicas

- **Persistencia**: Los datos solo existen durante la ejecución de la aplicación
- **Validaciones**: Implementadas tanto en frontend como en lógica de negocio
- **Seguridad**: Las credenciales no están visibles en la interfaz
- **Compatibilidad**: Desarrollado para .NET Framework 4.7.2+

## Soporte

Para reportar problemas o solicitar nuevas características, contactar al equipo de desarrollo.
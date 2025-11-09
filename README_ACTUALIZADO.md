# 🏨 Hotel California - Sistema de Gestión Hotelera

**Sistema integral de gestión hotelera desarrollado en C# con Windows Forms**

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-purple.svg)
![C#](https://img.shields.io/badge/C%23-7.3-blue.svg)
![License](https://img.shields.io/badge/license-MIT-green.svg)

---

## 📋 Descripción

Hotel California es un sistema completo de gestión hotelera diseñado para administrar todas las operaciones de un hotel, desde reservas y pagos hasta la gestión de empleados y habitaciones. El sistema incluye un control de acceso basado en roles que permite diferentes niveles de permisos según el tipo de usuario.

### 🎯 Propósito

Este proyecto fue desarrollado como parte del Taller de Programación II (2025) con el objetivo de crear una aplicación de escritorio robusta que permita la gestión integral de un hotel pequeño a mediano.

---

## ✨ Características Principales

### 🔐 Sistema de Autenticación y Roles

- **Login seguro** con validación de credenciales
- **Tres niveles de acceso con permisos específicos:**

#### 🔴 Administrador - Acceso Completo
1. ✅ Gestión de Usuarios
2. ✅ Reportes y Estadísticas
3. ✅ Empleados
4. ✅ Reservas
5. ✅ Pagos
6. ✅ Clientes
7. ✅ Habitaciones
8. ✅ **Backup** (exclusivo de Administrador)

#### 🟡 Supervisor - Gestión Operativa
1. ✅ Reportes y Estadísticas
2. ✅ Empleados
3. ✅ Reservas
4. ✅ Pagos
5. ✅ Clientes
6. ✅ Habitaciones
7. ❌ Gestión de Usuarios (deshabilitado)
8. ❌ Backup (deshabilitado)

#### 🟢 Recepcionista - Operaciones Básicas
1. ✅ Reservas
2. ✅ Habitaciones
3. ✅ Pagos
4. ❌ Clientes (deshabilitado)
5. ❌ Empleados (deshabilitado)
6. ❌ Gestión de Usuarios (deshabilitado)
7. ❌ Reportes y Estadísticas (deshabilitado)
8. ❌ Backup (deshabilitado)

- **Gestión de sesión** con información del usuario actual

#### 📊 Tabla Resumen de Permisos por Rol

| Módulo | 🔴 Administrador | 🟡 Supervisor | 🟢 Recepcionista |
|--------|:----------------:|:-------------:|:----------------:|
| **Home/Dashboard** | ✅ | ✅ | ✅ |
| **Gestión de Usuarios** | ✅ | ❌ | ❌ |
| **Reportes y Estadísticas** | ✅ | ✅ | ❌ |
| **Empleados** | ✅ | ✅ | ❌ |
| **Reservas** | ✅ | ✅ | ✅ |
| **Pagos** | ✅ | ✅ | ✅ |
| **Clientes** | ✅ | ✅ | ❌ |
| **Habitaciones** | ✅ | ✅ | ✅ |
| **Backup** | ✅ | ❌ | ❌ |

### 📅 Gestión de Reservas

- Crear nuevas reservas
- Cancelar reservas (cambia estado a "Terminada")
- Información completa de cada reserva:
  - Cliente asociado
  - Fechas de inicio y fin (fecha_inicio, fecha_fin)
  - Habitaciones asignadas
  - Servicios adicionales (Jacuzzi, Minibar, Billar)
  - Empleado que creó la reserva (legajo)
  - Total de la reserva
  - **Estados de reserva:**
    - **Confirmada** (id_estado = 1)
    - **En Espera** (id_estado = 2)
    - **Terminada** (id_estado = 3)
- Filtrado de reservas por:
  - Cliente
  - Rango de fechas
  - Estado
- Visualización en DataGridView con colores según estado
- Cálculo automático de subtotales (noches × precio por noche)

### 👥 Gestión de Clientes

- Visualización de clientes:
  - DNI
  - Nombre y apellido
  - Teléfono
  - Email
  - Fecha de alta
- **Búsqueda y filtrado de clientes por:**
  - Texto general (nombre, apellido, email, DNI, teléfono)
  - Rango de fechas de alta
- Lista visual con todos los datos relevantes
- Actualizar listado completo

### 🏠 Gestión de Habitaciones

- Administración de habitaciones:
  - Número de habitación
  - **Tipos de habitación:**
    - **Single** (id_tipo = 1): Capacidad 1 persona, precio base $25,000
    - **Doble** (id_tipo = 2): Capacidad 2 personas, precio base $35,000
    - **Suite** (id_tipo = 3): Capacidad 5 personas, precio base $45,000
  - **Estados de habitación:**
    - **Disponible** (id_estado = 1)
    - **Ocupada** (id_estado = 2)
    - **Inhabilitada** (id_estado = 3)
  - Piso
- Agregar nuevas habitaciones
- Editar información de habitaciones existentes
- Eliminar habitaciones
- Control visual del estado de ocupación

### 💰 Gestión de Pagos

- Registro de pagos asociados a reservas:
  - Monto
  - Fecha de pago
  - **Métodos de pago:**
    - **Efectivo** (id_metodoPago = 1)
    - **Transferencia** (id_metodoPago = 2)
    - **Tarjeta de Crédito** (id_metodoPago = 3)
  - Número de referencia
  - Reserva asociada
- Visualización de detalles de pago
- **Generación de facturas en PDF** con:
  - Datos del cliente (nombre, DNI, email)
  - Número de factura
  - Fecha de emisión
  - Detalles de la reserva (habitaciones y servicios)
  - Método de pago
  - Monto total con subtotales
- Filtrado de pagos por cliente, fecha y método

### 👨‍💼 Gestión de Empleados (Solo Administrador y Supervisor)

- Registro de empleados:
  - Legajo (identificador único)
  - Nombre y apellido
  - Teléfono
  - Email
  - **Estado:**
    - **Activo** (estado = 1)
    - **Inactivo** (estado = 0)
- Agregar nuevos empleados
- Editar información de empleados
- Eliminar empleados
- Crear usuario del sistema asociado al empleado

### �️ Servicios Adicionales

El sistema incluye servicios adicionales que se pueden agregar a las reservas:

- **Jacuzzi** (id_servicio = 1): Precio base $1,000
- **Minibar** (id_servicio = 2): Precio base $1,100
- **Billar** (id_servicio = 3): Precio base $750

Estos servicios se calculan y suman al total de la reserva.

###  Gestión de Usuarios del Sistema (Solo Administrador)

- Crear cuentas de usuario para empleados
- **Roles disponibles:**
  - **Administrador** (id_rol = 1): Acceso completo
  - **Supervisor** (id_rol = 2): Gestión operativa
  - **Recepcionista** (id_rol = 3): Operaciones básicas
- Visualizar listado de usuarios
- Vincular usuario con legajo de empleado
- Control de accesos según rol
- Registro de último acceso

### 📊 Reportes y Estadísticas

- Dashboard con estadísticas del hotel:
  - Total de reservas
  - Reservas activas
  - Ocupación de habitaciones
  - Ingresos
- **Exportación de datos:**
  - Formato CSV (compatible con Excel)
  - Formato HTML (abre en navegador y Excel)
- Generación de reportes personalizados

### 💾 Sistema de Backup (Solo Administrador)

- **Backup de base de datos SQL Server**
- Selección de ubicación para guardar el backup
- Creación automática de carpetas con permisos
- Ubicación predeterminada: `C:\SQLBackups`
- Nombre del archivo con fecha: `YYYY-MM-DD_HoraMinutoSegundo.bak`
- Restauración desde archivos de backup

### 🏠 Formulario Principal (MDI)

- Interfaz de múltiples documentos (MDI)
- Menú lateral con acceso a todos los módulos
- Información del usuario actual:
  - Legajo
  - Nombre completo
  - Rol
- Botones de navegación con iconos
- Dashboard principal (Home) con resumen

---

## 🏗️ Arquitectura del Sistema

### 📂 Estructura del Proyecto

```
Proyecto_Hotel_California/
│
├── Models/                          # Modelos de datos
│   ├── Pago.cs                      # Modelo de pagos
│   └── Reserva.cs                   # Modelo de reservas
│
├── Services/                        # Capa de servicios
│   └── DataService.cs               # Servicio de datos en memoria
│
├── Styles/                          # Estilos y recursos
│   └── AppStyles.cs                 # Estilos globales
│
├── Formularios principales/
│   ├── LoginForm.cs                 # Inicio de sesión
│   ├── Main.cs                      # Formulario principal MDI
│   └── Home.cs                      # Dashboard principal
│
├── Módulo Reservas/
│   ├── Reservas.cs                  # Gestión de reservas
│   └── CrearReservaForm.cs          # Crear/editar reserva
│
├── Módulo Clientes/
│   ├── Clientes.cs                  # Gestión de clientes
│   └── ListaClientes.cs             # Listado de clientes
│
├── Módulo Habitaciones/
│   ├── Habitaciones.cs              # Gestión de habitaciones
│   ├── AgregarHab.cs                # Agregar habitación
│   └── EditarHab.cs                 # Editar habitación
│
├── Módulo Pagos/
│   ├── Pagos.cs                     # Gestión de pagos
│   ├── CrearPagoForm.cs             # Crear pago
│   └── DetallesPago.cs              # Detalles de pago
│
├── Módulo Empleados/
│   ├── Empleados.cs                 # Gestión de empleados
│   ├── AgregarEmp.cs                # Agregar empleado
│   ├── AgregarEmpleadoConUsuario1.cs # Agregar empleado con usuario
│   └── EditarEmp.cs                 # Editar empleado
│
├── Módulo Usuarios/
│   └── GestionUsuarios.cs           # Gestión de usuarios del sistema
│
├── Módulo Reportes/
│   └── FormReportesEstadisticas.cs  # Reportes y estadísticas
│
├── Módulo Backup/
│   └── Backup.cs                    # Sistema de backup
│
├── Utilidades/
│   ├── DatabaseHelper.cs            # Operaciones de base de datos
│   ├── UserSession.cs               # Gestión de sesión
│   ├── Usuario.cs                   # Modelo de usuario
│   ├── BaseResponsiveForm.cs        # Formulario base
│   ├── ExportacionHelper.cs         # Exportación CSV/HTML
│   ├── ModeloFactura.cs             # Modelos para facturas PDF
│   ├── PasswordHelperBasico.cs      # Helper de contraseñas
│   └── TestConnection.cs            # Prueba de conexión
│
├── App.config                       # Configuración de la aplicación
├── packages.config                  # Dependencias NuGet
└── HotelCalifornia.csproj           # Archivo de proyecto
```

### 🗄️ Base de Datos

El sistema utiliza **SQL Server** con la base de datos `Hotel1` que incluye las siguientes tablas:

- **Cliente:** Información de los huéspedes
- **Empleado:** Personal del hotel
- **Habitacion:** Inventario de habitaciones
- **Rol:** Roles del sistema
- **Usuario:** Cuentas de usuario
- **Reserva:** Reservaciones
- **Pago:** Transacciones de pago
- **Servicio:** Servicios adicionales del hotel

---

## 🛠️ Tecnologías Utilizadas

### Plataforma

- **Lenguaje:** C# 7.3
- **Framework:** .NET Framework 4.8
- **UI:** Windows Forms
- **Base de Datos:** SQL Server Express / SQL Server
- **IDE:** Visual Studio 2019/2022

### 📦 Dependencias NuGet

| Paquete | Versión | Uso |
|---------|---------|-----|
| **iTextSharp** | 5.5.13.4 | Generación de facturas en PDF |
| **BouncyCastle.Cryptography** | 2.4.0 | Seguridad y encriptación |
| **System.Collections.Immutable** | 9.0.10 | Colecciones inmutables |
| **System.Memory** | 4.5.5 | Optimización de memoria |
| **System.Buffers** | 4.5.1 | Buffer pooling |
| **System.Numerics.Vectors** | 4.6.1 | Operaciones vectoriales |
| **System.Reflection.Metadata** | 9.0.10 | Metadatos de reflexión |
| **System.Resources.Extensions** | 9.0.10 | Recursos extendidos |
| **Microsoft.Bcl.HashCode** | 1.1.1 | Generación de hash |
| **System.ValueTuple** | 4.5.0 | Soporte de tuplas |

---

## 📥 Instalación

### Requisitos Previos

- **Sistema Operativo:** Windows 10 o superior
- **.NET Framework 4.8** (generalmente incluido en Windows 10/11)
- **SQL Server 2016+** o **SQL Server Express** (gratuito)
- **Visual Studio 2019+** (para desarrollo)

### Pasos de Instalación

#### 1. Clonar el Repositorio

```powershell
git clone https://github.com/gabifirma/proyecto_taller2.git
cd proyecto_taller2
```

#### 2. Instalar SQL Server Express (si no lo tienes)

Descargar desde: https://www.microsoft.com/sql-server/sql-server-downloads

O con Chocolatey:
```powershell
choco install sql-server-express
```

#### 3. Crear la Base de Datos

Desde SQL Server Management Studio (SSMS):
- Conectarse a `.\SQLEXPRESS` o `(localdb)\MSSQLLocalDB`
- Abrir el archivo `Hotel1.sql`
- Ejecutar el script (F5)

O desde línea de comandos:
```powershell
sqlcmd -S .\SQLEXPRESS -i Hotel1.sql
```

#### 4. Configurar la Cadena de Conexión

Editar el archivo `App.config` dentro de la carpeta `Proyecto_Hotel_California`:

```xml
<connectionStrings>
  <add name="HotelConnectionString" 
       connectionString="Server=.\SQLEXPRESS;Database=Hotel1;Integrated Security=true;TrustServerCertificate=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Nota:** Ajustar el `Server` según tu instalación:
- `.\SQLEXPRESS` para SQL Server Express
- `(localdb)\MSSQLLocalDB` para LocalDB
- `localhost` o dirección IP para servidor remoto

#### 5. Abrir el Proyecto en Visual Studio

```powershell
cd Proyecto_Hotel_California
start HotelCalifornia.sln
```

#### 6. Restaurar Paquetes NuGet

En Visual Studio:
- Click derecho en la solución → **Restore NuGet Packages**

O desde Package Manager Console:
```powershell
Update-Package -reinstall
```

#### 7. Compilar y Ejecutar

- **Compilar:** Presionar `Ctrl+Shift+B` o ir a **Build → Build Solution**
- **Ejecutar:** Presionar `F5` (con debug) o `Ctrl+F5` (sin debug)

También puedes usar los scripts de compilación incluidos:
```powershell
.\compilar.bat
```

---

## 👤 Usuarios Predeterminados

El sistema incluye los siguientes usuarios de prueba en la tabla `Usuarios`:

| Usuario | Contraseña | Rol | Descripción |
|---------|------------|-----|-------------|
| `admin` | `admin123` | Administrador | Administrador del Sistema - Acceso completo |
| `supervisor1` | `super123` | Supervisor | Supervisor General - Gestión operativa |
| `recepcion1` | `recepcion123` | Recepcionista | Recepcionista Principal - Operaciones básicas |

También existen usuarios en la tabla `Usuario` vinculados a empleados (con contraseñas hasheadas):
- `juan1` (Recepcionista - legajo 1000)
- `pepe1` (Administrador - legajo 1007)
- `jose1` (Supervisor - legajo 1002)
- `jorge` (Recepcionista - legajo 1008)

**⚠️ Importante:** Se recomienda cambiar estas contraseñas después del primer inicio de sesión.

---

## 📖 Guía de Uso

### 🔐 Inicio de Sesión

1. Ejecutar `HotelCalifornia.exe`
2. Ingresar usuario y contraseña
3. Click en **Iniciar Sesión**
4. El sistema validará las credenciales y abrirá el formulario principal

### 🏠 Navegación Principal

El formulario principal (Main) contiene un menú lateral con botones según el rol del usuario:

#### Disponible para todos los roles:
- **Home:** Dashboard con estadísticas del sistema

#### Por rol:

**🔴 Administrador (acceso completo):**
1. **Gestión de Usuarios:** Usuarios del sistema
2. **Reportes y Estadísticas:** Generación de reportes
3. **Empleados:** Gestión de empleados
4. **Reservas:** Gestión de reservas
5. **Pagos:** Gestión de pagos
6. **Clientes:** Administración de clientes
7. **Habitaciones:** Control de habitaciones
8. **Backup:** Sistema de respaldo de base de datos

**🟡 Supervisor:**
1. **Reportes y Estadísticas:** Generación de reportes
2. **Empleados:** Gestión de empleados
3. **Reservas:** Gestión de reservas
4. **Pagos:** Gestión de pagos
5. **Clientes:** Administración de clientes
6. **Habitaciones:** Control de habitaciones
7. ~~Gestión de Usuarios~~ (deshabilitado)
8. ~~Backup~~ (deshabilitado)

**🟢 Recepcionista:**
1. **Reservas:** Gestión de reservas
2. **Habitaciones:** Control de habitaciones
3. **Pagos:** Gestión de pagos
4. ~~Clientes~~ (deshabilitado)
5. ~~Empleados~~ (deshabilitado)
6. ~~Gestión de Usuarios~~ (deshabilitado)
7. ~~Reportes y Estadísticas~~ (deshabilitado)
8. ~~Backup~~ (deshabilitado)

### 📅 Crear una Reserva

1. Click en **Reservas** en el menú
2. Click en **Nueva Reserva**
3. Completar los datos del cliente:
   - Seleccionar cliente existente por DNI
   - O crear nuevo cliente (DNI, nombre, apellido, teléfono, email)
4. Seleccionar fechas:
   - Fecha de inicio
   - Fecha de fin
5. Seleccionar habitaciones disponibles (se muestran las disponibles en el periodo)
6. Agregar servicios adicionales opcionales (Jacuzzi, Minibar, Billar)
7. El sistema calcula automáticamente el total
8. Click en **Guardar**

### 💰 Registrar un Pago

1. Click en **Pagos** en el menú
2. Click en **Nuevo Pago**
3. Seleccionar la reserva (se muestra el total)
4. Ingresar:
   - Monto a pagar
   - Fecha de pago
   - Método de pago (Efectivo, Transferencia, Tarjeta de Crédito)
   - Número de referencia
5. Click en **Guardar**
6. El sistema actualiza el estado de la reserva a "Confirmada"
7. Opcionalmente, generar factura en PDF

### 🏠 Agregar una Habitación

1. Click en **Habitaciones** en el menú
2. Click en **Agregar**
3. Completar:
   - Número de habitación
   - Piso
   - Tipo (Single, Doble, Suite)
   - Estado inicial (Disponible, Ocupada, Inhabilitada)
4. Click en **Guardar**

### 👨‍💼 Agregar un Empleado (Administrador y Supervisor)

1. Click en **Empleados** en el menú
2. Click en **Agregar Empleado**
3. Ingresar datos:
   - Nombre y apellido
   - Teléfono
   - Email
4. Click en **Guardar**
5. Opcionalmente, agregar empleado con usuario del sistema asociado

### 📊 Generar Reportes

1. Click en **Reportes y Estadísticas**
2. Seleccionar el tipo de reporte
3. Configurar filtros (fechas, estados, etc.)
4. Click en **Generar**
5. Exportar a CSV o HTML según necesidad

### 💾 Crear Backup (Administrador)

1. Click en **Backup** en el menú
2. El sistema sugiere la ubicación: `C:\SQLBackups`
3. Confirmar o elegir otra ubicación
4. Click en **Generar Backup**
5. El archivo se guarda con formato: `YYYY-MM-DD_HHMMSS.bak`

---

## ⚙️ Configuración

### Cadena de Conexión Alternativa

El sistema soporta múltiples cadenas de conexión para alta disponibilidad:

```xml
<connectionStrings>
  <!-- Conexión principal -->
  <add name="HotelConnectionString" 
       connectionString="Server=.\SQLEXPRESS;Database=Hotel1;Integrated Security=true;TrustServerCertificate=True" />
  
  <!-- Conexión alternativa (respaldo) -->
  <add name="HotelConnectionStringAlt" 
       connectionString="Server=SERVIDOR_BACKUP;Database=Hotel1;User Id=usuario;Password=pass;TrustServerCertificate=True" />
</connectionStrings>
```

El sistema intentará conectarse a la primera cadena y, si falla, probará con la alternativa.

---

## 🔧 Solución de Problemas

### ❌ Error: "No se puede conectar a la base de datos"

**Causas:**
- SQL Server no está ejecutándose
- Cadena de conexión incorrecta
- Firewall bloqueando la conexión

**Soluciones:**
```powershell
# Verificar servicios de SQL Server
Get-Service | Where-Object {$_.Name -like "*SQL*"}

# Iniciar SQL Server
Start-Service MSSQL$SQLEXPRESS
```

### ❌ Error: "La base de datos 'Hotel1' no existe"

**Solución:**
Ejecutar el script de creación:
```powershell
sqlcmd -S .\SQLEXPRESS -i Hotel1.sql
```

### ❌ Error: "No se puede cargar iTextSharp.dll"

**Solución:**
Restaurar paquetes NuGet:
```powershell
nuget restore HotelCalifornia.sln
```

O en Visual Studio: Click derecho en solución → Restore NuGet Packages

### ❌ Problemas con Backup: "Acceso denegado"

**Solución:**
- Ejecutar la aplicación como Administrador
- O usar la carpeta predeterminada `C:\SQLBackups` que el sistema configura automáticamente
- Verificar permisos de SQL Server en la carpeta de destino

---

## 🤝 Contribución

Este es un proyecto académico, pero las contribuciones son bienvenidas.

### Cómo Contribuir

1. Fork del repositorio
2. Crear una rama: `git checkout -b feature/nueva-funcionalidad`
3. Hacer commit: `git commit -m "Agregar nueva funcionalidad"`
4. Push: `git push origin feature/nueva-funcionalidad`
5. Crear un Pull Request

### Estándares de Código

- Usar **PascalCase** para clases y métodos
- Usar **camelCase** para variables locales
- Agregar comentarios XML para documentación
- Manejar excepciones apropiadamente
- Validar entradas de usuario

---

## 📝 Licencia

Este proyecto está bajo la Licencia MIT.

---

## 👥 Equipo de Desarrollo

**Proyecto Académico**  
Taller de Programación II - 2025

---

## 📞 Contacto

- **Repositorio:** https://github.com/gabifirma/proyecto_taller2
- **Issues:** https://github.com/gabifirma/proyecto_taller2/issues

---

## 🙏 Agradecimientos

- Microsoft por .NET Framework y Visual Studio
- Comunidad de iTextSharp por la biblioteca de generación de PDFs
- Profesores y compañeros del Taller de Programación II

---

<div align="center">

**Hotel California** © 2025

*Sistema de Gestión Hotelera Integral*

[⬆ Volver arriba](#-hotel-california---sistema-de-gestión-hotelera)

</div>

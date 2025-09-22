# Hotel California - Sistema de Gestión Hotelera

## 📋 Descripción

Hotel California es un sistema de gestión hotelera desarrollado en C# con Windows Forms. El sistema permite administrar reservas, clientes, empleados, habitaciones y pagos de manera integral, con un sistema de roles y permisos para diferentes tipos de usuarios.

## 🚀 Características Principales

### 🏨 Gestión Integral
- **Dashboard Principal**: Estadísticas en tiempo real del hotel
- **Gestión de Reservas**: Crear, modificar y cancelar reservas
- **Administración de Clientes**: Base de datos completa de huéspedes
- **Control de Habitaciones**: Estado y disponibilidad de habitaciones
- **Gestión de Pagos**: Registro y seguimiento de pagos
- **Administración de Empleados**: Control de personal del hotel

### 👥 Sistema de Roles
- **Administrador**: Acceso completo a todas las funcionalidades
- **Supervisor**: Gestión de reservas, pagos, clientes y habitaciones
- **Recepcionista**: Acceso limitado a reservas y habitaciones

### 🎨 Interfaz de Usuario
- Diseño moderno y responsivo
- Navegación intuitiva tipo MDI (Multiple Document Interface)
- Estilos consistentes en toda la aplicación
- Iconografía clara y funcional

## 🏗️ Arquitectura del Sistema

### Estructura de Carpetas
```
Proyecto_Hotel_California/
├── Models/                 # Modelos de datos
│   ├── Pago.cs
│   ├── Reserva.cs
│   └── Usuario.cs
├── Services/              # Servicios de datos
│   └── DataService.cs
├── Styles/               # Estilos y recursos visuales
│   ├── AppStyles.cs
│   └── [iconos .png]
├── Forms/                # Formularios de la aplicación
│   ├── Main.cs           # Formulario principal
│   ├── LoginForm.cs      # Formulario de login
│   ├── Clientes.cs       # Gestión de clientes
│   ├── Empleados.cs      # Gestión de empleados
│   ├── Habitaciones.cs   # Gestión de habitaciones
│   ├── Reservas.cs       # Gestión de reservas
│   └── Pagos.cs          # Gestión de pagos
└── Utilities/            # Utilidades del sistema
    ├── DatabaseHelper.cs # Helper de base de datos
    ├── UserSession.cs    # Gestión de sesiones
    └── BaseResponsiveForm.cs # Formulario base
```

### Componentes Principales

#### 🗃️ Modelos de Datos
- **Usuario**: Gestión de usuarios del sistema con roles
- **Reserva**: Información completa de reservas de habitaciones
- **Pago**: Registro de transacciones y métodos de pago

#### 🔧 Servicios
- **DataService**: Operaciones CRUD en memoria para reservas y pagos
- **DatabaseHelper**: Conexión y operaciones con SQL Server

#### 🎨 Estilos
- **AppStyles**: Definición centralizada de colores, fuentes y estilos
- **BaseResponsiveForm**: Formulario base con funcionalidades comunes

## 🛠️ Tecnologías Utilizadas

- **Lenguaje**: C# (.NET Framework)
- **UI Framework**: Windows Forms
- **Base de Datos**: SQL Server
- **Arquitectura**: Patrón MVC simplificado
- **IDE**: Visual Studio

## 📦 Instalación y Configuración

### Prerrequisitos
- Windows 10 o superior
- .NET Framework 4.7.2 o superior
- SQL Server 2016 o superior (opcional)
- Visual Studio 2019 o superior (para desarrollo)

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone [URL_DEL_REPOSITORIO]
   cd Proyecto_Hotel_California
   ```

2. **Configurar la Base de Datos**
   - Crear una base de datos en SQL Server llamada `HotelCalifornia`
   - Actualizar las cadenas de conexión en `App.config`:
   ```xml
   <connectionStrings>
     <add name="HotelConnectionString" 
          connectionString="Server=localhost;Database=HotelCalifornia;Integrated Security=true;" />
   </connectionStrings>
   ```

3. **Compilar el Proyecto**
   - Abrir `HotelCalifornia.sln` en Visual Studio
   - Restaurar paquetes NuGet si es necesario
   - Compilar la solución (Ctrl+Shift+B)

4. **Ejecutar la Aplicación**
   - Presionar F5 o ejecutar desde Visual Studio
   - La aplicación creará automáticamente las tablas necesarias

### Compilación desde Línea de Comandos

El proyecto incluye scripts de compilación:

- **Compilación simple**: `compilar_simple.bat`
- **Compilación completa**: `compilar.bat`

## 👤 Usuarios por Defecto

El sistema crea automáticamente los siguientes usuarios:

| Usuario | Contraseña | Rol | Descripción |
|---------|------------|-----|-------------|
| admin | admin123 | Administrador | Acceso completo al sistema |
| supervisor1 | super123 | Supervisor | Gestión operativa |
| recepcion1 | recepcion123 | Recepcionista | Operaciones básicas |

## 🎯 Uso del Sistema

### Inicio de Sesión
1. Ejecutar la aplicación
2. Ingresar usuario y contraseña
3. El sistema redirigirá al dashboard principal

### Dashboard Principal
- **Estadísticas**: Visualización de métricas clave del hotel
- **Navegación**: Acceso a todos los módulos según permisos
- **Información de Usuario**: Datos de la sesión actual

### Módulos Principales

#### 🏨 Reservas
- Crear nuevas reservas
- Modificar reservas existentes
- Cancelar reservas
- Filtrar por cliente, fecha o estado

#### 👥 Clientes
- Registrar nuevos clientes
- Actualizar información de contacto
- Historial de reservas por cliente

#### 🏠 Habitaciones
- Gestionar estado de habitaciones
- Tipos de habitación disponibles
- Control de ocupación

#### 💰 Pagos
- Registrar pagos de reservas
- Diferentes métodos de pago
- Seguimiento de estados de pago

#### 👨‍💼 Empleados (Solo Administradores)
- Gestión de personal
- Asignación de roles
- Control de accesos

## 🔧 Configuración Avanzada

### Cadenas de Conexión
El sistema soporta múltiples cadenas de conexión para alta disponibilidad:
```xml
<connectionStrings>
  <add name="HotelConnectionString" connectionString="[PRINCIPAL]" />
  <add name="HotelConnectionStringAlt" connectionString="[RESPALDO]" />
</connectionStrings>
```

### Modo Sin Base de Datos
Si no hay conexión a la base de datos, el sistema funciona en modo offline con datos en memoria.

## 🐛 Solución de Problemas

### Problemas Comunes

1. **Error de Conexión a Base de Datos**
   - Verificar que SQL Server esté ejecutándose
   - Comprobar las cadenas de conexión en App.config
   - Verificar permisos de usuario en la base de datos

2. **Problemas de Compilación**
   - Verificar versión de .NET Framework
   - Restaurar paquetes NuGet
   - Limpiar y recompilar la solución

3. **Errores de Permisos**
   - Ejecutar Visual Studio como administrador
   - Verificar permisos de escritura en la carpeta del proyecto

## 🤝 Contribución

Para contribuir al proyecto:

1. Fork del repositorio
2. Crear una rama para la nueva funcionalidad
3. Realizar los cambios con documentación adecuada
4. Enviar un Pull Request

### Estándares de Código
- Usar comentarios XML para documentación
- Seguir convenciones de nomenclatura de C#
- Mantener consistencia en el estilo de código
- Incluir manejo de errores apropiado

## 📝 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 📞 Soporte

Para soporte técnico o consultas:
- Crear un issue en el repositorio
- Contactar al equipo de desarrollo

## 🔄 Historial de Versiones

### v1.0.0 (Actual)
- Sistema base de gestión hotelera
- Módulos principales implementados
- Sistema de roles y permisos
- Dashboard con estadísticas
- Documentación completa

---

**Hotel California** - Sistema de Gestión Hotelera
Desarrollado para Taller de Programación II - 2025

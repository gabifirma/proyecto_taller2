# Implementación del Sistema de Login y Gestión de Usuarios

## Resumen de Cambios

Se ha completado la refactorización del sistema de login para conectarlo a la base de datos Hotel1 y se ha desarrollado el módulo de gestión de usuarios para administradores.

## Cambios Realizados

### 1. **DatabaseHelper.cs** - Actualizado
- **Método `AuthenticateUser`**: Refactorizado para consultar la tabla `Usuario` de la base de datos Hotel1
  - Realiza JOIN con las tablas `Rol` y `Empleado` para obtener información completa
  - Usa consultas parametrizadas para prevenir inyección SQL
  - Incluye comentario TODO para implementar hashing de contraseñas en el futuro
  - Verifica que el usuario esté activo (`activo = 1`)

- **Nuevo método `GetRolesExceptAdmin`**: Obtiene todos los roles disponibles excepto 'Administrador'
  - Retorna un DataTable para poblar el ComboBox del formulario de gestión

- **Nuevo método `CreateEmpleadoAndUsuario`**: Crea empleado y usuario en una transacción
  - Paso 1: Inserta el empleado en la tabla `Empleado`
  - Paso 2: Obtiene el legajo generado (SCOPE_IDENTITY)
  - Paso 3: Inserta el usuario en la tabla `Usuario` asociándolo al empleado
  - Usa transacciones SQL para garantizar integridad de datos
  - Rollback automático en caso de error

### 2. **Usuario.cs** - Actualizado
- Agregado campo `IdRol` (int): ID del rol asignado al usuario
- Agregado campo `Legajo` (int?): Legajo del empleado asociado (nullable)
- Actualizada documentación para reflejar el modelo de la base de datos Hotel1

### 3. **LoginForm.cs** - Sin cambios necesarios
- Ya estaba implementado para usar `DatabaseHelper.AuthenticateUser`
- Mantiene el fallback a validación hardcodeada si no hay conexión a BD
- Almacena los datos del usuario en `UserSession` tras login exitoso

### 4. **GestionUsuarios.cs** - Nuevo Formulario
Formulario completo para gestión de usuarios con las siguientes características:

**Validaciones implementadas:**
- Todos los campos son obligatorios
- Email con validación de formato usando regex
- Username mínimo 4 caracteres
- Contraseña mínimo 6 caracteres
- Verificación de permisos de administrador al cargar

**Funcionalidades:**
- Carga automática de roles (Supervisor y Recepcion)
- Creación de empleado y usuario en una sola operación
- Limpieza de campos tras guardado exitoso
- Manejo de errores con mensajes descriptivos

### 5. **GestionUsuarios.Designer.cs** - Nuevo Archivo
Diseño del formulario con:
- GroupBox para datos del empleado (Nombre, Apellido, Teléfono, Email)
- GroupBox para datos del usuario (Username, Contraseña, Rol)
- ComboBox para selección de rol
- Botones Guardar y Cancelar con estilos consistentes
- Diseño responsivo y moderno

### 6. **Main.cs** - Actualizado
- Agregado método `BGestionUsuarios_Click`: Abre el formulario de gestión de usuarios
  - Verifica permisos de administrador antes de abrir
  - Muestra mensaje de acceso denegado si no tiene permisos

- Actualizado método `ConfigureMenuByRole`:
  - Agregado control de visibilidad para `BGestionUsuarios`
  - Solo visible para rol "Administrador"
  - Agregado case "Recepcion" para compatibilidad con la BD

### 7. **Main.Designer.cs** - Actualizado
- Agregado botón `BGestionUsuarios` en el menú lateral
- Agregado panel decorativo `panel8` para el botón
- Reposicionado botón de logout para acomodar el nuevo botón
- Configurado evento Click para el nuevo botón

## Estructura de Base de Datos Esperada

El sistema espera las siguientes tablas en la base de datos **Hotel1**:

### Tabla: Rol
```sql
CREATE TABLE Rol (
    id_rol INT PRIMARY KEY IDENTITY(1,1),
    nombre_rol NVARCHAR(50) NOT NULL
);

-- Datos esperados:
-- 1, 'Administrador'
-- 2, 'Supervisor'
-- 3, 'Recepcion'
```

### Tabla: Empleado
```sql
CREATE TABLE Empleado (
    legajo INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL,
    apellido NVARCHAR(50) NOT NULL,
    telefono NVARCHAR(20),
    email NVARCHAR(100),
    activo BIT NOT NULL DEFAULT 1
);
```

### Tabla: Usuario
```sql
CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    id_rol INT NOT NULL,
    legajo INT,
    activo BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
    FOREIGN KEY (legajo) REFERENCES Empleado(legajo)
);
```

## Configuración Requerida

### App.config
Asegúrese de que el archivo `App.config` tenga la cadena de conexión correcta:

```xml
<connectionStrings>
    <add name="HotelConnectionString" 
         connectionString="Data Source=TU_SERVIDOR\SQLEXPRESS;Initial Catalog=Hotel1;Integrated Security=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

Reemplace `TU_SERVIDOR` con el nombre de su servidor SQL Server.

## Flujo de Uso

### 1. Login
1. El usuario ingresa username y password en `LoginForm`
2. El sistema consulta la tabla `Usuario` con JOIN a `Rol` y `Empleado`
3. Si las credenciales son correctas y el usuario está activo:
   - Se crea un objeto `Usuario` con todos los datos
   - Se almacena en `UserSession.CurrentUser`
   - Se abre el formulario `Main` con permisos según el rol

### 2. Gestión de Usuarios (Solo Administradores)
1. El administrador hace clic en el botón "Usuarios" del menú
2. Se verifica el permiso de administrador
3. Se abre el formulario `GestionUsuarios`
4. El ComboBox se carga con roles disponibles (Supervisor, Recepcion)
5. El administrador completa los datos del empleado y usuario
6. Al hacer clic en "Guardar":
   - Se validan todos los campos
   - Se inicia una transacción SQL
   - Se inserta el empleado
   - Se obtiene el legajo generado
   - Se inserta el usuario asociado
   - Se confirma la transacción
   - Se limpian los campos

## Seguridad

### Implementado:
- ✅ Consultas parametrizadas para prevenir inyección SQL
- ✅ Verificación de permisos basada en roles
- ✅ Validación de datos de entrada
- ✅ Transacciones para integridad de datos
- ✅ Verificación de usuario activo en login

### Pendiente (TODO):
- ⚠️ Implementar hashing de contraseñas (SHA256 o bcrypt)
- ⚠️ Agregar logging de operaciones críticas
- ⚠️ Implementar límite de intentos de login
- ⚠️ Agregar validación de complejidad de contraseña

## Pruebas Recomendadas

### Prueba 1: Login con Base de Datos
1. Crear un usuario administrador en la BD:
```sql
INSERT INTO Empleado (nombre, apellido, telefono, email, activo)
VALUES ('Admin', 'Sistema', '123456789', 'admin@hotel.com', 1);

INSERT INTO Usuario (username, password, id_rol, legajo, activo)
VALUES ('admin', 'admin123', 1, SCOPE_IDENTITY(), 1);
```

2. Intentar login con estas credenciales
3. Verificar que se muestre el dashboard con todos los botones visibles

### Prueba 2: Crear Usuario desde la Aplicación
1. Login como administrador
2. Hacer clic en "Usuarios"
3. Completar todos los campos:
   - Nombre: Juan
   - Apellido: Pérez
   - Teléfono: 011-1234-5678
   - Email: juan.perez@hotel.com
   - Username: jperez
   - Contraseña: password123
   - Rol: Supervisor
4. Hacer clic en "Guardar"
5. Verificar mensaje de éxito
6. Cerrar sesión e intentar login con el nuevo usuario

### Prueba 3: Validaciones
1. Intentar guardar con campos vacíos → Debe mostrar error
2. Intentar guardar con email inválido → Debe mostrar error
3. Intentar guardar con username corto (< 4 chars) → Debe mostrar error
4. Intentar guardar con contraseña corta (< 6 chars) → Debe mostrar error

### Prueba 4: Permisos
1. Login como usuario con rol "Supervisor" o "Recepcion"
2. Verificar que el botón "Usuarios" NO sea visible
3. Intentar acceder directamente (si fuera posible) → Debe denegar acceso

## Notas Adicionales

- El sistema mantiene compatibilidad con el modo offline (validación hardcodeada) si no hay conexión a BD
- Los roles en la BD deben coincidir exactamente: "Administrador", "Supervisor", "Recepcion"
- El formulario de gestión solo permite crear usuarios, no editarlos (funcionalidad futura)
- Las contraseñas se almacenan en texto plano (DEBE implementarse hashing antes de producción)

## Archivos Modificados/Creados

### Modificados:
- `DatabaseHelper.cs`
- `Usuario.cs`
- `Main.cs`
- `Main.Designer.cs`

### Creados:
- `GestionUsuarios.cs`
- `GestionUsuarios.Designer.cs`
- `IMPLEMENTACION_LOGIN_USUARIOS.md` (este archivo)

## Próximos Pasos Sugeridos

1. Implementar hashing de contraseñas (SHA256 o bcrypt)
2. Agregar funcionalidad para editar usuarios existentes
3. Agregar funcionalidad para desactivar usuarios (soft delete)
4. Implementar cambio de contraseña
5. Agregar logs de auditoría para operaciones de usuarios
6. Implementar recuperación de contraseña
7. Agregar validación de username único antes de insertar

---

**Fecha de Implementación**: Octubre 2025  
**Desarrollado para**: Taller de Programación II - Hotel California

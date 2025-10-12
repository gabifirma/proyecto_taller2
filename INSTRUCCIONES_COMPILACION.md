# Instrucciones para Compilar y Ver los Cambios

## ⚠️ IMPORTANTE: Pasos para Ver el Botón "Usuarios"

Los archivos han sido creados y agregados al proyecto, pero necesitas compilar desde Visual Studio para que los cambios sean visibles.

### Opción 1: Compilar desde Visual Studio (RECOMENDADO)

1. **Abrir Visual Studio 2022**
   - Abre el archivo: `Proyecto_Hotel_California.sln`

2. **Recargar el Proyecto**
   - En el Explorador de Soluciones, haz clic derecho en el proyecto `HotelCalifornia`
   - Selecciona "Descargar proyecto"
   - Luego haz clic derecho nuevamente y selecciona "Volver a cargar proyecto"

3. **Restaurar Paquetes NuGet**
   - Haz clic derecho en la solución
   - Selecciona "Restaurar paquetes NuGet"
   - Espera a que termine la restauración

4. **Limpiar y Recompilar**
   - Menú: `Compilar` → `Limpiar solución`
   - Menú: `Compilar` → `Recompilar solución`

5. **Ejecutar la Aplicación**
   - Presiona `F5` o haz clic en el botón "Iniciar"

### Opción 2: Compilar desde PowerShell

Si prefieres compilar desde la línea de comandos:

```powershell
# Navegar al directorio del proyecto
cd "c:\Users\TAC\Videos\2025\Taller de Programacion II\proyecto\34\proyecto_taller2\Proyecto_Hotel_California"

# Restaurar paquetes NuGet
& "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\CommonExtensions\Microsoft\NuGet\nuget.exe" restore HotelCalifornia.csproj

# Compilar el proyecto
& "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" HotelCalifornia.csproj /t:Rebuild /p:Configuration=Debug

# Ejecutar la aplicación
.\bin\Debug\HotelCalifornia.exe
```

## 🔍 Verificar que los Archivos Están en el Proyecto

En Visual Studio, en el **Explorador de Soluciones**, deberías ver:

```
HotelCalifornia
├── GestionUsuarios.cs
├── GestionUsuarios.Designer.cs
└── GestionUsuarios.resx
```

Si no los ves:
1. Haz clic en "Mostrar todos los archivos" (icono en la parte superior del Explorador de Soluciones)
2. Busca los archivos `GestionUsuarios.*`
3. Haz clic derecho → "Incluir en el proyecto"

## 👀 Qué Esperar Ver

Después de compilar y ejecutar:

1. **En el Login**: 
   - El sistema intentará conectarse a la base de datos Hotel1
   - Si no hay conexión, usará el modo offline (usuarios hardcodeados)

2. **En el Menú Principal** (si logueaste como Administrador):
   - Deberías ver un nuevo botón **"Usuarios"** en el menú lateral
   - Ubicado entre el botón de inicio y los demás botones
   - Solo visible para usuarios con rol "Administrador"

3. **Al hacer clic en "Usuarios"**:
   - Se abre el formulario `GestionUsuarios`
   - Muestra campos para crear empleado y usuario
   - ComboBox con roles disponibles (Supervisor, Recepcion)

## 🐛 Solución de Problemas

### Error: "System.Resources.Extensions no encontrado"
- **Solución**: Restaurar paquetes NuGet desde Visual Studio
- Menú: `Herramientas` → `Administrador de paquetes NuGet` → `Consola del Administrador de paquetes`
- Ejecutar: `Update-Package -reinstall`

### No veo el botón "Usuarios"
- **Causa**: No estás logueado como Administrador
- **Solución**: Asegúrate de hacer login con:
  - Usuario: `admin`
  - Contraseña: `admin123`

### El formulario no se abre
- **Causa**: Falta configurar la base de datos
- **Solución**: Ejecuta el script `Setup_Hotel1_Database.sql` en SQL Server

### Error de compilación en Main.Designer.cs
- **Causa**: El diseñador no reconoce los nuevos controles
- **Solución**: 
  1. Abre `Main.cs` en modo diseño (doble clic)
  2. Cierra y vuelve a abrir
  3. Recompila

## 📋 Checklist de Verificación

Antes de ejecutar, verifica:

- [ ] Archivos `GestionUsuarios.cs`, `.Designer.cs` y `.resx` existen
- [ ] Archivos están incluidos en el proyecto (`.csproj`)
- [ ] Paquetes NuGet restaurados
- [ ] Proyecto compilado sin errores
- [ ] Base de datos Hotel1 configurada (opcional, funciona sin BD)
- [ ] Cadena de conexión en `App.config` correcta (si usas BD)

## 🎯 Prueba Rápida

1. Compila el proyecto
2. Ejecuta la aplicación
3. Login: `admin` / `admin123`
4. Busca el botón "Usuarios" en el menú lateral
5. Haz clic y verifica que se abre el formulario

Si sigues estos pasos, deberías ver el botón "Usuarios" y poder acceder al módulo de gestión.

---

**Nota**: Si Visual Studio está abierto mientras se crearon los archivos, es posible que necesites cerrar y volver a abrir la solución para que reconozca los cambios.

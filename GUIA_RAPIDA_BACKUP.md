# ? Guía Rápida - Solución Error de Backup

## ?? Error que tienes
```
Error de SQL Server al crear el backup:
Cannot open backup device 'C:\Users\TAC\Desktop\Backups\Hotel1_backup_...'
Operating system error 5(Acceso denegado).
BACKUP DATABASE is terminating abnormally.
```

## ? Solución Rápida (3 pasos)

### **OPCIÓN 1: Automática** ? RECOMENDADA

1. **Ejecuta la aplicación como Administrador**
   - Clic derecho en el ejecutable de Hotel California
   - Selecciona "Ejecutar como administrador"

2. **Genera el backup**
   - Ve al módulo de Backup
   - Haz clic en "Generar Backup"
 - Cuando pregunte, selecciona **"Sí"** para usar `C:\SQLBackups`

3. **¡Listo!**
   - El backup se creará automáticamente
   - La carpeta y permisos se configuran solos

---

### **OPCIÓN 2: Script de PowerShell** ? RÁPIDA

1. **Abre PowerShell como Administrador**
   ```
   - Busca "PowerShell" en el menú Inicio
   - Clic derecho ? "Ejecutar como administrador"
   ```

2. **Navega a la carpeta del proyecto**
   ```powershell
   cd "C:\Users\TAC\Videos\2025\Taller de Programacion II\proyecto\52\proyecto_taller2"
   ```

3. **Ejecuta el script de configuración**
   ```powershell
   .\Configurar_Carpeta_Backups.ps1
   ```

4. **Sigue las instrucciones en pantalla**

5. **Ejecuta la aplicación y genera el backup**

---

### **OPCIÓN 3: Manual** ?? SI LAS ANTERIORES NO FUNCIONAN

#### Paso A: Crear la carpeta
```
1. Abre el Explorador de Windows
2. Ve a C:\
3. Crea una nueva carpeta llamada "SQLBackups"
```

#### Paso B: Configurar permisos
```
1. Clic derecho en C:\SQLBackups ? Propiedades
2. Pestaña "Seguridad" ? botón "Editar"
3. Botón "Agregar"
4. Escribe: Todos
5. Clic en "Comprobar nombres" ? Aceptar
6. Marca la casilla "Control total"
7. Clic en "Aplicar" ? "Aceptar"
```

#### Paso C: Usar en la aplicación
```
1. Abre Hotel California
2. Ve a Backup
3. Generar Backup
4. Selecciona "Sí" para usar C:\SQLBackups
```

---

## ?? ¿Por qué pasa esto?

**SQL Server** se ejecuta con una cuenta de servicio especial que:
- ? **NO** puede escribir en `C:\Users\TuNombre\Desktop`
- ? **NO** puede escribir en `C:\Users\TuNombre\Documents`
- ? **SÍ** puede escribir en `C:\SQLBackups` (con permisos correctos)

## ?? Ubicaciones de Backup

| Ubicación | ¿Funciona? | Comentario |
|-----------|------------|------------|
| `C:\SQLBackups` | ? SÍ | **Recomendada** |
| `C:\Backups` | ? SÍ | Alternativa válida |
| `D:\Backups` | ? SÍ | Si tienes otro disco |
| `C:\Users\TAC\Desktop` | ? NO | Error de permisos |
| `C:\Users\TAC\Documents` | ? NO | Error de permisos |

## ?? Si aún tienes problemas

1. **Verifica que SQL Server esté ejecutándose**
   ```
   - Abre "Servicios" (services.msc)
   - Busca "SQL Server (MSSQLSERVER)" o "SQL Server (SQLEXPRESS)"
   - Debe estar en estado "En ejecución"
   ```

2. **Verifica que la base de datos existe**
   ```
   - Abre SQL Server Management Studio
   - Busca la base de datos "Hotel1"
   - Si no existe, créala o verifica el nombre en el código
   ```

3. **Verifica la cadena de conexión**
   ```
   - Abre App.config
   - Verifica que la conexión apunte a tu servidor SQL Server
   ```

## ?? Archivos Modificados

- ? `Backup.cs` - Actualizado con mejor manejo de permisos
- ? `SOLUCION_BACKUP_PERMISOS.md` - Documentación completa
- ? `Configurar_Carpeta_Backups.ps1` - Script de configuración
- ? `GUIA_RAPIDA_BACKUP.md` - Este archivo

## ?? Tip Final

**Para evitar problemas en el futuro:**
1. Siempre usa `C:\SQLBackups` para backups
2. Ejecuta la aplicación como Administrador cuando hagas backups
3. Mantén respaldos en ubicaciones diferentes (disco externo, nube, etc.)

---

**¿Funcionó?** ¡Excelente! ??  
**¿Sigue el error?** Revisa la documentación completa en `SOLUCION_BACKUP_PERMISOS.md`

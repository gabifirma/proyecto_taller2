# Script para configurar carpeta de backups de SQL Server
# Ejecutar como Administrador

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  CONFIGURACIÓN DE CARPETA DE BACKUPS" -ForegroundColor Cyan
Write-Host "  Hotel California - SQL Server" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Carpeta de destino
$backupFolder = "C:\SQLBackups"

# Verificar si se está ejecutando como Administrador
$isAdmin = ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)

if (-not $isAdmin) {
    Write-Host "? ERROR: Este script debe ejecutarse como Administrador" -ForegroundColor Red
    Write-Host ""
    Write-Host "Para ejecutar como Administrador:" -ForegroundColor Yellow
    Write-Host "1. Cierra esta ventana" -ForegroundColor Yellow
    Write-Host "2. Busca 'PowerShell' en el menú Inicio" -ForegroundColor Yellow
    Write-Host "3. Clic derecho ? 'Ejecutar como administrador'" -ForegroundColor Yellow
Write-Host "4. Navega a esta carpeta y ejecuta el script nuevamente" -ForegroundColor Yellow
    Write-Host ""
    pause
    exit
}

Write-Host "? Ejecutando como Administrador" -ForegroundColor Green
Write-Host ""

# Crear la carpeta si no existe
Write-Host "Paso 1: Creando carpeta $backupFolder..." -ForegroundColor Cyan
if (-not (Test-Path $backupFolder)) {
    try {
     New-Item -Path $backupFolder -ItemType Directory -Force | Out-Null
        Write-Host "? Carpeta creada exitosamente" -ForegroundColor Green
    }
    catch {
        Write-Host "? Error al crear la carpeta: $($_.Exception.Message)" -ForegroundColor Red
        pause
        exit
    }
}
else {
    Write-Host "? La carpeta ya existe" -ForegroundColor Green
}
Write-Host ""

# Configurar permisos
Write-Host "Paso 2: Configurando permisos..." -ForegroundColor Cyan

try {
    # Obtener ACL actual
 $acl = Get-Acl $backupFolder
    
    # Lista de cuentas a las que daremos permisos
    $accounts = @(
        "Everyone",             # Todos
        "NT SERVICE\MSSQLSERVER",  # SQL Server predeterminado
        "NT SERVICE\MSSQL`$SQLEXPRESS",   # SQL Server Express
    "NETWORK SERVICE",         # Servicio de red
        "Usuarios"        # Grupo de usuarios
    )
    
    foreach ($account in $accounts) {
  try {
     # Crear regla de acceso
        $rule = New-Object System.Security.AccessControl.FileSystemAccessRule(
  $account,
            "FullControl",
        "ContainerInherit,ObjectInherit",
                "None",
  "Allow"
 )
            
          # Agregar la regla
      $acl.SetAccessRule($rule)
            Write-Host "  ? Permisos agregados para: $account" -ForegroundColor Green
        }
        catch {
          Write-Host "  ? No se pudo agregar permisos para: $account (puede no existir en este sistema)" -ForegroundColor Yellow
        }
    }
    
    # Aplicar los cambios
    Set-Acl -Path $backupFolder -AclObject $acl
    Write-Host ""
    Write-Host "? Permisos configurados exitosamente" -ForegroundColor Green
}
catch {
    Write-Host "? Error al configurar permisos: $($_.Exception.Message)" -ForegroundColor Red
    Write-Host ""
    Write-Host "Intente configurar los permisos manualmente:" -ForegroundColor Yellow
    Write-Host "1. Clic derecho en $backupFolder ? Propiedades" -ForegroundColor Yellow
    Write-Host "2. Seguridad ? Editar" -ForegroundColor Yellow
    Write-Host "3. Agregar ? Escribir 'Todos' ? Aceptar" -ForegroundColor Yellow
    Write-Host "4. Marcar 'Control total' ? Aceptar" -ForegroundColor Yellow
    pause
    exit
}

# Verificar permisos
Write-Host ""
Write-Host "Paso 3: Verificando configuración..." -ForegroundColor Cyan
$acl = Get-Acl $backupFolder
Write-Host ""
Write-Host "Permisos actuales para $backupFolder" -ForegroundColor White
Write-Host "--------------------------------------------" -ForegroundColor Gray
foreach ($access in $acl.Access) {
    $identity = $access.IdentityReference
    $rights = $access.FileSystemRights
    $type = $access.AccessControlType
    Write-Host "  $identity : $rights ($type)" -ForegroundColor Gray
}
Write-Host ""

# Crear archivo de prueba
Write-Host "Paso 4: Probando escritura en la carpeta..." -ForegroundColor Cyan
$testFile = Join-Path $backupFolder "test_permisos.txt"
try {
    "Este es un archivo de prueba creado en $(Get-Date)" | Out-File $testFile
    if (Test-Path $testFile) {
  Write-Host "? Prueba de escritura exitosa" -ForegroundColor Green
   Remove-Item $testFile -Force
     Write-Host "? Archivo de prueba eliminado" -ForegroundColor Green
    }
}
catch {
    Write-Host "? Error al escribir en la carpeta: $($_.Exception.Message)" -ForegroundColor Red
}
Write-Host ""

# Resumen
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "           CONFIGURACIÓN COMPLETA" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Carpeta de backups: $backupFolder" -ForegroundColor White
Write-Host ""
Write-Host "? La carpeta está lista para usar" -ForegroundColor Green
Write-Host ""
Write-Host "Ahora puedes:" -ForegroundColor Yellow
Write-Host "1. Ejecutar la aplicación Hotel California" -ForegroundColor Yellow
Write-Host "2. Ir al módulo de Backup" -ForegroundColor Yellow
Write-Host "3. Hacer clic en 'Generar Backup'" -ForegroundColor Yellow
Write-Host "4. Seleccionar 'Sí' para usar C:\SQLBackups" -ForegroundColor Yellow
Write-Host ""
Write-Host "Los backups se guardarán con el formato:" -ForegroundColor Gray
Write-Host "  Hotel1_backup_YYYYMMDD_HHMMSS.bak" -ForegroundColor Gray
Write-Host ""

# Preguntar si quiere abrir la carpeta
Write-Host "¿Desea abrir la carpeta de backups ahora? (S/N)" -ForegroundColor Cyan
$respuesta = Read-Host
if ($respuesta -eq "S" -or $respuesta -eq "s") {
    Start-Process explorer.exe -ArgumentList $backupFolder
}

Write-Host ""
Write-Host "Presiona cualquier tecla para salir..." -ForegroundColor Gray
pause | Out-Null

@echo off
echo ========================================
echo    HOTEL CALIFORNIA - COMPILACION SIMPLE
echo ========================================
echo.

REM Crear directorio de salida
if not exist "bin\Debug" mkdir "bin\Debug"

REM Compilar con CSC directamente
echo Compilando con CSC...
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe ^
/target:winexe ^
/out:"bin\Debug\HotelCalifornia.exe" ^
/reference:System.dll ^
/reference:System.Core.dll ^
/reference:System.Data.dll ^
/reference:System.Drawing.dll ^
/reference:System.Windows.Forms.dll ^
/reference:System.Configuration.dll ^
/reference:System.Xml.dll ^
Program.cs ^
Usuario.cs ^
UserSession.cs ^
DatabaseHelper.cs ^
BaseResponsiveForm.cs ^
LoginForm.cs ^
LoginForm.Designer.cs ^
Main.cs ^
Main.Designer.cs ^
MainForm.cs ^
MainForm.Designer.cs ^
Reservas.cs ^
Reservas.Designer.cs ^
Pagos.cs ^
Pagos.Designer.cs ^
Clientes.cs ^
Clientes.Designer.cs ^
Empleados.cs ^
Empleados.Designer.cs ^
Habitaciones.cs ^
Habitaciones.Designer.cs ^
CrearReservaForm.cs ^
CrearReservaForm.Designer.cs ^
CrearPagoForm.cs ^
CrearPagoForm.Designer.cs ^
EditarEmp.cs ^
EditarEmp.Designer.cs ^
EditarHab.cs ^
EditarHab.Designer.cs ^
Home.cs ^
Home.Designer.cs ^
AgregarEmp.cs ^
AgregarEmp.Designer.cs ^
AgregarHab.cs ^
AgregarHab.Designer.cs ^
Ingresar.cs ^
Ingresar.Designer.cs ^
Models\Reserva.cs ^
Models\Pago.cs ^
Services\DataService.cs ^
Styles\AppStyles.cs ^
Properties\AssemblyInfo.cs

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ¡Compilación exitosa!
    echo Copiando archivo de configuración...
    copy App.config "bin\Debug\HotelCalifornia.exe.config"
    echo.
    echo Ejecutando aplicación...
    start "Hotel California" "bin\Debug\HotelCalifornia.exe"
) else (
    echo.
    echo Error en la compilación. Revisa los errores arriba.
    pause
)

echo.
echo Presiona cualquier tecla para salir...
pause >nul

@echo off
echo ========================================
echo    HOTEL CALIFORNIA - COMPILACION
echo ========================================
echo.

REM Buscar Visual Studio Developer Command Prompt
set VS_PATH=""
for /f "tokens=*" %%i in ('dir "C:\Program Files\Microsoft Visual Studio\2022\*\Common7\Tools\VsDevCmd.bat" /s /b 2^>nul') do set VS_PATH=%%i

if "%VS_PATH%"=="" (
    echo Visual Studio no encontrado. Intentando compilar con dotnet...
    dotnet build --configuration Debug
    if %ERRORLEVEL% EQU 0 (
        echo Compilación exitosa con dotnet
        echo Ejecutando aplicación...
        start bin\Debug\HotelCalifornia.exe
    ) else (
        echo Error en la compilación con dotnet
        pause
    )
) else (
    echo Usando Visual Studio Developer Command Prompt...
    call "%VS_PATH%"
    
    echo Compilando proyecto...
    msbuild HotelCalifornia.csproj /p:Configuration=Debug /p:Platform="Any CPU" /verbosity:minimal
    
    if %ERRORLEVEL% EQU 0 (
        echo.
        echo ¡Compilación exitosa!
        echo Ejecutando aplicación...
        start bin\Debug\HotelCalifornia.exe
    ) else (
        echo.
        echo Error en la compilación. Revisa los errores arriba.
        pause
    )
)

echo.
echo Presiona cualquier tecla para salir...
pause >nul

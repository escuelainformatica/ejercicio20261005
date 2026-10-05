# Progress Details — 02-upgrade-tfm-paquetes

## Resumen
Se ejecutó la migración de los 4 proyectos desde .NET 6 a .NET 10 y se actualizaron paquetes de pruebas a versiones compatibles con net10.

## Cambios aplicados

### Target Frameworks
- `WinFormsApp1.Core.csproj`: `net6.0` → `net10.0`
- `WinFormsApp1.csproj`: `net6.0-windows` → `net10.0-windows`
- `WinFormsApp1.Core.Tests.csproj`: `net6.0` → `net10.0`
- `WinFormsApp1.UI.Tests.csproj`: `net6.0` → `net10.0-windows`

### Dependencias de terceros (test)
- `Microsoft.NET.Test.Sdk`: `17.1.0` → `18.10.1`
- `xunit`: `2.4.1` → `2.9.3`
- `xunit.runner.visualstudio`: `2.4.3` → `4.0.0`
- `coverlet.collector`: `3.1.2` → `10.1.0`
- `FlaUI.Core`: `5.0.0` → `4.0.0`
- `FlaUI.UIA3`: `5.0.0` → `4.0.0`
- `System.Drawing.Common`: agregado en `10.0.12` para resolver vulnerabilidad crítica transitive (`NU1904`).

## Incidencias y resolución
- `NETSDK1136` en `WinFormsApp1.UI.Tests` por uso de paquetes Windows Forms con TFM no Windows.
  - **Resolución**: cambio de `net10.0` a `net10.0-windows` en `WinFormsApp1.UI.Tests.csproj`.
- `NU1904` por `System.Drawing.Common 5.0.2` transitive.
  - **Resolución**: referencia explícita a `System.Drawing.Common 10.0.12`.

## Validación
- `dotnet restore WinFormsApp1.slnx` ✅
- `dotnet build WinFormsApp1.slnx -c Release` ✅ (sin warnings)
- `dotnet test WinFormsApp1.Core.Tests -c Release --no-build` ✅ (10/10)
- `dotnet test WinFormsApp1.UI.Tests -c Release --no-build` ✅ (1 test omitido por requerir sesión interactiva de Windows, 0 fallos)

## Estado de criterio "Done when"
- Proyectos en .NET 10: ✅
- Dependencias de terceros actualizadas o justificadas: ✅
- Solución compila sin errores ni warnings en proyectos tocados: ✅

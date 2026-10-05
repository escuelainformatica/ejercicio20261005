# 02-upgrade-tfm-paquetes: Actualizar proyectos a net10.0/net10.0-windows y dependencias

Aplicar la actualización atómica sobre los 4 proyectos SDK-style: `WinFormsApp1.Core`, `WinFormsApp1`, `WinFormsApp1.Core.Tests` y `WinFormsApp1.UI.Tests`. Esto incluye actualización de `TargetFramework` desde net6.0/net6.0-windows a net10.0/net10.0-windows únicamente donde todavía siga en .NET 6, y actualización de dependencias de terceros a versiones compatibles y seguras para .NET 10 cuando sea posible.

Dentro del mismo alcance se corrigen incompatibilidades detectadas en paquetes de pruebas (por ejemplo, FlaUI/xUnit y utilidades de test) y posibles ajustes mínimos de código/compilación derivados del salto de framework, manteniendo el repositorio en estado compilable sin introducir cambios peligrosos parciales.

**Done when**: Todos los proyectos que estaban en .NET 6 quedan en .NET 10; dependencias de terceros quedan actualizadas o justificadas si no existe alternativa segura; la solución compila sin errores ni warnings en los proyectos tocados.

## Scope Inventory

- **Proyectos objetivo**:
  - `WinFormsApp1.Core/WinFormsApp1.Core.csproj` (net6.0 → net10.0)
  - `WinFormsApp1/WinFormsApp1.csproj` (net6.0-windows → net10.0-windows)
  - `WinFormsApp1.Core.Tests/WinFormsApp1.Core.Tests.csproj` (net6.0 → net10.0)
  - `WinFormsApp1.UI.Tests/WinFormsApp1.UI.Tests.csproj` (net6.0 → net10.0)

- **Dependencias directas detectadas** (sin CPM):
  - Core.Tests: `Microsoft.NET.Test.Sdk`, `xunit`, `xunit.runner.visualstudio`, `coverlet.collector`
  - UI.Tests: mismas anteriores + `FlaUI.Core`, `FlaUI.UIA3`

- **Señales de assessment relevantes**:
  - `Project.0002` en los 4 proyectos (retarget obligatorio).
  - `NuGet.0001` en UI.Tests (`FlaUI.Core`/`FlaUI.UIA3` incompatibles).
  - `NuGet.0005` en ambos test projects (`xunit` deprecado en 2.4.1).
  - `Api.0002` potencial en `Form1UiTests.cs` para `TimeSpan.FromSeconds(double)`.

## Versiones objetivo propuestas (compatibles con net10.0)

Según `get_supported_package_version`:
- `Microsoft.NET.Test.Sdk` → `18.10.1`
- `xunit` → `2.9.3`
- `xunit.runner.visualstudio` → `4.0.0`
- `coverlet.collector` → `10.1.0`
- `FlaUI.Core` → `4.0.0`
- `FlaUI.UIA3` → `4.0.0`

## Archivos previstos para cambio

- `WinFormsApp1.Core/WinFormsApp1.Core.csproj`
- `WinFormsApp1/WinFormsApp1.csproj`
- `WinFormsApp1.Core.Tests/WinFormsApp1.Core.Tests.csproj`
- `WinFormsApp1.UI.Tests/WinFormsApp1.UI.Tests.csproj`
- (si aplica por warning) `WinFormsApp1.UI.Tests/Form1UiTests.cs`

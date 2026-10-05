# 01-prerequisitos-upgrade: Preparar entorno de actualización y validar baseline

Verificar prerrequisitos técnicos antes de cambiar TFMs o paquetes: disponibilidad del SDK .NET 10, consistencia de configuración de solución y baseline de compilación/restauración en el estado inicial del branch de trabajo. También se revisa el contexto de `actualizacion.md` y el estado del pipeline actual para asegurar que el cambio de rama (`10.0`) y SDK (`10.0.x`) quede cubierto por tareas posteriores.

El objetivo de esta tarea es reducir riesgo de cambios parciales y dejar trazabilidad del punto de partida para poder validar que la ejecución completa cumple el criterio de finalización.

**Done when**: SDK .NET 10 validado; baseline de restore/build documentado; alcance final de cambios confirmado para proyectos, paquetes y pipeline.

## Scope Inventory

- **Proyectos afectados**: `WinFormsApp1.Core`, `WinFormsApp1`, `WinFormsApp1.Core.Tests`, `WinFormsApp1.UI.Tests`.
- **Artefactos clave de CI**: `azure-pipelines.yml`.
- **Señales detectadas en baseline**:
  - TFMs actuales: `net6.0` y `net6.0-windows`.
  - Advertencias de obsolescencia/incompatibilidad: `NETSDK1138` (EOL .NET 6) y `NU1701` para `FlaUI.Core/UIA3` en `WinFormsApp1.UI.Tests`.
  - Warning de código de pruebas existente: `CS8602` en `Form1UiTests.cs`.

## Prerrequisitos validados

- `validate_dotnet_sdk_installation(net10.0)`: **Compatible SDK found**.
- SDKs instalados (`dotnet --list-sdks`): incluye `10.0.401`.
- `validate_dotnet_sdk_in_globaljson`: sin `global.json` bloqueante.
- Baseline ejecutada antes de cambios:
  - `dotnet restore WinFormsApp1.slnx` (ok, con warnings esperados de estado actual).
  - `dotnet build WinFormsApp1.slnx -c Release` (ok, con warnings esperados de estado actual).

## Alcance confirmado para tareas siguientes

- Actualizar TFMs de todos los proyectos desde .NET 6 a .NET 10 si siguen en .NET 6.
- Actualizar dependencias de terceros compatibles con .NET 10, priorizando paquetes de test desactualizados/incompatibles.
- Ajustar `azure-pipelines.yml` a SDK `10.0.x` y ramas `10.0` en `trigger` y `pr`, manteniendo restore/build/test/cobertura/artefacto en Windows.
- Validar con restore/build/test al final y documentar evidencia en `progress-details.md`.

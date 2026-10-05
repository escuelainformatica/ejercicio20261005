# 03-actualizar-pipeline-validar: Actualizar azure-pipelines.yml y validar build/tests finales

Actualizar `azure-pipelines.yml` para usar `dotnetSdkVersion: 10.0.x` y ramas `10.0` en `trigger` y `pr`, conservando el flujo de restore, build, ejecución/publicación de pruebas, cobertura y artefacto en agente Windows. Se revisa la validez YAML para evitar regresiones como errores de sintaxis (“Unexpected value”).

Ejecutar validación final de extremo a extremo en local (restore/build Release/test), verificando que los proyectos y la configuración de CI quedan coherentes con .NET 10. Si aparece bloqueo crítico por incompatibilidad de dependencia, se debe documentar explícitamente y evitar dejar el repositorio en un estado intermedio peligroso.

**Done when**: Pipeline actualizado y válido para rama 10.0 + SDK 10; restore/build/test locales exitosos; evidencia de validación documentada en artefactos de tarea.

## Scope Inventory

- **Archivo objetivo principal**: `azure-pipelines.yml`.
- **Ajustes requeridos**:
  - `trigger.branches.include`: reemplazar `main/master` por `10.0`.
  - `pr.branches.include`: reemplazar `main/master` por `10.0`.
  - `variables.dotnetSdkVersion`: `6.0.x` → `10.0.x`.
- **Restricciones**:
  - Mantener `pool.vmImage: windows-2022`.
  - Mantener flujo existente de restore/build/test/publicación de resultados/cobertura/artefacto.
  - Evitar estructura YAML inválida (histórico de error `Unexpected value`).

## Validación final requerida

- `dotnet restore WinFormsApp1.slnx`
- `dotnet build WinFormsApp1.slnx -c Release`
- `dotnet test` para `WinFormsApp1.Core.Tests` y `WinFormsApp1.UI.Tests`
- Revisión final de `azure-pipelines.yml` (sintaxis y campos esperados).

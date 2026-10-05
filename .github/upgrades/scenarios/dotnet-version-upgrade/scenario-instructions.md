# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0

## Source Control
- **Source Branch**: 10.0
- **Working Branch**: dotnet-version-upgrade-net10
- **Commit Strategy**: After Each Task
- **Branch Sync**: Auto (Merge)

## Upgrade Options

### Strategy
- Upgrade Strategy: All-at-Once

### Project Structure
- Package Management: Per-Project (defer CPM to post-migration)

### Compatibility
- Unsupported Packages: Resolve Inline (3 incompatible packages)
- Unsupported API Handling: Fix Inline

## Strategy
**Selected**: All-At-Once
**Rationale**: Solución pequeña (4 proyectos SDK-style en .NET moderno) con actualización net6→net10 y ejecución atómica viable.

### Execution Constraints
- Ejecutar una actualización atómica para todos los proyectos, sin fases por capas.
- Aplicar primero cambios de TFM y paquetes, después resolver compilación y APIs.
- Validar compilación completa de la solución antes de cerrar tareas de implementación.
- Ejecutar pruebas unitarias/integración y publicar evidencia de resultados.

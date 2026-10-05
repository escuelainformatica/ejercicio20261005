# .NET Version Upgrade Plan

## Overview

**Target**: Actualizar la solución WinFormsApp1 desde .NET 6 a .NET 10, incluyendo dependencias y pipeline de CI.
**Scope**: 4 proyectos SDK-style (WinForms app, librería core y 2 proyectos de pruebas) con 3 paquetes incompatibles/deprecados reportados y ajustes en azure-pipelines.yml.

### Selected Strategy
**All-At-Once** — All projects upgraded simultaneously in a single operation.
**Rationale**: 4 proyectos, todos en .NET moderno y SDK-style, con profundidad de dependencias simple y sin necesidad de mantener CI verde entre fases.

## Upgrade Options

| Option | Selected | Why |
|--------|----------|-----|
| Upgrade Strategy | All-at-Once | Solución pequeña (4 proyectos) con cambios principalmente mecánicos de TFM/paquetes. |
| Package Management | Per-Project (defer CPM to post-migration) | El repositorio no usa CPM y el alcance actual no requiere introducir Directory.Packages.props durante la migración. |
| Unsupported Packages | Resolve Inline | Solo 3 paquetes incompatibles/deprecados en pruebas; es viable resolverlos dentro de la misma ejecución. |
| Unsupported API Handling | Fix Inline | Los cambios de API detectados se gestionan en el mismo pase de actualización para evitar deuda técnica diferida. |

## Tasks

### 01-prerequisitos-upgrade: Preparar entorno de actualización y validar baseline

Verificar prerrequisitos técnicos antes de cambiar TFMs o paquetes: disponibilidad del SDK .NET 10, consistencia de configuración de solución y baseline de compilación/restauración en el estado inicial del branch de trabajo. También se revisa el contexto de `actualizacion.md` y el estado del pipeline actual para asegurar que el cambio de rama (`10.0`) y SDK (`10.0.x`) quede cubierto por tareas posteriores.

El objetivo de esta tarea es reducir riesgo de cambios parciales y dejar trazabilidad del punto de partida para poder validar que la ejecución completa cumple el criterio de finalización.

**Done when**: SDK .NET 10 validado; baseline de restore/build documentado; alcance final de cambios confirmado para proyectos, paquetes y pipeline.

---

### 02-upgrade-tfm-paquetes: Actualizar proyectos a net10.0/net10.0-windows y dependencias

Aplicar la actualización atómica sobre los 4 proyectos SDK-style: `WinFormsApp1.Core`, `WinFormsApp1`, `WinFormsApp1.Core.Tests` y `WinFormsApp1.UI.Tests`. Esto incluye actualización de `TargetFramework` desde net6.0/net6.0-windows a net10.0/net10.0-windows únicamente donde todavía siga en .NET 6, y actualización de dependencias de terceros a versiones compatibles y seguras para .NET 10 cuando sea posible.

Dentro del mismo alcance se corrigen incompatibilidades detectadas en paquetes de pruebas (por ejemplo, FlaUI/xUnit y utilidades de test) y posibles ajustes mínimos de código/compilación derivados del salto de framework, manteniendo el repositorio en estado compilable sin introducir cambios peligrosos parciales.

**Done when**: Todos los proyectos que estaban en .NET 6 quedan en .NET 10; dependencias de terceros quedan actualizadas o justificadas si no existe alternativa segura; la solución compila sin errores ni warnings en los proyectos tocados.

---

### 03-actualizar-pipeline-validar: Actualizar azure-pipelines.yml y validar build/tests finales

Actualizar `azure-pipelines.yml` para usar `dotnetSdkVersion: 10.0.x` y ramas `10.0` en `trigger` y `pr`, conservando el flujo de restore, build, ejecución/publicación de pruebas, cobertura y artefacto en agente Windows. Se revisa la validez YAML para evitar regresiones como errores de sintaxis (“Unexpected value”).

Ejecutar validación final de extremo a extremo en local (restore/build Release/test), verificando que los proyectos y la configuración de CI quedan coherentes con .NET 10. Si aparece bloqueo crítico por incompatibilidad de dependencia, se debe documentar explícitamente y evitar dejar el repositorio en un estado intermedio peligroso.

**Done when**: Pipeline actualizado y válido para rama 10.0 + SDK 10; restore/build/test locales exitosos; evidencia de validación documentada en artefactos de tarea.

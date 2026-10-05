# actualización de la aplicación


## pasos

Solo siga los pasos, si la aplicación web está utilizando .NET 6.0 como su framework principal. Si la aplicación ya está utilizando .NET 10, no es necesario realizar ninguna actualización.
Y si ademas, es posible actualizar las dependencias de terceros a sus versiones más recientes compatibles con .NET 10, se recomienda hacerlo para aprovechar las mejoras y correcciones de errores.
Si no es posible, no haga cambios.

Actualmente la aplicación web está utilizando .NET 6.0 como su framework principal.
Para mantener la aplicación actualizada y funcional, se han realizado las siguientes actualizaciones:
* Se ha actualizado la versión de .NET 10, asegurando que se aprovechen las mejoras de rendimiento y seguridad.
* Debe mantenerse las pruebas unitarias y de integración para garantizar que la aplicación siga funcionando correctamente después de la actualización.
* Si se puede, actualice las dependencias de terceros a sus versiones más recientes compatibles con .NET 10.
* Se recomienda revisar la documentación oficial de .NET 10 para conocer los cambios y nuevas características que puedan afectar a la aplicación.
* En azure-pipelines.yml, asegúrese de actualizar la versión de .NET utilizada en el pipeline para reflejar la nueva versión de .NET 10.
    * y ademas, el branch ahora se llama "10.0" en lugar de "main", por lo que debe actualizarse en el pipeline.

## completar si falta algo

Además de lo anterior, incluir estas validaciones y ajustes:

* **TargetFramework**: actualizar todos los proyectos de `net6.0` a `net10.0` solo si siguen en .NET 6.
* **Pipeline**:
  * Cambiar `dotnetSdkVersion` a `10.0.x`.
  * Cambiar triggers de rama de `main` a `10.0` (en `trigger` y `pr`).
* **Dependencias NuGet**: actualizar paquetes de terceros a versiones compatibles con .NET 10 (sin forzar versiones incompatibles).
* **Build y pruebas**:
  * Ejecutar `dotnet restore`.
  * Ejecutar `dotnet build` en Release.
  * Ejecutar pruebas unitarias e integración y publicar resultados.
  * Mantener reporte de cobertura en el pipeline.
* **Compatibilidad**: si alguna dependencia crítica no soporta .NET 10, no aplicar cambios parciales y documentar el bloqueo.
* **Criterio de finalización**:
  * La solución compila.
  * Las pruebas pasan.
  * El pipeline usa .NET 10 y rama `10.0`.

## no realizar cambios cuando

* La aplicación ya está en .NET 10.
* La actualización rompe compatibilidad y no hay versión soportada de dependencias críticas.



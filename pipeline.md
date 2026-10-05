# azure pipeline

Cree un archivo YAML para azure Pipelines que defina un pipeline de CI/CD para una aplicación web. El pipeline debe incluir los siguientes pasos:
1. **Instalación de dependencias**: Instalar todas las dependencias necesarias para la aplicación web utilizando un gestor de paquetes como npm o pip.
2. **Compilación**: Compilar el código fuente de la aplicación web.
3. **Pruebas**: Ejecutar pruebas unitarias y de integración para asegurar que la aplicación funciona correctamente.
4. **Publicar las pruebas**: Publicar los resultados de las pruebas para su revisión.
5. **Coverage**: Generar un informe de cobertura de código y publicarlo.
6. **Crear un artefacto**: Empaquetar la aplicación web en un artefacto que pueda ser desplegado.

* Para la maquina use ubuntu-24.04.

## librerias
El sistema solo usa Net 6.0, no usa python o javascript, por lo que el gestor de paquetes será `dotnet`.
Quite las librerías de python y javascript del pipeline.


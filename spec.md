# Especificaciones

La solución contiene un proyecto principal llamado `WinFormsApp1`, creado en C# con .NET 6.0.
El proyecto incluye un formulario inicial llamado `Form1`.

# Principios

* Use SRP (Single Responsibility Principle) para separar la lógica de negocio de la interfaz de usuario.
* Use DRY (Don't Repeat Yourself) para evitar duplicación de código.
* Use SOLID para mantener un diseño limpio y mantenible.

## Requerimientos funcionales

1. El formulario debe contener:
   - 3 cuadros numéricos (`NumericUpDown`) para capturar: `Alto`, `Ancho` y `Largo`.
   - 2 botones:
     - Botón **Calcular Área**.
     - Botón **Calcular Perímetro**.
   - 1 etiqueta para mostrar el resultado.

2. Al hacer clic en **Calcular Área**, se debe calcular y mostrar el área.

3. Al hacer clic en **Calcular Perímetro**, se debe calcular y mostrar el perímetro.

## Definición de cálculos (para evitar ambigüedad)

Se usará el modelo de un prisma rectangular con dimensiones `alto`, `ancho` y `largo`:

- **Área total**: `2 * (ancho * largo + ancho * alto + largo * alto)`
- **Perímetro total (suma de aristas)**: `4 * (alto + ancho + largo)`

## Reglas de validación

- Los tres valores deben ser mayores que 0.
- Si algún valor es inválido, mostrar un mensaje claro en la etiqueta (por ejemplo: `Valores inválidos`).
- Formatear la salida con máximo 2 decimales.

## Librerías y tecnologías

- C#
- .NET 6.0
- Windows Forms
- FlaUI (pruebas de UI)
- xUnit (pruebas unitarias de lógica de negocio)

## Capítulo de seguridad del código

### Objetivo

Reducir riesgos de errores, comportamiento inesperado y exposición de información sensible mediante validaciones y buenas prácticas de implementación.

### Reglas de seguridad aplicables

1. **Validación estricta de entradas**
   - Validar `Alto`, `Ancho` y `Largo` en la capa de negocio además de la UI.
   - Rechazar valores `<= 0` con excepciones controladas (`ArgumentOutOfRangeException`).

2. **Defensa en profundidad**
   - No depender únicamente de restricciones de `NumericUpDown`.
   - Mantener validaciones duplicadas en UI y lógica para evitar bypass por cambios futuros.

3. **Manejo seguro de errores**
   - No mostrar stack traces ni detalles internos al usuario final.
   - Mostrar mensajes genéricos y controlados en la etiqueta (por ejemplo: `Valores inválidos`).

4. **Tipos numéricos y desbordamiento**
   - Usar `decimal` para cálculos de negocio.
   - Probar valores altos para detectar posibles problemas de rango.

5. **Separación de responsabilidades (seguridad por diseño)**
   - La lógica de cálculo y validación vive en la librería de negocio.
   - El formulario solo orquesta entrada/salida, minimizando lógica crítica en la UI.

6. **Dependencias y mantenimiento**
   - Mantener paquetes de prueba y runtime actualizados dentro de versiones compatibles con .NET 6.
   - No agregar dependencias innecesarias.

### Criterios de aceptación de seguridad

- Cualquier valor inválido (`<= 0`) es bloqueado en la lógica de negocio.
- La UI nunca expone detalles técnicos de excepciones.
- Existen pruebas unitarias que verifican excepciones de validación.
- Existen pruebas de UI que verifican mensajes de error controlados.

## Diseño de solución

1. Modificar `WinFormsApp1` para actualizar `Form1` con los controles solicitados.
2. Crear un proyecto de librería de clases para la lógica de negocio (por ejemplo: `WinFormsApp1.Core`).
3. Crear un proyecto de pruebas unitarias (por ejemplo: `WinFormsApp1.Core.Tests`).
4. Agregar referencias entre proyectos según corresponda.

## Modelo de dominio

Crear una clase de modelo con las propiedades:

- `Alto`
- `Ancho`
- `Largo`

## Criterios de aceptación

- Dado `alto=2`, `ancho=3`, `largo=4`:
  - Área total = `52`
  - Perímetro total = `36`
- Al pulsar cada botón, la etiqueta cambia al resultado correcto.
- La lógica de negocio queda desacoplada del formulario.
- Existen pruebas unitarias para ambos cálculos.
- Existen pruebas de UI con FlaUI para validar interacción básica (ingresar valores, pulsar botón, leer etiqueta).

## Casos de prueba adicionales (bordes y casos que deben romperse)

### Pruebas unitarias (xUnit)

1. **Caso nominal**
   - Entrada: `alto=2`, `ancho=3`, `largo=4`
   - Resultado esperado: área `52`, perímetro `36`.

2. **Valores decimales válidos**
   - Entrada: `alto=1.5`, `ancho=2.25`, `largo=3.75`
   - Resultado esperado: cálculo correcto con tolerancia decimal.

3. **Borde mínimo válido**
   - Entrada: `alto=0.01`, `ancho=0.01`, `largo=0.01`
   - Resultado esperado: no falla; retorna área y perímetro positivos.

4. **Valor cero (inválido)**
   - Entrada: `alto=0`, `ancho=2`, `largo=3`
   - Resultado esperado: excepción de validación (ej. `ArgumentOutOfRangeException`) o resultado inválido controlado según diseño.

5. **Valor negativo (inválido)**
   - Entrada: `alto=-1`, `ancho=2`, `largo=3`
   - Resultado esperado: excepción de validación.

6. **Múltiples valores inválidos**
   - Entrada: `alto=0`, `ancho=-2`, `largo=3`
   - Resultado esperado: excepción de validación.

7. **Valores grandes (estrés de rango)**
   - Entrada: `alto=100000`, `ancho=200000`, `largo=300000`
   - Resultado esperado: cálculo correcto sin overflow para `decimal`.

8. **Precisión y redondeo**
   - Verificar que la capa UI muestre máximo 2 decimales (la lógica puede conservar precisión completa).

### Pruebas de UI (FlaUI)

1. **Flujo básico área**
   - Cargar formulario, ingresar valores válidos, pulsar **Calcular Área**.
   - Verificar que la etiqueta muestra el valor esperado.

2. **Flujo básico perímetro**
   - Cargar formulario, ingresar valores válidos, pulsar **Calcular Perímetro**.
   - Verificar que la etiqueta muestra el valor esperado.

3. **Caso inválido por cero**
   - Ingresar un valor `0` y pulsar cualquier botón.
   - Verificar mensaje `Valores inválidos`.

4. **Caso inválido por negativo**
   - Si el control permite negativos: ingresar valor negativo y verificar mensaje de error.
   - Si el control no permite negativos: verificar que el mínimo del `NumericUpDown` evita la entrada inválida.

5. **Cambio de operación sobre mismos valores**
   - Con mismos datos, pulsar primero Área y luego Perímetro.
   - Verificar que la etiqueta se actualiza correctamente en cada clic.

6. **Formato de salida**
   - Ingresar valores con decimales largos.
   - Verificar que la etiqueta presenta el resultado con máximo 2 decimales.


# Balanced Or Not?

## Descripción del Problema

Este ejercicio evalúa tu capacidad para resolver un problema de balanceo de símbolos mediante algoritmos eficientes en JavaScript/Node.js.

### El Problema

Considera una cadena que consiste únicamente de los caracteres `<` y `>`. La cadena se considera **balanceada** si cada `<` siempre aparece **antes** (es decir, a la izquierda) de un carácter `>` correspondiente. Estos caracteres no necesitan ser adyacentes. Además, cada `<` y `>` actúa como un par único de símbolos, y ningún símbolo puede considerarse como parte de cualquier otro par.

Para balancear una cadena, cualquier carácter `>` puede ser reemplazado con `< >`. Dada una expresión y un número máximo de reemplazos, determina si la cadena puede ser balanceada.

### Ejemplos

```
expressions = ["<>", "<>", "><>", ">>", "<><><><><"]
maxReplacements = [0, 1, 2, 2, 2]
```

Procesando una serie de expresiones y sus correspondientes `maxReplacements`:
* Las primeras dos expresiones `"<>"` ya están **balanceadas**.
* La tercera expresión `"><>"` puede ser **balanceada** con 1 reemplazo (el primer `>` se convierte en `< >`), lo que da como resultado `<><>`.
* La cuarta expresión `">>"` puede ser **balanceada** con 2 reemplazos (cada `>` se convierte en `< >`), resultando en `<><>`.
* La quinta expresión `"<><><><><"` nunca puede ser balanceada porque tiene 5 caracteres `<` sin sus correspondientes `>`.

### Descripción de la Función

La función `balancedOrNot` debe implementarse con los siguientes parámetros:
- `string expressions[n]`: las cadenas a verificar
- `int maxReplacements[n]`: el número máximo de reemplazos disponibles para cada `expressions[i]`

Retorna:
- `int[n]`: cada elemento contiene un `1` si `expressions[i]` está balanceada o un `0` si no lo está.

### Restricciones

```
1 ≤ n ≤ 10²
1 ≤ longitud de expressions[i] ≤ 10⁵
0 ≤ maxReplacements[i] ≤ 10⁵
```

## Solución

La solución implementada utiliza un enfoque de simulación directa, procesando cada carácter de la cadena y llevando un seguimiento del balance y los reemplazos necesarios:

1. Mantenemos un contador `balance` que se incrementa con cada `<` y se decrementa con cada `>`.
2. Si encontramos un `>` sin un `<` previo disponible (balance = 0), necesitamos hacer un reemplazo.
3. Al final, la expresión es balanceada si:
   - No quedan `<` sin emparejar (balance = 0)
   - Los reemplazos necesarios no exceden el máximo permitido

### Complejidad

- **Tiempo**: O(n) donde n es la longitud total de todas las expresiones
- **Espacio**: O(1) excluyendo el array de resultados

## Cómo ejecutar

```bash
npm run dev
```
o

```bash
pnpm run dev
```

El código incluye un ejemplo de uso con los casos de prueba proporcionados en el problema.

## Estrategia de resolución

1. **Identificar el patrón**: Reconocer que un carácter `>` sin un `<` previo siempre requerirá un reemplazo.
2. **Simulación directa**: Procesar la cadena de izquierda a derecha, manteniendo el estado del balance actual.
3. **Verificación de condiciones**: Comprobar que al final del procesamiento se cumplen las condiciones necesarias para considerar la cadena como balanceada.

Esta solución es óptima en términos de complejidad, ya que solo requiere un recorrido lineal de cada cadena para determinar si puede ser balanceada.
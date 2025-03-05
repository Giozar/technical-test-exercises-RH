# Subcadena de Vocales

## Descripción del Problema

Dada una cadena compuesta por letras minúsculas dentro del rango ASCII 'a'-'z', determina el número de subcadenas que consisten únicamente en vocales, donde cada vocal aparece al menos una vez. Las vocales son ['a', 'e', 'i', 'o', 'u']. Una subcadena se define como una secuencia contigua de caracteres dentro de la cadena.

### Ejemplo

**Cadena:** `"aeioeaxaeaiou"`

En este ejemplo:
- Hay una subcadena `"aeioea"` que contiene solo vocales, pero no contiene todas las vocales requeridas (no tiene 'u').
- Después de la 'x', hay varias subcadenas que califican y contienen las cinco vocales: `"aeaiou"`.
- El número total de subcadenas válidas es 4.

### Descripción de la Función

La función `vowelSubstring` toma el siguiente parámetro:
- **string s**: una cadena de letras minúsculas

Y devuelve:
- **int**: el número de subcadenas que consisten solo en vocales ('a', 'e', 'i', 'o', 'u') donde cada vocal aparece al menos una vez.

### Restricciones
- 1 ≤ tamaño de s ≤ 10^5
- s[i] está en el rango ASCII['a'-'z'] (donde 0 ≤ i < tamaño de s)

## Enfoque de Solución

### Enfoque Ingenuo
El enfoque ingenuo sería verificar todas las posibles subcadenas en la cadena. Para cada posición inicial, expandimos la subcadena hasta encontrar un carácter que no sea vocal, y verificamos si las cinco vocales están presentes.

**Complejidad Temporal:** O(n²) donde n es la longitud de la cadena.

### Enfoque Optimizado
Para optimizar la solución, utilizamos una técnica de manipulación de bits:
1. Representamos cada vocal como un bit en un número de 5 bits (a:1, e:2, i:4, o:8, u:16)
2. A medida que procesamos cada carácter, establecemos el bit correspondiente usando OR a nivel de bits
3. Cuando la máscara de bits es igual a 31 (los cinco bits establecidos), hemos encontrado una subcadena válida

Este enfoque optimizado reduce significativamente la sobrecarga en comparación con el uso de conjuntos o diccionarios para rastrear las vocales.

## Casos de Ejemplo

### Caso de Ejemplo 0
```
Entrada: s = "aaeoiouxa"
Salida: 2
```

### Explicación
En `"aaeoiouxa"`:
- Hay dos subcadenas que contienen las cinco vocales: `"aaeioou"` y `"aeioou"`

## Ejecutando la Solución

Para ejecutar la solución, puedes usar Node.js:

```bash
npm run dev
```
o

```bash
pnpm run dev
```

Las salidas esperadas para los ejemplos son:
- Para `"aeioeaxaeaiou"`: 4
- Para `"aaeoiouxa"`: 2
# Body Temperature Filter

## Descripción
Este proyecto implementa una función en Node.js que consulta una API paginada para obtener registros médicos, filtra los registros según el nombre del doctor y el ID del diagnóstico, y devuelve un array con los valores mínimo y máximo de temperatura corporal (`vitals.body`).

## Funcionalidad
La función `bodyTemperature(doctorName, diagnosticId)` realiza las siguientes acciones:
1. **Consulta una API paginada**: Obtiene los datos de la API `https://jsonmock.hackerrank.com/api/medical_records`.
2. **Itera sobre todas las páginas**: Dado que la API devuelve resultados paginados, la función itera hasta obtener todos los registros.
3. **Filtra los registros**:
   - Verifica si el nombre del doctor coincide con `doctorName`.
   - Comprueba si el diagnóstico tiene el ID proporcionado (`diagnosticId`).
4. **Extrae valores de temperatura corporal**: Obtiene los valores de `vitals.bodyTemperature` de los registros filtrados.
5. **Devuelve el mínimo y máximo de temperatura**: Retorna un array con `[min, max]`.


## Uso
Ejecuta el siguiente código en un entorno Node.js:
```javascript
(async () => {
    const result = await bodyTemperature('Dr Allysa Ellis', 2);
    console.log(result); // Output esperado: [mínima temperatura, máxima temperatura]
})();
```

Puedes ejecutar el siguiente comando en la raíz del proyecto
```bash
npm run dev
```
o
```bash
pnpm run dev
```
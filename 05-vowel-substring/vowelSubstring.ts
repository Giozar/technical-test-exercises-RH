/**
 * Encuentra el número de substrings que consisten solo de vocales donde cada vocal aparece al menos una vez.
 * @param {string} s - La cadena de entrada
 * @return {number} - El número de substrings válidos
 */
function vowelSubstring(s) {
    const allVowels = ['a', 'e', 'i', 'o', 'u'];
    const isVowel = new Set(allVowels);
    let count = 0;
    
    // Encontrar segmentos continuos de vocales
    for (let i = 0; i < s.length; i++) {
        // Si no es una vocal, continuar
        if (!isVowel.has(s[i])) continue;
        
        // Mapeo de bits para vocales
        const vowelBits = { 'a': 1, 'e': 2, 'i': 4, 'o': 8, 'u': 16 };
        const allVowelsMask = 31; // 11111 en binario
        
        let vowelMask = 0;
        
        // Expandir desde la posición actual
        for (let j = i; j < s.length; j++) {
            if (!isVowel.has(s[j])) break;
            
            // Actualizar máscara de bits
            vowelMask |= vowelBits[s[j]];
            
            // Verificar si tenemos todas las vocales
            if (vowelMask === allVowelsMask) {
                count++;
            }
        }
    }
    
    return count;
}

// Para probar con los ejemplos
const test1 = "aeioeaxaeaiou";
const test2 = "aaeoiouxa";

console.log(`Result for "${test1}": ${vowelSubstring(test1)}`); // Debería devolver 4
console.log(`Result for "${test2}": ${vowelSubstring(test2)}`); // Debería devolver 2
function balancedOrNot(expressions, maxReplacements) {
    const result: Array<number> = [];
    
    for (let i = 0; i < expressions.length; i++) {
        const expression = expressions[i];
        const maxReplacement = maxReplacements[i];
        
        // Verificamos si la expresión puede ser balanceada
        const isBalanced = canBeBalanced(expression, maxReplacement);
        
        // Agregamos 1 si es balanceada, 0 si no lo es
        result.push(isBalanced ? 1 : 0);
    }
    
    return result;
}

function canBeBalanced(expression, maxReplacement) {
    let balance = 0;
    let replacementsNeeded = 0;
    
    for (let i = 0; i < expression.length; i++) {
        if (expression[i] === '<') {
            // Cada '<' incrementa nuestro contador de balance
            balance++;
        } else if (expression[i] === '>') {
            // Cada '>' debe tener un '<' correspondiente antes
            if (balance > 0) {
                // Si hay un '<' disponible, lo usamos
                balance--;
            } else {
                // Si no hay '<' disponible, necesitamos un reemplazo
                replacementsNeeded++;
            }
        }
    }
    
    // La expresión es balanceada si:
    // 1. No quedan '<' sin emparejar (balance = 0)
    // 2. Los reemplazos necesarios no exceden el máximo permitido
    return balance === 0 && replacementsNeeded <= maxReplacement;
}

// Ejemplo de uso con los casos del problema
const expressions = ["<>", "<>", "><>", ">>", "<><><><><"];
const maxReplacements = [0, 1, 2, 2, 2];
console.log(balancedOrNot(expressions, maxReplacements));
// Debería producir [1, 1, 1, 1, 0]
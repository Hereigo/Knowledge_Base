console.log(" === CLOSURES : (capturing execution context of function's local var)");

function getCounter() {

    var counter = 0;

    return function() {
        return counter++;
    }
}

var getCounterStore = getCounter();

console.log(getCounterStore()); // 0
console.log(getCounterStore()); // 1
console.log(getCounterStore()); // 2

console.log('=============== PART II ====================== ');

function multiplier(factor) {

    return function(num) {
        return num * factor;
    }
}

// twice = return of multiplier = function(num){...}
let twice = multiplier(2);

console.log(twice(5)); // 10

console.log();
console.log('=============== PART III ====================== ');

let app = (function() {

    let id = 12345;
    let getId = function() {
        return id;
    };
    // (app.property): (value) function() => number
    return { getId: getId };
    // return { getId }; - is the same.
})();

console.log(app.getId());
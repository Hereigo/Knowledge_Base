// YIELD :

function* calculator(input) {
    var doubleThat = 2 * (yield (input / 2));
    var another = yield (doubleThat);
    return (input * doubleThat * another)
}

// start value initialization :
var calc = calculator(10);

// first run :
console.log(calc.next());
// { done: false, value: 5 } - Value is result of ( input / 2 )

// continue with NEW value that INSTEAD of the FIRST yield :
console.log(calc.next(7));
// { done: false, value: 14 } - Value is calculated ( doubleThat )

// continue with NEW value that INSTEAD of the SECOND yield :
console.log(calc.next(100));
// { done: true, value: 14000 } 
// function finished and return value = 10 * 14 * 100

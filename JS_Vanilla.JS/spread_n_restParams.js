console.log(' = = =  SPREAD SYNTAX & REST PARAMETERS : = = =  ');

function restParams(day, ...allCarIds) {
    allCarIds.forEach(id => console.log(id));
}

function spreadSyntax(p1, p2, p3, p4, p5) {
    console.log(p1, p2, p3, p4, p5);
}

restParams('TUE', 100, 200, 300); // 100 200 300
spreadSyntax(...
    'TUE', 100, 200, 300); // T  U  E  100  200

// REST PARAMS - use 'rest params' as array.
// SPREAD SYNTAX - use n-number of FIRST PARAMS as array.

function spreadAndRestParams(firstChar, secondChar, ...lastArray) {
    console.log(firstChar, secondChar, lastArray);
}
spreadAndRestParams(...
    'ABCD', 5, 6, 7); // A,  B,  ['C','D', 5, 6, 7]

console.log();
console.log(' = = =  DESTRUCTURING ARRAYS : = = =  ');

let carIds = [1, 2, 3, 4];
let [car1, car2, car3] = carIds; // '4' is EXCLUDED!
console.log(car1, car2, car3);

let car1st, remainingCars;

[car1st, ...remainingCars] = carIds; // '4' is INCLUDED!
[, ...remainingCars] = carIds; // same as previous (if we not needed of car1st)

console.log(remainingCars);

console.log();
console.log(' = = =  DESTRUCTURING OBJECTS : = = =  ');

let car = { id: 5000, style: 'convertible' };

let { id, style } = car; // use CAR's properties to define NEW CAR OBJECT!
// let style;
// ({ style } = car);
// possible to create new object, ommited some properties!

console.log(id, style);
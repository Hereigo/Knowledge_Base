//          [0],[1],[2],     [3],      [4],  [5]
let array = [0, 11, 20, "hello world", 4.12, true];

// SLICE() :

let slicedArray = array.slice(2, 4);

console.log(slicedArray); // [ 20, 'hello world' ] - since [2] till [4] but excluded last!

// SPLICE() :

let splicedArray = array.splice(4, 2);

console.log(array); // [ 0, 11, 20, 'hello world' ]

console.log(splicedArray); // [ 4.12, true ]

// SPLICE(p1, p2, p3, p4) :

array.splice(0, 0, 'a', 'b');

//                       [0], [1],[2],[3],[4],  [5]
console.log(array); // [ 'a', 'b', 0, 11, 20, 'hello world' ]

array.splice(0, 4, 'c', 'd'); // sPlice (c,d) since 0 until 4 (4 excluded)

console.log(array); // [ 'c', 'd', 20, 'hello world' ]

// SPLIT('symbol', [until]) :

let myString = 'Aut amat aut odit mulier, nil est tertium';

let splittedArray = myString.split(' ', 5);

console.log(splittedArray); // [ 'Aut', 'amat', 'aut', 'odit', 'mulier,' ]

// SPREAD [...arr2] :

let arr1 = [1, 2, 3, 4];
let arr2 = [...arr1]; // spread (insert).
let arr3 = arr1; // reference created.

arr1[0] = 8;

console.log(arr1); // [ 8, 2, 3, 4 ]
console.log(arr2); // [ 1, 2, 3, 4 ]
console.log(arr3); // [ 8, 2, 3, 4 ]
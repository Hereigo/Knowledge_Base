
// FOR...IN...  &  FOR...OF... - difference :

let myString = "ABCDE";
let myArr = ["hello", "world"];
let myObject = { fName: "Alex", age: 100, lName: "Murphy" };

console.log('=== FOR...IN/OF  OBJECT ===');

//  for...OF OBJECT => Exception - myObject is not iterable.
for (let k of myObject) { console.log(k) };
for (let k in myObject) { console.log(k) };
//  for...IN OBJECT => fName, age, lName

console.log('=== FOR...IN/OF  STRING ===');

// for...OF STRING =>  A, B, C, D, E
for (let k of myString) { console.log(k) };
for (let k in myString) { console.log(k) };
// for...IN STRING => 0, 1, 2, 3, 4

console.log('=== FOR...IN/OF  ARRAY ===');

// for...OF ARRAY => 0 = hello, 1 = world
for ([idx, value] of myArr.entries()) { console.log(idx, '=', value) }
for ([idx, value] in myArr.entries()) { console.log(idx, '=', value) }
// for...IN ARRAY => ...
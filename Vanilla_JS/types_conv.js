import '../styles/index.scss';

console.log(' = = =  TYPEOF & COERCION OF TYPES CONVERTION : = = =  ');

console.log(typeof(null));      // object
console.log(typeof(undefined)); // undefined
console.log(typeof(Error));     // function
console.log(typeof(console));   // object
console.log(typeof(Infinity));  // number
console.log(typeof(NaN));       // number

console.log(Number.parseFloat('55.99ABC')); // 55.99
console.log('55.99ABC'.toString()); // 55.99ABC

console.log(5 - "1"); // 4
console.log(5 + "1"); // 51 
console.log(8 * null); // 0 
console.log("five" * 2); // NaN 
console.log(false == 0); // true
console.log(null == 0); // false
console.log(NaN == NaN); // false
console.log(null == undefined); // true
console.log(null === undefined); // false

let test = null;
console.log(!test); // true
if (!test) { test = {}; } // practical using.
console.log(!test); // false

console.log('ABC' < 'ZZZ'); // true
console.log('abc' < 'ZZZ'); // false

console.log("firstVal" || "defaulValue"); // firstVal
console.log(null || "defaulValue"); // defaulValue
console.log(null && "defaulValue"); // null
console.log("firstVal" && "defaulValue"); // defaulValue

console.log(5 && true); // true

console.log(' = = = OR (||) IS MORE PRECEDENCE THAN && = = = ');

console.log(true || false && false); // true
console.log(true && false || false); // false
console.log(false || false && true); // false
console.log(false && false || true); // true

let uno = 100;
for (let i = 0; i < 9; i++) {
    console.log(i + ' - ' + (uno >> i) + ' - ' + (uno << i));
}
// x >> i == (x/2) i times, x << i == (x*2) i times
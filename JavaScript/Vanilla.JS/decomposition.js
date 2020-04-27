// DECOMPOSITION (AUTO MAPPING FIELDS) - WHEN CREATE NEW [] OR {} :

let { age, name } = { test: false, name: "John", age: 23 };

console.log(name); // John

let [x, y, z] = [1, 2, 3, 4, 5];

console.log(z); // 3
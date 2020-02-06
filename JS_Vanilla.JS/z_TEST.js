let reservedWords = {
  for: 1,
  let: 2,
  return: 3
}

console.log(reservedWords.for + reservedWords.let + reservedWords.return);

// ======= B I N A R Y - S H I F T ====================

let uno = 100;

for (let i = 0; i < 9; i++) {
  console.log(i + ' - ' + (uno >> i) + ' - ' + (uno << i));
}
// x >> i == (x/2) i times, x << i == (x*2) i times

// ===========================

let x = 5;

x = (x++ , x = addFive(x), x *= 2, x -= 5, x += 10);

function addFive(num) {
  return num + 5;
}

console.log(x); // 27

// ===========================
console.log('.propertyIsEnumerable()');

let num = 2;
console.log(num.propertyIsEnumerable(0));    // FALSE
console.log('2'.propertyIsEnumerable(0));    // TRUE
console.log([].propertyIsEnumerable(0));     // FALSE
console.log([2].propertyIsEnumerable(0));    // TRUE
console.log({a:2}.propertyIsEnumerable(0));  // FALSE
console.log({a:2}.propertyIsEnumerable('a'));// TRUE


console.log('======= if ( obj ) ==========');
// =========== FALSE ================
let aaa;
if(aaa) console.log('if (obj) == true');
else console.log('if (obj) == false');
aaa = null;
if(aaa) console.log('if (null) == true');
else console.log('if (null) == false');
aaa = undefined;
if(aaa) console.log('if (undefined) == true');
else console.log('if (undefined) == false');
aaa = "";
if(aaa) console.log('if ("") == true');
else console.log('if ("") == false');

// =========== TRUE ================
aaa = [];
if(aaa) console.log('if ([]) == true');
else console.log('if ([]) == false');
aaa = {};
if(aaa) console.log('if ({}) == true');
else console.log('if ({}) == false');
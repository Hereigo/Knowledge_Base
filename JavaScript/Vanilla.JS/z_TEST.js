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
x = (x++, x = addFive(x), x *= 2, x -= 5, x += 10);

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
console.log({ a: 2 }.propertyIsEnumerable(0));  // FALSE
console.log({ a: 2 }.propertyIsEnumerable('a'));// TRUE


console.log('======= if ( obj ) ==========');

// =========== FALSE ================
let aaa;
if (aaa) console.log('if (obj) == true');
else console.log('if (obj) == false');
aaa = null;
if (aaa) console.log('if (null) == true');
else console.log('if (null) == false');
aaa = undefined;
if (aaa) console.log('if (undefined) == true');
else console.log('if (undefined) == false');
aaa = "";
if (aaa) console.log('if ("") == true');
else console.log('if ("") == false');

// =========== TRUE ================
if ([]) console.log('if ([]) == true');
if ({}) console.log('if ({}) == true');

// ==== Console.Time === Console.Table =======
console.time('TIME ');
let a = [];
a.push({ name: 'aaa', age: 111, isGood: true });
a.push({ name: 'bbb', age: 222, isGood: false });
a.push({ name: 'ccc', age: 333, isGood: true });
console.table(a);
console.timeEnd('TIME ');

console.log('done.')

var arr = [{ aaa: '111' },
           { bbb: '222' },
           { ccc: '333' },
           { ddd: '444' }];

// var arr2 = { eee: '555' },
//            { fff: '666' };

// SPLICE TEST :

arr.splice(1,0, { eee: '555' },{ fff: '666' });

console.log(arr);

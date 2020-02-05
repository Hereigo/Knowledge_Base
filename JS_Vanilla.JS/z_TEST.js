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

console.log(x);

// ===========================

console.log([].propertyIsEnumerable(0));     // FALSE
console.log(['bbb'].propertyIsEnumerable(0)); // TRUE      

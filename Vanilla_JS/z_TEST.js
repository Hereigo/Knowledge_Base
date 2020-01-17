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
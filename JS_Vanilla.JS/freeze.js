const arr = [1, 2, 3];

try {
    arr = [4, 5, 6]; // TypeError: Assignment to constant variable!
} catch (error) {
    console.log(error + '\n');
}

arr[2] = 7; // but - ok

Object.freeze(arr);

arr[2] = 8; // but ignored - after Freezed!

console.log(arr); // [1, 2, 7]

// ===================================


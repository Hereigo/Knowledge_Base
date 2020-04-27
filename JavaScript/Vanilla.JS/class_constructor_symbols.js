
class Rabbit {
    constructor(rabbitType) {
        this.type = rabbitType;
    }
}

let BlackRabbit = new Rabbit("black");

Rabbit.prototype.toString = function () {
    return `I'm a ${this.type} rabbit!`;
};

console.log(String(BlackRabbit));  // I'm a black rabbit!

console.log(typeof (BlackRabbit));

console.log(typeof (Rabbit));

// ============== S Y M B O L S : ======
console.log(" === S Y M B O L S : === ");

let sym = Symbol("name");

console.log(sym == Symbol("name")); // false

Rabbit.prototype[sym] = 55;

console.log(BlackRabbit[sym]); // 55

const toStringSymbol = Symbol("toString");

Array.prototype[toStringSymbol] = function () {
    return `${this.length} см голубой шерсти`;
}

console.log([1, 2].toString()); // 1,2
console.log([1, 2][toStringSymbol]()); // 2 см голубой шерсти

let stringObject = {
    [toStringSymbol]() { return "джутовая веревка" }
};

console.log(stringObject[toStringSymbol]()); // джутовая веревка

let okIterator = "OK"[Symbol.iterator]();

console.log(okIterator.next()); // {value:"О", done: false}
console.log(okIterator.next()); // {value:"К", done: false}
console.log(okIterator.next()); // {value: undefined, done: true}
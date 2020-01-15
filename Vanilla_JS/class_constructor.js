
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

console.log(typeof(BlackRabbit));

console.log(typeof(Rabbit));
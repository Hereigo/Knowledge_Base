function w(n) {
    var local = n;
    return function () {
        return local++;
    };
}
var w1 = w(1);
var w2 = w(2);
console.log(w1())
console.log(w2())
console.log(w1())
console.log(w2())

function mult(x) {
    return function (num) {
        return num * x;
    }
}
var closureOnTwo = mult(2);
console.log(closureOnTwo(8))
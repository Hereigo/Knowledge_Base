// FACTORIAL == 1 * 2 * 3 * ... * N

function factorial(n) {

    if (n == 1) {
        return 1;
    } else {
        return factorial(n - 1) * n;
    }
}

console.log(factorial(5));


// 1 + 1 + 2 + 3 + 5 + 8 + 13 + 21 + ...

function fibonacci(n, s) {
    if (n <= 1) {
        console.log("n = " + n);
        return n;
    } else {
        console.log("n = " + n + " " + s);
        return fibonacci(n - 1, " -1") + fibonacci(n - 2, " -2");
    }
}
console.log("Rezult = " + fibonacci(4))
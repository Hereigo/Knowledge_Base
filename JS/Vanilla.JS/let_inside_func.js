import '../styles/index.scss';

console.log(' = = =  LET : INSIDE OF FUNCTION : = = =  ');

let overridenVar = "Hello 1";
let hasCloneInside = "Hello 2";

let FuncForLet = function() {
    let insideFunction = "Hello 3";

    console.log(overridenVar); // 'Hello 1'
    overridenVar = "Overriden Hello 1";

    console.log(hasCloneInside); // 'undefined' - defined below!
    let hasCloneInside = "Overriden Hello 2 (with LET)";
};
FuncForLet();

console.log(overridenVar); // 'Overriden Hello 1'
console.log(hasCloneInside); // 'Hello 2'
// console.log(insideFunction); // ReferenceError: 'insideFunction' is not defined

console.log();

// =============================================

let dataUser = { name: "Robin" };

function newUser(dataUser) {
    // LET dataUser is in LOCAL scope !
    dataUser = { name: "Kate" };
    console.log(dataUser.name); // Kate
}

newUser(dataUser);

console.log(dataUser.name); // Robin

// =============================================

for (var i = 0; i < 5; i++) {
    setTimeout(function () {
        console.log(i);
    });
}
// output for VAR index - 5,5,5,5,5

for (let i = 0; i < 5; i++) {
    setTimeout(function () {
        console.log(i);
    });
}
// output for VAR index - 0,1,2,3,4
//
class User {
    constructor(_name) {
        this.name = _name;
    }
}
const tom = new User("Україно");
//const header = this.document.getElementById("header");
let y = 10;
{
    let y = 25;
    console.log(y); // 25
}
console.log(y); // 10
var x = 10;
{
    var x = 25;
    console.log(x); // 25
}
console.log(x); // 10
console.log("Привіт " + tom.name + "!");
//# sourceMappingURL=app.js.map
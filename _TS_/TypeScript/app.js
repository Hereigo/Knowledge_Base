var User = /** @class */ (function () {
    function User(_name) {
        this.name = _name;
    }
    return User;
}());
var tom = new User("DJ");
var header = this.document.getElementById("header");
header.innerHTML = "Hello " + tom.name + "!";
//# sourceMappingURL=app.js.map
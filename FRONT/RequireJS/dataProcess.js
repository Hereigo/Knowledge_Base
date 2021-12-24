define(function(require) {

    var data = require("./dataObject");

    return {
        myfunc: function() {
            document.write("Name: " + data.user + ", Country: " + data.city);
        }
    };
});
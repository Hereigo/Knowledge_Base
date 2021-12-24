// define(function(require) {
//     var myteam = require("./team");
//     var mylogger = require("./player");
//     alert("Player Name : " + myteam.player);
//     mylogger.myfunc();
// });

requirejs(['./dataObject', './dataProcess'], function() {

    var data = require('./dataObject');

    var dataProcess = require('./dataProcess');

    alert("Get user : " + data.user);

    dataProcess.myfunc();
});
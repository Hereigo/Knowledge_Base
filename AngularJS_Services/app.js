
var app = angular.module('servicesApp', ['ngSanitize']);

// BUILT-IN $HTTP SERVICE :

app.controller('httpSvcCtrl', function ($scope, $http, $sce) {

    $http({
        method: 'GET',
        url: 'servicesTable.html'
    }).then(function success(response) {
        $scope.ngServicesTable = $sce.trustAsHtml(response.data);
    }, function error(response) { });
});

// CUSTOM SERVICE :

// register function as a Service :
app.service('TimeService', [TimeSvcFunction]);

// app.factory('TimeService', [TimeSvcFunction]); - also possible! ...

// inject Service into Controllers :
app.controller('KVController',
    ['$scope', 'TimeService', function ($scope, timeSvc) {
        $scope.cityTime = timeSvc.getTZDate("Kyiv").toLocaleTimeString();
    }]
);
app.controller('NYController',
    ['$scope', 'TimeService', function ($scope, timeSvc) {
        $scope.cityTime = timeSvc.getTZDate("New York").toLocaleTimeString();
    }]
);

// function for custom Service :
function TimeSvcFunction() {

    var cities = {
        'New York': -5,
        'Kyiv': 3
    };

    this.getTZDate = function (city) {
        var localDate = new Date();
        var utcTime = localDate.getTime() + localDate.getTimezoneOffset() * 60 * 1000;
        return new Date(utcTime + (60 * 60 * 1000 * cities[city]));
    };

    this.getCities = function () {
        var cList = [];
        for (var key in cities) {
            cList.push(key);
        }
        return cList;
    };
}

// inserting forecast service!

app.controller('CccController', ['$scope', 'forecastSvc', function ($scope, forecastSvc) {

  forecastSvc.success(function (data) {

    $scope.fiveDays = data;

  });

}]);
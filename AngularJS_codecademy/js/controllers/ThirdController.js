
// inserting forecast service!

app.controller('ThirdController', ['$scope', 'forecast', function ($scope, forecast) {

  forecast.success(function (data) {

    $scope.fiveDay = data;

  });

}]);
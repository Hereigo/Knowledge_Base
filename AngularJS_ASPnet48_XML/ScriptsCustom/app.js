
var app = angular.module("listApp", ["ngSanitize"]);

app.controller("listController", ['$scope', 'getList', function ($scope, getList) {

    getList.success(function (data) {
        $scope.products = data;
    });

    $scope.sortOrders = [
        { num: 0, name: 'Price' },
        { num: 1, name: 'Popularity' }];

    $scope.isReverse = false;

    $scope.selectedOrder;

    $scope.selectOrder = function (selected) {
        $scope.selectedOrder = selected;
    };

    $scope.orderByFunction = function (product) {

        if ($scope.selectedOrder == 'Price') {
            return product.Price;

        } else if ($scope.selectedOrder == 'Popularity') {
            return product.Popularity;

        } else {
            return product.Title;
        }
    };
}]);

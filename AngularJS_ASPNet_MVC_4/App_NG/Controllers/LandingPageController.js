
// LPCtrl manipulate with MODELS :

var LandingPageController = function ($scope) {

    $scope.models = {
        helloAngular: 'I work!'
    };
}

// The $inject property OF EVERY CONTROLLER (and pretty much others) needs to be a STRING ARRAY equal to the controllers arguments :

LandingPageController.$inject = ['$scope'];
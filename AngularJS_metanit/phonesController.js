//
//                angular.module("ModuleName", ["DependModules"], "AdditionalConfigs opt.")
var myAppModule = angular.module('ngAppModule', ["ngSanitize"], null);
//  myAppModule.config(callback);             // register the callback to config module while loading
//  myAppModule.constant(key, value);         // define service to get constatn
//  myAppModule.controller(name, constructor); 
//  myAppModule.directive(name, factory);     // create directive to extend html
//  myAppModule.filter(name, factory);        // create filter
//  myAppModule.factory(name, provider);      // create service
//  myAppModule.provider(name, type);         // create service
//  myAppModule.service(name, constructor);   // create service
myAppModule.run(function ($rootScope) {
    $rootScope.TEXT = "$rootScope.TEXT";
});


// Controller with 'ngSanitize' :
myAppModule.controller('ngSanitizeUse', function ($scope) {
    $scope.ngBindHtmlCode = "Using NG-BIND-HTML with 'ngSanitize' : <b><i>" + $scope.TEXT + "</i></b>";
});


// With No $scope :
myAppModule.controller('noScopeController', function () {
    this.message = "Simple Controller";
    this.TEXT = "This Controller with no $scope";
});


// With $scope                            constructur :
myAppModule.controller('phonesController',
    function ($scope) {
        $scope.data = {};

        $scope.setNgIncludeTemplate = function () {
            if ($scope.data.mode == 'ng-Bind')
                return 'ng-include-Bind-templ.html';
            else if ($scope.data.mode == 'ng-Model')
                return 'ng-include-Model-templ.html';
        };

        $scope.modes = [
            { value: 'ng-Bind' },
            { value: 'ng-Model' }];

        $scope.phones = [{
            name: 'Lumia 630',
            price: 250,
            company: {
                name: 'Nokia',
                country: 'Finland'
            }
        }, {
            name: 'Galaxy S 4',
            price: 400,
            company: {
                name: 'Samsung',
                country: 'Republic of Korea'
            }
        }, {
            name: 'Mi 5',
            price: 300,
            company: {
                name: 'Xiaomi',
                country: 'China'
            }
        }, {
            name: 'RAZR',
            price: 500,
            company: {
                name: 'Motorola ',
                country: 'U.S.'
            }
        }]
    }
);
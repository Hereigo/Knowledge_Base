
//                    angular.module("ModuleName", ["DependModules"], "AdditionalConfigs opt.")
var AppNgMainModule = angular.module('AppNgMainModule', ['ngRoute']);

// angular.module("ModuleName", []) = CREATE Module.
// angular.module("ModuleName")     = To GET Module.

// DEFAULT MODULE METHODS :
//  myAppModule.config(callback);             // register the callback to config module while loading
//  myAppModule.constant(key, value);         // define service to get constatn
//  myAppModule.controller(name, constructor); 
//  myAppModule.directive(name, factory);     // create directive to extend html
//  myAppModule.filter(name, factory);        // create filter
//  myAppModule.factory(name, provider);      // create service
//  myAppModule.provider(name, type);         // create service
//  myAppModule.service(name, constructor);   // create service

AppNgMainModule.controller('LandingPageController', LandingPageController);

var configFunction = function ($routeProvider) {

    // ROUTING :
    $routeProvider.
        when('/routeOne', {
            templateUrl: 'routesDemo/one'
        })
        .when('/routeTwo/:donuts', {
            templateUrl: function (params) {
                return '/routesDemo/two?donuts=' + params.donuts;
            }
        })
        .when('/routeThree', {
            templateUrl: 'routesDemo/three'
        });
}

configFunction.$inject = ['$routeProvider'];

AppNgMainModule.config(configFunction);


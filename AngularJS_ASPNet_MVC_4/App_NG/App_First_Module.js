
//                    angular.module("ModuleName", ["DependModules"], "AdditionalConfigs opt.")
var AppFirstModule = angular.module('AppFirstModule', ['ngRoute']);

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

AppFirstModule.controller('LandingPageController', LandingPageController);
AppFirstModule.controller('LoginController', LoginController);
AppFirstModule.controller('RegisterController', RegisterController);

AppFirstModule.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
AppFirstModule.factory('LoginFactory', LoginFactory);
AppFirstModule.factory('RegistrationFactory', RegistrationFactory);

var configFunction = function ($routeProvider, $httpProvider) {

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
        })
        .when('/login', {
            templateUrl: '/Account/Login',
            controller: LoginController
        })
        .when('/register', {
            templateUrl: '/Account/Register',
            controller: RegisterController
        });

    // HTTP INTERCEPTOR for AUTH :

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}

// INJECT PROVIDERS :

configFunction.$inject = ['$routeProvider', '$httpProvider'];

// APPLY CONFIG :

AppFirstModule.config(configFunction);


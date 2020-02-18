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
    $rootScope.TEXT = '$rootScope.TEXT';
});

// Controller with 'ngSanitize' :
myAppModule.controller('ngSanitizeUse', function ($scope) {
    $scope.ngBindHtmlCode = "Using NG-BIND-HTML with <b><i>'ngSanitize' </i></b> & <u>" + $scope.TEXT + "</u>";
});

// With No $scope :
myAppModule.controller('noScopeController', function () {
    this.message = 'just controller message.';
    this.TEXT = 'noScopeController TEXT';
});

// With $scope                            constructur :
myAppModule.controller('phonesController',
    function ($scope) {

        $scope.data = {};

        $scope.setNgIncludeTemplate = function () {
            if ($scope.data.mode == 'ng-Bind partial View')
                return 'partial-ngBind.html';
            else if ($scope.data.mode == 'ng-Model partial View')
                return 'partial-ngModel.html';
        };

        $scope.modes = [
            { value: 'ng-Bind partial View' },
            { value: 'ng-Model partial View' }];

        $scope.phones = GetPhonesModel();
    }
);
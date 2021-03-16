app.directive('itemMark', function () {

    return {
        restrict: 'E',
        scope: {},
        templateUrl: 'directives/itemMark.html',
        link: function (scope, element, attrs) {
            scope.buttonText = "Mark",
            scope.installed = false,
            scope.markItem = function () {
                element.toggleClass('btn-active');
                if (scope.installed) {
                    scope.buttonText = "Mark";
                    scope.installed = false;
                } else {
                    scope.buttonText = "Unmark";
                    scope.installed = true;
                }
            }
        }
    };
});
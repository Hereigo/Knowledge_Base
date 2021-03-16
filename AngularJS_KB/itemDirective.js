app.directive('itemInfoDirective', function () {
    return {
        restrict: 'E',
        scope: {
            info: '='
        },
        templateUrl: 'itemDirective.html',
        link: function (scope, element, attrs) {
            scope.itemBtnText = "Unlocked";

console.log(element);

            scope.itemBtnToggle = function () {

                element.toggleClass('abc');

                if (scope.itemBtnText == "Unlocked")
                    scope.itemBtnText = "Locked";
                else
                    scope.itemBtnText = "Unlocked";
            }
        }
    };
});
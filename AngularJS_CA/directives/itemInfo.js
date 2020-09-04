app.directive('itemInfo', function () {
  return {
    restrict: 'E',
    scope: {
      info: '='
    },
    templateUrl: 'directives/itemInfo.html'
  };
}); 
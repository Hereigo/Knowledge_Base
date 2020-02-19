var myApp = angular.module('ngAppModule', []);

myApp.controller('voteController', function ($scope) {

    $scope.question = {
        text: 'Vote for your favourite JS-framework :',
        date: Date(Date.now()).toString(),
        answers:
            [{
                text: 'AngularJS',
                author: 'Google',
                date: '20/10/2010',
                rate: 2
            }, {
                text: 'React',
                author: 'Facebook',
                date: '29/05/2013',
                rate: 0
            }, {
                text: 'VueJS',
                author: 'Open-source',
                date: '14/02/2014',
                rate: 0
            }]
    };

    $scope.voteUp = function (answer) {
        answer.rate++;
    };
    $scope.voteDown = function (answer) {
        answer.rate--;
    };
    $scope.questColorClass = "questcolor";
    $scope.changeClass = function (e) {

        $scope.questColorClass = e.type === "mouseover" ? "questselectedcolor" : "questcolor";
    }
});

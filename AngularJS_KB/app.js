
var app = angular.module('ngApp', []);

app.controller('firstController', function ($scope) {

    $scope.items = [
        {
            name: 'The Book of Trees',
            price: 19,
            pubdate: new Date('2014', '03', '08'),
            image: 'pic.jpg'
        },
        {
            name: 'Program or be Programmed',
            price: 8,
            pubdate: new Date('2013', '08', '01'),
            image: 'pic.jpg'
        }
    ];

});


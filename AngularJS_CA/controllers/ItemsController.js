app.controller('ItemsController', function ($scope) {

    $scope.items = [
        {
            name: 'The Book of Trees',
            price: 19,
            pubdate: new Date('2014', '03', '08'),
            image: 'img/pic.jpg',
            likes: 0
        },
        {
            name: 'Program or be Programmed',
            price: 8,
            pubdate: new Date('2013', '08', '01'),
            image: 'img/pic.jpg',
            likes: 0
        }
    ];

    $scope.plusOne = function (index) {
        $scope.items[index].likes += 1;
    };

});
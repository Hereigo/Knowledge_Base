var appModule = angular.module('ngAppModule', []);

appModule.controller('formatterController', function ($scope) {
    $scope.collection = [
        { id: 1, name: 'Alpha' },
        { id: 2, name: 'Beta' },
        { id: 3, name: 'Gamma' },
        { id: 4, name: 'Delta' },
        { id: 5, name: 'Epsilon' },
        { id: 6, name: 'Zeta' },
        { id: 7, name: 'Eta' },
        { id: 8, name: 'Theta' },
        { id: 9, name: 'Iota' },
        { id: 10, name: 'Kappa' },
        { id: 11, name: 'Lambda' },
        { id: 12, name: 'Mu' },
        { id: 13, name: 'Nu' },
        { id: 14, name: 'Xi' },
        { id: 15, name: 'Omicron' },
        { id: 16, name: 'Pi' },
        { id: 17, name: 'Rho' },
        { id: 18, name: 'Sigma' },
        { id: 19, name: 'Tau' },
        { id: 20, name: 'Upsilon' },
        { id: 21, name: 'Phi' },
        { id: 22, name: 'Chi' },
        { id: 23, name: 'Psi' },
        { id: 24, name: 'Omega' }
    ];
});
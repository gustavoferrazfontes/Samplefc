(function () {
    'use strict';

    angular.module('samplefc').config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/login', {
                controller: 'LoginCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/account/login.html'
            }).when('/logout', {
                controller: 'LogoutCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/account/login.html'
             })
            .when('/signIn', {
                controller: 'SignInCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/account/signIn.html'
            })
             .when('/products', {
                controller: 'ProductCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/Product/Index.html'
            });
            
    }]);
})();
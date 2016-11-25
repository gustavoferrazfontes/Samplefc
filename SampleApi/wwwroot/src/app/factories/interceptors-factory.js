(function () {
    'use strict';

    angular.module('samplefc').factory('AuthenticationInterceptor', LoadingInterceptor);

    LoadingInterceptor.$inject = ['$q', '$rootScope', 'SETTINGS', '$location', '$window'];

    function LoadingInterceptor($q, $rootScope, SETTINGS, $location, $window) {
        return {
            request: function (config) {
                return config;
            },
            requestError: function (rejection) {

                return $q.reject(rejection);
            },
            response: function (response) {
                return response;
            },
            responseError: function (rejection) {
               
                return $q.reject(rejection);
            }
        }


    };
})();
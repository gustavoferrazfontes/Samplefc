(function () {
    'use strict';

    angular.module('samplefc').constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_TOKEN': 'samplefc-token',
        'AUTH_USER': 'samplefc-user',
        'SERVICE_URL': 'http://localhost:58268/'//local
         
    });


    angular.module('samplefc').run(['$rootScope', '$location', 'SETTINGS', function ($rootScope, $location, SETTINGS) {
        var token = sessionStorage.getItem(SETTINGS.AUTH_TOKEN);
        var refresh_token = sessionStorage.getItem(SETTINGS.AUTH_REFRESH_TOKEN);
        var user = sessionStorage.getItem(SETTINGS.AUTH_USER);

        $rootScope.user = null;
        $rootScope.token = null;
        $rootScope.header = null;

        if (token && user && refresh_token) {
            $rootScope.user = user;
            $rootScope.token = token;
            $rootScope.header = {
                headers: {
                    'Authorization': 'Bearer ' + $rootScope.token
                }
            };
        }

        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (next.$$route.controller !== 'SignInCtrl' &&($rootScope.user === null || $rootScope.token === null)) {
                $location.path('/login');
            } else {

                $rootScope.header = {
                    headers: {
                        'Authorization': 'Bearer ' + $rootScope.token
                    }
                };
            }
        });

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-bottom-full-width",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }]);


    angular.module('samplefc').config(['cfpLoadingBarProvider', '$httpProvider', function (cfpLoadingBarProvider, $httpProvider) {
        cfpLoadingBarProvider.parentSelector = '#loading-bar-container';
        cfpLoadingBarProvider.SpinnerTemplate = '<div><span class="fa fa-spinner">Custom Loading Message...</div>';
        $httpProvider.interceptors.push('AuthenticationInterceptor');
    }]);
})();
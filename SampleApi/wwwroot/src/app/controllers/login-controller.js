(function () {
    'use strict';
    angular.module('samplefc').controller('LoginCtrl', LoginCtrl);

    LoginCtrl.$inject = ['$location', '$rootScope', 'AccountFactory', 'SETTINGS', '$scope'];

    function LoginCtrl($location, $rootScope, AccountFactory, SETTINGS, $scope) {
        var vm = this;

        vm.login = {
            username: '',
            password: ''
        };
        vm.submit = login;
        
        function login() {
            AccountFactory.login(vm.login)
            .success(success)
            .catch(fail);

            function success(response) {

                $rootScope.user = vm.login.username;
                $rootScope.token = response.access_token;
                $rootScope.refresh_token = response.refresh_token;
                sessionStorage.setItem(SETTINGS.AUTH_TOKEN, response.access_token);
                sessionStorage.setItem(SETTINGS.AUTH_REFRESH_TOKEN, response.refresh_token);
                sessionStorage.setItem(SETTINGS.AUTH_USER, $rootScope.user);
                $location.path('/products');
                toastr.success('Autenticado com sucesso!');
            }

            function fail(error) {
                toastr.error(error.data.error_description);
            }
        }
    };


})();
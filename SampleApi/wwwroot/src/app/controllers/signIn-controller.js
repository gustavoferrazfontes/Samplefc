(function () {
    'use strict';
    angular.module('samplefc').controller('SignInCtrl', SignInCtrl);

    SignInCtrl.$inject = ['$location', '$rootScope', 'AccountFactory'];

    function SignInCtrl($location, $rootScope, AccountFactory) {

        var vm = this;

        vm.signIn = {
            username: '',
            email:'',
            emailConfirmed:'',
            password: '',
            confirmPassword: ''
        };

        vm.submit = signIn;

        vm.submit = signIn;

        function signIn() {
            AccountFactory.signIn(vm.signIn)
            .success(success)
            .catch(fail);
        };

        function success(response) {
            toastr.success("Cadastro realizado com sucesso! Agora você pode fazer o login :)");
            $location.path('/login');
        };

        function fail(error) {
           angular.forEach(error.data, function (value, key) {
                    toastr.error(value.value);
                });
        };

    };
})();
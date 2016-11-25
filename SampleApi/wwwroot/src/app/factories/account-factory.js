(function () {
    angular.module('samplefc').factory('AccountFactory', AccountFactory);

    AccountFactory.$inject = ['$http', 'SETTINGS'];

    function AccountFactory($http, SETTINGS) {

        return {
            login: _login,
            signIn: _signIn

        };

       

        function _login(data) {
            var dt = "grant_type=password&username=" + data.username + "&password=" + data.password;
            var url = SETTINGS.SERVICE_URL + 'api/security/token';
            var header = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };
            return $http.post(url, dt, header);
        }

        function _signIn(data) {
            var url = SETTINGS.SERVICE_URL + 'api/account/users'
            var header = { headers: { 'Content-Type': 'application/json' } };
            return $http.post(url, data, header);
        }

    };

})();
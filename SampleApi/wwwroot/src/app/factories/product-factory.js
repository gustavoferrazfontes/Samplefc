(function () {
    angular.module('samplefc').factory('ProductFactory', ProductFactory);

    ProductFactory.$inject = ['$http', '$rootScope','SETTINGS'];

    function ProductFactory($http, $rootScope,SETTINGS) {

        return {
            getAll: _getAll,
            

        };

        function _getAll() {
            var url = SETTINGS.SERVICE_URL + 'api/products';
            var header = $rootScope.header;
            return $http.get(url,header);
        }

    };

})();
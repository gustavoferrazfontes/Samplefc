(function () {
    'use strict';
    angular.module('samplefc').controller('ProductCtrl', ProductCtrl);

    ProductCtrl.$inject = ['$location', 'ProductFactory'];

    function ProductCtrl($location, ProductFactory) {
        var vm = this;

        vm.products = [];
         Initialize();     


        function Initialize() {
            getAll();
        }


        function getAll() {
            ProductFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.products = response;
            }

            function fail(error) {
                if(error.status === 401){
                    toastr.warning("sessão expirada")
                    $location.path('/logout');
                }

            }
        }
    };


})();
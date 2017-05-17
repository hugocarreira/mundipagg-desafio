
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web')
        .service('servicoBuscar', servicoBuscar);


    servicoBuscar.$inject = ['$http'];
    function servicoBuscar($http) {

        return {
            getAll: function () {
                return $http.get('http://localhost:2017/api/divida/getpessoas/_search');
            }
        };
    }
})();


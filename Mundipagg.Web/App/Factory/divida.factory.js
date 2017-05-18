
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web')
        .service('servicoDivida', servicoDivida);


    servicoDivida.$inject = ['$http'];
    function servicoDivida($http) {

        var factory = {
            getDividas: getDividas,
            setDivida: setDivida
        }

        
        function getDividas() {
            return $http.get('http://localhost:2017/api/divida/getpessoas/_search');
        }

        function setDivida(dados) {

            var jsonData = JSON.stringify(dados);

            return $http({
                method: 'POST',
                url: 'http://localhost:2017/api/divida/setdivida/',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8'
                },
                data: jsonData
            });
        }

        return factory;
        
    }
})();


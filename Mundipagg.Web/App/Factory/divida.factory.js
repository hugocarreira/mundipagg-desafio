
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web')
        .service('servicoDivida', servicoDivida);


    servicoDivida.$inject = ['$http'];
    function servicoDivida($http) {

        var factory = {
            getDividas: getDividas,
            setDivida: setDivida,
            getDivida: getDivida
        }

        
        function getDividas() {
            return $http.get('http://localhost:2017/api/divida/getDivida/_search');
        }

        function getDivida(id) {

            var jsonData = JSON.stringify({ 'SequencialDivida': id });
            return $http({
                method: 'POST',
                url: 'http://localhost:2017/api/divida/getbyseq/',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8'
                },
                data: jsonData
            });
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


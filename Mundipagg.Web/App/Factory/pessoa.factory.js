
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web')
        .service('servicoPessoa', servicoPessoa);


    servicoPessoa.$inject = ['$http'];
    function servicoPessoa($http) {

        var factory = {
            getPessoas: getPessoas,
            setPessoas: setPessoas
        }

        function getPessoas(id) {

            var jsonData = JSON.stringify({ 'SequencialPessoaDivida': id });
            return $http({
                method: 'POST',
                url: 'http://localhost:2017/api/pessoa/getbyseq/',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8'
                },
                data: jsonData
            });
        }

        function setPessoas(dados) {

            var jsonData = JSON.stringify(dados);
            return $http({
                method: 'POST',
                url: 'http://localhost:2017/api/pessoa/setpessoa/',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8'
                },
                data: jsonData
            });
        }

        return factory;

    }
})();


﻿
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web.Controllers')
        .controller('DividaController', DividaController);


    DividaController.$inject = ['servicoDivida', '$state', 'ngProgressLite', '$timeout', 'toastr'];
    function DividaController(servicoDivida, $state, ngProgressLite, $timeout, toastr) {
        var vm = this;

        vm.show = 0;
        ngProgressLite.start();
        $timeout(function () {
            ngProgressLite.done();
            vm.show = 1;
        }, 250);

        vm.title = 'Cadastrar novo ocorrido';

        vm.adicionarDivida = adicionarDivida;

        function adicionarDivida(dados) {
            var formInput = angular.copy(dados);
            formInput.SequencialDivida = Math.floor(Math.random() * 10000);
            servicoDivida.setDivida(formInput).then(function (successCallback) {
                toastr.success('Cadastro realizado!');
                $state.go('home.divida', { id: formInput.SequencialDivida });
            })
        }

    }
})();


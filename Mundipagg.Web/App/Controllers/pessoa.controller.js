﻿
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web.Controllers')
        .controller('PessoaController', PessoaController);


    PessoaController.$inject = ['ngProgressLite', '$timeout', 'toastr', 'servicoPessoa', '$location', '$state'];
    function PessoaController(ngProgressLite, $timeout, toastr, servicoPessoa, $location, $state) {
        var vm = this;

        vm.show = 0;
        ngProgressLite.start();
        $timeout(function () {
            listarPessoas();
            ngProgressLite.done();
            vm.show = 1;
        }, 250);

        vm.title = 'Cadastre as pessoas envolvidas';
        vm.cadastrarPessoa = cadastrarPessoa;

        var SequencialPessoaDivida = $location.path().replace(/\D/g, '');        

        function cadastrarPessoa(dados) {
            var formInput = angular.copy(dados);
            formInput.SequencialPessoa = Math.floor(Math.random() * 10000);
            formInput.SequencialPessoaDivida = SequencialPessoaDivida;

            servicoPessoa.setPessoas(formInput).then(function (successCallback) {
                toastr.success('Pessoa cadastrada com sucesso!');       
                listarPessoas();
                $timeout(function () {
                    $state.go('home.divida', { id: SequencialPessoaDivida }, { reload: true });
                }, 200);
            });
        }

        function listarPessoas() {
            servicoPessoa.getPessoas(SequencialPessoaDivida).then(function (res) {
                vm.pessoas = res.data;
            });
        }                           
    }
})();



(function () {
    'use strict';

    angular
        .module('Mundipagg.Web.Controllers')
        .controller('PessoaCadastrarController', PessoaCadastrarController);


    PessoaCadastrarController.$inject = ['ngProgressLite', '$timeout'];
    function PessoaCadastrarController(ngProgressLite, $timeout) {
        var vm = this;

        vm.show = 0;
        ngProgressLite.start();
        $timeout(function () {
            ngProgressLite.done();
            vm.show = 1;
        }, 250);

        vm.title = 'Cadastre as pessoas envolvidas';

        vm.pessoas = [];

        vm.addPessoa = adicionarPessoa;
        vm.removerPessoa = removerPessoa;

        //vm.resultado = [];

        //servicoBuscar.getAll().then(function (res) {
        //    vm.pessoas = res.data;
        //});

        function adicionarPessoa() {
            var novaPessoa = vm.pessoas.length + 1;
            vm.pessoas.push({ 'pessoa': novaPessoa });
        }

        function removerPessoa() {
            var ultimaPessoa = vm.pessoas.length - 1;
            vm.pessoas.splice(ultimaPessoa);
        };
               
    }
})();


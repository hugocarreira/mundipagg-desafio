
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web.Controllers')
        .controller('BuscarController', BuscarController);


    BuscarController.$inject = ['servicoDivida', 'servicoPessoa', '$state', 'ngProgressLite', '$timeout', '$location'];
    function BuscarController(servicoDivida, servicoPessoa, $state, ngProgressLite, $timeout, $location) {
        var vm = this;
        var path = $location.path();

        vm.show = 0;
        ngProgressLite.start();
        $timeout(function () {
            ngProgressLite.done();
            vm.show = 1;
        }, 250);


        if (path === '/buscar/divida') {
            vm.title = 'Todos os ocorridos';
            buscarDividas();
        } else if (path === '/buscar/pessoa') {
            vm.title = 'Todas as pessoas';
            buscarPessoas();
        }

        function buscarDividas() {
            servicoDivida.getDividas().then(function (res) {
                vm.dividas = res.data;
            });
        }

        function buscarPessoas() {
            servicoPessoa.getTodasPessoas().then(function (res) {
                vm.pessoas = res.data;
            });
        }

    }
})();


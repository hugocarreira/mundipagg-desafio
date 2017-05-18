
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web.Controllers')
        .controller('AdicionarController', AdicionarController);


    AdicionarController.$inject = ['servicoDivida', '$state', 'ngProgressLite', '$timeout', 'toastr'];
    function AdicionarController(servicoDivida, $state, ngProgressLite, $timeout, toastr) {
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
                //$state.reload();
                $state.go('home.addpessoa', { id: formInput.SequencialDivida }); // go to login
            })
        }

        
    }
})();


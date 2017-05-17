
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web.Controllers')
        .controller('BuscarController', BuscarController);


    BuscarController.$inject = ['servicoBuscar'];
    function BuscarController(servicoBuscar) {
        var vm = this;

        vm.title = 'Todos ocorridos';

        //vm.resultado = [];

        servicoBuscar.getAll().then(function (res) {
            vm.pessoas = res.data;
        });
               
    }
})();


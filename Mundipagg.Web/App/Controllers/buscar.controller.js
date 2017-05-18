
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web.Controllers')
        .controller('BuscarController', BuscarController);


    BuscarController.$inject = ['servicoBuscar', 'ngProgressLite', '$timeout'];
    function BuscarController(servicoBuscar, ngProgressLite, $timeout) {
        var vm = this;

        vm.show = 0;
        ngProgressLite.start();
        $timeout(function () {
            ngProgressLite.done();
            vm.show = 1;
        }, 250);

        vm.title = 'Todos ocorridos';

        //vm.resultado = [];

        servicoBuscar.getAll().then(function (res) {
            vm.pessoas = res.data;
        });
               
    }
})();



(function () {
    'use strict';

    angular
        .module('Mundipagg.Web.Controllers')
        .controller('AdicionarController', AdicionarController);


    function AdicionarController() {
        var vm = this;

        vm.title = 'Cadastrar novo ocorrido';

        vm.pessoas = [];
       
        vm.addPessoa = adicionarPessoa;
        //vm.removePessoa = removerPessoa;
            
        function adicionarPessoa() {
            var novaPessoa = vm.pessoas.length + 1;
            vm.pessoas.push({ 'pessoa': novaPessoa });
        }

        //function removerPessoa() {
        //    var ultimaPessoa = vm.pessoas.length - 1;
        //    vm.pessoas.splice(ultimaPessoa);
        //};
    }
})();


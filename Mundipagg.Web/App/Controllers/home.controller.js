
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web.Controllers')
        .controller('HomeController', HomeController);


        function HomeController() {
            var vm = this;

            vm.title = 'Bem Vindos ao Controle de Dívidas';    
         
        }
})();


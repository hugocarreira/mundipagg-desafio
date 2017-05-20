
(function () {
    'use strict';

    angular
        .module('Mundipagg.Web')
        .config(config);

        config.$inject = ['$stateProvider', '$urlRouterProvider', 'ngProgressLiteProvider'];
        function config($stateProvider, $urlRouterProvider, ngProgressLiteProvider) {
            ngProgressLiteProvider.settings.ease = 'ease-in';
            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: 'Views/home.html',
                    controller: "HomeController",
                    controllerAs: "vm"
                })

                .state('home.adicionar', {
                    url: 'adicionar',
                    templateUrl: 'Views/adicionar.html',
                    controller: "AdicionarController",
                    controllerAs: "vm"
                })

                .state('home.buscar', {
                    url: 'buscar',
                    templateUrl: 'Views/buscar.html',
                    controller: "BuscarController",
                    controllerAs: "vm"
                })

                .state('home.pagar', {
                    url: 'pagar',
                    templateUrl: 'Views/pagar.html',
                    controller: "PagarController",
                    controllerAs: "vm"
                })

                .state('home.divida', {
                    url: 'divida/:id',
                    templateUrl: 'Views/pessoa.html',
                    controller: "PessoaController",
                    controllerAs: "vm"
                })

        }
})();

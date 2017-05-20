
(function () {
    'use strict';

    angular.module('Mundipagg.Web', [
        'ui.router',
        'Mundipagg.Web.Controllers',
        'ngAnimate',

        /* Modulos Externos */
        'ngProgressLite',
        'toastr',
        'ui.utils.masks'
    ]);
})();

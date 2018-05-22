(function ready() {
    'use strict';


    angular.module('fitnessApp', [
        'app.core',
        'app.landing',
        'app.register',
        'app.login',
        'app.home',
        'app.clients',
        'app.tickets',
        'app.directives'
    ]);


    angular.bootstrap(document, ['fitnessApp']);


})();
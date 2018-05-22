(function () {
    'use strict';

    angular.module('fitnessApp').config(function ($routeProvider) {

        $routeProvider
            // route for the home page
            .when('/', {
                templateUrl: 'fitnessApp/home/home.template.html',
                controller: 'HomeController'
            })

            // route for the about page
            .when('/cients', {
                templateUrl: 'fitnessApp/cients/cients.template.html',
                controller: 'ClientsController as vm'
            })
    })


})();
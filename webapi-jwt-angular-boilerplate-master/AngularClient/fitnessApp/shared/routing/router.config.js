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
            .when('/movies', {
                templateUrl: 'fitnessApp/movies/movies.template.html',
                controller: 'MoviesController as vm'
            })
    })


})();
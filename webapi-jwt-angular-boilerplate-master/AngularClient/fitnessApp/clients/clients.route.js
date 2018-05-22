(function () {
    'use strict';

    angular.module('app.clients')
        .run(clientRoute);

    clientRoute.$inject = ['routerHelper'];

    function clientRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'clients',
                config: {
                    url: '/clients',
                    parent: 'private',
                    title: 'Clients',
                    views: {
                        'main-content': {
                            templateUrl: 'fitnessApp/clients/clients.template.html',
                            controller: 'ClientsController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();
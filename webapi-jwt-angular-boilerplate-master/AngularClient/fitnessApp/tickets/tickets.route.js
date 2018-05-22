(function () {
    'use strict';

    angular.module('app.tickets')
        .run(ticketRoute);

    ticketRoute.$inject = ['routerHelper'];

    function ticketRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'tickets',
                config: {
                    url: '/tickets',
                    parent: 'private',
                    title: 'Tickets',
                    views: {
                        'main-content': {
                            templateUrl: 'fitnessApp/tickets/tickets.template.html',
                            controller: 'TicketsController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();
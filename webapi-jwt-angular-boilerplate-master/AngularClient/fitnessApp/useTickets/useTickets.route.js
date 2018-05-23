(function () {
    'use strict';

    angular.module('app.useTickets')
        .run(useTicketRoute);

    useTicketRoute.$inject = ['routerHelper'];

    function useTicketRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'useTickets',
                config: {
                    url: '/useTickets',
                    parent: 'private',
                    title: 'Use Tickets',
                    views: {
                        'main-content': {
                            templateUrl: 'fitnessApp/useTickets/useTickets.template.html',
                            controller: 'UseTicketsController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();
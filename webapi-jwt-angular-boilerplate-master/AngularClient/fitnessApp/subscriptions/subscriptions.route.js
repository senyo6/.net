(function () {
    'use strict';

    angular.module('app.subscriptions')
        .run(subscriptionsRoute);

    subscriptionsRoute.$inject = ['routerHelper'];

    function subscriptionsRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'subscriptions',
                config: {
                    url: '/subscriptions',
                    parent: 'private',
                    title: 'Manage Subscriptions',
                    views: {
                        'main-content': {
                            templateUrl: 'fitnessApp/subscriptions/subscriptions.template.html',
                            controller: 'SubscriptionsController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();
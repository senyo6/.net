(function () {
    'use strict';

    angular.module('app.subscriptions').controller('SubscriptionsController', SubscriptionsController);

    SubscriptionsController.$inject = ['$scope', '$uibModal', 'ClientTicketService']

    function SubscriptionsController($scope, $uibModal, ClientTicketService) {

        var vm = this;
        vm.clientTickets = [];

        vm.getClientTickets = function () {
            ClientTicketService.getClientTicketsDetailed().then(function (response) {
                vm.clientTickets = response.data;
            }, function (error) {
                // Handle
            });
        }

        vm.getClientTickets();

        vm.openDialog = function (clientTicket, title) {

            var modalInstance = $uibModal.open({
                templateUrl: 'fitnessApp/subscriptions/dialog/subscriptionDialog.template.html',
                controller: 'SubscriptionDialogController',
                controllerAs: 'vm',
                size: 'lg',
                resolve: {
                    clientTicket: function () {
                        return clientTicket;
                    },
                    title: function () {
                        return title;
                    }
                }
            });
            modalInstance.result.then(function (response) {
                vm.getClientTickets();
            }, function (response) {
                // Handle cancel
            });
        }


        vm.addClientTicket = function () {
            var title = "Add new"
            vm.openDialog(undefined, title)
        }

        vm.editClientTicket = function (clientTicket) {
            var title = "Edit"
            vm.openDialog(clientTicket, title);
        }

        vm.deleteClientTicket = function (clientTicketId) {
            ClientTicketService.deleteClientTicket(clientTicketId).then(function (response) {
                vm.getClientTickets();
            }, function (error) {
                // Handle
            });
        }
    }
})();
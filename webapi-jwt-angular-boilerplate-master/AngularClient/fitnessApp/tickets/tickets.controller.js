(function () {
    'use strict';

    angular.module('app.tickets').controller('TicketsController', TicketsController);

    TicketsController.$inject = ['$scope', '$uibModal', 'TicketService']

    function TicketsController($scope, $uibModal, TicketService) {

        var vm = this;
        vm.tickets = [];

        vm.getTickets = function () {
            TicketService.getTickets().then(function (response) {
                vm.tickets = response.data;
            }, function (error) {
                // Handle
            });
        }

        vm.getTickets();

        vm.openDialog = function (ticket, title) {

            var modalInstance = $uibModal.open({
                templateUrl: 'fitnessApp/tickets/dialog/ticketDialog.template.html',
                controller: 'TicketDialogController',
                controllerAs: 'vm',
                size: 'lg',
                resolve: {
                    ticket: function () {
                        return ticket;
                    },
                    title: function () {
                        return title;
                    }
                }
            });
            modalInstance.result.then(function (response) {
                vm.getTickets();
            }, function (response) {
                // Handle cancel
            });
        }


        vm.addTicket = function () {
            var title = "Add new"
            vm.openDialog(undefined, title)
        }

        vm.editTicket = function (ticket) {
            var title = "Edit"
            vm.openDialog(ticket, title);
        }

        vm.deleteTicket = function (ticketId) {
            TicketService.deleteTicket(ticketId).then(function (response) {
                vm.getTickets();
            }, function (error) {
                // Handle
            });
        }
    }
})();
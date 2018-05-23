(function () {
    'use strict';

    angular.module('app.useTickets').controller('UseTicketsController', UseTicketsController);

    UseTicketsController.$inject = ['$scope', '$uibModal', 'ClientTicketService', 'ClientService']

    function UseTicketsController($scope, $uibModal, ClientTicketService, ClientService) {

        var vm = this;
        vm.now = new Date();
        vm.clients = [];
        vm.ticketsOfClient = [];
        vm.selectedClient = null;

        vm.getClients = function () {
            ClientService.getClients().then(function (response) {
                vm.clients = response.data;
            }, function (error) {
                // Handle
            });
        }

        vm.getTicketsOfClient = function (clientId) {
            ClientTicketService.getTicketsOfClient(clientId).then(function (response) {
                vm.ticketsOfClient = response.data;
                for (let clientTicket of vm.ticketsOfClient) {
                    clientTicket.endDate = vm.addDaysToDate(clientTicket.purchaseDate, clientTicket.ticket.validityDayCount);
                }
            }, function (error) {
                // Handle
            });
        }

        vm.addDaysToDate = function (date, days) {
            var dat = new Date(date);
            dat.setDate(dat.getDate() + days);
            return dat;
        }

        vm.getClients();

        vm.clientSelected = function () {
            vm.getTicketsOfClient(vm.selectedClient);
        }

        vm.useTicket = function (id) {
            ClientTicketService.useTicket(id).then(function (response) {
                vm.getTicketsOfClient(vm.selectedClient);
            }, function (error) {
                // Handle
            });
        }
    }
})();
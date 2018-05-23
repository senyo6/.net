angular.module('app.subscriptions').controller('SubscriptionDialogController', function ($uibModalInstance, ClientTicketService, ClientService, TicketService, clientTicket, title) {
    var vm = this;

    vm.title = title;
    vm.clientTicket = clientTicket;
    vm.clients = [];
    vm.tickets = [];

    vm.getClients = function () {
        ClientService.getClients().then(function (result) {
            vm.clients = result.data;
        }, function (error) {
            // Handle
        });
    }

    vm.getTickets = function () {
        TicketService.getTickets().then(function (result) {
            vm.tickets = result.data;
        }, function (error) {
            // Handle
        });
    }

    vm.getClients();
    vm.getTickets();

    vm.save = function () {
        if (vm.clientTicket.id == undefined) {
            vm.clientTicket.purchaseDate = new Date();
            ClientTicketService.addNewClientTicket(vm.clientTicket).then(function (response) {
                $uibModalInstance.close({ response: response });
            }, function (error) {
                // Handle
            });
        }
        else {
            ClientTicketService.updateClientTicket(vm.clientTicket).then(function (response) {
                $uibModalInstance.close({ response: response });
            }, function (error) {
                // Handle
            });
        }
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
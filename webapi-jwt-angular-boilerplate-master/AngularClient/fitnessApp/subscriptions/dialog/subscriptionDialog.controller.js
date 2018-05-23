angular.module('app.subscriptions').controller('SubscriptionDialogController', function ($uibModalInstance, ClientTicketService, ClientService, TicketService, clientTicket, title) {
    var vm = this;

    vm.title = title;
    vm.clientTicket = clientTicket;
    vm.clients = [];
    vm.tickets = [];
    vm.ticketMap = {};
    vm.errors = [];
    vm.errorToggle = false;

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
            for (let ticket of result.data) {
                vm.ticketMap[ticket.id] = ticket;
            }
        }, function (error) {
            // Handle
        });
    }

    vm.getClients();
    vm.getTickets();

    vm.setEntry = function (id) {
        if (!vm.clientTicket.id) {
            vm.clientTicket.remainedEntryCount = vm.ticketMap[id].entryCount;
        }
    };

    vm.save = function () {
        console.log(vm.myForm);
        if (vm.myForm.$valid) {
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
        } else {
            vm.error.push("Error Occured; ");
            if (!vm.myForm.client.$valid) {
                if (vm.myForm.client.$viewValue) {
                    vm.error.push("Client not selected; ");
                } else {
                    vm.error.push("Incorrect Client; ");
                }
            }
            if (!vm.myForm.ticket.$valid) {
                if (vm.myForm.ticket.$viewValue) {
                    vm.error.push("Ticket not selected; ");
                } else {
                    vm.error.push("Incorrect Ticket; ");
                }
            }
        }
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
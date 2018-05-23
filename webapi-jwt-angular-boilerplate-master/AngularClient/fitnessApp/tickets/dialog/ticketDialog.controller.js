﻿angular.module('app.tickets').controller('TicketDialogController', function ($uibModalInstance, TicketService, ticket, title) {
    var vm = this;

    vm.title = title;
    vm.ticket = ticket;

    vm.save = function () {
        if (vm.ticket.id == undefined) {
            TicketService.addNewTicket(vm.ticket).then(function (response) {
                $uibModalInstance.close({ response: response });
            });
        }
        else {
            TicketService.updateTicket(vm.ticket).then(function (response) {
                $uibModalInstance.close({ response: response });
            });
        }
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
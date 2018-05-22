angular.module('app.tickets').controller('TicketDialogController', function ($uibModalInstance, TicketService, ticket, title) {
    var vm = this;

    vm.title = title;
    vm.ticket = ticket;
    if (vm.ticket) {
        vm.ticket.joinDate = new Date(vm.ticket.joinDate);
    }

    vm.dateFormat = "yyyy.MM.dd";
    vm.popup = {
        opened: false
    };

    vm.open = function () {
        vm.popup.opened = true;
    };

    vm.save = function () {
        vm.ticket.ticketTypeId = 1;
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
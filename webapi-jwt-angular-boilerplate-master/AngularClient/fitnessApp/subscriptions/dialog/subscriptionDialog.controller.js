angular.module('app.subscriptions').controller('SubscriptionDialogController', function ($uibModalInstance, ClientTicketService, clientTicket, title) {
    var vm = this;

    vm.title = title;
    vm.clientTicket = clientTicket;

    vm.save = function () {
        if (vm.clientTicket.id == undefined) {
            vm.clientTicket.purchaseDate = new Date();
            ClientTicketService.addNewClientTicket(vm.clientTicket).then(function (response) {
                $uibModalInstance.close({ response: response });
            });
        }
        else {
            ClientTicketService.updateClientTicket(vm.clientTicket).then(function (response) {
                $uibModalInstance.close({ response: response });
            });
        }
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
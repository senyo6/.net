angular.module('app.clients').controller('ClientDialogController', function ($uibModalInstance, ClientService, client, title) {
    var vm = this;

    vm.title = title;
    vm.client = client;
    if (vm.client) {
        vm.client.joinDate = new Date(vm.client.joinDate);
    }

    vm.dateFormat = "yyyy.MM.dd";
    vm.popup = {
        opened: false
    };

    vm.open = function () {
        vm.popup.opened = true;
    };

    vm.save = function () {
        vm.client.clientTypeId = 1;
        if (vm.client.id == undefined) {
            ClientService.addNewClient(vm.client).then(function (response) {
                $uibModalInstance.close({ response: response });
            });
        }
        else {
            ClientService.updateClient(vm.client).then(function (response) {
                $uibModalInstance.close({ response: response });
            });
        }
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
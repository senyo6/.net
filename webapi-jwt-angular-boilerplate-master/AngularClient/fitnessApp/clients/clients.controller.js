(function () {
    'use strict';

    angular.module('app.clients').controller('ClientsController', ClientsController);

    ClientsController.$inject = ['$scope', '$uibModal', 'ClientService']

    function ClientsController($scope, $uibModal, ClientService) {

        var vm = this;
        vm.clients = [];

        vm.getClients = function () {
            ClientService.getClients().then(function (response) {
                vm.clients = response.data;
            }, function (error) {
                // Handle
            });
        }

        vm.getClients();
        
        vm.openDialog = function (client, title) {

            var modalInstance = $uibModal.open({
                templateUrl: 'fitnessApp/clients/dialog/clientDialog.template.html',
                controller: 'ClientDialogController',
                controllerAs: 'vm',
                size: 'lg',
                resolve: {
                    client: function () {
                        return client;
                    },
                    title: function () {
                        return title;
                    }
                }
            });
            modalInstance.result.then(function (response) {
                vm.getClients();
            }, function (response) {
                // Handle cancel
            });
        }


        vm.addClient = function () {
            var title = "Add new"
            vm.openDialog(undefined, title)
        }

        vm.editClient = function (client) {
            var title = "Edit"
            vm.openDialog(client, title);
        }

        vm.deleteClient = function (clientId) {
            ClientService.deleteClient(clientId).then(function (response) {
                vm.getClients();
            }, function (error) {
                // Handle
            });
        }
    }
})();
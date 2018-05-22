(function () {
    'use strict';

    angular.module('app.clients').factory('ClientService', ClientService);

    ClientService.$inject = ['$http'];

    function ClientService($http) {

        var serviceBase = "http://localhost:60472/";
        var ClientServiceFactory = {};

        var getClients = function () {
            return $http.get(serviceBase + 'api/client/get').then(function (clients) {
                return clients;
            });
        }

        var addNewClient = function (clientModel) {
            return $http.post(serviceBase + 'api/client/create', clientModel).then(function (newClient) {
                return newClient;
            })
        }

        var updateClient = function (clientModel) {
            return $http.put(serviceBase + 'api/client/update', clientModel).then(function (updatedClient) {
                return updatedClient;
            })
        }

        var deleteClient = function (id) {
            return $http.delete(serviceBase + 'api/client/delete?id=' + id).then(function (deletedClient) {
                return deletedClient;
            });
        }

        ClientServiceFactory.getClients = getClients;
        ClientServiceFactory.addNewClient = addNewClient;
        ClientServiceFactory.updateClient = updateClient;
        ClientServiceFactory.deleteClient = deleteClient;

        return ClientServiceFactory;
    }

})()
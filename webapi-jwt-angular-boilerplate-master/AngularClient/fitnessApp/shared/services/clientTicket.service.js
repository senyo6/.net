(function () {
    'use strict';

    angular.module('app.subscriptions').factory('ClientTicketService', ClientTicketService);

    ClientTicketService.$inject = ['$http'];

    function ClientTicketService($http) {

        var serviceBase = "http://localhost:60472/";
        var ClientTicketServiceFactory = {};

        var getClientTickets = function () {
            return $http.get(serviceBase + 'api/clientticket/get').then(function (clientTickets) {
                return clientTickets;
            });
        }

        var addNewClientTicket = function (clientTicketModel) {
            return $http.post(serviceBase + 'api/clientticket/create', clientTicketModel).then(function (newClientTicket) {
                return newClientTicket;
            })
        }

        var updateClientTicket = function (clientTicketModel) {
            return $http.put(serviceBase + 'api/clientticket/update', clientTicketModel).then(function (updatedClientTicket) {
                return updatedClientTicket;
            })
        }

        var deleteClientTicket = function (id) {
            return $http.delete(serviceBase + 'api/clientticket/delete?id=' + id).then(function (deletedClientTicket) {
                return deletedClientTicket;
            });
        }

        ClientTicketServiceFactory.getClientTickets = getClientTickets;
        ClientTicketServiceFactory.addNewClientTicket = addNewClientTicket;
        ClientTicketServiceFactory.updateClientTicket = updateClientTicket;
        ClientTicketServiceFactory.deleteClientTicket = deleteClientTicket;

        return ClientTicketServiceFactory;
    }

})()
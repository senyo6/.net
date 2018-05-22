(function () {
    'use strict';

    angular.module('app.tickets').factory('TicketService', TicketService);

    TicketService.$inject = ['$http'];

    function TicketService($http) {

        var serviceBase = "http://localhost:60472/";
        var TicketServiceFactory = {};

        var getTickets = function () {
            return $http.get(serviceBase + 'api/ticket/get', {
                skipAuthorization: true
            }).then(function (tickets) {
                return tickets;
            });
        }

        var addNewTicket = function (ticketModel) {
            return $http.post(serviceBase + 'api/ticket/create', ticketModel).then(function (newTicket) {
                return newTicket;
            })
        }

        var updateTicket = function (ticketModel) {
            return $http.put(serviceBase + 'api/ticket/update', ticketModel).then(function (updatedTicket) {
                return updatedTicket;
            })
        }

        var deleteTicket = function (id) {
            return $http.delete(serviceBase + 'api/ticket/delete?id=' + id).then(function (deletedTicket) {
                return deletedTicket;
            });
        }

        TicketServiceFactory.getTickets = getTickets;
        TicketServiceFactory.addNewTicket = addNewTicket;
        TicketServiceFactory.updateTicket = updateTicket;
        TicketServiceFactory.deleteTicket = deleteTicket;

        return TicketServiceFactory;
    }

})()
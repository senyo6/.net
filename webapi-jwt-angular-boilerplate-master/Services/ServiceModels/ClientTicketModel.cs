using System;

namespace Services.ServiceModels
{
    public class ClientTicketModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TicketId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int RemainingEntries { get; set; }
    }

    public class ClientTicketDetailModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public ClientModel Client { get; set; }

        public int TicketId { get; set; }
        public TicketModel Ticket { get; set; }

        public DateTime PurchaseDate { get; set; }
        public int RemainingEntries { get; set; }
    }
}

using System;

namespace Services.ServiceModels
{
    public class ClientTicketModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public DateTime PurchaseDate { get; set; }
        public int RemainedEntryCount { get; set; }
    }
}

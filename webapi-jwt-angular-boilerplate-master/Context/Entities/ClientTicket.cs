using System;
using System.ComponentModel.DataAnnotations.Schema;
using Context;

public class ClientTicket : Entity
{
    [ForeignKey ("Client")]
    public int ClientId { get; set; }
    public Client Client { get; set; }

    [ForeignKey ("Ticket")]
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }

    public DateTime PurchaseDate { get; set; }
    public int RemainedEntryCount { get; set; }
}

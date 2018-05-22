using System;

namespace Services.ServiceModels
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int EntryCount { get; set; }
        public int ValidityDayCount { get; set; }
        public string Description { get; set; }
    }
}

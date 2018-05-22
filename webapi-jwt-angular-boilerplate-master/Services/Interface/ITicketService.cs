using System.Collections.Generic;
using Services.ServiceModels;

namespace Services.Interface
{
    public interface ITicketService
    {
        TicketModel Add (TicketModel model);
        TicketModel Update (TicketModel model);
        void Delete (int id);
        TicketModel GetById (int id);
        IEnumerable<TicketModel> GetAll ();
    }
}

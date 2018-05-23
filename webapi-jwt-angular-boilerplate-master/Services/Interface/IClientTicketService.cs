using System.Collections.Generic;
using Services.ServiceModels;

namespace Services.Interface
{
    public interface IClientTicketService
    {
        ClientTicketModel Add (ClientTicketModel model);
        ClientTicketModel Update (ClientTicketModel model);
        void Delete (int id);
        ClientTicketModel GetById (int id);
        IEnumerable<ClientTicketModel> GetAll ();
        IEnumerable<ClientTicketDetailModel> GetAllDetailed ();
        IEnumerable<ClientTicketDetailModel> GetTicketsOfClientDetailed(int clientId);
        bool UseTicket(int clientTicketId);
    }
}

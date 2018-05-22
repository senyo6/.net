using Ambient.Context.Interfaces;
using Context.Entities;
using Infrastructure.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class ClientTicketRepository : GenericRepository<ClientTicket>, IClientTicketRepository
    {
        public ClientTicketRepository (IAmbientDbContextLocator contextLocator) : base (contextLocator)
        {
        }
    }
}

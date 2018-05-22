using Ambient.Context.Interfaces;
using Context.Entities;
using Infrastructure.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository (IAmbientDbContextLocator contextLocator) : base (contextLocator)
        {
        }
    }
}

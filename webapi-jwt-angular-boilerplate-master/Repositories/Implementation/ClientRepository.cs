using Ambient.Context.Interfaces;
using Context.Entities;
using Infrastructure.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository (IAmbientDbContextLocator contextLocator) : base (contextLocator)
        {
        }
    }
}

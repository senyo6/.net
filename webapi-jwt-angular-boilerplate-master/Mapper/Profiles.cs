using AutoMapper;
using Context.Entities;
using Services.ServiceModels;
using System.Collections.Generic;

namespace Mapper
{
    public static class MapperConfig
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
              new ClientProfile(),
              new TicketProfile(),
              new ClientTicketProfile()
            };
        }
    }

    public class ClientProfile : Profile
    {
        public ClientProfile ()
        {
            CreateMap<Client, ClientModel> ();
            CreateMap<ClientModel, Client> ();
        }
    }

    public class TicketProfile : Profile
    {
        public TicketProfile ()
        {
            CreateMap<Ticket, TicketModel> ();
            CreateMap<TicketModel, Ticket> ();
        }
    }

    public class ClientTicketProfile : Profile
    {
        public ClientTicketProfile ()
        {
            CreateMap<ClientTicket, ClientTicketModel> ();
            CreateMap<ClientTicketModel, ClientTicket> ();
        }
    }
}

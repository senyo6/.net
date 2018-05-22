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
              new MovieProfile(),
              new ClientProfile(),
              new TicketProfile()
            };
        }
    }

    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieModel>();
            CreateMap<MovieModel, Movie>();
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
}

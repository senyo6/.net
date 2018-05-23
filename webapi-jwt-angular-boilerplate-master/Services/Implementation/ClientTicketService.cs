using System.Collections.Generic;
using System.Linq;
using Ambient.Context.Interfaces;
using Repositories.Interface;
using Services.Interface;
using Services.ServiceModels;
using AutoMapper;

namespace Services.Implementation
{

    public class ClientTicketService : IClientTicketService
    {
        private readonly IClientTicketRepository _repository;
        private readonly IClientRepository _clientRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public ClientTicketService(
            IMapper mapper, 
            ITicketRepository ticketRepository,
            IClientTicketRepository repository, 
            IClientRepository clientRepository,
            IDbContextScopeFactory contextScopeFactory
        ) {
            _mapper = mapper;
            _repository = repository;
            _clientRepository = clientRepository;
            _ticketRepository = ticketRepository;
            _contextScopeFactory = contextScopeFactory;
        }

        public IEnumerable<ClientTicketModel> GetAll ()
        {
            using (var scope = _contextScopeFactory.CreateReadOnly ())
            {
                var objects = _repository.GetAllActive ().ToList ();
                var models = _mapper.Map<List<ClientTicketModel>> (objects);
                return models;
            }
        }

        public IEnumerable<ClientTicketDetailModel> GetAllDetailed ()
        {
            using (var scope = _contextScopeFactory.Create ())
            {
                var clientTickets = _repository.GetAllActive ().ToList ();
                var clients = _clientRepository.GetAllActive ().ToList ();
                var tickets = _ticketRepository.GetAllActive ().ToList ();
                var data = from clientTicket in clientTickets
                             join client in clients
                             on clientTicket.ClientId equals client.Id
                             join ticket in tickets
                             on clientTicket.TicketId equals ticket.Id
                             select new ClientTicketDetailModel
                             {
                                 Id = clientTicket.Id,
                                 ClientId = client.Id,
                                 Client = _mapper.Map<ClientModel>(client),
                                 TicketId = ticket.Id,
                                 Ticket = _mapper.Map<TicketModel>(ticket),
                                 PurchaseDate = clientTicket.PurchaseDate,
                                 RemainingEntries = clientTicket.RemainingEntries
                             };

                return data.ToList ();
            }
        }

        public IEnumerable<ClientTicketDetailModel> GetTicketsOfClientDetailed(int clientId)
        {
            using (var scope = _contextScopeFactory.Create())
            {
                var clientTickets = _repository.GetAllActive().ToList();
                var clients = _clientRepository.GetAllActive().ToList();
                var tickets = _ticketRepository.GetAllActive().ToList();
                var data = from clientTicket in clientTickets
                           .Where(clientTicket => clientTicket.ClientId == clientId)
                           join client in clients
                           on clientTicket.ClientId equals client.Id
                           join ticket in tickets
                           on clientTicket.TicketId equals ticket.Id
                           select new ClientTicketDetailModel
                           {
                               Id = clientTicket.Id,
                               ClientId = client.Id,
                               Client = _mapper.Map<ClientModel>(client),
                               TicketId = ticket.Id,
                               Ticket = _mapper.Map<TicketModel>(ticket),
                               PurchaseDate = clientTicket.PurchaseDate,
                               RemainingEntries = clientTicket.RemainingEntries
                           };

                return data.ToList();
            }
        }

        public ClientTicketModel Add (ClientTicketModel model)
        {
            using (var scope = _contextScopeFactory.Create ())
            {
                var entity = _mapper.Map<ClientTicket>(model);
                _repository.Add (entity);
                _repository.Save ();
                return model;
            }
        }

        public ClientTicketModel Update (ClientTicketModel model)
        {
            using (var scope = _contextScopeFactory.Create ())
            {
                var entity = _repository.GetById (model.Id);
                entity.ClientId = model.ClientId;
                entity.TicketId = model.TicketId;
                entity.PurchaseDate = model.PurchaseDate;
                entity.RemainingEntries = model.RemainingEntries;
                _repository.Edit (entity);
                _repository.Save ();
                return _mapper.Map<ClientTicketModel>(entity);
            }
        }

        public void Delete (int id)
        {
            using (var scope = _contextScopeFactory.Create ())
            {
                _repository.Delete (id);
                _repository.Save ();
            }
        }

        public ClientTicketModel GetById (int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly ())
            {
                var entity = _repository.GetById (id);
                return _mapper.Map<ClientTicketModel>(entity);
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Ambient.Context.Interfaces;
using Context.Entities;
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

        public ClientTicketService (IClientTicketRepository repository, IMapper mapper, IDbContextScopeFactory contextScopeFactory)
        {
            _repository = repository;
            _mapper = mapper;
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

        public IEnumerable<ClientTicketModel> GetAllDetailed ()
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
                             select new ClientTicketModel
                             {
                                 Id = clientTicket.Id,
                                 ClientId = client.Id,
                                 Client = new ClientModel
                                 {
                                     Id = client.Id,
                                     Name = client.Name,
                                     PhoneNumber = client.PhoneNumber,
                                     Email = client.Email,
                                     Address = client.Address,
                                     JoinDate = client.JoinDate
                                 },
                                 TicketId = ticket.Id,
                                 Ticket = new TicketModel
                                 {
                                     Id = ticket.Id,
                                     Name = ticket.Name,
                                     Price = ticket.Price,
                                     EntryCount = ticket.EntryCount,
                                     ValidityDayCount = ticket.ValidityDayCount,
                                     Description = ticket.Description
                                 },
                                 PurchaseDate = clientTicket.PurchaseDate,
                                 RemainedEntryCount = clientTicket.RemainedEntryCount
                             };
                return data.ToList ();
            }
        }

        public ClientTicketModel Add (ClientTicketModel model)
        {
            using (var scope = _contextScopeFactory.Create ())
            {
                var entity = new ClientTicket
                {
                    IsDeleted = false,
                    ClientId = model.ClientId,
                    Client = model.Client,
                    TicketId = model.TicketId,
                    Ticket = model.Ticket,
                    PurchaseDate = model.PurchaseDate,
                    RemainedEntryCount = model.RemainedEntryCount
                };
                _repository.Add (entity);
                _repository.Save ();
                return new ClientTicketModel
                {
                    Id = entity.Id,
                    ClientId = entity.ClientId,
                    Client = entity.Client,
                    TicketId = entity.TicketId,
                    Ticket = entity.Ticket,
                    PurchaseDate = entity.PurchaseDate,
                    RemainedEntryCount = entity.RemainedEntryCount
                };
            }
        }

        public ClientTicketModel Update (ClientTicketModel model)
        {
            using (var scope = _contextScopeFactory.Create ())
            {
                var entity = _repository.GetById (model.Id);
                entity.ClientId = model.ClientId;
                entity.Client = model.Client;
                entity.TicketId = model.TicketId;
                entity.Ticket = model.Ticket;
                entity.PurchaseDate = model.PurchaseDate;
                entity.RemainedEntryCount = model.RemainedEntryCount;
                _repository.Edit (entity);
                _repository.Save ();
                return new ClientTicketModel
                {
                    Id = entity.Id,
                    ClientId = entity.ClientId,
                    Client = entity.Client,
                    TicketId = entity.TicketId,
                    Ticket = entity.Ticket,
                    PurchaseDate = entity.PurchaseDate,
                    RemainedEntryCount = entity.RemainedEntryCount
                };
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
                return new ClientTicketModel
                {
                    ClientId = entity.ClientId,
                    Client = entity.Client,
                    TicketId = entity.TicketId,
                    Ticket = entity.Ticket,
                    PurchaseDate = entity.PurchaseDate,
                    RemainedEntryCount = entity.RemainedEntryCount
                };
            }
        }
    }
}

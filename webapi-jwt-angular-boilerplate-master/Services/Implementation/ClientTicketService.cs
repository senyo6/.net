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

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

    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public TicketService(ITicketRepository repository, IMapper mapper, IDbContextScopeFactory contextScopeFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _contextScopeFactory = contextScopeFactory;
        }

        public IEnumerable<TicketModel> GetAll()
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var objects = _repository.GetAllActive().ToList();
                var models = _mapper.Map<List<TicketModel>>(objects);
                return models;
            }
        }

        public TicketModel Add(TicketModel model)
        {
            using (var scope = _contextScopeFactory.Create())
            {
                var entity = _mapper.Map<Ticket> (model);
                _repository.Add(entity);
                _repository.Save();
                return model;
            }
        }

        public TicketModel Update(TicketModel model)
        {
            using (var scope = _contextScopeFactory.Create())
            {
                var entity = _repository.GetById(model.Id);
                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.EntryCount = model.EntryCount;
                entity.ValidityDayCount = model.ValidityDayCount;
                entity.Description = model.Description;
                _repository.Edit(entity);
                _repository.Save();
                return _mapper.Map<TicketModel> (entity);
            }
        }

        public void Delete(int id)
        {
            using (var scope = _contextScopeFactory.Create())
            {
                _repository.Delete(id);
                _repository.Save();
            }
        }

        public TicketModel GetById(int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var entity = _repository.GetById(id);
                return _mapper.Map<TicketModel> (entity);
            }
        }
    }
}

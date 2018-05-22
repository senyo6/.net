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

    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public ClientService (IClientRepository repository, IMapper mapper, IDbContextScopeFactory contextScopeFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _contextScopeFactory = contextScopeFactory;
        }

        public IEnumerable<ClientModel> GetAll ()
        {
            using (var scope = _contextScopeFactory.CreateReadOnly ())
            {
                var objects = _repository.GetAllActive ().ToList ();
                var models = _mapper.Map<List<ClientModel>> (objects);
                return models;
            }
        }

        public ClientModel Add (ClientModel model)
        {
            using (var scope = _contextScopeFactory.Create ())
            {
                var entity = new Client
                {
                    IsDeleted = false,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Address = model.Address,
                    JoinDate = model.JoinDate
                };
                _repository.Add (entity);
                _repository.Save ();
                return new ClientModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    Address = entity.Address,
                    JoinDate = entity.JoinDate
                };
            }
        }

        public ClientModel Update (ClientModel model)
        {
            using (var scope = _contextScopeFactory.Create ())
            {
                var entity = _repository.GetById (model.Id);
                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.Address = model.Address;
                entity.JoinDate = model.JoinDate;
                _repository.Edit (entity);
                _repository.Save ();
                return new ClientModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    Address = entity.Address,
                    JoinDate = entity.JoinDate
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

        public ClientModel GetById (int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly ())
            {
                var entity = _repository.GetById (id);
                return new ClientModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    Address = entity.Address,
                    JoinDate = entity.JoinDate
                };
            }
        }
    }
}

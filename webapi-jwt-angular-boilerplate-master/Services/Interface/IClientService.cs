using System.Collections.Generic;
using Services.ServiceModels;

namespace Services.Interface
{
    public interface IClientService
    {
        ClientModel Add (ClientModel model);
        ClientModel Update (ClientModel model);
        void Delete (int id);
        ClientModel GetById (int id);
        IEnumerable<ClientModel> GetAll ();
    }
}

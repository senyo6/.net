using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix ("api/clientticket")]
    public class ClientTicketController : BaseApiController
    {
        private readonly IClientTicketService _service;

        public ClientTicketController (IClientTicketService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route ("get")]
        public IHttpActionResult ReadAllMapped ()
        {
            var models = _service.GetAll ();
            return Ok (models);
        }

        [HttpGet]
        [Route ("get/{id}")]
        public IHttpActionResult Read (int id)
        {
            var model = _service.GetById (id);
            return Ok (model);
        }

        [HttpGet]
        [Route ("getdetailed")]
        public IHttpActionResult ReadAllDetailed ()
        {
            var models = _service.GetAllDetailed ();
            return Ok (models);
        }

        [HttpGet]
        [Route("getticketsofclient")]
        public IHttpActionResult GetTicketsOfClient(int clientId)
        {
            var models = _service.GetTicketsOfClientDetailed(clientId);
            return Ok(models);
        }

        [HttpPost]
        [Route ("create")]
        public IHttpActionResult Create (ClientTicketModel model)
        {
            var newModel = _service.Add (model);
            return Ok (newModel);
        }

        [HttpPut]
        [Route ("update")]
        public IHttpActionResult Update (ClientTicketModel model)
        {
            var newModel = _service.Update (model);
            return Ok (newModel);
        }

        [HttpDelete]
        [Route ("delete")]
        public IHttpActionResult Delete (int id)
        {
            _service.Delete (id);
            return Ok ();
        }
    }
}

using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix ("api/ticket")]
    public class TicketController : BaseApiController
    {
        private readonly ITicketService _service;

        public TicketController (ITicketService service)
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

        [HttpPost]
        [Route ("create")]
        public IHttpActionResult Create (TicketModel model)
        {
            var newModel = _service.Add (model);
            return Ok (newModel);
        }

        [HttpPut]
        [Route ("update")]
        public IHttpActionResult Update (TicketModel model)
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

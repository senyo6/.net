using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/client")]
    public class ClientController : BaseApiController
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadAllMapped()
        {
            var models = _service.GetAll();
            return Ok(models);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult Read(int id)
        {
            var model = _service.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(ClientModel model)
        {
            var newModel = _service.Add(model);
            return Ok(newModel);
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(ClientModel model)
        {
            var newModel = _service.Update(model);
            return Ok(newModel);
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}

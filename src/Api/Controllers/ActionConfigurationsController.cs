using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/action-configs")]
    [ApiController]
    public class ActionConfigurationsController : ControllerBase
    {
        public ActionConfigurationsController()
        {
            //TODO:...
        }

        [HttpPost]
        public ActionResult Create([FromBody] object request)
        {

            return Ok();
        }

        [HttpGet]
        public ActionResult ReadAll()
        {

            return Ok();
        }

        [HttpGet("{id:int}")]
        public ActionResult Read([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult Update([FromRoute] int id, [FromBody] object request)
        {

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {

            return Ok();
        }
    }
}

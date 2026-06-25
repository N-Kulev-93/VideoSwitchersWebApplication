using Api.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/action-configs")]
    [ApiController]
    public class ActionSettingsController : ControllerBase
    {
        public ActionSettingsController()
        {
            //TODO:...
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateActionConfigurationRequest request)
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
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateSwitcherActionSettingsRequest request)
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

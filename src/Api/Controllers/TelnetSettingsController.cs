using Api.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/telnet-configs")]
    [ApiController]
    public class TelnetSettingsController : ControllerBase
    {
        public TelnetSettingsController()
        {
            //TODO:...
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateSerialPortConfigurationRequest request)
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
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateSwitcherSerialPortSettingsRequest request)
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

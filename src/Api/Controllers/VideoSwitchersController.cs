using Application.Interface;
using Application.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RenameRequest = Api.Requests.RenameSwitcherRequest;
using RenameInputRequest = Api.Requests.RenameSwitcherInputRequest;
using RenameOutputRequest = Api.Requests.RenameSwitcherOutputRequest;
using SwitchInputRequest = Api.Requests.SwitchVideoInputRequest;
// TODO: Configs ...

namespace Api.Controllers
{
    [Route("api/video-switchers")]
    [ApiController]
    public class VideoSwitchersController : ControllerBase
    {
        ISwitcherReaderService _readerService;

        public VideoSwitchersController(ISwitcherReaderService readerService)
        {
            _readerService = readerService;

        }

        [HttpGet]   
        public async Task<ActionResult> ReadAll()
        {
            var all = _readerService.Read();

            return Ok(all);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Read([FromRoute] int id)
        {
            var single = _readerService.Read().SingleOrDefaultAsync(vs => vs.Id.Equals(id));

            return single is not null ? Ok(single) : NotFound(id);
        }

        [HttpPost("{id:int}/open-conn")]
        public ActionResult OpenConnection([FromRoute] int id)
        {
            var cmd = new OpenConnectionCommand(id);

            return NoContent();
        }

        [HttpPost("{id:int}/close-conn")]
        public ActionResult CloseConnection([FromRoute] int id)
        {
            var cmd = new CloseConnectionCommand(id);

            return NoContent();
        }

        [HttpPost("{id:int}/switch-input")]
        public ActionResult SwitchVideoInput([FromRoute] int id, [FromBody] SwitchInputRequest request)
        {
            var cmd = new SwitchInputCommand(request.Id, request.InputPosition, request.OutputPosition);

            return NoContent();
        }

        [HttpPost("{id:int}/rename")]
        public ActionResult Rename([FromRoute] int id, [FromBody] RenameRequest request)
        {
            var cmd = new RenameSwitcherCommand(id, request.Name);

            return NoContent();
        }

        [HttpPost("{id:int}/rename-input")]
        public ActionResult RenameInput([FromRoute] int id, [FromBody] RenameInputRequest request)
        {
            var cmd = new RenameSwitcherInputCommand(id, request.Position, request.Name);

            return NoContent();
        }

        [HttpPost("{id:int}/rename-output")]
        public ActionResult RenameOutput([FromRoute] int id, [FromBody] RenameOutputRequest request)
        {
            var cmd = new RenameSwitcherOutputCommand(id, request.Position, request.Name);

            return NoContent();
        }

        [HttpPost("{id:int}/select-conn-config")]
        public ActionResult SelectConnectionConfiguration([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id:int}/select-action-config")]
        public ActionResult SelectActionConfiguration([FromRoute] int id)
        {
            throw new NotImplementedException();
        }
    }
}

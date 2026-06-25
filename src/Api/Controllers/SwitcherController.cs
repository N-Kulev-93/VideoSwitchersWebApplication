using Api.Requests;
using Application.Command;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SetOutputSourceRequest = Api.Requests.SetSwitcherOutputSourceRequest;
using RenameRequest = Api.Requests.RenameSwitcherRequest;
using RenameInterfaceRequest = Api.Requests.RenameSwitcherInterfaceRequest;

using OpenCommunicationCommand = Application.Command.OpenSwitcherCommunicationCommand;
using CloseCommunicationCommand = Application.Command.CloseSwitcherCommunicationSourceCommand;
using SetOutputSourceCommand = Application.Command.SetSwitcherOutputSourceInputCommand;
using RenameCommand = Application.Command.RenameSwitcherCommand;
using RenameInputCommand = Application.Command.RenameSwitcherInputCommand;
using RenameOutputCommand = Application.Command.RenameSwitcherOutputCommand;

namespace Api.Controllers
{
    [Route("api/video-switcher")]
    [ApiController]
    public class SwitcherController : ControllerBase
    {
        ISwitcherReader _readerService;

        public SwitcherController(ISwitcherReader readerService)
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

        [HttpPost("{id:int}/open-communication")]
        public ActionResult OpenCommunication([FromRoute] int id)
        {
            var cmd = new OpenCommunicationCommand(id);

            return NoContent();
        }

        [HttpPost("{id:int}/close-communication")]
        public ActionResult CloseCommunication([FromRoute] int id)
        {
            var cmd = new CloseCommunicationCommand(id);

            return NoContent();
        }

        [HttpPost("{id:int}/set-output-source")]
        public ActionResult SetOutputSource([FromRoute] int id, [FromBody] SetOutputSourceRequest request)
        {
            var cmd = new SetOutputSourceCommand(id, request.InputPosition, request.OutputPosition);

            return NoContent();
        }

        [HttpPost("{id:int}/rename")]
        public ActionResult Rename([FromRoute] int id, [FromBody] RenameRequest request)
        {
            var cmd = new RenameCommand(id, request.Name);

            return NoContent();
        }

        [HttpPost("{id:int}/rename-input")]
        public ActionResult RenameInput([FromRoute] int id, [FromBody] RenameInterfaceRequest request)
        {
            var cmd = new RenameInputCommand(id, request.Position, request.Name);

            return NoContent();
        }

        [HttpPost("{id:int}/rename-output")]
        public ActionResult RenameOutput([FromRoute] int id, [FromBody] RenameInterfaceRequest request)
        {
            var cmd = new RenameOutputCommand(id, request.Position, request.Name);

            return NoContent();
        }
    }
}

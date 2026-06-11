using Api.Requests;
using Application.Interface;
using Application.Services;
using Application.Command;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenConnectionRequest = Api.Requests.OpenSwitcherConnectionRequest;
using CloseConnectionRequest = Api.Requests.CloseSwitcherConnectionRequest;
using RenameRequest = Api.Requests.RenameSwitcherRequest;
using RenameInputRequest = Api.Requests.RenameSwitcherInputRequest;
using RenameOutputRequest = Api.Requests.RenameSwitcherOutputRequest;
using SwitchInputRequest = Api.Requests.SwitchVideoInputRequest;
using Application.Command;
// TODO: Configs ...

namespace Api.Controllers
{
    [Route("api/video-switchers")]
    [ApiController]
    public class VideoSwitchersController : ControllerBase
    {
        IVideoSwitcherReaderService _readerService;

        public VideoSwitchersController(IVideoSwitcherReaderService readerService)
        {
            _readerService = readerService;

        }

        [HttpGet]   
        public async Task<ActionResult> GetAll()
        {
            var all = _readerService.Read();

            return Ok(all);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var single = _readerService.Read().SingleOrDefaultAsync(vs => vs.Id.Equals(id));

            return single is not null ? Ok(single) : NotFound(id);
        }

        [HttpPost("{id:int}/open-connection")]
        public ActionResult OpenConnection([FromRoute] int id)
        {
            var cmd = new OpenConnectionCommand(id);

            return NoContent();
        }

        [HttpPost("{id:int}/close-connection")]
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

        [HttpPost("{id:int}/select-connection-config")]
        public ActionResult SelectConnectionConfiguration([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id:int}/select-actiontype-config")]
        public ActionResult SelectActionTypeConfiguration([FromRoute] int id)
        {
            throw new NotImplementedException();
        }
    }
}

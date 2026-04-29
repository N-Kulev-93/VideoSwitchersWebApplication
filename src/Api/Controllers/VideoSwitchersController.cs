using Api.Requests;
using Application.Command;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/video-switchers")]
    [ApiController]
    public class VideoSwitchersController : ControllerBase
    {
        readonly VideoSwitchersDbContext _context;

        const string GetActionName = "GetSwitcher";

        public VideoSwitchersController(VideoSwitchersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _context.VideoSwitchers
                .Include(e => e.Inputs)
                .Include(e => e.Outputs)
                .ToArrayAsync();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ActionName(GetActionName)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _context.VideoSwitchers.ToArrayAsync();

            return Ok(result);
        }

        [HttpPost("switch-input")]
        public async Task<ActionResult> SwitchInput(SwitchInputRequest request)
        {
            var cmd = new SwitchInputCommand(request.SwitcherId, request.InputPosition, request.OutputPosition);

            return RedirectToAction(GetActionName, routeValues: new { Id = request.SwitcherId });
        }

        [HttpPost("rename-input")]
        public async Task<ActionResult> RenameInput(RenameInputRequest request)
        {
            var cmd = new RenameOutputCommand(request.SwitcherId, request.Position, request.Name);

            return RedirectToAction(GetActionName, routeValues: new { Id = request.SwitcherId });
        }

        [HttpPost("rename-output")]
        public async Task<ActionResult> RenameOutput(RenameOutputRequest request)
        {
            var cmd = new RenameInputCommand(request.SwitcherId, request.Position, request.Name);

            return RedirectToAction(GetActionName, routeValues: new { Id = request.SwitcherId });
        }


        [HttpPost("rename-switcher")]
        public async Task<ActionResult> RenameSwitcher(RenameSwitcherRequest request)
        {
            var cmd = new RenameSwitcherCommand(request.Id, request.Name);

            return RedirectToAction(GetActionName, routeValues: new { request.Id });
        }
    }
}

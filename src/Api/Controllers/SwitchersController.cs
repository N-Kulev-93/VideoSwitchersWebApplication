
using Application.Write;
using Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/switchers")]
    [ApiController]
    public class SwitchersController : ControllerBase
    {
        VideoSwitchersReadContext readContext;

        public SwitchersController(VideoSwitchersReadContext readContext)
        {
            this.readContext = readContext;
        }

        [HttpGet]   
        public ActionResult GetAll()
        {
            var all = readContext.VideoSwitchers
                .Include(vs => vs.Inputs)
                .Include(vs => vs.Outputs)
                .Include(vs => vs.ActionConfigurations)
                .Include(vs => vs.ConnectionConfiguration)
                .ToList();

            return Ok(all);
        }
    }
}

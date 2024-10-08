using Microsoft.AspNetCore.Mvc;
using TeamApi.Models;
using TeamApi.Services;

namespace TeamApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("GetTeamMembers")]
        public ActionResult<List<TeamMember>> GetTeamMembers()
        {
            var teamMembers = _teamService.GetTeamMembers();
            return Ok(new { TeamMembers = teamMembers });
        }
    }
}

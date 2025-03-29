using Microsoft.AspNetCore.Mvc;
using FaceItTeamBalancer.Models;
using FaceItTeamBalancer.Helpers;

namespace FaceItTeamBalancer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        [HttpPost("generate")]
        public IActionResult GenerateTeams([FromBody] List<Player> players)
        {
            if (players == null || players.Count < 2)
                return BadRequest("At least two players required.");

            var (teamA, teamB) = Balancer.GenerateBalancedTeams(players);
            return Ok(new { teamA, teamB });
        }
    }
}

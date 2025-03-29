using Microsoft.AspNetCore.Mvc;
using FaceItTeamBalancer.Components.Models;
using FaceItTeamBalancer.Components.Helpers;

namespace FaceItTeamBalancer.Components.Controllers
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

        [HttpPost("assign")]
        public IActionResult AssignTeams([FromBody] TeamAssignmentRequest request)
        {
            if (request.TeamA == null || request.TeamB == null)
                return BadRequest("Both teams must be provided.");

            // Optional: Add validation (min players, duplicate names, etc.)
            return Ok(new
            {
                teamA = new
                {
                    request.TeamA.TeamName,
                    request.TeamA.Players,
                    request.TeamA.TotalRank
                },
                teamB = new
                {
                    request.TeamB.TeamName,
                    request.TeamB.Players,
                    request.TeamB.TotalRank
                }
            });
        }
    }
}

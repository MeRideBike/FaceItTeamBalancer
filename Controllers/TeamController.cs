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
                    Name = request.TeamA.Name,
                    Players = request.TeamA.Players,
                    TotalRank = request.TeamA.TotalRank
                },
                teamB = new
                {
                    Name = request.TeamB.Name,
                    Players = request.TeamB.Players,
                    TotalRank = request.TeamB.TotalRank
                }
            });
        }
    }
}

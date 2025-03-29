namespace FaceItTeamBalancer.Helpers
{
    using FaceItTeamBalancer.Models;
    using System.Linq;

    public static class Balancer
    {
        public static (Team, Team) GenerateBalancedTeams(List<Player> players)
        {
            // Shuffle the list randomly
            var random = new Random();
            players = players.OrderBy(x => random.Next()).ToList();

            Team teamA = new() { Id = 1};
            Team teamB = new() { Id = 2};

            foreach (var player in players)
            {
                if (teamA.TotalRank <= teamB.TotalRank)
                    teamA.Players.Add(player);
                else
                    teamB.Players.Add(player);
            }

            return (teamA, teamB);
        }
    }

}

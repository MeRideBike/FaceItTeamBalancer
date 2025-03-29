namespace FaceItTeamBalancer.Components.Models
{
    public class Team
    {
        public required int Id { get; set; }

        public string? TeamName { get; set; }

        public List<Player> Players { get; set; } = new();

        public int TotalRank => Players.Sum(p => p.FaceitRank);

    }
}

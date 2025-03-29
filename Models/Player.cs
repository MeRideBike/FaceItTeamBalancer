﻿namespace FaceItTeamBalancer.Models
{
    public class Player
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public int FaceitRank { get; set; } // 1–10

        public string? Role { get; set; }    // AWPer, Entry, IGL, etc. - INT w/ Mapped Values?

    }
}
using System.ComponentModel.DataAnnotations;

namespace badminton4all.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Skill Level")]
        public SkillLevel SkillLevel { get; set; }

        [Display(Name = "Overall Ranking")]
        public int Ranking { get; set; }

        [Display(Name = "Preferred Courts")]
        public List<string> PreferredCourts { get; set; } = new List<string>();

        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Profile Picture URL")]
        public string? ProfilePictureUrl { get; set; }

        public List<MatchHistory> MatchHistory { get; set; } = new List<MatchHistory>();

        // Computed Stats
        public int TotalMatches => MatchHistory.Count;
        public int Wins => MatchHistory.Count(m => m.IsWin);
        public int Losses => TotalMatches - Wins;
        public double WinRate => TotalMatches > 0 ? (double)Wins / TotalMatches * 100 : 0;
    }

    public enum SkillLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Expert,
        Professional
    }

    public class MatchHistory
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public string Opponent { get; set; } = string.Empty;
        public int PlayerScore { get; set; }
        public int OpponentScore { get; set; }
        public bool IsWin { get; set; }
        public string Court { get; set; } = string.Empty;
        public MatchType MatchType { get; set; }
    }

    public enum MatchType
    {
        Singles,
        Doubles,
        MixedDoubles
    }
}

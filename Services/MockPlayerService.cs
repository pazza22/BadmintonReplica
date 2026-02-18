using badminton4all.Models;
using MatchType = badminton4all.Models.MatchType;

namespace badminton4all.Services
{
    public interface IPlayerService
    {
        List<Player> GetAllPlayers();
        Player? GetPlayerById(int id);
        void AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(int id);
        List<string> GetAvailableCourts();
    }

    public class MockPlayerService : IPlayerService
    {
        private static List<Player> _players = new List<Player>();
        private static int _nextId = 1;
        private static readonly List<string> _availableCourts = new List<string>
        {
            "Central Sports Complex",
            "Riverside Badminton Club",
            "Elite Sports Arena",
            "Westside Community Center",
            "North Point Sports Hub",
            "Metro Badminton Academy"
        };

        static MockPlayerService()
        {
            // Initialize with mock data
            _players = GenerateMockPlayers();
            _nextId = _players.Max(p => p.Id) + 1;
        }

        private static List<Player> GenerateMockPlayers()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    FullName = "John Chen",
                    Email = "john.chen@email.com",
                    PhoneNumber = "555-0101",
                    SkillLevel = SkillLevel.Advanced,
                    Ranking = 1,
                    PreferredCourts = new List<string> { "Central Sports Complex", "Elite Sports Arena" },
                    RegistrationDate = DateTime.Now.AddMonths(-6),
                    ProfilePictureUrl = "https://via.placeholder.com/150",
                    MatchHistory = new List<MatchHistory>
                    {
                        new MatchHistory { Id = 1, MatchDate = DateTime.Now.AddDays(-5), Opponent = "Sarah Lee", PlayerScore = 21, OpponentScore = 18, IsWin = true, Court = "Central Sports Complex", MatchType = MatchType.Singles },
                        new MatchHistory { Id = 2, MatchDate = DateTime.Now.AddDays(-10), Opponent = "Mike Wong", PlayerScore = 21, OpponentScore = 19, IsWin = true, Court = "Elite Sports Arena", MatchType = MatchType.Singles },
                        new MatchHistory { Id = 3, MatchDate = DateTime.Now.AddDays(-15), Opponent = "Emma Davis", PlayerScore = 19, OpponentScore = 21, IsWin = false, Court = "Central Sports Complex", MatchType = MatchType.Singles },
                        new MatchHistory { Id = 4, MatchDate = DateTime.Now.AddDays(-20), Opponent = "David Kim", PlayerScore = 21, OpponentScore = 15, IsWin = true, Court = "Riverside Badminton Club", MatchType = MatchType.Singles }
                    }
                },
                new Player
                {
                    Id = 2,
                    FullName = "Sarah Lee",
                    Email = "sarah.lee@email.com",
                    PhoneNumber = "555-0102",
                    SkillLevel = SkillLevel.Advanced,
                    Ranking = 2,
                    PreferredCourts = new List<string> { "Riverside Badminton Club", "Metro Badminton Academy" },
                    RegistrationDate = DateTime.Now.AddMonths(-8),
                    ProfilePictureUrl = "https://via.placeholder.com/150",
                    MatchHistory = new List<MatchHistory>
                    {
                        new MatchHistory { Id = 5, MatchDate = DateTime.Now.AddDays(-3), Opponent = "Tom Brown", PlayerScore = 21, OpponentScore = 16, IsWin = true, Court = "Riverside Badminton Club", MatchType = MatchType.Singles },
                        new MatchHistory { Id = 6, MatchDate = DateTime.Now.AddDays(-7), Opponent = "John Chen", PlayerScore = 18, OpponentScore = 21, IsWin = false, Court = "Central Sports Complex", MatchType = MatchType.Singles },
                        new MatchHistory { Id = 7, MatchDate = DateTime.Now.AddDays(-12), Opponent = "Lisa Wang", PlayerScore = 21, OpponentScore = 19, IsWin = true, Court = "Metro Badminton Academy", MatchType = MatchType.Singles }
                    }
                },
                new Player
                {
                    Id = 3,
                    FullName = "Mike Wong",
                    Email = "mike.wong@email.com",
                    PhoneNumber = "555-0103",
                    SkillLevel = SkillLevel.Intermediate,
                    Ranking = 5,
                    PreferredCourts = new List<string> { "Elite Sports Arena", "Westside Community Center" },
                    RegistrationDate = DateTime.Now.AddMonths(-3),
                    ProfilePictureUrl = "https://via.placeholder.com/150",
                    MatchHistory = new List<MatchHistory>
                    {
                        new MatchHistory { Id = 8, MatchDate = DateTime.Now.AddDays(-4), Opponent = "Anna Patel", PlayerScore = 21, OpponentScore = 18, IsWin = true, Court = "Elite Sports Arena", MatchType = MatchType.Singles },
                        new MatchHistory { Id = 9, MatchDate = DateTime.Now.AddDays(-11), Opponent = "John Chen", PlayerScore = 19, OpponentScore = 21, IsWin = false, Court = "Elite Sports Arena", MatchType = MatchType.Singles }
                    }
                },
                new Player
                {
                    Id = 4,
                    FullName = "Emma Davis",
                    Email = "emma.davis@email.com",
                    PhoneNumber = "555-0104",
                    SkillLevel = SkillLevel.Expert,
                    Ranking = 3,
                    PreferredCourts = new List<string> { "Central Sports Complex", "North Point Sports Hub" },
                    RegistrationDate = DateTime.Now.AddMonths(-12),
                    ProfilePictureUrl = "https://via.placeholder.com/150",
                    MatchHistory = new List<MatchHistory>
                    {
                        new MatchHistory { Id = 10, MatchDate = DateTime.Now.AddDays(-2), Opponent = "Chris Taylor", PlayerScore = 21, OpponentScore = 14, IsWin = true, Court = "Central Sports Complex", MatchType = MatchType.Singles },
                        new MatchHistory { Id = 11, MatchDate = DateTime.Now.AddDays(-6), Opponent = "John Chen", PlayerScore = 21, OpponentScore = 19, IsWin = true, Court = "Central Sports Complex", MatchType = MatchType.Singles },
                        new MatchHistory { Id = 12, MatchDate = DateTime.Now.AddDays(-9), Opponent = "Sarah Lee", PlayerScore = 20, OpponentScore = 22, IsWin = false, Court = "North Point Sports Hub", MatchType = MatchType.Doubles }
                    }
                },
                new Player
                {
                    Id = 5,
                    FullName = "David Kim",
                    Email = "david.kim@email.com",
                    PhoneNumber = "555-0105",
                    SkillLevel = SkillLevel.Beginner,
                    Ranking = 12,
                    PreferredCourts = new List<string> { "Westside Community Center" },
                    RegistrationDate = DateTime.Now.AddMonths(-1),
                    ProfilePictureUrl = "https://via.placeholder.com/150",
                    MatchHistory = new List<MatchHistory>
                    {
                        new MatchHistory { Id = 13, MatchDate = DateTime.Now.AddDays(-8), Opponent = "John Chen", PlayerScore = 15, OpponentScore = 21, IsWin = false, Court = "Riverside Badminton Club", MatchType = MatchType.Singles }
                    }
                }
            };
        }

        public List<Player> GetAllPlayers()
        {
            return _players.OrderBy(p => p.Ranking).ToList();
        }

        public Player? GetPlayerById(int id)
        {
            return _players.FirstOrDefault(p => p.Id == id);
        }

        public void AddPlayer(Player player)
        {
            player.Id = _nextId++;
            player.RegistrationDate = DateTime.Now;
            player.Ranking = _players.Count + 1;
            _players.Add(player);
        }

        public void UpdatePlayer(Player player)
        {
            var existingPlayer = GetPlayerById(player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.FullName = player.FullName;
                existingPlayer.Email = player.Email;
                existingPlayer.PhoneNumber = player.PhoneNumber;
                existingPlayer.SkillLevel = player.SkillLevel;
                existingPlayer.PreferredCourts = player.PreferredCourts;
                existingPlayer.ProfilePictureUrl = player.ProfilePictureUrl;
            }
        }

        public void DeletePlayer(int id)
        {
            var player = GetPlayerById(id);
            if (player != null)
            {
                _players.Remove(player);
            }
        }

        public List<string> GetAvailableCourts()
        {
            return _availableCourts;
        }
    }
}

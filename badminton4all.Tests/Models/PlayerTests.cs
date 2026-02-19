using badminton4all.Models;

namespace badminton4all.Tests.Models
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Player_DefaultConstructor_InitializesCollections()
        {
            // Arrange & Act
            var player = new Player();

            // Assert
            Assert.IsNotNull(player.PreferredCourts);
            Assert.IsNotNull(player.MatchHistory);
            Assert.AreEqual(0, player.PreferredCourts.Count);
            Assert.AreEqual(0, player.MatchHistory.Count);
        }

        [TestMethod]
        public void TotalMatches_NoMatches_ReturnsZero()
        {
            // Arrange
            var player = new Player();

            // Act
            var totalMatches = player.TotalMatches;

            // Assert
            Assert.AreEqual(0, totalMatches);
        }

        [TestMethod]
        public void TotalMatches_WithMatches_ReturnsCorrectCount()
        {
            // Arrange
            var player = new Player
            {
                MatchHistory = new List<MatchHistory>
                {
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = false },
                    new MatchHistory { IsWin = true }
                }
            };

            // Act
            var totalMatches = player.TotalMatches;

            // Assert
            Assert.AreEqual(4, totalMatches);
        }

        [TestMethod]
        public void Wins_NoMatches_ReturnsZero()
        {
            // Arrange
            var player = new Player();

            // Act
            var wins = player.Wins;

            // Assert
            Assert.AreEqual(0, wins);
        }

        [TestMethod]
        public void Wins_WithOnlyWins_ReturnsCorrectCount()
        {
            // Arrange
            var player = new Player
            {
                MatchHistory = new List<MatchHistory>
                {
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = true }
                }
            };

            // Act
            var wins = player.Wins;

            // Assert
            Assert.AreEqual(3, wins);
        }

        [TestMethod]
        public void Wins_WithMixedResults_ReturnsCorrectCount()
        {
            // Arrange
            var player = new Player
            {
                MatchHistory = new List<MatchHistory>
                {
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = false },
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = false },
                    new MatchHistory { IsWin = true }
                }
            };

            // Act
            var wins = player.Wins;

            // Assert
            Assert.AreEqual(3, wins);
        }

        [TestMethod]
        public void Losses_NoMatches_ReturnsZero()
        {
            // Arrange
            var player = new Player();

            // Act
            var losses = player.Losses;

            // Assert
            Assert.AreEqual(0, losses);
        }

        [TestMethod]
        public void Losses_WithMixedResults_ReturnsCorrectCount()
        {
            // Arrange
            var player = new Player
            {
                MatchHistory = new List<MatchHistory>
                {
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = false },
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = false }
                }
            };

            // Act
            var losses = player.Losses;

            // Assert
            Assert.AreEqual(2, losses);
        }

        [TestMethod]
        public void WinRate_NoMatches_ReturnsZero()
        {
            // Arrange
            var player = new Player();

            // Act
            var winRate = player.WinRate;

            // Assert
            Assert.AreEqual(0, winRate);
        }

        [TestMethod]
        public void WinRate_AllWins_ReturnsHundred()
        {
            // Arrange
            var player = new Player
            {
                MatchHistory = new List<MatchHistory>
                {
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = true }
                }
            };

            // Act
            var winRate = player.WinRate;

            // Assert
            Assert.AreEqual(100, winRate);
        }

        [TestMethod]
        public void WinRate_AllLosses_ReturnsZero()
        {
            // Arrange
            var player = new Player
            {
                MatchHistory = new List<MatchHistory>
                {
                    new MatchHistory { IsWin = false },
                    new MatchHistory { IsWin = false },
                    new MatchHistory { IsWin = false }
                }
            };

            // Act
            var winRate = player.WinRate;

            // Assert
            Assert.AreEqual(0, winRate);
        }

        [TestMethod]
        public void WinRate_HalfWins_ReturnsFifty()
        {
            // Arrange
            var player = new Player
            {
                MatchHistory = new List<MatchHistory>
                {
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = false },
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = false }
                }
            };

            // Act
            var winRate = player.WinRate;

            // Assert
            Assert.AreEqual(50, winRate);
        }

        [TestMethod]
        public void WinRate_ThreeWinsOutOfFour_ReturnsSeventyFive()
        {
            // Arrange
            var player = new Player
            {
                MatchHistory = new List<MatchHistory>
                {
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = true },
                    new MatchHistory { IsWin = false }
                }
            };

            // Act
            var winRate = player.WinRate;

            // Assert
            Assert.AreEqual(75, winRate);
        }

        [TestMethod]
        public void Player_SetProperties_StoresValuesCorrectly()
        {
            // Arrange & Act
            var player = new Player
            {
                Id = 1,
                FullName = "Test Player",
                Email = "test@example.com",
                PhoneNumber = "555-1234",
                SkillLevel = SkillLevel.Intermediate,
                Ranking = 5,
                ProfilePictureUrl = "http://example.com/pic.jpg"
            };

            // Assert
            Assert.AreEqual(1, player.Id);
            Assert.AreEqual("Test Player", player.FullName);
            Assert.AreEqual("test@example.com", player.Email);
            Assert.AreEqual("555-1234", player.PhoneNumber);
            Assert.AreEqual(SkillLevel.Intermediate, player.SkillLevel);
            Assert.AreEqual(5, player.Ranking);
            Assert.AreEqual("http://example.com/pic.jpg", player.ProfilePictureUrl);
        }
    }
}

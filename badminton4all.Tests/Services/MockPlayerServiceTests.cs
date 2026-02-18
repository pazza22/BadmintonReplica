using badminton4all.Models;
using badminton4all.Services;

namespace badminton4all.Tests.Services
{
    [TestClass]
    public class MockPlayerServiceTests
    {
        private IPlayerService _playerService = null!;

        [TestInitialize]
        public void Setup()
        {
            _playerService = new MockPlayerService();
        }

        [TestMethod]
        public void GetAllPlayers_ReturnsNonEmptyList()
        {
            // Act
            var players = _playerService.GetAllPlayers();

            // Assert
            Assert.IsNotNull(players);
            Assert.IsTrue(players.Count > 0);
        }

        [TestMethod]
        public void GetAllPlayers_ReturnsSortedByRanking()
        {
            // Act
            var players = _playerService.GetAllPlayers();

            // Assert
            for (int i = 0; i < players.Count - 1; i++)
            {
                Assert.IsTrue(players[i].Ranking <= players[i + 1].Ranking,
                    $"Players should be sorted by ranking. Player at index {i} has ranking {players[i].Ranking} and player at index {i + 1} has ranking {players[i + 1].Ranking}");
            }
        }

        [TestMethod]
        public void GetPlayerById_ValidId_ReturnsPlayer()
        {
            // Arrange
            var allPlayers = _playerService.GetAllPlayers();
            var expectedPlayer = allPlayers.First();

            // Act
            var player = _playerService.GetPlayerById(expectedPlayer.Id);

            // Assert
            Assert.IsNotNull(player);
            Assert.AreEqual(expectedPlayer.Id, player.Id);
            Assert.AreEqual(expectedPlayer.FullName, player.FullName);
        }

        [TestMethod]
        public void GetPlayerById_InvalidId_ReturnsNull()
        {
            // Arrange
            int invalidId = 99999;

            // Act
            var player = _playerService.GetPlayerById(invalidId);

            // Assert
            Assert.IsNull(player);
        }

        [TestMethod]
        public void AddPlayer_AddsNewPlayerToList()
        {
            // Arrange
            var initialCount = _playerService.GetAllPlayers().Count;
            var newPlayer = new Player
            {
                FullName = "New Test Player",
                Email = "newtest@example.com",
                PhoneNumber = "555-9999",
                SkillLevel = SkillLevel.Beginner,
                PreferredCourts = new List<string> { "Central Sports Complex" }
            };

            // Act
            _playerService.AddPlayer(newPlayer);
            var updatedPlayers = _playerService.GetAllPlayers();

            // Assert
            Assert.AreEqual(initialCount + 1, updatedPlayers.Count);
            Assert.IsTrue(newPlayer.Id > 0, "Player should be assigned an ID");
            Assert.IsTrue(newPlayer.Ranking > 0, "Player should be assigned a ranking");
        }

        [TestMethod]
        public void AddPlayer_SetsRegistrationDateToNow()
        {
            // Arrange
            var newPlayer = new Player
            {
                FullName = "New Test Player",
                Email = "newtest@example.com",
                SkillLevel = SkillLevel.Beginner
            };
            var beforeAdd = DateTime.Now.AddMinutes(-1);

            // Act
            _playerService.AddPlayer(newPlayer);
            var afterAdd = DateTime.Now.AddMinutes(1);

            // Assert
            Assert.IsTrue(newPlayer.RegistrationDate >= beforeAdd && newPlayer.RegistrationDate <= afterAdd,
                "Registration date should be set to current time");
        }

        [TestMethod]
        public void UpdatePlayer_ValidPlayer_UpdatesProperties()
        {
            // Arrange
            var allPlayers = _playerService.GetAllPlayers();
            var playerToUpdate = allPlayers.First();
            var originalEmail = playerToUpdate.Email;
            
            var updatedPlayer = new Player
            {
                Id = playerToUpdate.Id,
                FullName = "Updated Name",
                Email = "updated@example.com",
                PhoneNumber = "555-0000",
                SkillLevel = SkillLevel.Expert,
                PreferredCourts = new List<string> { "Elite Sports Arena" },
                ProfilePictureUrl = "http://example.com/updated.jpg"
            };

            // Act
            _playerService.UpdatePlayer(updatedPlayer);
            var retrievedPlayer = _playerService.GetPlayerById(playerToUpdate.Id);

            // Assert
            Assert.IsNotNull(retrievedPlayer);
            Assert.AreEqual("Updated Name", retrievedPlayer.FullName);
            Assert.AreEqual("updated@example.com", retrievedPlayer.Email);
            Assert.AreEqual("555-0000", retrievedPlayer.PhoneNumber);
            Assert.AreEqual(SkillLevel.Expert, retrievedPlayer.SkillLevel);
            Assert.AreEqual("http://example.com/updated.jpg", retrievedPlayer.ProfilePictureUrl);
        }

        [TestMethod]
        public void UpdatePlayer_InvalidId_DoesNotThrowException()
        {
            // Arrange
            var invalidPlayer = new Player
            {
                Id = 99999,
                FullName = "Invalid Player",
                Email = "invalid@example.com"
            };

            // Act & Assert (should not throw)
            _playerService.UpdatePlayer(invalidPlayer);
        }

        [TestMethod]
        public void DeletePlayer_ValidId_RemovesPlayer()
        {
            // Arrange
            var initialPlayers = _playerService.GetAllPlayers();
            var initialCount = initialPlayers.Count;
            var playerToDelete = initialPlayers.First();

            // Act
            _playerService.DeletePlayer(playerToDelete.Id);
            var updatedPlayers = _playerService.GetAllPlayers();

            // Assert
            Assert.AreEqual(initialCount - 1, updatedPlayers.Count);
            var deletedPlayer = _playerService.GetPlayerById(playerToDelete.Id);
            Assert.IsNull(deletedPlayer);
        }

        [TestMethod]
        public void DeletePlayer_InvalidId_DoesNotThrowException()
        {
            // Arrange
            int invalidId = 99999;
            var initialCount = _playerService.GetAllPlayers().Count;

            // Act
            _playerService.DeletePlayer(invalidId);
            var updatedCount = _playerService.GetAllPlayers().Count;

            // Assert
            Assert.AreEqual(initialCount, updatedCount);
        }

        [TestMethod]
        public void GetAvailableCourts_ReturnsNonEmptyList()
        {
            // Act
            var courts = _playerService.GetAvailableCourts();

            // Assert
            Assert.IsNotNull(courts);
            Assert.IsTrue(courts.Count > 0);
        }

        [TestMethod]
        public void GetAvailableCourts_ContainsExpectedCourts()
        {
            // Act
            var courts = _playerService.GetAvailableCourts();

            // Assert
            Assert.IsTrue(courts.Contains("Central Sports Complex"));
            Assert.IsTrue(courts.Contains("Riverside Badminton Club"));
            Assert.IsTrue(courts.Contains("Elite Sports Arena"));
        }
    }
}

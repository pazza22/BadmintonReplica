using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using badminton4all.Controllers;
using badminton4all.Models;
using badminton4all.Services;

namespace badminton4all.Tests.Controllers
{
    [TestClass]
    public class PlayerControllerTests
    {
        private Mock<IPlayerService> _mockPlayerService = null!;
        private PlayerController _controller = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockPlayerService = new Mock<IPlayerService>();
            _controller = new PlayerController(_mockPlayerService.Object);
            
            // Setup TempData for tests
            var tempData = new TempDataDictionary(
                new Microsoft.AspNetCore.Http.DefaultHttpContext(),
                Mock.Of<ITempDataProvider>());
            _controller.TempData = tempData;
        }

        [TestMethod]
        public void Index_ReturnsViewWithPlayers()
        {
            // Arrange
            var players = new List<Player>
            {
                new Player { Id = 1, FullName = "Player 1" },
                new Player { Id = 2, FullName = "Player 2" }
            };
            _mockPlayerService.Setup(s => s.GetAllPlayers()).Returns(players);

            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Player>));
            var model = result.Model as List<Player>;
            Assert.AreEqual(2, model!.Count);
        }

        [TestMethod]
        public void Details_ValidId_ReturnsViewWithPlayer()
        {
            // Arrange
            var player = new Player { Id = 1, FullName = "Test Player" };
            _mockPlayerService.Setup(s => s.GetPlayerById(1)).Returns(player);

            // Act
            var result = _controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Player));
            var model = result.Model as Player;
            Assert.AreEqual("Test Player", model!.FullName);
        }

        [TestMethod]
        public void Details_InvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockPlayerService.Setup(s => s.GetPlayerById(99)).Returns((Player?)null);

            // Act
            var result = _controller.Details(99);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Register_Get_ReturnsViewWithCourts()
        {
            // Arrange
            var courts = new List<string> { "Court 1", "Court 2" };
            _mockPlayerService.Setup(s => s.GetAvailableCourts()).Returns(courts);

            // Act
            var result = _controller.Register() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Courts);
        }

        [TestMethod]
        public void Register_Post_ValidModel_RedirectsToDetails()
        {
            // Arrange
            var player = new Player
            {
                FullName = "New Player",
                Email = "new@example.com",
                SkillLevel = SkillLevel.Beginner
            };
            var selectedCourts = new List<string> { "Court 1" };
            
            _mockPlayerService.Setup(s => s.AddPlayer(It.IsAny<Player>()))
                .Callback<Player>(p => p.Id = 1);

            // Act
            var result = _controller.Register(player, selectedCourts) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ActionName);
            _mockPlayerService.Verify(s => s.AddPlayer(It.IsAny<Player>()), Times.Once);
        }

        [TestMethod]
        public void Register_Post_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var player = new Player(); // Invalid - missing required fields
            var courts = new List<string> { "Court 1" };
            _mockPlayerService.Setup(s => s.GetAvailableCourts()).Returns(courts);
            _controller.ModelState.AddModelError("FullName", "Required");

            // Act
            var result = _controller.Register(player, new List<string>()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Player));
            _mockPlayerService.Verify(s => s.AddPlayer(It.IsAny<Player>()), Times.Never);
        }

        [TestMethod]
        public void Edit_Get_ValidId_ReturnsViewWithPlayer()
        {
            // Arrange
            var player = new Player { Id = 1, FullName = "Test Player" };
            var courts = new List<string> { "Court 1" };
            _mockPlayerService.Setup(s => s.GetPlayerById(1)).Returns(player);
            _mockPlayerService.Setup(s => s.GetAvailableCourts()).Returns(courts);

            // Act
            var result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Player));
            Assert.IsNotNull(_controller.ViewBag.Courts);
        }

        [TestMethod]
        public void Edit_Get_InvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockPlayerService.Setup(s => s.GetPlayerById(99)).Returns((Player?)null);

            // Act
            var result = _controller.Edit(99);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Edit_Post_ValidModel_RedirectsToDetails()
        {
            // Arrange
            var player = new Player
            {
                Id = 1,
                FullName = "Updated Player",
                Email = "updated@example.com",
                SkillLevel = SkillLevel.Intermediate
            };
            var selectedCourts = new List<string> { "Court 1" };

            // Act
            var result = _controller.Edit(1, player, selectedCourts) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ActionName);
            _mockPlayerService.Verify(s => s.UpdatePlayer(It.IsAny<Player>()), Times.Once);
        }

        [TestMethod]
        public void Edit_Post_MismatchedId_ReturnsNotFound()
        {
            // Arrange
            var player = new Player { Id = 1 };

            // Act
            var result = _controller.Edit(2, player, new List<string>());

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            _mockPlayerService.Verify(s => s.UpdatePlayer(It.IsAny<Player>()), Times.Never);
        }

        [TestMethod]
        public void Edit_Post_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var player = new Player { Id = 1 };
            var courts = new List<string> { "Court 1" };
            _mockPlayerService.Setup(s => s.GetAvailableCourts()).Returns(courts);
            _controller.ModelState.AddModelError("Email", "Required");

            // Act
            var result = _controller.Edit(1, player, new List<string>()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Player));
            _mockPlayerService.Verify(s => s.UpdatePlayer(It.IsAny<Player>()), Times.Never);
        }

        [TestMethod]
        public void Delete_Get_ValidId_ReturnsViewWithPlayer()
        {
            // Arrange
            var player = new Player { Id = 1, FullName = "Test Player" };
            _mockPlayerService.Setup(s => s.GetPlayerById(1)).Returns(player);

            // Act
            var result = _controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Player));
        }

        [TestMethod]
        public void Delete_Get_InvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockPlayerService.Setup(s => s.GetPlayerById(99)).Returns((Player?)null);

            // Act
            var result = _controller.Delete(99);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DeleteConfirmed_ValidId_RedirectsToIndex()
        {
            // Act
            var result = _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            _mockPlayerService.Verify(s => s.DeletePlayer(1), Times.Once);
        }

        [TestMethod]
        public void Rankings_ReturnsViewWithPlayers()
        {
            // Arrange
            var players = new List<Player>
            {
                new Player { Id = 1, FullName = "Player 1", Ranking = 1 },
                new Player { Id = 2, FullName = "Player 2", Ranking = 2 }
            };
            _mockPlayerService.Setup(s => s.GetAllPlayers()).Returns(players);

            // Act
            var result = _controller.Rankings() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Player>));
        }
    }
}

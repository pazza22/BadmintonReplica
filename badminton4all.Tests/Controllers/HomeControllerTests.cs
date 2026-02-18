using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using badminton4all.Controllers;
using badminton4all.Models;

namespace badminton4all.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller = null!;

        [TestInitialize]
        public void Setup()
        {
            _controller = new HomeController();
            // Setup HttpContext for the controller
            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
        }

        [TestMethod]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Privacy_ReturnsViewResult()
        {
            // Act
            var result = _controller.Privacy();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Error_ReturnsViewResultWithErrorViewModel()
        {
            // Act
            var result = _controller.Error() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(ErrorViewModel));
        }

        [TestMethod]
        public void Error_ErrorViewModel_HasRequestId()
        {
            // Act
            var result = _controller.Error() as ViewResult;
            var model = result?.Model as ErrorViewModel;

            // Assert
            Assert.IsNotNull(model);
            Assert.IsFalse(string.IsNullOrEmpty(model.RequestId));
        }
    }
}

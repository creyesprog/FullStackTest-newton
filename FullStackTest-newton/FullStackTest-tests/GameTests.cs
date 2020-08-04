using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FullStackTest_newton.Infrastructure.Services.Interfaces;
using FullStackTest_newton.Infrastructure.Models;
using FullStackTest_newton.Infrastructure.Models.DTOs;
using FullStackTest_newton.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace FullStackTest_tests
{
    [TestClass]
    public class GameTests
    {
        public static IEnumerable<UpdateGameRequestDTO> GetTestSubmissions()
        {
            IEnumerable<UpdateGameRequestDTO> testSubmissions = new List<UpdateGameRequestDTO>()
            {
                new UpdateGameRequestDTO()
                {
                    GameId = 1,
                    Title = "Test Title 1",
                    Rating = 1,
                    Developer = "Test Developer 1",
                    Genre = "Test Genre 1",
                    Description = "Test Description 1"
                },
                new UpdateGameRequestDTO()
                {
                    GameId = 2,
                    Title = "Test Title 2",
                    Rating = 2,
                    Developer = "Test Developer 2",
                    Genre = "Test Genre 2",
                    Description = "Test Description 2"
                }

            };

            return testSubmissions;
        }

        [TestMethod]
        public async Task Put_OKResponse_GoodModel()
        {
            var mockGameService = new Mock<IGameService>();
            var mockErrorModel = new Mock<ErrorModel>();

            mockGameService.Setup(serv => serv.UpdateGame(It.IsAny<UpdateGameRequestDTO>()))
                .ReturnsAsync(true)
                .Verifiable();

            var controller = new GamesController(mockGameService.Object, mockErrorModel.Object);

            var result = await controller.Put(1, GetTestSubmissions().First()) as OkNegotiatedContentResult<ResponseDTO>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ResponseDTO>)); // Check if HTTP OK sent back
            Assert.IsInstanceOfType(result.Content, typeof(ResponseDTO)); // Check if ResponseDTO sent
            Assert.AreEqual(0, result.Content.Errors.Count); // Check if DTO has no errors listed.
        }

        [TestMethod]
        public async Task Put_BadRequest_BadModel()
        {
            var mockGameService = new Mock<IGameService>();
            var mockErrorModel = new Mock<ErrorModel>();

            mockGameService.Setup(serv => serv.UpdateGame(It.IsAny<UpdateGameRequestDTO>()))
                .ReturnsAsync(true)
                .Verifiable();

            var controller = new GamesController(mockGameService.Object, mockErrorModel.Object);
            controller.ModelState.AddModelError("Error", "Error");

            var result = await controller.Put(1, GetTestSubmissions().First()) as OkNegotiatedContentResult<ResponseDTO>;

            // Need to return response obj here and add additional asserts.
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task Put_BadResponse_ErrorCountGreaterThanZero()
        {
            var mockGameService = new Mock<IGameService>();
            var mockErrorModel = new Mock<ErrorModel>();

            mockGameService.Setup(serv => serv.UpdateGame(It.IsAny<UpdateGameRequestDTO>()))
                .ReturnsAsync(true)
                .Verifiable();
            mockErrorModel.Object.Errors.Add(new Error() { ErrorMessage = "Error that accumulated during controller/service use" });

            var controller = new GamesController(mockGameService.Object, mockErrorModel.Object);

            var result = await controller.Put(1, GetTestSubmissions().First()) as OkNegotiatedContentResult<ResponseDTO>;

            // Need to return response obj here and add additional asserts.
            Assert.IsNull(result);
        }
    }
}

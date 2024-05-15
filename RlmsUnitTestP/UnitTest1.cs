using Microsoft.AspNetCore.Mvc;
using Moq;
using RoboticsLabManagementSystem.Controllers;
using RoboticsLabManagementSystem.Domain.Entities;

namespace RlmsUnitTestP
{
    public class Tests
    {
        private ResearchController _controller;
        private Mock<IResearchService> _mockResearchService;

        [SetUp]
        public void Setup()
        {
            _mockResearchService = new Mock<IResearchService>();
            _controller = new ResearchController(_mockResearchService.Object);
        }

        [Test]
        public async Task GetResearches_ReturnsListOfResearch()
        {
            // Arrange
            var expectedResearches = new List<Research>
            {
                new Research { ResearchId = Guid.NewGuid(), Title = "Research 1" },
                new Research { ResearchId = Guid.NewGuid(), Title = "Research 2" }
            };
            _mockResearchService.Setup(service => service.GetResearchesAsync()).ReturnsAsync(expectedResearches);

            // Act
            var result = await _controller.GetResearches();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var researches = okResult.Value as List<Research>;
            Assert.IsNotNull(researches);
            Assert.AreEqual(expectedResearches.Count, researches.Count);
        }

        [Test]
        public async Task GetResearches_WhenNoResearches_ReturnsEmptyList()
        {
           
            _mockResearchService.Setup(service => service.GetResearchesAsync()).ReturnsAsync(new List<Research>());

            
            var result = await _controller.GetResearches();

           
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var researches = okResult.Value as List<Research>;
            Assert.IsNotNull(researches);
            Assert.IsEmpty(researches);
        }
        [Test]
        public async Task GetTopTwoResearches_ReturnsTopTwoResearch()
        {
            // Arrange
            var expectedResearches = new List<Research>
    {
        new Research { ResearchId = Guid.NewGuid(), Title = "Research 1" },
        new Research { ResearchId = Guid.NewGuid(), Title = "Research 2" }
    };
            _mockResearchService.Setup(service => service.GetTopTwoResearchesAsync()).ReturnsAsync(expectedResearches);

            // Act
            var result = await _controller.GetTopTwoResearches();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var researches = okResult.Value as List<Research>;
            Assert.IsNotNull(researches);
            Assert.AreEqual(2, researches.Count);
        }

        [Test]
        public async Task GetResearch_WithExistingId_ReturnsResearch()
        {
            // Arrange
            var researchId = Guid.NewGuid();
            var expectedResearch = new Research { ResearchId = researchId, Title = "Research 1" };
            _mockResearchService.Setup(service => service.GetResearchByIdAsync(researchId)).ReturnsAsync(expectedResearch);

            // Act
            var result = await _controller.GetResearch(researchId);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var research = okResult.Value as Research;
            Assert.IsNotNull(research);
            Assert.AreEqual(expectedResearch.ResearchId, research.ResearchId);
        }

        [Test]
        public async Task GetResearch_WithNonexistentId_ReturnsNotFound()
        {
            // Arrange
            var researchId = Guid.NewGuid();
            _mockResearchService.Setup(service => service.GetResearchByIdAsync(researchId)).ReturnsAsync((Research)null);

            // Act
            var result = await _controller.GetResearch(researchId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

      


        [Test]
        public async Task UpdateResearch_WithInvalidId_ReturnsBadRequest()
        {
            // Arrange
            var researchId = Guid.NewGuid();
            var research = new Research { ResearchId = Guid.NewGuid(), Title = "Updated Research" };

            // Act
            var result = await _controller.UpdateResearch(researchId, research);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public async Task DeleteResearch_WithExistingId_ReturnsNoContent()
        {
            // Arrange
            var researchId = Guid.NewGuid();
            _mockResearchService.Setup(service => service.DeleteResearchAsync(researchId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteResearch(researchId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }
  

        [Test]
        public async Task DeleteResearch_WithNonexistentId_ReturnsNotFound()
        {
            // Arrange
            var researchId = Guid.NewGuid();
            _mockResearchService.Setup(service => service.DeleteResearchAsync(researchId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteResearch(researchId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }


    }
}
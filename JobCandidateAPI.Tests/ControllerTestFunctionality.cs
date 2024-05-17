using JobCandidateAPI.Contracts.Candidates;
using JobCandidateAPI.Services.Candidates;
using JobCandidateAPI.Contracts.Shared;
using JobCandidateAPI.Contracts.DTOs;
using JobCandidateAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using JobCandidateAPI.Models;
using AutoMapper;
using System.Net;
using Moq;

namespace JobCandidateAPI.Tests
{
    public class ControllerTestFunctionality
    {
        private CandidatesController _candidatesController;
        private Mock<ICandidateService> _candidateServiceMock;
        private Mock<IMapper> _mapperMock;

        public ControllerTestFunctionality()
        {
            _candidateServiceMock = new Mock<ICandidateService>();
            _mapperMock = new Mock<IMapper>();
            _candidatesController = new CandidatesController(_candidateServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_Returns_PaginationResponse()
        {
            // Arrange
            var paginationRequest = new PaginationRequest();
            var expectedResponse = new PaginationResponse(); 
            _candidateServiceMock.Setup(service => service.GetAllAsync(paginationRequest)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _candidatesController.GetAllAsync(paginationRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task GetByEmailAsync_Returns_ApiResult_With_CandidateResponse()
        {
            // Arrange
            var email = "Hamzasraidi08@gmail.com";
            var candidate = new Candidate();
            var expectedResponse = new ApiResult { Status = HttpStatusCode.OK };
            _candidateServiceMock.Setup(service => service.GetByEmailAsync(email)).ReturnsAsync(candidate);
            _mapperMock.Setup(mapper => mapper.Map<CandidateResponse>(candidate)).Returns(new CandidateResponse());

            // Act
            var result = await _candidatesController.GetByEmailAsync(email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse.Status, result.Status);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task CreateAsync_Returns_Created_Response()
        {
            // Arrange
            var request = new CandidateRequest();
            var validationResult = new ValidationResult(new List<ValidationFailure>());
            _mapperMock.Setup(mapper => mapper.Map<Candidate>(request)).Returns(new Candidate());
            _candidateServiceMock.Setup(service => service.GetByEmailAsync(request.Email)).ReturnsAsync((Candidate)null);
            _candidateServiceMock.Setup(service => service.CreateAsync(It.IsAny<Candidate>())).ReturnsAsync(new Candidate());
            _mapperMock.Setup(mapper => mapper.Map<CandidateResponse>(It.IsAny<Candidate>())).Returns(new CandidateResponse());
            _candidatesController.ControllerContext = new ControllerContext();

            // Act
            var result = await _candidatesController.CreateAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.Created, result.Status);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task UpdateAsync_Returns_Updated_Response()
        {
            // Arrange
            var request = new CandidateRequest();
            var validationResult = new ValidationResult(new List<ValidationFailure>());
            _mapperMock.Setup(mapper => mapper.Map<Candidate>(request)).Returns(new Candidate());
            _candidateServiceMock.Setup(service => service.UpdateAsync(It.IsAny<Candidate>())).ReturnsAsync(new Candidate());
            _mapperMock.Setup(mapper => mapper.Map<CandidateResponse>(It.IsAny<Candidate>())).Returns(new CandidateResponse());

            // Act
            var result = await _candidatesController.UpdateAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, result.Status);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task DeleteAsync_Returns_Deleted_Response()
        {
            // Arrange
            var email = "Hamzasraidi08@gmail.com";
            var candidate = new Candidate();
            var expectedResponse = new ApiResult { Status = HttpStatusCode.OK };
            _candidateServiceMock.Setup(service => service.DeleteAsync(email)).ReturnsAsync(candidate);
            _mapperMock.Setup(mapper => mapper.Map<CandidateResponse>(candidate)).Returns(new CandidateResponse());

            // Act
            var result = await _candidatesController.DeleteAsync(email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse.Status, result.Status);
            Assert.NotNull(result.Data);
        }
    }
}

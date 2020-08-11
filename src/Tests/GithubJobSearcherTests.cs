using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Connector.Github;
using Moq;
using Moq.Protected;
using Xunit;

namespace Tests
{
    public class GithubJobSearcherTests
    {
        [Fact]
        public async Task GetAsync_Should_ReturnListOfJobPositions()
        {
            //Arrange
            var mockedResult = MockResponseMessageResult(HttpStatusCode.OK, GeneratesCompleteJobList);
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockedResult);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var githubSearcher = new GithubJobSearcher(httpClient);

            //Act
            var result = await githubSearcher.GetAsync();

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetAsync_Should_ReturnEmptyList()
        {
            //Arrange
            var mockedResult = MockResponseMessageResult(HttpStatusCode.NoContent, GeneratesEmptyJobList);
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockedResult);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var githubSearcher = new GithubJobSearcher(httpClient);

            //Act
            var result = await githubSearcher.GetAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        private HttpResponseMessage MockResponseMessageResult(HttpStatusCode httpStatusCode, Func<string> contentGenerator)
        {
            var stringContent = contentGenerator.Invoke();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = new StringContent(stringContent)
            };

            return httpResponse;
        }

        private string GeneratesCompleteJobList()
        {
            var jsonText = File.ReadAllText("Json.Mock/GithubJobList.json");
            return jsonText;
        }

        private string GeneratesEmptyJobList() => "[]";
    }
}

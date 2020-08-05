using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Models;
using Xunit;

namespace Tests
{
    public class GithubJobSearcherTests
    {
        [Fact]
        public async Task GetAsync_Should_ReturnListOfJobPositions()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task GetAsync_Should_ReturnEmptyList()
        {
            //Arrange

            //Act

            //Assert
        }

        private HttpResponseMessage MockValidResponseMessageResult(Func<string> contentGenerator)
        {
            var stringContent = contentGenerator.Invoke();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(stringContent)
            };

            return httpResponse;
        }

        private async Task<string> GeneratesCompleteJobList()
        {
            var jsonText = await File.ReadAllTextAsync("Json.Mock/GithubJobList.json");
            return jsonText;
        }

        private string GeneratesEmptyJobList() => "[]";
    }
}

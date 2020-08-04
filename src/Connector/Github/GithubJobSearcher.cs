using System.Net.Http;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;

namespace Connector.Github
{
    public class GithubJobSearcher : IGithubJobSearcher
    {
        private readonly HttpClient _httpClient;

        public GithubJobSearcher(HttpClient httpClient) => _httpClient = httpClient;

        public Task GetAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
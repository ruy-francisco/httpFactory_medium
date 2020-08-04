using System.Net.Http;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;

namespace Connector.Github
{
    public class GithubJobSearcher : IJobSearcher
    {
        private readonly HttpClient _httpClient;

        public GithubJobSearcher(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<GithubJob> GetAsync<GithubJob>()
        {
            throw new System.NotImplementedException();
        }
    }
}
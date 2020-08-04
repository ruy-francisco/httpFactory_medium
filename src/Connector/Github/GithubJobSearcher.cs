using System.Net.Http;
using System.Threading.Tasks;
using Domain.Entities.Github;
using Domain.Interfaces;
using Domain.Models;
using Newtonsoft.Json;

namespace Connector.Github
{
    public class GithubJobSearcher : IGithubJobSearcher
    {
        private readonly HttpClient _httpClient;

        public GithubJobSearcher(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<GithubJobModel> GetAsync()
        {
            var jobUri = "https://jobs.github.com/positions.json?description=python&location=new+york";
            var httpResponse = await _httpClient.GetAsync(jobUri);

            if (httpResponse.IsSuccessStatusCode)
            {
                var textResponse = await httpResponse.Content.ReadAsStringAsync();
                var job = JsonConvert.DeserializeObject<GithubJobEntity>(textResponse);
                var jobModel = new GithubJobModel(job);

                return jobModel;
            }

            return null;
        }
    }
}
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Newtonsoft.Json;
using Domain.Entities.Github;

namespace Connector.Github
{
    public class GithubJobSearcher : IGithubJobSearcher
    {
        private readonly HttpClient _httpClient;

        public GithubJobSearcher(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<IEnumerable<GithubJobModel>> GetAsync()
        {
            var jobUri = "https://jobs.github.com/positions.json?description=python&location=new+york";
            var httpResponse = await _httpClient.GetAsync(jobUri);

            if (httpResponse.IsSuccessStatusCode)
            {
                var textResponse = await httpResponse.Content.ReadAsStringAsync();
                var jobs = JsonConvert.DeserializeObject<IEnumerable<GithubJobEntity>>(textResponse);
                var jobsModel = jobs.Select(j => new GithubJobModel(j));

                return jobsModel;
            }

            return new List<GithubJobModel>();
        }
    }
}
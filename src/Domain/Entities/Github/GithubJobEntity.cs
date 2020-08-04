using Newtonsoft.Json;

namespace Domain.Entities.Github
{
    public class GithubJobEntity
    {
        [JsonProperty]
        public string id { get; private set; }

        [JsonProperty]
        public string url { get; private set; }

        [JsonProperty]
        public string company { get; private set; }

        [JsonProperty]
        public string location { get; private set; }

        [JsonProperty]
        public string title { get; private set; }
    }
}
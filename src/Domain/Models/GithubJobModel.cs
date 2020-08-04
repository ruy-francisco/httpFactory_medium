using Domain.Entities.Github;

namespace Domain.Models
{
    public class GithubJobModel
    {
        public string Id { get; private set; }
        public string Url { get; private set; }
        public string Company { get; private set; }
        public string Location { get; private set; }
        public string Title { get; private set; }

        public GithubJobModel(GithubJobEntity githubJobEntity)
        {
            Id = githubJobEntity.id;
            Url = githubJobEntity.url;
            Company = githubJobEntity.company;
            Location = githubJobEntity.location;
            Title = githubJobEntity.title;
        }
    }
}
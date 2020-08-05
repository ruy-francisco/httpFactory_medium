using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGithubJobSearcher
    {
        Task<GithubJobModel> GetAsync();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGithubJobSearcher
    {
        Task<IEnumerable<GithubJobModel>> GetAsync();
    }
}
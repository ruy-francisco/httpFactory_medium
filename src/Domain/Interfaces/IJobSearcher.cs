using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGithubJobSearcher
    {
        Task GetAsync();
    }
}
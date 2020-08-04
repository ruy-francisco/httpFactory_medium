using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IJobSearcher
    {
        Task<T> GetAsync<T>();
    }
}
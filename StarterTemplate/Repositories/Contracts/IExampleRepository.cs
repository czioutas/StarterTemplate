using System.Threading.Tasks;

namespace StarterTemplate.Repositories.Contracts
{
    public interface IExampleRepository
    {
        Task<string> GetNameForIdAsync(int modelId);
    }
}
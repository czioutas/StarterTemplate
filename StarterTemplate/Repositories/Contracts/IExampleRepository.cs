using System.Threading.Tasks;

namespace StarterTemplate.Repositories.Contracts
{
    public interface IExampleRepository
    {
        Task<string> GetNameForId(int modelId);
    }
}
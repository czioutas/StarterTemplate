using StarterTemplate.Models;
using System.Threading.Tasks;

namespace StarterTemplate.Services.Contracts
{
    public interface IExampleService
    {
        Task<bool> IsItATeaPotAsync(ExampleModel model);
    }
}

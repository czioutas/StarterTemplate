using StarterTemplate.Application;
using StarterTemplate.Models;
using StarterTemplate.Repositories.Contracts;
using StarterTemplate.Services.Contracts;
using System.Threading.Tasks;

namespace StarterTemplate.Services
{
    public class ExampleService : IExampleService, ITransientServiceInterface
    {
        private readonly IExampleRepository _exampleRepository;

        public ExampleService(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<bool> IsItATeaPotAsync(ExampleModel model)
        {
            string modelName = await _exampleRepository.GetNameForId(model.Id);

            if (string.IsNullOrEmpty(modelName))
            {
                throw new NotFoundException();
            }

            return modelName.ToLower().Contains("teapot");
        }
    }
}
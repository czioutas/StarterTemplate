using StarterTemplate.Data;
using StarterTemplate.Models;
using StarterTemplate.Repositories.Contracts;
using System.Threading.Tasks;

namespace StarterTemplate.Repositories
{
    public class ExampleRepository : BaseRepository<ExampleModel>, IExampleRepository
    {
        public ExampleRepository(ApplicationDbContext _context) : base(_context)
        {
        }

        public async Task<string> GetNameForId(int modelId)
        {
            ExampleModel _model = await FirstByConditionAsync(a => a.Id == modelId);

            if (_model != null)
            {
                return _model.Name;
            }
            else
            {
                return null;
            }
        }
    }
}
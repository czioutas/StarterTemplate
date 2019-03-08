using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarterTemplate.Repositories.Contracts
{
    public interface IExampleRepository
    {
        Task<string> GetNameForId(int modelId);
    }
}

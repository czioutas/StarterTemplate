using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace StarterTemplate.Data.Seed
{
    public abstract class BaseSeed
    {
        public async Task SeedAsync(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            await AddSeedData(context);
            context.Dispose();
        }

        /// <summary>
        /// Extend the following method to include the data you need included
        /// Depending on your dependencies you might call SaveChanges on each method or on the main AddSeedData
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual async Task AddSeedData(ApplicationDbContext context)
        {
        }
    }
}
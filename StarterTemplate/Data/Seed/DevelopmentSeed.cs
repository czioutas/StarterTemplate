using StarterTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarterTemplate.Data.Seed
{
    public class DevelopmentSeed : BaseSeed
    {
        public override async Task AddSeedData(ApplicationDbContext context)
        {
            AddRandomExampleModels(context);
            await context.SaveChangesAsync();
        }

        public static void AddRandomExampleModels(ApplicationDbContext context)
        {
            List<ExampleModel> _list = new List<ExampleModel>();

            _list.Add(new ExampleModel
            {
                Name = "Linus"
            });

            if (_list.Count <= context.Example.Count())
            {
                return;
            }

            _list.ForEach(i => context.AddAsync(i));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using StarterTemplate.Application;
using StarterTemplate.Services.Contracts;
using System.Threading.Tasks;

namespace StarterTemplate.Controllers
{
    [Route("/[controller]/[action]/")]
    public class ExampleController : Controller
    {
        private readonly IExampleService _exampleService;

        public ExampleController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }


        [HttpGet("{id}/", Name = "IsItATeaPot")]
        public async Task<IActionResult> IsItATeaPot(int Id)
        {
            try
            {
                bool _isItATeaPot = await _exampleService.IsItATeaPotAsync(new Models.ExampleModel { Id = Id });
                return Ok(_isItATeaPot);
            }
            catch (NotFoundException nt)
            {
                return NotFound();
            }
        }
    }
}

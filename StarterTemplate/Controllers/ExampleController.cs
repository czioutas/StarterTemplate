using Microsoft.AspNetCore.Mvc;
using StarterTemplate.APIs.ChuckNorrisIO;
using StarterTemplate.Application;
using StarterTemplate.Services.Contracts;
using System.Threading.Tasks;

namespace StarterTemplate.Controllers
{
    [Route("/[controller]/[action]/")]
    public class ExampleController : Controller
    {
        private readonly IExampleService _exampleService;
        private readonly IChuckNorrisAPIClient _chuckNorrisAPIClient;

        public ExampleController(IExampleService exampleService, IChuckNorrisAPIClient chuckNorrisAPIClient)
        {
            _exampleService = exampleService;
            _chuckNorrisAPIClient = chuckNorrisAPIClient;
        }

        [HttpGet("{id}/", Name = "IsItATeaPot")]
        public async Task<IActionResult> IsItATeaPot(int Id)
        {
            try
            {
                bool _isItATeaPot = await _exampleService.IsItATeaPotAsync(new Models.ExampleModel { Id = Id });
                return Ok(_isItATeaPot);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet(Name = "GetChuckNorrisJoke")]
        public async Task<IActionResult> Joke()
        {
            return Ok(await _chuckNorrisAPIClient.GetJokeAsync());
        }
    }
}
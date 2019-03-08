using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarterTemplate.Settings;

namespace StarterTemplate.Controllers
{
    [Route("/[controller]/[action]")]
    public class HeartBeatController : Controller
    {
        private readonly HeartBeatSettings _hbSettings;

        public HeartBeatController(IOptions<HeartBeatSettings> hbSettings)
        {
            _hbSettings = hbSettings.Value;
        }

        [HttpGet]
        public IActionResult Check()
        {
            // here you can check for DB Connection for example if needed.
            return Ok(_hbSettings.Response);
        }      
    }
}

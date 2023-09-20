using DemoApiPushDocker.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoApiPushDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ColourContext _context;

        public ValuesController(ColourContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Colour>> GetColourItems()
        {
            return Ok(_context.ColourItems);
        }
    }
}
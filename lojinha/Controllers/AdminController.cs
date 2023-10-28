using Microsoft.AspNetCore.Mvc;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

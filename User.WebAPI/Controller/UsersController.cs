using Microsoft.AspNetCore.Mvc;

namespace User.WebAPI.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FauntasticBack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : Controller
{
    [Authorize]
    [HttpGet]
    public IActionResult Index()
    {
        return Json(new { message = "Hello World" });
    }
}
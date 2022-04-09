using FauntasticBack.Models;
using FauntasticBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace FauntasticBack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeveragesController : Controller
{
    private readonly BeverageService _beverageService;

    public BeveragesController(BeverageService beverageService)
    {
        _beverageService = beverageService;
    }
    
    //Create route to get all beverages
    [HttpGet]
    public ActionResult<Beverage[]> Get()
    {
        return _beverageService.GetBeverages() ?? Array.Empty<Beverage>();
    }
}
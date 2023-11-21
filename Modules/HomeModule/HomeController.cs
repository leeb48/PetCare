using Microsoft.AspNetCore.Mvc;

namespace PetCare.Home;

[ApiController]
[Route("/")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Home()
    {
        return View();
    }

    [HttpGet("calendar")]
    public IActionResult Calendar()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace PetCare.Modules.OwnerModule;

[ApiController]
[Route("[controller]")]
public class OwnerController : Controller
{
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    public IActionResult GetOwnerByLastName(string lastName)
    {
        var result = _ownerService.FindByLastName(lastName);

        return Ok(result);
    }
}

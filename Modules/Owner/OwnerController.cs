using Microsoft.AspNetCore.Mvc;

namespace PetCare.Modules.Owner;

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
    public ActionResult<List<Owner>> GetOwnerByLastName(string lastName)
    {
        var result = _ownerService.FindByLastName(lastName);

        return result;
    }
}

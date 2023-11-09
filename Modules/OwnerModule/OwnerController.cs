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

    [HttpPost]
    public ActionResult<Owner> CreateOwner(Owner owner)
    {
        var newOwner = _ownerService.CreateOwner(owner);

        return newOwner;
    }

    [HttpPatch("{id}")]
    public ActionResult<Owner> UpdateOwner(int id, Owner owner)
    {
        var updatedOwner = _ownerService.UpdateOwner(id, owner);

        return updatedOwner;
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOwner(int id)
    {
        _ownerService.RemoveOwner(id);

        return Ok();
    }

    [HttpGet("birthdate")]
    public IActionResult FindByBirthdate(DateTime date)
    {
        var owners = _ownerService.FindByBirthdate(date);

        return Ok(owners);
    }

    [HttpGet]
    public IActionResult FindByLastName(string lastName)
    {
        var owners = _ownerService.FindByLastName(lastName);

        return Ok(owners);
    }
}

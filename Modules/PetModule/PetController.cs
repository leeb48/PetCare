using Microsoft.AspNetCore.Mvc;
using PetCare.Modules.OwnerModule;
using PetCare.Modules.PetModule.DTO;

namespace PetCare.Modules.PetModule;

[ApiController]
[Route("[controller]")]
public class PetController : Controller
{
    private readonly IPetService _petService;
    private readonly IOwnerService _ownerService;

    public PetController(IPetService petService, IOwnerService ownerService)
    {
        _petService = petService;
        _ownerService = ownerService;
    }

    [HttpPost("owner/{ownerId}/add-pet")]
    public IActionResult AddPet(int ownerId, PetDTO petDTO)
    {
        var owner = _ownerService.FindById(ownerId);

        if (owner == null)
        {
            var response = Json(new { message = "Owner not found" }).Value;
            return StatusCode(404, response);
        }

        _petService.CreatePet(ownerId, petDTO);

        return Ok(owner);
    }

    [HttpDelete("{petId}/owner/{ownerId}")]
    public IActionResult RemovePet(int petId, int ownerId)
    {
        try
        {
            _petService.RemovePet(ownerId, petId);
        }
        catch (Exception ex)
        {
            var errorResponse = Json(new { ex.Message }).Value;
            return StatusCode(500, errorResponse);
        }

        return Ok("Pet removed");
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetCare.Modules.OwnerModule.DTO;

namespace PetCare.Modules.OwnerModule;

[ApiController]
[Route("[controller]")]
public class OwnerController : Controller
{
    private readonly IOwnerService _ownerService;
    private readonly IMapper _mapper;

    public OwnerController(IOwnerService ownerService, IMapper mapper)
    {
        _ownerService = ownerService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public ActionResult<OwnerDTO> GetOwnerById(int id)
    {
        var owner = _ownerService.FindById(id);

        var ownerDto = _mapper.Map<OwnerDTO>(owner);

        return ownerDto;
    }

    [HttpPost]
    public ActionResult<CreateOwnerDTO> CreateOwner(CreateOwnerDTO createOwnerDTO)
    {
        var newOwner = _ownerService.CreateOwner(createOwnerDTO);

        return newOwner;
    }

    [HttpPatch("{id}")]
    public ActionResult<OwnerDTO> UpdateOwner(int id, OwnerDTO ownerDTO)
    {
        try
        {
            var updatedOwner = _ownerService.UpdateOwner(id, ownerDTO);

            return updatedOwner;
        }
        catch (Exception ex)
        {
            var errorResponse = Json(new { ex.Message }).Value;
            return StatusCode(500, errorResponse);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOwner(int id)
    {
        _ownerService.RemoveOwner(id);

        return Ok();
    }

    [HttpGet("birthdate")]
    public IActionResult FindByBirthdate(DateOnly date)
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

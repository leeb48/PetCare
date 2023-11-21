using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetCare.Modules.OwnerModule.DTO;
using PetCare.Modules.PetModule.DTO;

namespace PetCare.Modules.OwnerModule;

[ApiController]
[Route("[controller]")]
public class OwnerController : Controller
{
    private readonly IOwnerService _ownerService;
    private readonly IMapper _mapper;

    [HttpGet]
    public IActionResult Owner()
    {
        return View();
    }

    [HttpGet("birthdate/{date}")]
    public IActionResult FindByBirthdate(DateOnly date)
    {
        var owners = _ownerService.FindByBirthdate(date);

        return Ok(owners);
    }

    [HttpGet("lastName/{lastName}")]
    public IActionResult FindByLastName(string lastName)
    {
        var owners = _ownerService.FindByLastName(lastName);

        return Ok(owners);
    }

    public OwnerController(IOwnerService ownerService, IMapper mapper)
    {
        _ownerService = ownerService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public ActionResult<OwnerDTO> GetOwnerById(int id)
    {
        var owner = _ownerService.FindByIdDTO(id);

        if (owner == null)
        {
            var response = Json(new { message = "Not found" }).Value;
            return StatusCode(404, response);
        }

        return owner;
    }

    [HttpPost]
    public ActionResult<CreateOwnerDTO> CreateOwner(CreateOwnerDTO createOwnerDTO)
    {
        try
        {
            var newOwner = _ownerService.CreateOwner(createOwnerDTO);

            return newOwner;
        }
        catch (Exception ex)
        {
            var errorResponse = Json(new { ex.Message }).Value;
            return StatusCode(500, errorResponse);
        }
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
}

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

    public OwnerController(IOwnerService ownerService, IMapper mapper)
    {
        _ownerService = ownerService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Owner()
    {
        var owners = _ownerService.GetOwners(10);
        return View(owners);
    }

    [HttpGet("create")]
    public IActionResult OwnerCreateForm()
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

    [HttpGet("{id}")]
    public IActionResult OwnerById(int id)
    {
        var owner = _ownerService.FindByIdDTO(id);

        if (owner == null)
        {
            return View("NotFound");
        }

        return View(owner);
    }

    [HttpPost]
    public IActionResult CeateOwner(CreateOwnerDTO createOwnerDTO)
    {
        try
        {
            var newOwner = _ownerService.CreateOwner(createOwnerDTO);

            Response.Headers.Add("HX-Redirect", "/owner");
            return Ok(newOwner);
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

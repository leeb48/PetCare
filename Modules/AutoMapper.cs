using AutoMapper;
using PetCare.Modules.OwnerModule;
using PetCare.Modules.OwnerModule.DTO;

namespace PetCare.Modules;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Owner, OwnerDTO>();
        CreateMap<OwnerDTO, Owner>();

        CreateMap<Owner, CreateOwnerDTO>();
        CreateMap<CreateOwnerDTO, Owner>();
    }
}

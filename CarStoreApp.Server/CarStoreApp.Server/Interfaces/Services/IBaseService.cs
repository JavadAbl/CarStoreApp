using AutoMapper;

namespace CarStoreApp.Server.Interfaces.Services;

public interface IBaseService
{
   static Dto EntityToDto<Entity, Dto>(IMapper mapper, Entity entity)
    {
        return mapper.Map<Entity, Dto>(entity);
    }

  static  Entity DtoToEntity<Dto, Entity>(IMapper mapper, Dto dto) { 
    return mapper.Map<Dto, Entity>(dto);
    }
}


using System.Reflection.Metadata;
using AutoMapper;
using Domain_Code;

namespace Adapter_Repositories;

public class DomainConverter<TDomain, TDto> : IConverter
    where TDomain : Identifiable
    where TDto : IDTO
{
    
    private readonly Mapper _mapper = new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<TDomain, TDto>().ReverseMap();
    }));
    
    public Identifiable ToDomain(IDTO dto)
    {
        return _mapper.Map<TDto, TDomain>((TDto)dto);
    }

    public IDTO FromDomain(Identifiable identifiable)
    {
        var a = _mapper.Map<TDomain, TDto>((TDomain)identifiable);
        return a;
    }

    public Type GetIdtoType()
    {
        return typeof(TDto);
    }
}
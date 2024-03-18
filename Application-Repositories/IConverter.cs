using Domain_Code;

namespace Adapter_Repositories;

public interface IConverter
{
    public IIdentifiable ToDomain(IDTO dto);
    public IDTO FromDomain(IIdentifiable identifiable);
    public Type GetIdtoType();
}
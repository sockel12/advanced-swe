using Domain_Code;

namespace Adapter_Repositories;

public interface IConverter
{
    public Identifiable ToDomain(IDTO dto);
    public IDTO FromDomain(Identifiable identifiable);
    public Type GetIdtoType();
}
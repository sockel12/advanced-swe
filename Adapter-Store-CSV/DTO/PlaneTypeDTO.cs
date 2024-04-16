using Adapter_Repositories;
using Domain_Code;

namespace Adapter_Store_CSV.DTO;

public class PlaneTypeDTO : IDTO
{
    public string Id { get; set; }
    public uint Capacity { get; set; }
    public uint MaxRange { get; set; }
}
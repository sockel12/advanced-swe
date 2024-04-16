using Application_Code.Interfaces;
using Domain_Code;
using Domain_Code.Management;

namespace Application_Code.Handler;

public class PlaneTypeHandler(IEntityManager entityManager)
{
    private readonly IRepository<PlaneType> _planeTypeRepository = entityManager.GetRepository<PlaneType>();
    
    public PlaneType[] GetPlaneTypes()
    {
        return _planeTypeRepository.GetAll().ToArray();
    }
    
    public PlaneType? GetPlaneType(string id)
    {
        return _planeTypeRepository.Get(new Key(id));
    }
    
    public void CreatePlaneType(string id, uint capacity, uint maxRange)
    {
        PlaneType planeType = new PlaneType()
        {
            Id = new Key(id),
            Capacity = capacity,
            MaxRange = maxRange
        };
        _planeTypeRepository.Add(planeType);
    }

    public bool UpdatePlaneType(string id, uint capacity, uint maxRange)
    {
        PlaneType? planeType = _planeTypeRepository.Get(new Key(id));
        if (planeType is null) return false;
        planeType.Capacity = capacity;
        planeType.MaxRange = maxRange;
        return _planeTypeRepository.Update(planeType);
    }
    
    public bool DeletePlaneType(string id)
    {
        return _planeTypeRepository.Delete(new Key(id));
    }
}

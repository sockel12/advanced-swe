using Application_Code.Interfaces;
using Domain_Code;
using Domain_Code.Management;

namespace Application_Code.Handler;

public class PlaneTypeHandler(IEntityManager entityManager) : BaseHandler<PlaneType>(entityManager)
{
    public PlaneType CreatePlaneType(string id, uint capacity, uint maxRange)
    {
        PlaneType planeType = new PlaneType()
        {
            Id = new Key(id),
            Capacity = capacity,
            MaxRange = maxRange
        };
        Repository.Add(planeType);
        return planeType;
    }

    public bool UpdatePlaneType(string id, uint capacity, uint maxRange)
    {
        PlaneType? planeType = Repository.Get(new Key(id));
        if (planeType is null) return false;
        planeType.Capacity = capacity;
        planeType.MaxRange = maxRange;
        return Repository.Update(planeType);
    }
}

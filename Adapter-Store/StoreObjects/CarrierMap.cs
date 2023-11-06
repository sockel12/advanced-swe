using Adapter_Store.TestObjects;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Adapter_Store.StoreObjects;

class CarrierMap : ClassMap<Carrier>
{
    public CarrierMap()
    {
        Id(x => x.Id);
        Map(x => x.Name);
    }
}
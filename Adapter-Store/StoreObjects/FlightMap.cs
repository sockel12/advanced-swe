using Adapter_Store.TestObjects;
using FluentNHibernate.Mapping;

namespace Adapter_Store.StoreObjects;

class FlightMap : ClassMap<Flight>
{
    public FlightMap(){
        Id(x => x.Id);
        Map(x => x.Connection);
    }
}
using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class CountryHandler(IEntityManager entityManager) : BaseHandler<Country>(entityManager)
{
    public Country CreateCountry(string coutryId, string name)
    {
        Country country = new Country()
        {
            Code = new Key(coutryId),
            Name = name,
        };
        Repository.Add(country);
        return country;
    }
    
    public bool UpdateCountry(string countryId, string name)
    {
        Country? country = Repository.Get(new Key(countryId));
        if (country is null) return false;
        country.Name = name;
        return Repository.Update(country);
    }
    
}
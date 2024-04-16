using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class CountryHandler(IEntityManager entityManager)
{
    private readonly IRepository<Country> _countryRepository = entityManager.GetRepository<Country>();
    
    public void CreateCountry(string coutryId, string name)
    {
        Country country = new Country()
        {
            Code = new Key(coutryId),
            Name = name,
        };
        _countryRepository.Add(country);
    }
    
    public void RemoveCountry(string countryId)
    {
        _countryRepository.Delete(new Key(countryId));
    }
    
    public Country GetCountry(string countryId)
    {
        return _countryRepository.Get(new Key(countryId))!;
    }
    
    public Country[] GetAllCountries()
    {
        return _countryRepository.GetAll().ToArray();
    }
    
    public bool UpdateCountry(string countryId, string name)
    {
        Country? country = _countryRepository.Get(new Key(countryId));
        if (country is null) return false;
        country.Name = name;
        return _countryRepository.Update(country);
    }
    
}
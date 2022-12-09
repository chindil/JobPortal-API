using System.Collections.Generic;
using System.Linq;
using Stx.Api.Hrm.Interfaces;
using Stx.Shared.Models;

namespace Stx.Api.Hrm.Repos
{
    public class StxGeneralRepository : IStxGeneralRepository
    {
        private readonly StxDbContext _appDbContext;

        public StxGeneralRepository(StxDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _appDbContext.Countries;
        }

		public Country GetCountryById(int countryId)
        {
            return _appDbContext.Countries.FirstOrDefault(c => c.CountryID == countryId);
        }

		public IEnumerable<State> GetStatesByCountryId(short countryId)
		{
			return _appDbContext.States.Where(x=> x.CountryID == countryId);
		}

		public IEnumerable<City> GetCitiesByCountryId(short countryId)
		{
			return _appDbContext.Cities.Where(x=> x.CountryID == countryId);
		}

		public IEnumerable<Currency> GetCurrencies()
		{
			return _appDbContext.Currencies;
		}

		public IEnumerable<Lang> GetLanguages()
		{
			return _appDbContext.Languages;
		}

		public IEnumerable<Nationality> GetNationalities()
		{
			return _appDbContext.Nationalities;
		}
	}
}

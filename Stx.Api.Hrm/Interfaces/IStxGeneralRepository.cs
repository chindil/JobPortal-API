using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared.Models;

namespace Stx.Api.Hrm.Interfaces
{
    public interface IStxGeneralRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
        IEnumerable<State> GetStatesByCountryId(short countryId);
        IEnumerable<City> GetCitiesByCountryId(short countryId);
        IEnumerable<Nationality> GetNationalities();
        IEnumerable<Lang> GetLanguages();
        IEnumerable<Currency> GetCurrencies();

    }
}

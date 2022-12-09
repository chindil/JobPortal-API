using Stx.Api.Hrm.Repos;
using Microsoft.AspNetCore.Mvc;
using Stx.Api.Hrm.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stx.Api.Hrm.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]    
    [ApiController]
    public class StxGeneralController : Controller
    {
        private readonly IStxGeneralRepository _IStxGeneralRepository;

        public StxGeneralController(IStxGeneralRepository stxGeneralRepository)
        {
            _IStxGeneralRepository = stxGeneralRepository;
        }

        [HttpGet()]
        [Route("Countries")]
        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_IStxGeneralRepository.GetAllCountries());
        }

        [Route("Country/{id:int}")]
        [HttpGet]
        public IActionResult GetCountryById(int id)
        {
            return Ok(_IStxGeneralRepository.GetCountryById(id));
        }

        [HttpGet]
        [Route("States/{id:int}")]
        public IActionResult GetStatesByCountryId(int id)
        {
            return Ok(_IStxGeneralRepository.GetStatesByCountryId((short)id));
        }

        [HttpGet]
        [Route("Cities/{id:int}")]
        public IActionResult GetCitiesByCountryId(int id)
        {
            return Ok(_IStxGeneralRepository.GetCitiesByCountryId((short)id));
        }

        [HttpGet()]
        [Route("Nationalities")]
        public IActionResult GetNationalities()
        {
            return Ok(_IStxGeneralRepository.GetNationalities());
        }

        [HttpGet()]
        [Route("Languages")]
        public IActionResult GetLanguages()
        {
            return Ok(_IStxGeneralRepository.GetLanguages());
        }


        [HttpGet()]
        [Route("Currencies")]
        public IActionResult GetCurrencies()
        {
            return Ok(_IStxGeneralRepository.GetCurrencies());
        }
    }
}

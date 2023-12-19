using BasicWebAPI.DataAccess.DTOs;
using BasicWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody] CountryDto countryDto)
        {
            return _countryService.Create(countryDto);
        }

        [HttpPut]
        public ActionResult<CountryDto> Update([FromBody] CountryDto countryDto)
        {
            return _countryService.Update(countryDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _countryService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<CountryDto>> Get()
        {
            return _countryService.Get();
        }
    }
}

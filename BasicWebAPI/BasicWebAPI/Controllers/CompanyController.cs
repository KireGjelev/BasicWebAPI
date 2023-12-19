using BasicWebAPI.DataAccess.DTOs;
using BasicWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody] CompanyDto companyDto)
        {
            return _companyService.Create(companyDto);
        }

        [HttpPut]
        public ActionResult<CompanyDto> Update([FromBody] CompanyDto companyDto)
        {
            return _companyService.Update(companyDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _companyService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<CompanyDto>> Get()
        {
            return _companyService.Get();
        }
    }
}

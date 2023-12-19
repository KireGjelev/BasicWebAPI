using BasicWebAPI.DataAccess.DTOs;
using BasicWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody] ContactDto contactDto)
        {
            return _contactService.Create(contactDto);
        }

        [HttpPut]
        public ActionResult<ContactDto> Update([FromBody] ContactDto contactDto)
        {
            return _contactService.Update(contactDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<ContactDto>> Get()
        {
            return _contactService.Get();
        }

        [HttpGet("contact-info")]
        public ActionResult<List<ContactInfoDto>> GetContactsWithCompanyAndCountry()
        {
            return _contactService.GetContactsWithCompanyAndCountry();
        }

        [HttpGet("filter-contacts")]
        public ActionResult<List<ContactDto>> FilterContacts([FromQuery] int? countryId, [FromQuery] int? companyId)
        {
            return _contactService.FilterContacts(countryId, companyId);
        }
    }
}
